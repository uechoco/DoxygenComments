namespace Enhanced.Classification
{
    using System;

    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    sealed class ParserAttribute : Attribute
    {
        private readonly string formatName;

        public ParserAttribute(string formatName)
        {
            this.formatName = formatName;
        }

        public string FormatName
        {
            get { return this.formatName; }
        }
    }
}
