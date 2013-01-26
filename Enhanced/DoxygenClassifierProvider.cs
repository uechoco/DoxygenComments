namespace Enhanced
{
    using Enhanced.Classification;
    using Microsoft.VisualStudio.Text;
    using Microsoft.VisualStudio.Text.Classification;
    using Microsoft.VisualStudio.Utilities;
    using System.ComponentModel.Composition;

    [Export(typeof(IClassifierProvider))]
    [ContentType("C/C++")]
    internal sealed class DoxygenClassifierProvider : IClassifierProvider
    {
        [Import]
        internal IClassificationTypeRegistryService ClassificationRegistry = null;

        [Import]
        internal IParsersManager ParsersManager = null;

        public IClassifier GetClassifier(ITextBuffer buffer)
        {
            return buffer.Properties.GetOrCreateSingletonProperty<DoxygenCommandClassifier>(
                delegate { return new DoxygenCommandClassifier(ClassificationRegistry, ParsersManager); });
        }
    }
}
