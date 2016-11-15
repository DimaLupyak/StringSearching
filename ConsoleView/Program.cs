using Logic;
using StringSearch;
using System;
using System.Collections.Generic;

namespace ConsoleView
{
    static class Program
    {
        static void Main(string[] args)
        {
            string text = "1aeee2 1A2 1  a 2  1  A2";
            string pattern = "1y2";
            foreach (var searcher in SearchAlgorithmsManager.Instance.GetAll())
            {
                Console.WriteLine("Type: " + searcher.GetType());
                WriteResult(searcher.SearchAll(text, pattern));
            }
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
