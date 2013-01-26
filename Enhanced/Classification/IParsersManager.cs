namespace Enhanced.Classification
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal interface IParsersManager
    {
        IEnumerable<string> GetNames();
        IParser GetParser(string name);
    }
}
