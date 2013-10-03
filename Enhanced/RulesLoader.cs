/**
 * Copyright (c) 2013 Alexander Manenko
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

    public static class RulesLoader
    {
        public static IDictionary<string, Regex> LoadRules()
        {
            var thisFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = Path.Combine(thisFolder, "Rules.txt");
            var lines = File.ReadAllLines(path);
            var dictionary = new Dictionary<string, Regex>(168);

            foreach (var line in lines)
            {
                var items = line.Split(new[] { '`' }, StringSplitOptions.RemoveEmptyEntries).Select(l => l.Trim()).ToArray();
                if (items.Length == 2)
                {
                    var command = items[0];
                    var pattern = items[1];

                    if (string.IsNullOrEmpty(pattern) || string.IsNullOrEmpty(command))
                    {
                        continue;
                    }

                    var regex = new Regex(pattern);
                    dictionary.Add(command, regex);
                }
            }

            return dictionary;
        }
    }
}
