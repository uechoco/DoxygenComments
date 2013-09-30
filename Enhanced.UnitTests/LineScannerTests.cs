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
namespace Enhanced.UnitTests
{
    using Microsoft.VisualStudio.Text;
    using Moq;
    using System.Collections.Generic;
    using Xunit;

    public sealed class LineScannerTests
    {
        [Fact(DisplayName = "LineScanner.EndOfLine should return `false` if current line position is less than length of the snapshot line.")]
        public void EndOfLine_Should_Return_False_If_Current_Line_Position_Is_Less_Than_Length_Of_The_Line()
        {
            // Arrange
            var snapshotLineMock = CreateSnapshotLineMock("Dha Werda Verda a'den tratu!");
            var state = LineScanState.Default;
            var textSpans = new List<SnapshotSpan>();

            var scanner = new LineScanner(snapshotLineMock.Object, state, textSpans);

            // Act
            var endOfLine = scanner.EndOfLine;

            // Assert
            Assert.False(endOfLine);
        }

        [Fact(DisplayName = "LineScanner.EndOfLine should return `true` if current line position is equals to the length of the snapshot line.")]
        public void EndOfLine_Should_Return_True_If_Current_Line_Position_Is_Equal_To_The_Length_Of_The_Line()
        {
            // Arrange
            var snapshotLineMock = CreateSnapshotLineMock(string.Empty);
            var state = LineScanState.Default;
            var textSpans = new List<SnapshotSpan>();

            var scanner = new LineScanner(snapshotLineMock.Object, state, textSpans);

            // Act
            var endOfLine = scanner.EndOfLine;

            // Assert
            Assert.True(endOfLine);
        }

        [Fact(DisplayName = "LineScanner.Char should return a character from the snapshot line at the current position.")]
        public void Char_Should_Return_A_Character_From_The_Snapshot_Line_At_The_Current_Position()
        {
            // Arrange
            const string text = "Kom'rk tsad droten troch nyn ures adenn!";
            var snapshotLineMock = CreateSnapshotLineMock(text);
            var state = LineScanState.Default;
            var textSpans = new List<SnapshotSpan>();

            var scanner = new LineScanner(snapshotLineMock.Object, state, textSpans);
            scanner.Advance(3);

            // Act
            var c = scanner.Char();

            // Assert
            Assert.Equal('\'', c);
        }

        [Fact(DisplayName = "LineScanner.AdvanceToEndOfLine should change current position in the snapshot line to the its end.")]
        public void AdvanceToEndOfLine_Should_Change_Current_Position_In_The_Snapshot_Line_To_The_Its_End()
        {
            // Arrange
            const string text = "Kom'rk tsad droten troch nyn ures adenn!";
            var snapshotLineMock = CreateSnapshotLineMock(text);
            var state = LineScanState.Default;
            var textSpans = new List<SnapshotSpan>();

            var scanner = new LineScanner(snapshotLineMock.Object, state, textSpans);

            // Act
            scanner.AdvanceToEndOfLine();

            // Assert
            Assert.True(scanner.EndOfLine);
        }

        [Fact(DisplayName = "LineScanner.NextChar should return the next char relative to the current position.")]
        public void NextChar_Should_Return_The_Next_Char_Relative_To_The_Current_Position()
        {
            // Arrange
            const string text = "Kom'rk tsad droten troch nyn ures adenn!";
            var snapshotLineMock = CreateSnapshotLineMock(text);
            var state = LineScanState.Default;
            var textSpans = new List<SnapshotSpan>();

            var scanner = new LineScanner(snapshotLineMock.Object, state, textSpans);
            scanner.Advance();

            // Act
            var c = scanner.NextChar();

            // Assert
            Assert.Equal('m', c);
        }

        [Fact(DisplayName = "LineScanner.NextChar should return character with code zero if the next character relative to the current position doesn't exist.")]
        public void NextChar_Should_Return_Character_With_Code_Zero_If_The_Next_Character_Relative_To_The_Current_Position_Does_Not_Exist()
        {
            // Arrange
            const string text = "Kom'rk tsad droten troch nyn ures adenn!";
            var snapshotLineMock = CreateSnapshotLineMock(text);
            var state = LineScanState.Default;
            var textSpans = new List<SnapshotSpan>();

            var scanner = new LineScanner(snapshotLineMock.Object, state, textSpans);
            scanner.AdvanceToEndOfLine();

            // Act
            var c = scanner.NextChar();

            // Assert
            Assert.Equal((char)0, c);
        }

