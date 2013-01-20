namespace EnhancedCommentsCpp
{
    using Microsoft.VisualStudio.Text;
    using Microsoft.VisualStudio.Text.Classification;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Reflection;

    internal sealed class DoxygenCommandClassifier : IClassifier
    {
        private IClassificationType _classificationType;

        internal DoxygenCommandClassifier(IClassificationTypeRegistryService registry)
        {
            _classificationType = registry.GetClassificationType("Doxygen Command");
        }

        public event EventHandler<ClassificationChangedEventArgs> ClassificationChanged;

        public IList<ClassificationSpan> GetClassificationSpans(SnapshotSpan span)
        {
            var result = new List<ClassificationSpan>();
            var buffer = span.Snapshot.TextBuffer;

            var commentHelper = new CommentHelper(span.Snapshot.TextBuffer);

            if (commentHelper.Available)
            {
                var commentSpans = commentHelper.GetCommentSpans(span);
                if (commentSpans.Count > 0)
                {
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

                            foreach (var commentSpan in commentSpans)
                            {
                                if (tokenSpan.OverlapsWith(commentSpan.Span))
                                {
                                    result.Add(new ClassificationSpan(tokenSpan, _classificationType));
                                    break;
                                }
                            }

                            currentOffset = token.Length + token.StartIndex;
                        }
                    } while (token != null && currentOffset < currentText.Length);
                }
            }

            return result;
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

        private sealed class CommentHelper
        {
            private Type _colorerType;
            private object _colorer;

            public CommentHelper(ITextBuffer buffer)
            {
                _colorerType = Type.GetType("Microsoft.VisualC.CppColorer, Microsoft.VisualC.Editor.Implementation, Version=11.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a");
                buffer.Properties.TryGetProperty(_colorerType, out _colorer);
            }

            public bool Available
            {
                get { return _colorer != null; }
            }

            private IList<ClassificationSpan> GetClassificationSpans(SnapshotSpan classifySpan)
            {
                return ((IClassifier)_colorer).GetClassificationSpans(classifySpan);
            }

            public IList<ClassificationSpan> GetCommentSpans(SnapshotSpan classifySpan)
            {
                if (!Available)
                {
                    throw new InvalidOperationException();
                }

                return GetClassificationSpans(classifySpan)
                        .Where(s => s.ClassificationType.Classification == "comment")
                        .ToList();
            }
        }
    }
}
