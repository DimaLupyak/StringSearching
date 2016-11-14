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
            var a = new AlgorithmZ();
            Console.WriteLine(a.SearchAll("a s asf fas".ToCharArray(), " as".ToCharArray()).IntArrayToString());
            Console.ReadKey();
        }

        static public string IntArrayToString(this int[] array)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var item in array)
            {
                builder.Append(item).Append("  ");
            }
            return builder.ToString();
        }
    }
}
