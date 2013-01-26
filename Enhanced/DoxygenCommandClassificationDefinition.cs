namespace Enhanced
{
    using Enhanced.Classification;
    using Microsoft.VisualStudio.Text.Classification;
    using Microsoft.VisualStudio.Utilities;
    using System.ComponentModel.Composition;

    internal static class DoxygenCommandClassificationDefinition
    {
        [Export(typeof(ClassificationTypeDefinition))]
        [Name(FormatNames.DoxygenCommand)]
        internal static ClassificationTypeDefinition DoxygenCommandTypeDefinition;
    }
}
