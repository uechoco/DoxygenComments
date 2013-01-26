namespace Enhanced.Classification.Doxygen
{
    using Enhanced.Doxygen;
    using Microsoft.VisualStudio.Text.Classification;
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    [Parser(Commands.Param)]
    internal class ParamParser : IParser
    {
        private const string Pattern = @"^*(?<command>[@\\]param)\s*(?<direction>(?:\[out])|(?:\[in])|(?:\[in,\s*out]))?\s+(?<argname>\w+\b)?";
        private readonly IClassificationType commandCT;
        private readonly IClassificationType directionCT;
        private readonly IClassificationType argnameCT;
        private readonly Regex regex;

        public ParamParser(IClassificationTypeRegistryService registry)
        {
            this.commandCT = registry.GetClassificationType(FormatNames.DoxygenCommand);
            this.directionCT = registry.GetClassificationType(FormatNames.DoxygenParamDirection);
            this.argnameCT = registry.GetClassificationType(FormatNames.DoxygenParamArgName);
            this.regex = new Regex(Pattern, 
                RegexOptions.CultureInvariant |
                RegexOptions.Compiled |
                RegexOptions.Singleline);
        }

        public int Parse(string text, int start, IList<Token> tokens)
        {
            var match = this.regex.Match(text, start);

            var command = match.Groups["command"];
            var direction = match.Groups["direction"];
            var argname = match.Groups["argname"];

            var indexes = new int[3];
            indexes[0] = AddToken(tokens, command, this.commandCT);
            indexes[1] = AddToken(tokens, direction, this.directionCT);
            indexes[2] = AddToken(tokens, argname, this.argnameCT);

            var lastIndex = Math.Max(indexes[0], Math.Max(indexes[1], indexes[2]));
            if (lastIndex == -1)
            {
                lastIndex = start;
            }
            return lastIndex;
        }

        private int AddToken(IList<Token> tokens, Group g, IClassificationType ct)
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
