using StringSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleView
{
    static class Program
    {
        static void Main(string[] args)
        {
            string text = "    1a    21   212";
            string pattern = "1 A 2";
            ISearchAlgorithm searcher = new StringSearchWhitespaceAndCaseInsensitive();
            WriteResult(searcher.SearchAll(text, pattern));
            Console.ReadKey();
        }

        static void WriteResult(ResultItem result)
        {
            if (result != null) Console.WriteLine("{0}: {1}", result.Index, result.Value);
        }
        static void WriteResult(IEnumerable<ResultItem> results)
        {
            foreach (var result in results)
            {
                WriteResult(result);
            }
        }
    }
}
