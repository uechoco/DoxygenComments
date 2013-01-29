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
    [ClassificationType(ClassificationTypeNames = FormatNames.DoxygenHeaderFile)]
    [Name(FormatNames.DoxygenHeaderFile)]
    [UserVisible(true)]
    [Order(Before = Priority.High)]
    internal sealed class DoxygenHeaderFile : ClassificationFormatDefinition
    {
        public DoxygenHeaderFile()
        {
            this.DisplayName = Strings.DoxygenHeaderFileDisplayName;
            this.ForegroundColor = Colors.Gray;
        }
    }
}
