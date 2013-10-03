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

    public sealed class DoxygenCommandTagger : ITagger<DoxygenCommandTag>, IDisposable
    {
        private readonly ITextBuffer textBuffer;
        private readonly Doxygen doxygen;

        public DoxygenCommandTagger(ITextBuffer textBuffer)
        {
            this.textBuffer = textBuffer;
            this.doxygen = new Doxygen();
        }

        public IEnumerable<ITagSpan<DoxygenCommandTag>> GetTags(NormalizedSnapshotSpanCollection spans)
        {
            foreach (var span in spans)
            {
                var lineStart = span.Start;
                while (lineStart < span.End)
                {
                    var line = lineStart.GetContainingLine();
                    var text = line.GetText();

                    var index = 0;
                    while (index < text.Length)
	                {
                        index = text.IndexOf("@brief", index);

                        if (index != -1)
                        {
                            yield return new TagSpan<DoxygenCommandTag>(
                                new SnapshotSpan(lineStart + index, "@brief".Length), 
                                new DoxygenCommandTag(Doxygen.Token_brief));
                            index += "@brief".Length;
                        }
                        else
                        {
                            break;
                        }
                    }
                    
                    //var state = this.lineCache[line.LineNumber];

                    //var textSpans = new List<SnapshotSpan>();
                    ////state = this.ScanLine(state, line, textSpans);
                    //foreach (var textSpan in textSpans)
                    //{
                    //    if (textSpan.IntersectsWith(span))
                    //    {
                    //        yield return new TagSpan<DoxygenCommentTag>(textSpan, new DoxygenCommentTag());
                    //    }
                    //}

                   // Advance to next line.
                   lineStart = line.EndIncludingLineBreak;
                }
            }
        }

        public event EventHandler<SnapshotSpanEventArgs> TagsChanged;

        public void Dispose()
        {
        }
    }
}
