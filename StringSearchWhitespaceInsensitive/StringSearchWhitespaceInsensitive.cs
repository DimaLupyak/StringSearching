using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSearch
{
    public class StringSearchWhitespaceInsensitive : ISearchAlgorithm
    {
        virtual protected string GetNormalized(string str)
        {
            return str.Replace(" ", "");
        }

        public ResultItem Search(string text, string pattern)
        {
            ResultItem result = null;
            string normalizedText = GetNormalized(text);
            string normalizedPatternt = GetNormalized(pattern);
            int normalizedPatternPosition = normalizedText.IndexOf(normalizedPatternt);
            int patternPosition = 0;
            int lenght = 0;
            if (normalizedPatternPosition > -1)
            {
                for (int i = 0; ;)
                {
                    if (text[patternPosition] == ' ')
                    {
                        patternPosition++;
                        continue;
                    }
                    if (i == normalizedPatternPosition) break;
                    if (text[patternPosition] != ' ') i++;
                    patternPosition++;
                }
                for (int j = 0; j < normalizedPatternt.Length; lenght++)
                {
                    if (text[patternPosition + lenght] == normalizedPatternt[j]) j++;
                }
                string value = text.Substring(patternPosition, lenght);
                result = new ResultItem(patternPosition, value);
            }
            return result;
        }

        public IEnumerable<ResultItem> SearchAll(string text, string pattern)
        {
            var result = new List<ResultItem>();
            bool finish = false;
            int lastPatternPosition = 0;
            while (!finish)
            {
                ResultItem resultItem = Search(text.Substring(lastPatternPosition), pattern);
                if (resultItem != null)
                {
                    result.Add(new ResultItem(resultItem.Index + lastPatternPosition, resultItem.Value));
                    lastPatternPosition += resultItem.Index + 1;
                }
                else
                {
                    finish = true;
                }
            }

            return result;
        }
    }
}

