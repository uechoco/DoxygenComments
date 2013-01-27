namespace Enhanced.Classification
{
    using System;

    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    internal sealed class PatternAttribute : Attribute
    {
        private readonly string pattern;

        public PatternAttribute(string pattern)
        {
            this.pattern = pattern;
        }

        public string Pattern
        {
            get { return this.pattern; }
        }
    }
}
