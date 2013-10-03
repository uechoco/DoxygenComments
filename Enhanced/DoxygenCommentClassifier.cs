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
    using Microsoft.VisualStudio.Text;
    using Microsoft.VisualStudio.Text.Classification;
    using Microsoft.VisualStudio.Text.Tagging;
    using System;
    using System.Collections.Generic;

    public sealed class DoxygenCommentClassifier : ITagger<ClassificationTag>
    {
        #region Fields
        private readonly ITextBuffer buffer;
        private readonly IClassificationType commentClassification;
        private readonly ITagAggregator<DoxygenCommentTag> tagAggregator; 
        #endregion

        #region Constructors
        public DoxygenCommentClassifier(ITextBuffer buffer, ITagAggregator<DoxygenCommentTag> tagAggregator, IClassificationTypeRegistryService typeService)
        {
            this.buffer = buffer;
            this.commentClassification = typeService.GetClassificationType(Enhanced.ClassificationFormats.Names.DoxygenComment);
            this.tagAggregator = tagAggregator;
        } 
        #endregion

        #region Methods
        public IEnumerable<ITagSpan<ClassificationTag>> GetTags(NormalizedSnapshotSpanCollection spans)
        {
            foreach (var tagSpan in this.tagAggregator.GetTags(spans))
            {
                var tagSpans = tagSpan.Span.GetSpans(spans[0].Snapshot);
                yield return
                    new TagSpan<ClassificationTag>(tagSpans[0],
                                                   new ClassificationTag(this.commentClassification));
            }
        } 
        #endregion

        #region Events
        public event EventHandler<SnapshotSpanEventArgs> TagsChanged; 
        #endregion
    }
}
