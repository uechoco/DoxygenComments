namespace Enhanced
{
    using Enhanced.Classification;
    using Microsoft.VisualStudio.Text.Classification;
    using Microsoft.VisualStudio.Utilities;
    using System.ComponentModel.Composition;

#pragma warning disable 649
    internal static class DoxygenCommandClassificationDefinition
    {
        [Export(typeof(ClassificationTypeDefinition))]
        [Name(FormatNames.DoxygenCommand)]
        internal static ClassificationTypeDefinition DoxygenCommand;

        [Name(FormatNames.DoxygenParamDirection)]
        [Export(typeof(ClassificationTypeDefinition))]
        internal static ClassificationTypeDefinition DoxygenParamDirection;

        [Name(FormatNames.DoxygenParamArgName)]
        [Export(typeof(ClassificationTypeDefinition))]
        internal static ClassificationTypeDefinition DoxygenParamArgName;
    }
#pragma warning restore 649
}
