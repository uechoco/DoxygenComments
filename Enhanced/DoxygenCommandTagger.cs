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
    using Enhanced.ClassificationFormats;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Tagging;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

    public sealed class DoxygenCommandTagger : ITagger<DoxygenCommandTag>, IDisposable
    {
        private readonly ITextBuffer textBuffer;
        private readonly Doxygen doxygen;
        private readonly ITagAggregator<DoxygenCommentTag> doxygenCommentsAggregator;
        private readonly IEnumerable<Rule> rules;

        public DoxygenCommandTagger(ITextBuffer textBuffer, ITagAggregator<DoxygenCommentTag> doxygenCommentsAggregator)
        {
            this.textBuffer = textBuffer;
            this.doxygen = new Doxygen();
            this.doxygenCommentsAggregator = doxygenCommentsAggregator;
            this.rules = Rule.GetRules();
        }

        public IEnumerable<ITagSpan<DoxygenCommandTag>> GetTags(NormalizedSnapshotSpanCollection spans)
        {
            if (spans.Count == 0)
                yield break;

            var snapshot = spans[0].Snapshot;

            foreach (var doxygenComment in this.doxygenCommentsAggregator.GetTags(spans))
            {
                var doxygenCommentSpans = doxygenComment.Span.GetSpans(snapshot);
                if (doxygenCommentSpans.Count != 1)
                {
                    continue;
                }
                else
                {
                    var doxygenCommentSpan = doxygenCommentSpans[0];
                    var text = snapshot.GetText(doxygenCommentSpan);
                    var spanStart = doxygenCommentSpan.Start;

                    foreach (var rule in this.rules)
                    {
                        var match = rule.Regex.Match(text, 0);
                        while (match.Success)
                        {
                            var group = match.Groups[DoxygenCommandGroup];
                            if (group.Success)
                            {
                                yield return new TagSpan<DoxygenCommandTag>(new SnapshotSpan(spanStart + group.Index, group.Length), new DoxygenCommandTag(DoxygenClassificationFormat.Command));
                            }

                            group = match.Groups[DoxygenArgOneGroup];
                            if (group.Success)
                            {
                                yield return new TagSpan<DoxygenCommandTag>(new SnapshotSpan(spanStart + group.Index, group.Length), new DoxygenCommandTag(DoxygenClassificationFormat.ArgOne));
                            }

                            group = match.Groups[DoxygenArgTwoGroup];
                            if (group.Success)
                            {
                                yield return new TagSpan<DoxygenCommandTag>(new SnapshotSpan(spanStart + group.Index, group.Length), new DoxygenCommandTag(DoxygenClassificationFormat.ArgTwo));
                            }

                            group = match.Groups[DoxygenArgThreeGroup];
                            if (group.Success)
                            {
                                yield return new TagSpan<DoxygenCommandTag>(new SnapshotSpan(spanStart + group.Index, group.Length), new DoxygenCommandTag(DoxygenClassificationFormat.ArgThree));
                            }

                            match = rule.Regex.Match(text, match.Index + match.Length);
                        }
                    }
                }
            }
        }

        public event EventHandler<SnapshotSpanEventArgs> TagsChanged;

        public void Dispose()
        {
            this.doxygenCommentsAggregator.Dispose();
            GC.SuppressFinalize(this);
        }

        private const string DoxygenCommandGroup = "DoxygenCommand";
        private const string DoxygenArgOneGroup = "DoxygenCommandArgOne";
        private const string DoxygenArgTwoGroup = "DoxygenCommandArgTwo";
        private const string DoxygenArgThreeGroup = "DoxygenCommandArgThree";

        private static DoxygenClassificationFormat GetFormat(string name)
        {
            switch (name)
            {
                case DoxygenCommandGroup:
                    return DoxygenClassificationFormat.Command;
                case DoxygenArgOneGroup:
                    return DoxygenClassificationFormat.ArgOne;
                case DoxygenArgTwoGroup:
                    return DoxygenClassificationFormat.ArgTwo;
                case DoxygenArgThreeGroup:
                    return DoxygenClassificationFormat.ArgThree;
                default:
                    throw new InvalidOperationException("Provided match group is unknown");
            }
        }
    }
}
