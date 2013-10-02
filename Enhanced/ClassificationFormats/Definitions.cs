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
namespace Enhanced.ClassificationFormats
{
    using Microsoft.VisualStudio.Text.Classification;
    using Microsoft.VisualStudio.Utilities;
    using System.ComponentModel.Composition;

    public static class Definitions
    {
#if DEBUG
        [Export(typeof(ClassificationTypeDefinition))]
        [Name(Names.DoxygenComment)]
        public static ClassificationTypeDefinition DoxygenComment = null;
#endif

        [Export(typeof(ClassificationTypeDefinition))]
        [Name(Names.DoxygenCommand)]
        public static ClassificationTypeDefinition DoxygenCommand;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name(Names.DoxygenCommandArgOne)]
        public static ClassificationTypeDefinition DoxygenCommandArgOne;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name(Names.DoxygenCommandArgTwo)]
        public static ClassificationTypeDefinition DoxygenCommandArgTwo;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name(Names.DoxygenCommandArgThree)]
        public static ClassificationTypeDefinition DoxygenCommandArgThree;
    }
}
