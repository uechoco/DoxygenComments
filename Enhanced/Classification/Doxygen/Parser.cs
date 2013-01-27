namespace Enhanced.Classification.Doxygen
{
    using Microsoft.VisualStudio.Text.Classification;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    internal abstract class Parser : IParser
    {
        protected abstract IEnumerable<string> Groups
        {
            get;
        }

        protected abstract IDictionary<string, IClassificationType> ClassificationTypes
        {
            get;
        }

        protected abstract Regex Regex
        {
            get;
        }

        public int Parse(string text, int start, IList<Token> tokens)
        {
            var match = this.Regex.Match(text, start);

            var indexes = new List<int>();

            // TODO: match.Success

            foreach (var groupName in this.Groups)
            {
                var group = match.Groups[groupName];
                indexes.Add(AddToken(tokens, group, this.ClassificationTypes[groupName]));
            }

            var lastIndex = indexes.Max();
            if (lastIndex == -1)
            {
                lastIndex = start;
            }

            return lastIndex;
        }

        protected int AddToken(IList<Token> tokens, Group g, IClassificationType ct)
        {
            var lastIndex = -1;
            if (g.Success)
            {
                var token = new Token()
                {
                    Start = g.Index,
                    Length = g.Length,
                    ClassificationType = ct
                };

                tokens.Add(token);
                lastIndex = token.Start + token.Length;
            }

            return lastIndex;
        }
    }
}
