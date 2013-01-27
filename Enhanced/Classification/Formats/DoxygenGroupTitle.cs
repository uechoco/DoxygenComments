namespace Enhanced.Classification.Formats
{
    using Enhanced.Classification;
    using Enhanced.Resources;
    using Microsoft.VisualStudio.Text.Classification;
    using Microsoft.VisualStudio.Utilities;
    using System.ComponentModel.Composition;
    using System.Windows.Media;

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = FormatNames.DoxygenGroupTitle)]
    [Name(FormatNames.DoxygenGroupTitle)]
    [UserVisible(true)]
    [Order(Before = Priority.High)]
    internal class DoxygenGroupTitle : ClassificationFormatDefinition
    {
        public DoxygenGroupTitle()
        {
            this.DisplayName = Strings.DoxygenGroupTitleDisplayName;
            this.ForegroundColor = Colors.Teal;
            this.IsItalic = true;
        }
    }
}
