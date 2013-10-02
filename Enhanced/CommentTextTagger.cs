/**
 * Copyright (c) 2013 Alexander Manenko
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
    using System.Text;

    public abstract class CommentTextTagger<T> : ITagger<T>, IDisposable where T : ITag 
    {
        #region Fields
        private readonly ITextBuffer textBuffer;
        private readonly List<LineScanState> lineCache;
        private readonly ITextSnapshot lineCacheSnapshot;
        #endregion

        #region Constructors
        protected CommentTextTagger(ITextBuffer buffer)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer");
            }

            this.textBuffer = buffer;

            // Populate our cache initially.
            this.lineCacheSnapshot = this.TextBuffer.CurrentSnapshot;
            this.lineCache = new List<LineScanState>(this.lineCacheSnapshot.LineCount);
            this.lineCache.AddRange(Enumerable.Repeat(LineScanState.Default, this.lineCacheSnapshot.LineCount));
            this.RescanLines(this.lineCacheSnapshot, 0, this.lineCacheSnapshot.LineCount - 1);

            this.TextBuffer.Changed += this.HandleTextContentChanged;
        }
        #endregion

        #region Properties
        protected ITextBuffer TextBuffer
        {
            get
            {
                return this.textBuffer;
            }
        }
        #endregion

        #region Methods
        public void Dispose()
        {
            Dispose(true);
            // GC.SuppressFinalize(this); <-- Don't need to call this since we don't have finalizer. 
            //                                And I believe :) that I will not override Dispose(bool)
            //                                in derived classes
        }

        protected abstract void ScanSingleLine(LineScanner scanner, int endPosition = -1);

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.TextBuffer.Changed -= this.HandleTextContentChanged;
            }
        }

        protected virtual void OnTextContentChanged(TextContentChangedEventArgs e)
        {
        }
        #endregion

        #region Helpers
        private void HandleTextContentChanged(object sender, TextContentChangedEventArgs e)
        {
            this.OnTextContentChanged(e);
        }

        private int RescanLines(ITextSnapshot snapshot, int startLine, int lastDirtyLine)
        {
            var currentLine = startLine;
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

        private LineScanState ScanLine(LineScanState state, ITextSnapshotLine line, List<SnapshotSpan> textSpans = null)
        {
            var scanner = new LineScanner(line, state, textSpans);

            while (!scanner.EndOfLine)
            {
                if (scanner.State == LineScanState.Default)
                {
                    this.ScanDefault(scanner);
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
            Debug.Assert(scanner.State == LineScanState.Default || scanner.State == LineScanState.MultilineComment);

            return scanner.State;
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
                    scanner.Advance(3);
                    this.ScanSingleLine(scanner);

                    scanner.State = LineScanState.Default;
                    return;
                }
                else if (currentChar == '/' && nextChar == '*' && (nextNextChar == '*' || nextNextChar == '!')) // multi-line doxygen comment
                {
                    scanner.Advance(3);
                    scanner.State = LineScanState.MultilineComment;
                    ScanMultilineComment(scanner);
                }
                else
                {
                    scanner.Advance();
                }
            }
        }

        private int FindCloseComment(LineScanner scanner)
        {
            var position = -1;

            while (!scanner.EndOfLine)
            {
                if (scanner.Char() == '*' && scanner.NextChar() == '/') // close comment
                {
                    position = scanner.LinePosition;
                    break;
                }
                else
                {
                    scanner.Advance();
                }
            }

            return position;
        }

        private void ScanMultilineComment(LineScanner scanner)
        {
            var position = FindCloseComment(scanner);
            if (position != -1)
            {
                this.ScanSingleLine(scanner, position);
                // TODO: Move out of the comment and set line state to default
            }
            else
            {
                // TODO: Move to the previous position
                this.ScanSingleLine(scanner);
                // There is no close comment on this line
            }
            ////while (!scanner.EndOfLine)
            ////{
            ////    if (scanner.Char() == '*' && scanner.NextChar() == '/') // close comment
            ////    {
            ////        scanner.EndMarkText();
            ////        scanner.Advance(2);
            ////        scanner.State = LineScanState.Default;

            ////        return; // done with multi-line comment.
            ////    }
            ////    else
            ////    {
            ////        scanner.Advance();
            ////    }
            ////}

            Debug.Assert(scanner.State == LineScanState.MultilineComment);
        }
        #endregion
    }
}
