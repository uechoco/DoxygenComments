﻿/**
 * Copyright (c) 2013-2015 Oleksandr Manenko
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
namespace Enhanced
{
    using Microsoft.VisualStudio.Text;
    using Microsoft.VisualStudio.Text.Tagging;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public sealed class DoxygenCommentTagger : ITagger<DoxygenCommentTag>, IDisposable
    {
        #region Fields
        private readonly ITextBuffer buffer;
        private readonly List<LineScanState> lineCache;
        private ITextSnapshot lineCacheSnapshot;
        #endregion

        #region Constructors
        public DoxygenCommentTagger(ITextBuffer buffer)
        {
            this.buffer = buffer;

            // Populate our cache initially.
            var snapshot = this.buffer.CurrentSnapshot;
            var lines = snapshot.LineCount;
            this.lineCache = new List<LineScanState>(snapshot.LineCount);
            this.lineCache.AddRange(Enumerable.Repeat(LineScanState.Default, snapshot.LineCount));

            this.RescanLines(snapshot, startLine: 0, lastDirtyLine: snapshot.LineCount - 1);
            this.lineCacheSnapshot = snapshot;

            // Listen for text changes so we can stay up-to-date.
            this.buffer.Changed += this.OnTextBufferChanged;
        }
        #endregion

        private int RescanLines(ITextSnapshot snapshot, int startLine, int lastDirtyLine)
        {
            int currentLine = startLine;
            var state = this.lineCache[currentLine];
            var updatedStateForCurrentLine = true;

            // Go until we have covered all of the dirty lines and we get to a line where our
            // new state matches the old state.
            while (currentLine < lastDirtyLine || (updatedStateForCurrentLine && currentLine < snapshot.LineCount))
            {
                var line = snapshot.GetLineFromLineNumber(currentLine);
                state = this.ScanLine(state, line);

                // Advance to next line.
                currentLine++;
                if (currentLine < snapshot.LineCount)
                {
                    updatedStateForCurrentLine = (state != this.lineCache[currentLine]);
                    this.lineCache[currentLine] = state;
                }
            }

            return currentLine - 1; // last line updated.
        }

        public void Dispose()
        {
            this.buffer.Changed -= this.OnTextBufferChanged;
        }

        public IEnumerable<ITagSpan<DoxygenCommentTag>> GetTags(NormalizedSnapshotSpanCollection spans)
        {
            foreach (var span in spans)
            {
                // If we're called on the non-current snapshot, return nothing.
                if (span.Snapshot != this.lineCacheSnapshot)
                {
                    yield break;
                }

                var lineStart = span.Start;
                while (lineStart < span.End)
                {
                    var line = lineStart.GetContainingLine();
                    var state = this.lineCache[line.LineNumber];

                    var textSpans = new List<SnapshotSpan>();
                    state = this.ScanLine(state, line, textSpans);
                    foreach (var textSpan in textSpans)
                    {
                        if (textSpan.IntersectsWith(span))
                        {
                            yield return new TagSpan<DoxygenCommentTag>(textSpan, new DoxygenCommentTag());
                        }
                    }

                    // Advance to next line.
                    lineStart = line.EndIncludingLineBreak;
                }
            }
        }

        private LineScanState ScanLine(LineScanState state, ITextSnapshotLine line, List<SnapshotSpan> textSpans = null)
        {
            var scanner = new LineScanner(line, state, textSpans);

            while (!scanner.EndOfLine)
            {
                if (scanner.State == LineScanState.Default)
                {
                    this.ScanDefault(scanner);
                }
                else if (scanner.State == LineScanState.DoxygenMultilineComment)
                {
                    this.ScanDoxygenMultilineComment(scanner);
                }
                else if (scanner.State == LineScanState.MultilineComment)
                {
                    this.ScanMultilineComment(scanner);
                }
                else
                {
                    Debug.Fail("Invalid state at beginning of line.");
                }
            }

            // End Of Line state must be one of these.
            Debug.Assert(scanner.State == LineScanState.Default || scanner.State == LineScanState.MultilineComment || scanner.State == LineScanState.DoxygenMultilineComment);

            return scanner.State;
        }

        private void ScanDoxygenMultilineComment(LineScanner scanner)
        {
            scanner.BeginMarkText();

            while (!scanner.EndOfLine)
            {
                if (scanner.Char() == '*' && scanner.NextChar() == '/') // close comment
                {
                    scanner.Advance(2);
                    scanner.EndMarkText();
                    scanner.State = LineScanState.Default;

                    return; // done with multi-line comment.
                }
                else
                {
                    scanner.Advance();
                }
            }

            // End of line.
            scanner.EndMarkText();
            Debug.Assert(scanner.State == LineScanState.DoxygenMultilineComment);
        }

        private void ScanMultilineComment(LineScanner scanner)
        {
            while (!scanner.EndOfLine)
            {
                if (scanner.Char() == '*' && scanner.NextChar() == '/') // close comment
                {
                    scanner.Advance(2);
                    scanner.State = LineScanState.Default;

                    return; // done with multi-line comment.
                }
                else
                {
                    scanner.Advance();
                }
            }

            // End of line.
            Debug.Assert(scanner.State == LineScanState.MultilineComment);
        }

        private void ScanDefault(LineScanner scanner)
        {
            while (!scanner.EndOfLine)
            {
                var currentChar = scanner.Char();
                var nextChar = scanner.NextChar();
                var nextNextChar = scanner.NextNextChar();
                if (currentChar == '/' && nextChar == '/' && (nextNextChar == '/' || nextNextChar == '!')) // single line doxygen comment
                {
                    scanner.State = LineScanState.DoxygenComment;

                    scanner.BeginMarkText();
                    scanner.AdvanceToEndOfLine();
                    scanner.EndMarkText();

                    scanner.State = LineScanState.Default;
                    return;
                }
                else if (currentChar == '/' && nextChar == '*' && (nextNextChar == '*' || nextNextChar == '!')) // multi-line doxygen comment
                {
                    scanner.State = LineScanState.DoxygenMultilineComment;
                    this.ScanDoxygenMultilineComment(scanner);
                }
                else if (currentChar == '/' && nextChar == '/') // single line comment
                {
                    scanner.AdvanceToEndOfLine();
                    scanner.State = LineScanState.Default;
                }
                else if (currentChar == '/' && nextChar == '*') // multi-line comment
                {
                    scanner.State = LineScanState.MultilineComment;
                    this.ScanMultilineComment(scanner);
                }
                else
                {
                    scanner.Advance();
                }
            }
        }

        public event EventHandler<SnapshotSpanEventArgs> TagsChanged;

        private void OnTextBufferChanged(object sender, TextContentChangedEventArgs e)
        {
            var snapshot = e.After;

            // First update this.lineCache so its size matches snapshot.LineCount.
            foreach (var change in e.Changes)
            {
                if (change.LineCountDelta > 0)
                {
                    var line = snapshot.GetLineFromPosition(change.NewPosition).LineNumber;
                    this.lineCache.InsertRange(line, Enumerable.Repeat(LineScanState.Default, change.LineCountDelta));
                }
                else if (change.LineCountDelta < 0)
                {
                    var line = snapshot.GetLineFromPosition(change.NewPosition).LineNumber;
                    this.lineCache.RemoveRange(line, -change.LineCountDelta);
                }
            }

            // Now that this.lineCache is the appropriate size we can safely start rescanning.
            // If we hadn't updated this.lineCache, then rescanning could walk off the edge.

            var changedSpans = new List<SnapshotSpan>();
            foreach (var change in e.Changes)
            {
                var startLine = snapshot.GetLineFromPosition(change.NewPosition);
                var endLine = snapshot.GetLineFromPosition(change.NewPosition);
                var lastUpdatedLine = this.RescanLines(snapshot, startLine.LineNumber, endLine.LineNumber);
                changedSpans.Add(new SnapshotSpan(
                    startLine.Start,
                    snapshot.GetLineFromLineNumber(lastUpdatedLine).End));
            }

            this.lineCacheSnapshot = snapshot;

            var tagsChanged = this.TagsChanged;
            if (tagsChanged != null)
            {
                foreach (var span in changedSpans)
                {
                    tagsChanged(this, new SnapshotSpanEventArgs(span));
                }
            }
        }
    }
}
