namespace Enhanced.Classification.Formats
{
    using Enhanced.Classification;
    using Enhanced.Resources;
    using Microsoft.VisualStudio.Text.Classification;
    using Microsoft.VisualStudio.Utilities;
    using System.ComponentModel.Composition;
    using System.Windows.Media;

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = FormatNames.DoxygenCommandArgThree)]
    [Name(FormatNames.DoxygenCommandArgThree)]
    [UserVisible(true)]
    [Order(Before = Priority.High)]
    internal sealed class DoxygenCommandArgThree : ClassificationFormatDefinition
    {
        public DoxygenCommandArgThree()
        {
            this.DisplayName = Strings.DoxygenCommandArgThreeDisplayName;
            this.ForegroundColor = Colors.Teal;
        }
    }
}
