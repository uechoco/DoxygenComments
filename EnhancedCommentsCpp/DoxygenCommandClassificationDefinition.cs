using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace EnhancedCommentsCpp
{
    internal static class DoxygenCommandClassificationDefinition
    {
        [Export(typeof(ClassificationTypeDefinition))]
        [Name("Doxygen Command")]
        internal static ClassificationTypeDefinition DoxygenCommandTypeDefinition = null;
    }
}