        [Fact(DisplayName = "LineScanner.NextNextChar should return the character that has position 'current_position + 2'.")]
        public void NextNextChar_Should_Return_Correct_Char()
        {
            // Arrange
            const string text = "Kom'rk tsad droten troch nyn ures adenn!";
            var snapshotLineMock = CreateSnapshotLineMock(text);
            var state = LineScanState.Default;
            var textSpans = new List<SnapshotSpan>();

            var scanner = new LineScanner(snapshotLineMock.Object, state, textSpans);
            scanner.Advance(5);

            // Act
            var c = scanner.NextNextChar();

            // Assert
            Assert.Equal('t', c);
        }

        [Fact(DisplayName = "LineScanner.NextNextChar should return character with code zero if the character that has position 'current_position + 2' doesn't exist.")]
        public void NextNextChar_Should_Return_Character_With_Code_Zero_If_Character_Does_Not_Exist()
        {
            // Arrange
            const string text = "Kom'rk tsad droten troch nyn ures adenn!";
            var snapshotLineMock = CreateSnapshotLineMock(text);
            var state = LineScanState.Default;
            var textSpans = new List<SnapshotSpan>();

            var scanner = new LineScanner(snapshotLineMock.Object, state, textSpans);
            scanner.Advance(text.Length - 2);

            // Act
            var c = scanner.NextNextChar();

            // Assert
            Assert.Equal((char)0, c);
        }

        [Fact(DisplayName = "LineScanner.EndMarkText shouldn't fail if text span list used to initalize line scanner was `null` reference.")]
        public void EndMarkText_Should_Not_Fail_If_Text_Span_List_Used_To_Initialize_Line_Scanner_Was_Null_Reference()
        {
            // Arrange
            const string text = "Kom'rk tsad droten troch nyn ures adenn!";
            var snapshotLineMock = CreateSnapshotLineMock(text);
            var state = LineScanState.Default;

            var scanner = new LineScanner(snapshotLineMock.Object, state, null);
            scanner.Advance(text.Length - text.Length / 2);

            // Act
            scanner.BeginMarkText();
            scanner.Advance(4);
            scanner.EndMarkText(); // Shouldn't throw exception. This a valid situation
        }

        [Fact(DisplayName = "LineScanner.EndMarkText should add valid snapshot spans to the list of text spans.")]
        public void EndMarkText_Should_Add_Valid_Snapshot_Spans_To_List_Of_Text_Spans()
        {
            // Arrange
            const string text = "Kom'rk tsad droten troch nyn ures adenn! Dha Werda Verda a'den tratu!";
            const int textSnapshotLength = 232920;
            const int lineStartPosition = 827;

            var textSnapshotMock = new Mock<ITextSnapshot>();
            textSnapshotMock.Setup(ts => ts.Length).Returns(textSnapshotLength);
            var lineStart = new SnapshotPoint(textSnapshotMock.Object, lineStartPosition);

            var snapshotLineMock = CreateSnapshotLineMock(text);
            snapshotLineMock.Setup(sl => sl.Start).Returns(lineStart);
            
            var state = LineScanState.Default;
            var textSpans = new List<SnapshotSpan>();

            var scanner = new LineScanner(snapshotLineMock.Object, state, textSpans);
            scanner.Advance(4);

            // Act
            scanner.BeginMarkText();
            scanner.Advance(4);
            scanner.EndMarkText();

            scanner.Advance(8);

            scanner.BeginMarkText();
            scanner.Advance(7);
            scanner.EndMarkText();

            // Assert
            Assert.Equal(2, textSpans.Count);
            
            var span = textSpans[0];
            Assert.Equal(lineStartPosition + 4, span.Start.Position);
            Assert.Equal(4, span.Length);

            span = textSpans[1];
            Assert.Equal(lineStartPosition + 4 + 4 + 8, span.Start.Position);
            Assert.Equal(7, span.Length);
        }

        private static Mock<ITextSnapshotLine> CreateSnapshotLineMock(string text)
        {
            var snapshotLineMock = new Mock<ITextSnapshotLine>();
            snapshotLineMock.Setup(sl => sl.GetText()).Returns(text);
            snapshotLineMock.Setup(sl => sl.Length).Returns(text.Length);

            return snapshotLineMock;
        }
    }
}
