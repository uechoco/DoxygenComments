namespace EnhancedCommentsCpp
{
    using Microsoft.VisualStudio.Text;
    using Microsoft.VisualStudio.Text.Classification;
    using System.Collections.Generic;

    /// <summary>Classifier for C++ code.</summary>
    internal interface ICppClassifier : IClassifier
    {
        /// <summary>
        /// Gets all the <see cref="Microsoft.VisualStudio.Text.Classification.ClassificationSpan"/> objects
        /// that overlap the given range of text.
        /// </summary>
        /// <param name="span">The snapshot span.</param>
        /// <returns>
        /// A list of <see cref="Microsoft.VisualStudio.Text.Classification.ClassificationSpan"/> objects
        /// that intersect with the given range.
        /// </returns>
        IList<ClassificationSpan> GetCommentClassificationSpans(SnapshotSpan span);
    }
}
