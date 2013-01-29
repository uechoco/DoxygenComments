using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enhanced.Classification.Formats
{
    using Enhanced.Classification;
    using Enhanced.Resources;
    using Microsoft.VisualStudio.Text.Classification;
    using Microsoft.VisualStudio.Utilities;
    using System.ComponentModel.Composition;
    using System.Windows.Media;

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = FormatNames.DoxygenMacroName)]
    [Name(FormatNames.DoxygenMacroName)]
    [UserVisible(true)]
    [Order(Before = Priority.High)]
    internal sealed class DoxygenMacroName : ClassificationFormatDefinition
    {
        public DoxygenMacroName()
        {
            this.DisplayName = Strings.DoxygenMacroNameDisplayName;
            this.ForegroundColor = Colors.Teal;
        }
    }
}
