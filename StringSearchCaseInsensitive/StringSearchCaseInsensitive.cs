using System.ComponentModel;

namespace StringSearch
{
    [Description("Returns similar strings. Case insensitive")]
    [StringSearchAlgorithm("Case insensitive", Version = "1.3")]
    public class StringSearchCaseInsensitive : ASearchAlgorithm
    {
        protected override string GetNormalized(string str)
        {
            return str.ToLower();
        }
    }
}

