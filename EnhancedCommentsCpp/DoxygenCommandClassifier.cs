namespace EnhancedCommentsCpp
{
    using Microsoft.VisualStudio.Text;
    using Microsoft.VisualStudio.Text.Classification;
    using System;
    using System.Collections.Generic;

    internal sealed class DoxygenCommandClassifier : DoxygenCommandClassifierBase
    {
        private IClassificationType _classificationType;

        internal DoxygenCommandClassifier(IClassificationTypeRegistryService registry)
        {
            _classificationType = registry.GetClassificationType(Formats.DoxygenCommand);
        }

        /// <summary>
        /// Gets all the <see cref="Microsoft.VisualStudio.Text.Classification.ClassificationSpan"/> objects
        /// that overlap the given range of text.
        /// </summary>
        /// <param name="span">The snapshot span.</param>
        /// <param name="comments">The comments spans.</param>
        /// <returns>
        /// A list of <see cref="Microsoft.VisualStudio.Text.Classification.ClassificationSpan"/> objects
        /// that intersect with the given range.
        /// </returns>
        protected override IList<ClassificationSpan> GetDoxygenCommandSpans(SnapshotSpan span, IEnumerable<ClassificationSpan> comments)
        {
            var doxygenCommandSpans = new List<ClassificationSpan>();
            var currentText = span.GetText();
            var currentOffset = 0;

            // Scan the current span for all tokens.
            Token token = null;
            do
            {
                token = Scan(currentText, currentOffset, currentText.Length - currentOffset);
                if (token != null)
                {
                    var start = span.Start.Position + token.StartIndex;
                    var tokenSpan = new SnapshotSpan(span.Snapshot, start, token.Length);

                    if (this.IsInsideComment(tokenSpan, comments))
                    {
                        doxygenCommandSpans.Add(new ClassificationSpan(tokenSpan, _classificationType));
                    }

                    currentOffset = token.Length + token.StartIndex;
                }
            } while (token != null && currentOffset < currentText.Length);

            return doxygenCommandSpans;
        }

        private Token Scan(string text, int startIndex, int length)
        {
            Token token = null;
            var index = startIndex;
            while (index < text.Length)
            {
                bool found = false;
                foreach (var cmd in Doxygen.Commands)
                {
                    if (IsToken(text, cmd, index))
                    {
                        var nextCharIndex = index + cmd.Length;
                        if (nextCharIndex < text.Length)
                        {
                            if (IdentifierChar(text[nextCharIndex]))
                            {
                                continue;
                            }
                        }

                        token = new Token
                        {
                            Length = cmd.Length,
                            StartIndex = index,
                            TokenKind = TokenKind.DoxygenCommand,
                            Text = cmd
                        };

                        found = true;
                        break;
                    }
                }

                if (found)
                {
                    break;
                }

                index++;
            }

            return token;
        }

        private bool IsToken(string text, string token, int startIndex)
        {
            var isToken = false;

            if (text.Length >= startIndex + token.Length)
            {
                var i = text.IndexOf(token, startIndex, token.Length);
                isToken = i == startIndex;
            }

            return isToken;
        }

        private bool IdentifierChar(char c)
        {
            return (char.IsPunctuation(c) || char.IsWhiteSpace(c) || char.IsSymbol(c)) == false;
        }
    }
}
