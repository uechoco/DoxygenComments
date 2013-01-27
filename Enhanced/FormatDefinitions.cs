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

        [Name(FormatNames.DoxygenParamDirection)]
        [Export(typeof(ClassificationTypeDefinition))]
        internal static ClassificationTypeDefinition DoxygenParamDirection;

        [Name(FormatNames.DoxygenParamArgName)]
        [Export(typeof(ClassificationTypeDefinition))]
        internal static ClassificationTypeDefinition DoxygenParamArgName;

        [Name(FormatNames.DoxygenGroupName)]
        [Export(typeof(ClassificationTypeDefinition))]
        internal static ClassificationTypeDefinition DoxygenGroupName;

        [Name(FormatNames.DoxygenGroupTitle)]
        [Export(typeof(ClassificationTypeDefinition))]
        internal static ClassificationTypeDefinition DoxygenGroupTitle;

        //[Regex(@"^*(?<command>(?:[@\\]e)|(?:[@\\]em)|(?:[@\\]a))\s+(?<word>\w+\b)?")]
        [Name(FormatNames.DoxygenEmphasize)]
        [Export(typeof(ClassificationTypeDefinition))]
        internal static ClassificationTypeDefinition DoxygenEmphasize;
    }
#pragma warning restore 649
}
