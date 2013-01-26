namespace Enhanced.Classification
{
    using System.Collections.Generic;

    internal interface IParser
    {
        int Parse(string text, int start, IList<Token> tokens);
    }
}
