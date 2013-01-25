namespace Enhanced.Classification
{
    using Microsoft.VisualStudio.Text;
    using Microsoft.VisualStudio.Text.Classification;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>Wrapper around Microsoft's internal classifier for C++.</summary>
    internal sealed class CppClassifier : ICppClassifier
    {
        private readonly IClassifier colorer;

        /// <summary>Ocurs when the classification of a span of text has changed.</summary>
        public event EventHandler<ClassificationChangedEventArgs> ClassificationChanged;

        /// <summary>
        /// Gets value indicating whether Microsoft's internal classifier for C++ is avalable. 
        /// </summary>
        private bool IsAvailable
        {
            get { return this.colorer != null; }
        }

        /// <summary>
        /// Initializes new instance of the <see cref="CppClassifier"/> using provided text buffer.
        /// </summary>
        /// <param name="buffer">Text buffer used to get Microsoft's internal classifier for C++.</param>
        internal CppClassifier(ITextBuffer buffer)
        {
            this.colorer = buffer.Properties.PropertyList
                    .Select(p => p.Value as IClassifier)
                    .Where(i => i != null)
                    .Where(i => i.GetType().IsSubclassOf(typeof(DoxygenCommandClassifierBase)) == false)
                    .Where(i => i.GetType().FullName == "Microsoft.VisualC.CppColorer")
                    .FirstOrDefault();
        }

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
            var spans = new List<ClassificationSpan>();

            if (this.IsAvailable)
            {
                spans.AddRange(this.colorer.GetClassificationSpans(span));
            }

            return spans;
        }

        /// <summary>
        /// Gets all the <see cref="Microsoft.VisualStudio.Text.Classification.ClassificationSpan"/> objects
        /// that overlap the given range of text.
        /// </summary>
        /// <param name="span">The snapshot span.</param>
        /// <returns>
        /// A list of <see cref="Microsoft.VisualStudio.Text.Classification.ClassificationSpan"/> objects
        /// that intersect with the given range.
        /// </returns>
        public IList<ClassificationSpan> GetCommentClassificationSpans(SnapshotSpan span)
        {
            return this.GetClassificationSpans(span)
                .Where(s => s.ClassificationType.Classification == Formats.Comment)
                .ToList();
        }
    }
}
