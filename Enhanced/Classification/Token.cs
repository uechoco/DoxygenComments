namespace Enhanced.Classification
{
    using Microsoft.VisualStudio.Text.Classification;

    internal class Token
    {
        public IClassificationType ClassificationType;
        public int Start;
        public int Length;
    }
}
