//namespace Enhanced.Classification.Doxygen
//{
//    using Microsoft.VisualStudio.Text;
//    using Microsoft.VisualStudio.Text.Classification;
//    using System.Collections.Generic;

//    interface IParser
//    {
//        IEnumerable<Token> Parse(string text, int start);
//    }

//    class Token
//    {
//        public string Name;
//        public string Value;
//        public int Start;
//        public int End;
//        Token Child;
//    }

//    public class DoxygenParser
//    {
//        IEnumerable<IParser> parsers;

//        public IEnumerable<Token> Parse(string text)
//        {
//            foreach (var parser in parsers)
//            {
//                var token = parser.Parse(text, 1);
//                if (token != null)
//                {
//                }
//            }
//            return null;
//        }
//    }

//    public class ParamParser
//    {
//        public IEnumerable<Token> Parse(string text, int start)
//        {
//            return null;
//        }
//    }
//}
