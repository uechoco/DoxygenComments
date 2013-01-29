namespace Enhanced.Classification.Formats
{
    using Enhanced.Classification;
    using Enhanced.Resources;
    using Microsoft.VisualStudio.Text.Classification;
    using Microsoft.VisualStudio.Utilities;
    using System.ComponentModel.Composition;
    using System.Windows.Media;

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = FormatNames.DoxygenClassName)]
    [Name(FormatNames.DoxygenClassName)]
    [UserVisible(true)]
    [Order(Before = Priority.High)]
    internal sealed class DoxygenClassName : ClassificationFormatDefinition
    {
        public DoxygenClassName()
        {
            this.DisplayName = Strings.DoxygenClassNameDisplayName;
            this.ForegroundColor = Colors.Teal;
        }
    }
}
