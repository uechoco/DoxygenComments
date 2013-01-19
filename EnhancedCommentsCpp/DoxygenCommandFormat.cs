using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;
using System.Windows.Media;

namespace EnhancedCommentsCpp
{
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "Doxygen Command")]
    [Name("Doxygen Command")]
    [UserVisible(true)]
    [Order(Before = Priority.High)]
    internal sealed class DoxygenCommandFormat : ClassificationFormatDefinition
    {
        public DoxygenCommandFormat()
        {
            this.DisplayName = "Doxygen Command";
            this.ForegroundColor = Colors.BlueViolet;
            this.TextDecorations = System.Windows.TextDecorations.Underline;
        }
    }
}
