using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using System;
using System.Collections.Generic;

namespace EnhancedCommentsCpp
{
    class DoxygenCommandClassifier : IClassifier
    {
        IClassificationType _classificationType;

        internal DoxygenCommandClassifier(IClassificationTypeRegistryService registry)
        {
            _classificationType = registry.GetClassificationType("Doxygen Command");
        }

        public event EventHandler<ClassificationChangedEventArgs> ClassificationChanged;

        public IList<ClassificationSpan> GetClassificationSpans(SnapshotSpan span)
        {
            var result = new List<ClassificationSpan>();
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
                    result.Add(new ClassificationSpan(tokenSpan, _classificationType));

                    currentOffset = token.Length + token.StartIndex;
                }
            } while (token != null && currentOffset < currentText.Length);

            return result;
        }

        private Token Scan(string text, int startIndex, int length)
        {
            Token token = null;

            foreach (var cmd in DoxygenCommands.Commands)
            {
                var start = text.IndexOf(cmd, startIndex, length);
                if (start != -1)
                {
                    var nextCharIndex = start + cmd.Length;
                    if (nextCharIndex < length)
                    {
                        var c = text[nextCharIndex];
                        if (char.IsPunctuation(c) ||
                            char.IsWhiteSpace(c) ||
                            char.IsSymbol(c))
                        {
                            token = new Token
                            {
                                Length = cmd.Length,
                                StartIndex = start
                            };

                            break;
                        }   
                    }
                }
            }

            return token;
        }
    }
}
