
using System;
namespace StringSearch
{
    public class ResultItem
    {
        public int Index { get; private set; }
        public string Value { get; private set; }
        public ResultItem(int index, string value)
        {
            Index = index;
            Value = value;
        }
    }
}
