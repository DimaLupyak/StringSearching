using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSearch
{
    public class StringSearchCaseInsensitive : ISearchAlgorithm
    {
        public ResultItem Search(string text, string pattern)
        {
            ResultItem result = null;
            int patternPosition = text.ToLower().IndexOf(pattern.ToLower());
            if(patternPosition > -1)
            {
                string value = text.Substring(patternPosition, pattern.Length);
                result = new ResultItem(patternPosition, value);
            }
            return result;
        }

        public IEnumerable<ResultItem> SearchAll(string text, string pattern)
        {
            var result = new List<ResultItem>();
            int lastPatternPosition = 0;
            while (lastPatternPosition != -1)
            {
                lastPatternPosition = text.ToLower().IndexOf(pattern.ToLower(), lastPatternPosition);
                if(lastPatternPosition!= -1)
                {
                    string value = text.Substring(lastPatternPosition, pattern.Length);
                    result.Add(new ResultItem(lastPatternPosition, value));
                    lastPatternPosition++;
                }
            }
            return result;
        }
    }
}

