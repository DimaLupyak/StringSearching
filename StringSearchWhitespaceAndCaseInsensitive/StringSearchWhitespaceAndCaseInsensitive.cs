using System.ComponentModel;

namespace StringSearch
{
    [Description("Returns similar strings. Whitespaces and Case insensitive")]
    [StringSearchAlgorithm("Whitespaces and Case insensitive", Version = "1.2")]
    public class StringSearchWhitespaceAndCaseInsensitive : ASearchAlgorithm
    {
        override protected string GetNormalized(string str)
        {
            return str.ToLower().Replace(Ignore, "");
        }

        protected override string Ignore
        {
            get { return " "; }
        }
    }
}

