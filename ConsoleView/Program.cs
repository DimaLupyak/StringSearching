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
            string pattern = "1a2";
            foreach (var searcher in SearchAlgorithmsManager.Instance.GetAll())
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("{0,-60}{1, 20}", searcher.Name, "(v." + searcher.Version + ")");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("- {0,-80}", searcher.Description);
                WriteResult(searcher.Algorithm.SearchAll(text, pattern));
            }
            Console.ReadKey();
        }

        static void WriteResult(ResultItem result)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (result != null) Console.WriteLine("{0}: {1}", result.Index, result.Value);
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void WriteResult(IEnumerable<ResultItem> results)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (results.GetEnumerator().MoveNext() == false)
            {
                Console.WriteLine("Not found");
            }
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var result in results)
            {
                WriteResult(result);
            }
        }
    }
}
