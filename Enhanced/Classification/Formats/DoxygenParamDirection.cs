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
    [Name(FormatNames.DoxygenParamDirection)]
    [ClassificationType(ClassificationTypeNames = FormatNames.DoxygenParamDirection)]
    internal sealed class DoxygenParamDirection : ClassificationFormatDefinition
    {
        public DoxygenParamDirection()
        {
            this.DisplayName = Strings.DoxygenParamDirectionDisplayName;
            this.ForegroundColor = Colors.Gray;
        }
    }
}
