using System.ComponentModel;

namespace StringSearch
{
    [Description("Returns identical strings")]
    [StringSearchAlgorithm("Identical", Version = "1.4")]
    public class StringSearchIdentical : ASearchAlgorithm
    {
        override public ResultItem Search(string text, string pattern)
        {
            ResultItem result = null;
            int patternPosition = text.IndexOf(pattern);
            if (patternPosition > -1)
            {
                result = new ResultItem(patternPosition, pattern);
            }
            return result;
        }
    }
}
