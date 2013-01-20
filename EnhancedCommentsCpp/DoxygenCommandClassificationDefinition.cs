namespace EnhancedCommentsCpp
{
    using System.ComponentModel.Composition;
    using Microsoft.VisualStudio.Text.Classification;
    using Microsoft.VisualStudio.Utilities;

    internal static class DoxygenCommandClassificationDefinition
    {
        [Export(typeof(ClassificationTypeDefinition))]
        [Name("Doxygen Command")]
        internal static ClassificationTypeDefinition DoxygenCommandTypeDefinition = null;
    }
}
