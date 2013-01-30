namespace Enhanced.Classification.Formats
{
    using Enhanced.Classification;
    using Enhanced.Resources;
    using Microsoft.VisualStudio.Text.Classification;
    using Microsoft.VisualStudio.Utilities;
    using System.ComponentModel.Composition;
    using System.Windows.Media;

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = FormatNames.DoxygenCommandArgOne)]
    [Name(FormatNames.DoxygenCommandArgOne)]
    [UserVisible(true)]
    [Order(Before = Priority.High)]
    internal sealed class DoxygenCommandArgOne : ClassificationFormatDefinition
    {
        public DoxygenCommandArgOne()
        {
            this.DisplayName = Strings.DoxygenCommandArgOneDisplayName;
            this.ForegroundColor = Colors.Teal;
        }
    }
}
