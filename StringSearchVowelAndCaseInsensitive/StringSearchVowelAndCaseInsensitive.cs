using System.ComponentModel;

namespace StringSearch
{
    [Description("Returns similar strings. Vowel laters and Case insensitive")]
    [StringSearchAlgorithm("Vowel and Case insensitive", Version = "1.1")]
    public class StringSearchVowelAndCaseInsensitive : ASearchAlgorithm
    {
        override protected string GetNormalized(string str)
        {
            str = str.ToLower();
            foreach (var ch in Ignore)
            {
                str = str.Replace(ch.ToString(), "");
            }
            return str;
        }

        protected override string Ignore
        {
            get { return "aeiouy"; }
        }
    }
}

