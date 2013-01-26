namespace Enhanced.Classification.Doxygen
{
    using Microsoft.VisualStudio.Text.Classification;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    internal abstract class Parser : IParser
    {
        private readonly Regex regex;

        protected Parser(string pattern)
        {
            this.regex = new Regex(pattern,
                RegexOptions.CultureInvariant |
                RegexOptions.Compiled |
                RegexOptions.Singleline);
        }

        protected Regex Regex
        {
            get { return this.regex; }
        }

        public abstract int Parse(string text, int start, IList<Token> tokens);

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
