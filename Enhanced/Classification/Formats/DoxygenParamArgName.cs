namespace Enhanced.Classification.Formats
{
    using Enhanced.Classification;
    using Enhanced.Resources;
    using Microsoft.VisualStudio.Text.Classification;
    using Microsoft.VisualStudio.Utilities;
    using System.ComponentModel.Composition;
    using System.Windows.Media;

    [UserVisible(true)]
    [Order(Before = Priority.High)]
    [Export(typeof(EditorFormatDefinition))]
    [Name(FormatNames.DoxygenParamArgName)]
    [ClassificationType(ClassificationTypeNames = FormatNames.DoxygenParamArgName)]
    internal sealed class DoxygenParamArgName : ClassificationFormatDefinition
    {
        public DoxygenParamArgName()
        {
            this.DisplayName = Strings.DoxygenParamArgNameDisplayName;
            this.ForegroundColor = Colors.Teal;
        }
    }
}
