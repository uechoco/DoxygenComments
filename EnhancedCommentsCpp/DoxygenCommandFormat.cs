namespace EnhancedCommentsCpp
{
    using EnhancedCommentsCpp.Resources;
    using Microsoft.VisualStudio.Text.Classification;
    using Microsoft.VisualStudio.Utilities;
    using System.ComponentModel.Composition;
    using System.Windows.Media;

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = Formats.DoxygenCommand)]
    [Name(Formats.DoxygenCommand)]
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
