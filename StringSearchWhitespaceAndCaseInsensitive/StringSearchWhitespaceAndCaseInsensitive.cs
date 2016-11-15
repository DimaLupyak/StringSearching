using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSearch
{
    public class StringSearchWhitespaceAndCaseInsensitive : StringSearchWhitespaceInsensitive
    {
        override protected string GetNormalized(string str)
        {
            return str.ToLower().Replace(" ", "");
        }
    }
}

