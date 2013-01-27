namespace Enhanced.Classification.Formats
{
    using Enhanced.Classification;
    using Enhanced.Resources;
    using Microsoft.VisualStudio.Text.Classification;
    using Microsoft.VisualStudio.Utilities;
    using System.ComponentModel.Composition;
    using System.Windows.Media;

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = FormatNames.DoxygenEmphasize)]
    [Name(FormatNames.DoxygenEmphasize)]
    [UserVisible(true)]
    [Order(Before = Priority.High)]
    internal class DoxygenEmphasize : ClassificationFormatDefinition
    {
        public DoxygenEmphasize()
        {
            this.DisplayName = Strings.DoxygenEmphasizeDisplayName;
            this.IsItalic = true;
        }
    }
}
