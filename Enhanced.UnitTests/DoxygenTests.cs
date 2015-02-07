/**
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
namespace Enhanced.UnitTests
{
    using Xunit;

    public class DoxygenTests
    {
        [Fact(DisplayName="`Doxygen.Token` should return `-1` (`Token_unknown`) if provided command is not Doxygen command.")]
        public void Token_Should_Return_Token_unknown_If_Provided_Command_Is_Not_Doxygen_Command()
        {
            // Arrange
            var doxygen = new Doxygen();

            // Act
            var token = doxygen.Token("Dha Werda Verda a'den tratu!");

            // Assert
            Assert.Equal(Doxygen.Token_unknown, token);
        }

        [Fact(DisplayName = "`Doxygen.Token` should return valid token for provided Doxygen command.")]
        public void Token_Should_Return_Valid_Token_For_Provided_Doxygen_Command()
        {
            // Arrange
            var doxygen = new Doxygen();

            // Act
            var token = doxygen.Token(@"tableofcontents");

            // Assert
            Assert.Equal(Doxygen.Token_tableofcontents, token);
        }

        [Fact(DisplayName = "`Doxygen.Command` should return `null` if provided token is not Doxygen command token.")]
        public void Command_Should_Return_Null_If_Provided_Token_Is_Not_Doxygen_Command_Token()
        {
            // Arrange
            var doxygen = new Doxygen();

            // Act
            var command = doxygen.Command(Doxygen.Token_broken_bar + 128379);

            // Assert
            Assert.Null(command);
        }

        [Fact(DisplayName = "Doxygen.Command should return valid Doxygen command for provided Doxygen command token.")]
        public void Command_Should_Return_Doxygen_Command_For_Provided_Doxygen_Command_Token()
        {
            // Arrange
            var doxygen = new Doxygen();

            // Act
            var command = doxygen.Command(Doxygen.Token_enddocbookonly);

            // Assert
            Assert.Equal(Doxygen.Command_enddocbookonly, command);
        }
    }
}
