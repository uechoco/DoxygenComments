namespace Enhanced.Classification.Formats
{
    using Enhanced.Classification;
    using Enhanced.Resources;
    using Microsoft.VisualStudio.Text.Classification;
    using Microsoft.VisualStudio.Utilities;
    using System.ComponentModel.Composition;
    using System.Windows.Media;

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = FormatNames.DoxygenCommand)]
    [Name(FormatNames.DoxygenCommand)]
    [UserVisible(true)]
    [Order(Before = Priority.High)]
    internal sealed class DoxygenCommandFormat : ClassificationFormatDefinition
    {
        public DoxygenCommandFormat()
        {
            this.DisplayName = Strings.DoxygenCommandDisplayName;
            this.ForegroundColor = Colors.BlueViolet;
        }
    }
}
