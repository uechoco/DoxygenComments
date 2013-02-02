namespace Enhanced.Classification.Formats
{
    using Enhanced.Classification;
    using Enhanced.Resources;
    using Microsoft.VisualStudio.Text.Classification;
    using Microsoft.VisualStudio.Utilities;
    using System.ComponentModel.Composition;
    using System.Windows.Media;

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = FormatNames.DoxygenCommandArgTwo)]
    [Name(FormatNames.DoxygenCommandArgTwo)]
    [UserVisible(true)]
    [Order(Before = Priority.High)]
    internal sealed class DoxygenCommandArgTwo : ClassificationFormatDefinition
    {
        public DoxygenCommandArgTwo()
        {
            this.DisplayName = Strings.DoxygenCommandArgTwoDisplayName;
            this.ForegroundColor = Colors.Gray;
        }
    }
}
