namespace Enhanced
{
    using Enhanced.Classification;
    using Microsoft.VisualStudio.Text.Classification;
    using Microsoft.VisualStudio.Utilities;
    using System.ComponentModel.Composition;

#pragma warning disable 649
    internal static class FormatDefinitions
    {
        [Export(typeof(ClassificationTypeDefinition))]
        [Name(FormatNames.DoxygenCommand)]
        internal static ClassificationTypeDefinition DoxygenCommand;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name(FormatNames.DoxygenCommandArgOne)]
        internal static ClassificationTypeDefinition DoxygenCommandArgOne;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name(FormatNames.DoxygenCommandArgTwo)]
        internal static ClassificationTypeDefinition DoxygenCommandArgTwo;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name(FormatNames.DoxygenCommandArgThree)]
        internal static ClassificationTypeDefinition DoxygenCommandArgThree;
    }
#pragma warning restore 649
}
