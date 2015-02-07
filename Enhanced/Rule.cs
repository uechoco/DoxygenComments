/**
 * Copyright (c) 2013-2015 Oleksandr Manenko
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
namespace Enhanced
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;

    public sealed class Rule
    {
        public Rule(string command, string pattern)
        {
            this.Command = command;
            this.Regex = new Regex(pattern, RegexOptions.CultureInvariant);
        }

        public string Command
        {
            get;
            private set;
        }

        public Regex Regex
        {
            get;
            private set;
        }

        public override string ToString()
        {
            return string.Format("{0}  ->  {1}", this.Command, this.Regex);
        }

        #region Predefined rules
        private static IEnumerable<Rule> rules;
        private const int NumberOfRules = 168;

        public static IEnumerable<Rule> GetRules()
        {
            if (rules == null)
            {
                var lines = ReadRulesFile();
                rules = lines.Select(ParseRule).Where(rule => rule != null).ToArray();
            }

            return rules;
        }

        private static Rule ParseRule(string line)
        {
            Rule rule = null;
            var items = line.Split(new[] { "->" }, StringSplitOptions.RemoveEmptyEntries).Select(l => l.Trim()).ToArray();
            if (items.Length == 2)
            {
                var command = items[0];
                var pattern = items[1];

                if (string.IsNullOrEmpty(pattern) || string.IsNullOrEmpty(command))
                {
                    // Do nothing. The rule doen't have command or pattern (most likely)
                }
                else
                {
                    rule = new Rule(command, pattern);
                }
            }

            return rule;
        }

        private static IEnumerable<string> ReadRulesFile()
        {
            return File.ReadAllLines(GetRulesFilePath());
        }

        private static string GetRulesFilePath()
        {
            var thisFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = Path.Combine(thisFolder, "Rules.txt");

            return path;
        }
        #endregion
    }
}
