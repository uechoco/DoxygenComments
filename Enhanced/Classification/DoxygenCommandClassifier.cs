namespace Enhanced.Classification
{
    using Microsoft.VisualStudio.Text;
    using Microsoft.VisualStudio.Text.Classification;
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public sealed class DoxygenCommandClassifier : DoxygenCommandClassifierBase
    {
        private readonly IClassificationType classificationType;
        private readonly string[] commands;

        public DoxygenCommandClassifier(IClassificationTypeRegistryService registry)
        {
            this.classificationType = registry.GetClassificationType(Formats.DoxygenCommand);
            this.commands = Doxygen.Commands.GetCommandsSortedByLength().ToArray();
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
            DoxygenCommandToken token = null;
            do
            {
                token = Scan(currentText, currentOffset, currentText.Length - currentOffset);
                if (token != null)
                {
                    var start = span.Start.Position + token.StartIndex;
                    var tokenSpan = new SnapshotSpan(span.Snapshot, start, token.Length);

                    if (this.IsInsideComment(tokenSpan, comments))
                    {
                        doxygenCommandSpans.Add(new ClassificationSpan(tokenSpan, this.classificationType));
                    }

                    currentOffset = token.Length + token.StartIndex;
                }
            } while (token != null && currentOffset < currentText.Length);

            return doxygenCommandSpans;
        }

        private DoxygenCommandToken Scan(string text, int startIndex, int length)
        {
            DoxygenCommandToken token = null;
            var index = startIndex;
            while (index < text.Length)
            {
                bool found = false;
                foreach (var cmd in this.commands)
                {
                    if (IsToken(text, cmd, index))
                    {
                        var nextCharIndex = index + cmd.Length + 1;
                        if (nextCharIndex < text.Length)
                        {
                            if (IdentifierChar(text[nextCharIndex]))
                            {
                                continue;
                            }
                        }

                        token = new DoxygenCommandToken
                        {
                            Length = cmd.Length + 1,
                            StartIndex = index,
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

            var t1 = "\\" + token;
            var t2 = "@" + token;

            if (text.Length >= startIndex + t1.Length)
            {
                var i = text.IndexOf(t1, startIndex, t1.Length);
                isToken = i == startIndex;

                if (!isToken)
                {
                    i = text.IndexOf(t2, startIndex, t2.Length);
                    isToken = i == startIndex;
                }
            }

            return isToken;
        }

        private bool IdentifierChar(char c)
        {
            return (char.IsPunctuation(c) || char.IsWhiteSpace(c) || char.IsSymbol(c)) == false;
        }
    }
}
