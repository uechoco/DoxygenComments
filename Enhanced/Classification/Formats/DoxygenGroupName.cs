namespace Enhanced.Classification.Formats
{
    using Enhanced.Classification;
    using Enhanced.Resources;
    using Microsoft.VisualStudio.Text.Classification;
    using Microsoft.VisualStudio.Utilities;
    using System.ComponentModel.Composition;
    using System.Windows.Media;

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = FormatNames.DoxygenGroupName)]
    [Name(FormatNames.DoxygenGroupName)]
    [UserVisible(true)]
    [Order(Before = Priority.High)]
    internal class DoxygenGroupName : ClassificationFormatDefinition
    {
        public DoxygenGroupName()
        {
            this.DisplayName = Strings.DoxygenGroupNameDisplayName;
            this.ForegroundColor = Colors.Teal;
        }
    }
}
