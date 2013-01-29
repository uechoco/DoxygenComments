namespace Enhanced.Classification.Formats
{
    using Enhanced.Classification;
    using Enhanced.Resources;
    using Microsoft.VisualStudio.Text.Classification;
    using Microsoft.VisualStudio.Utilities;
    using System.ComponentModel.Composition;
    using System.Windows.Media;

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = FormatNames.DoxygenDirPath)]
    [Name(FormatNames.DoxygenDirPath)]
    [UserVisible(true)]
    [Order(Before = Priority.High)]
    internal sealed class DoxygenDirPath : ClassificationFormatDefinition
    {
        public DoxygenDirPath()
        {
            this.DisplayName = Strings.DoxygenDirPathDisplayName;
            this.ForegroundColor = Colors.Teal;
        }
    }
}
