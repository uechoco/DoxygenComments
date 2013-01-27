namespace Enhanced.Classification
{
    using Enhanced.Classification.Doxygen;
    using Enhanced.Doxygen;
    using Microsoft.VisualStudio.Text.Classification;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;

    [Export(typeof(IParsersManager))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    internal class ParsersManager : IParsersManager
    {
        private readonly List<string> names;
        private readonly Dictionary<string, IParser> parsers = new Dictionary<string, IParser>();

        [ImportingConstructor]
        public ParsersManager(IClassificationTypeRegistryService registry)
        {
            var coll = Commands.GetCommandsAndPatterns().ToList();
            foreach (var i in coll)
            {
                var command = i.Item1;
                var pattern = i.Item2;
                if (pattern != null)
                {
                    var parser = new GenericParser(registry, pattern);
                    this.parsers.Add(command, parser);
                }
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
