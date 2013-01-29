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

        [Name(FormatNames.DoxygenEmphasize)]
        [Export(typeof(ClassificationTypeDefinition))]
        internal static ClassificationTypeDefinition DoxygenEmphasize;

        [Name(FormatNames.DoxygenClassName)]
        [Export(typeof(ClassificationTypeDefinition))]
        internal static ClassificationTypeDefinition DoxygenClassName;

        [Name(FormatNames.DoxygenHeaderFile)]
        [Export(typeof(ClassificationTypeDefinition))]
        internal static ClassificationTypeDefinition DoxygenHeaderFile;

        [Name(FormatNames.DoxygenHeaderName)]
        [Export(typeof(ClassificationTypeDefinition))]
        internal static ClassificationTypeDefinition DoxygenHeaderName;

        [Name(FormatNames.DoxygenMacroName)]
        [Export(typeof(ClassificationTypeDefinition))]
        internal static ClassificationTypeDefinition DoxygenMacroName;

        [Name(FormatNames.DoxygenDirPath)]
        [Export(typeof(ClassificationTypeDefinition))]
        internal static ClassificationTypeDefinition DoxygenDirPath;
    }
#pragma warning restore 649
}
