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
    using System.Collections.Generic;

    public class LineScanner
    {
        #region Fields
        private ITextSnapshotLine snapshotLine;
        private string lineText;
        private int linePosition;
        private List<SnapshotSpan> textSpans;
        private int textStart = -1;
        #endregion

        #region Constructors
        public LineScanner(ITextSnapshotLine line, LineScanState state, List<SnapshotSpan> textSpans)
        {
            this.snapshotLine = line;
            this.textSpans = textSpans;

            this.lineText = this.snapshotLine.GetText();
            this.linePosition = 0;

            this.State = state;
        }
        #endregion

        #region Properties
        public LineScanState State
        {
            get;
            set;
        }

        public bool EndOfLine
        {
            get 
            {
                return this.linePosition >= this.snapshotLine.Length; 
            }
        }

        public int LinePosition
        {
            get
            {
                return this.linePosition;
            }
        }
        #endregion

        #region Methods
        public void Advance(int count = 1)
        {
            this.linePosition += count;
        }

        public char Char()
        {
            return this.lineText[this.linePosition];
        }

        public char NextChar()
        {
            return this.GetChar(1);
        }

        public char NextNextChar()
        {
            return this.GetChar(2);
        }

        public void AdvanceToEndOfLine()
        {
            this.linePosition = this.snapshotLine.Length;
        }

        public void BeginMarkText()
        {
            this.textStart = this.linePosition;
        }

        public void EndMarkText()
        {
            if (this.textSpans != null && this.linePosition > this.textStart)
            {
                this.textSpans.Add(new SnapshotSpan(this.snapshotLine.Start + this.textStart, this.linePosition - this.textStart));
            }

            this.textStart = -1;
        }

        private char GetChar(int offset)
        {
            var c = (char)0;
            if (this.linePosition < this.snapshotLine.Length - offset)
            {
                c = this.lineText[this.linePosition + offset];
            }

            return c;
        }
        #endregion
    }
}
