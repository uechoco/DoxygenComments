namespace EnhancedCommentsCpp
{
    using Microsoft.VisualStudio.Text;
    using Microsoft.VisualStudio.Text.Classification;
    using System;
    using System.Collections.Generic;

    internal abstract class DoxygenCommandClassifierBase : IClassifier
    {
        /// <summary>Ocurs when the classification of a span of text has changed.</summary>
        public event EventHandler<ClassificationChangedEventArgs> ClassificationChanged;

        /// <summary>
        /// Gets all the <see cref="Microsoft.VisualStudio.Text.Classification.ClassificationSpan"/> objects
        /// that overlap the given range of text.
        /// </summary>
        /// <param name="span">The snapshot span.</param>
        /// <returns>
        /// A list of <see cref="Microsoft.VisualStudio.Text.Classification.ClassificationSpan"/> objects
        /// that intersect with the given range.
        /// </returns>
        public IList<ClassificationSpan> GetClassificationSpans(SnapshotSpan span)
        {
            var doxygenCommandSpans = new List<ClassificationSpan>();
            var buffer = span.Snapshot.TextBuffer;
            var cpp = GetCppClassifier(buffer);
            var commentSpans = cpp.GetCommentClassificationSpans(span);
            if (commentSpans.Count > 0)
            {
                var spans = GetDoxygenCommandSpans(span, commentSpans);
                doxygenCommandSpans.AddRange(spans);
            }

            return doxygenCommandSpans;
        }

        /// <summary>
        /// Checks whether provided token span is inside one of the comments spans.
        /// </summary>
        /// <param name="tokenSpan">Token span to check.</param>
        /// <param name="comments">Collection of comment spans.</param>
        /// <returns><c>true</c> if provided token span is in comments spans or <c>false</c> if it is not.</returns>
        protected bool IsInsideComment(SnapshotSpan tokenSpan, IEnumerable<ClassificationSpan> comments)
        {
            var isInsideComment = false;
            foreach (var commentSpan in comments)
            {
                if (tokenSpan.OverlapsWith(commentSpan.Span))
                {
                    isInsideComment = true;
                    break;
                }
            }

            return isInsideComment;
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
        protected abstract IList<ClassificationSpan> GetDoxygenCommandSpans(SnapshotSpan span, IEnumerable<ClassificationSpan> comments);

        /// <summary>
        /// Returns classifier that can classify C++ code.
        /// </summary>
        /// <param name="buffer">Buffer for which get C++ classifier.</param>
        /// <returns>Classifier for C++ code.</returns>
        protected virtual ICppClassifier GetCppClassifier(ITextBuffer buffer)
        {
            return new CppClassifier(buffer);
        }

        /// <summary>
        /// Raises <see cref="ClassificationChanged"/> event.
        /// </summary>
        /// <param name="changeSpan">The span of the classification that changed.</param>
        protected virtual void OnClassificationChanged(SnapshotSpan changeSpan)
        {
            var handler = ClassificationChanged;
            if (handler != null)
            {
                handler(this, new ClassificationChangedEventArgs(changeSpan));
            }
        }
    }
}
