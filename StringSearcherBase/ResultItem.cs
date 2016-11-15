using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSearch
{
    public class ResultItem
    {
        public readonly int Index;
        public readonly string Value;
        public ResultItem(int index, string value)
        {
            Index = index;
            Value = value;
        }
    }
}
