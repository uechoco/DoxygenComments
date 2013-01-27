namespace Enhanced.Classification.Doxygen
{
    using Microsoft.VisualStudio.Text.Classification;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    internal class GenericParser : Parser
    {
        private readonly Regex regex;
        private readonly IDictionary<string, IClassificationType> classificationTypes =
            new Dictionary<string, IClassificationType>();

        public GenericParser(IClassificationTypeRegistryService registry, string pattern)
        {
            this.regex = new Regex(pattern,
                RegexOptions.CultureInvariant |
                RegexOptions.Compiled |
                RegexOptions.Singleline);
            var groups = regex.GetGroupNames();
            foreach (var g in groups)
            {
                var ct = registry.GetClassificationType(g);
                if (ct != null)
                {
                    this.classificationTypes.Add(g, ct);
                }
            }
        }

        protected override IEnumerable<string> Groups
        {
            get { return this.classificationTypes.Keys; }
        }

        protected override IDictionary<string, IClassificationType> ClassificationTypes
        {
            get { return this.classificationTypes; }
        }

        protected override Regex Regex
        {
            get { return this.regex; }
        }
    }
}
