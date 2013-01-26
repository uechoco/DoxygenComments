namespace Enhanced.Classification
{
    using Microsoft.VisualStudio.Text.Classification;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;

    [Export(typeof(IParsersManager))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    internal class ParsersManager : IParsersManager
    {
        private readonly List<string> names = new List<string>();
        private readonly Dictionary<string, IParser> parsers = new Dictionary<string,IParser>();

        [ImportingConstructor]
        public ParsersManager(IClassificationTypeRegistryService registry)
        {
            var thisAssembly = this.GetType().Assembly;
            var parserTypes = thisAssembly.GetTypes()
                .Where(t => t.IsAbstract == false)
                .Where(t => t.CustomAttributes
                    .FirstOrDefault(a => a.AttributeType == typeof(ParserAttribute)) != null);

            // Now we have parser types
            foreach (var parserType in parserTypes)
            {
                var parser = (IParser)Activator.CreateInstance(parserType, registry);
                var attr = (ParserAttribute)parserType.GetCustomAttributes(typeof(ParserAttribute), false)[0];
                this.parsers.Add(attr.FormatName, parser);
            }

            this.names = (from c in this.parsers.Keys
                         orderby c.Length descending
                         select c).ToList();
        }

        public IEnumerable<string> GetNames()
        {
            return this.names;
        }

        public IParser GetParser(string name)
        {
            IParser parser = null;
            this.parsers.TryGetValue(name, out parser);

            return parser;
        }
    }
}
