namespace Enhanced.Classification
{
    using Microsoft.VisualStudio.Text;
    using Microsoft.VisualStudio.Text.Classification;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Enhanced.Doxygen;

    internal sealed class DoxygenCommandClassifier : DoxygenCommandClassifierBase
    {
        private readonly IClassificationType classificationType;
        private readonly string[] commands;
        private readonly IParsersManager parsersManager;

        public DoxygenCommandClassifier(IClassificationTypeRegistryService registry, IParsersManager parsersManager)
        {
            this.classificationType = registry.GetClassificationType(FormatNames.DoxygenCommand);
            this.commands = Commands.GetCommandsSortedByLength().ToArray();
            this.parsersManager = parsersManager;
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
            var spans = new List<ClassificationSpan>();
            var currentText = span.GetText();
            var currentOffset = 0;
            var parsers = parsersManager.GetNames();

            var found = false;
            var tokens = new List<Token>();
            do
            {
                found = false;
                foreach (var parserName in parsers)
                {
                    var parser = parsersManager.GetParser(parserName);
                    var lastIndex = parser.Parse(currentText, currentOffset, tokens);
                    if (lastIndex != currentOffset)
                    {
                        // Found
                        currentOffset = lastIndex;
                        found = true;
                        break;
                    }
                    else
                    {
                        // Not found
                    }
                }
            } while (found && currentOffset < currentText.Length);

            foreach (var token in tokens)
            {
                var start = span.Start.Position + token.Start;
                var tokenSpan = new SnapshotSpan(span.Snapshot, start, token.Length);
                if (this.IsInsideComment(tokenSpan, comments))
                {
                    spans.Add(new ClassificationSpan(tokenSpan, token.ClassificationType));
                }
            }

            return spans;
        }
    }
}
