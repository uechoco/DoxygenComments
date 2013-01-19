using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;

namespace EnhancedCommentsCpp
{
    [Export(typeof(IClassifierProvider))]
    [ContentType("C/C++")]
    internal class EnhancedCommentsCppProvider : IClassifierProvider
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
