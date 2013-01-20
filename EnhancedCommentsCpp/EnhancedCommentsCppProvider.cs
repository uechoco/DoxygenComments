namespace EnhancedCommentsCpp
{
    using Microsoft.VisualStudio.Text;
    using Microsoft.VisualStudio.Text.Classification;
    using Microsoft.VisualStudio.Utilities;
    using System.ComponentModel.Composition;

    [Export(typeof(IClassifierProvider))]
    [ContentType("C/C++")]
    internal sealed class EnhancedCommentsCppProvider : IClassifierProvider
    {
        [Import]
        internal IClassificationTypeRegistryService ClassificationRegistry = null;

        public IClassifier GetClassifier(ITextBuffer buffer)
        {
            return buffer.Properties.GetOrCreateSingletonProperty<DoxygenCommandClassifier>(
                delegate { return new DoxygenCommandClassifier(ClassificationRegistry); });
        }
    }
}
