namespace EnhancedCommentsCpp
{
    using System.ComponentModel.Composition;
    using Microsoft.VisualStudio.Text.Classification;
    using Microsoft.VisualStudio.Utilities;
    using Enhanced.Classification;

    internal static class DoxygenCommandClassificationDefinition
    {
        [Export(typeof(ClassificationTypeDefinition))]
        [Name(Formats.DoxygenCommand)]
        internal static ClassificationTypeDefinition DoxygenCommandTypeDefinition = null;
    }
}
