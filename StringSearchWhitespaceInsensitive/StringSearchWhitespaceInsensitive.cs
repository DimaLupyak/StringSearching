using System.ComponentModel;

namespace StringSearch
{
    [Description("Returns similar strings. Whitespaces insensitive")]
    [StringSearchAlgorithm("Whitespaces insensitive", Version = "1.2")]
    public class StringSearchWhitespaceInsensitive : ASearchAlgorithm
    {
        protected override string GetNormalized(string str)
        {
            return str.Replace(Ignore, "");
        }

        protected override string Ignore
        {
            get { return " "; }
        }
    }
}

