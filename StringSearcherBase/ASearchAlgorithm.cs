using System;
using System.Collections.Generic;
using System.Linq;

namespace StringSearch
{
    public abstract class ASearchAlgorithm : ISearchAlgorithm
    {
        virtual protected string Ignore 
        { 
            get 
            { 
                return String.Empty; 
            } 
        }

        virtual protected string GetNormalized(string str)
        {
            return str;
        }
        
        virtual public ResultItem Search(string text, string pattern)
        {
            ResultItem result = null;
            string ignore = Ignore;
            string normalizedText = GetNormalized(text);
            string normalizedPatternt = GetNormalized(pattern);
            int normalizedPatternPosition = normalizedText.IndexOf(normalizedPatternt);
            int patternPosition = 0;
            int lenght = 0;
            if (normalizedPatternPosition > -1)
            {
                for (int i = 0; ; )
                {
                    if (ignore.Contains(text[patternPosition]))
                    {
                        patternPosition++;
                        continue;
                    }
                    if (i == normalizedPatternPosition) break;
                    if (!ignore.Contains(text[patternPosition])) i++;
                    patternPosition++;
                }
                for (int j = 0; j < normalizedPatternt.Length; lenght++)
                {
                    if (text.ToLower()[patternPosition + lenght] == normalizedPatternt.ToLower()[j]) j++;
                }
                string value = text.Substring(patternPosition, lenght);
                result = new ResultItem(patternPosition, value);
            }
            return result;
        }

        virtual public IEnumerable<ResultItem> SearchAll(string text, string pattern)
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
