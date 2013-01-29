namespace Enhanced.Classification.Formats
{
    using Enhanced.Classification;
    using Enhanced.Resources;
    using Microsoft.VisualStudio.Text.Classification;
    using Microsoft.VisualStudio.Utilities;
    using System.ComponentModel.Composition;
    using System.Windows.Media;

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = FormatNames.DoxygenHeaderName)]
    [Name(FormatNames.DoxygenHeaderName)]
    [UserVisible(true)]
    [Order(Before = Priority.High)]
    internal sealed class DoxygenHeaderName : ClassificationFormatDefinition
    {
        public DoxygenHeaderName()
        {
            this.DisplayName = Strings.DoxygenHeaderNameDisplayName;
            this.ForegroundColor = Colors.Teal;
        }
    }
}
