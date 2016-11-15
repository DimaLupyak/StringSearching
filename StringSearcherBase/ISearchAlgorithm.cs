using System.Collections.Generic;
namespace StringSearch
{
    public interface ISearchAlgorithm
    {
        ResultItem Search(string text, string pattern);

        IEnumerable<ResultItem> SearchAll(string text, string pattern);
    }
}
