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
            char[] s = "as F  a sf asf fas".ToLower().Replace(" ", "").ToCharArray();
            char[] key = "F   as".ToLower().Replace(" ","").ToCharArray();
            var searcher = new AlgorithmKmp();
            Console.WriteLine("as F  a sf asf fas".IndexOf("a s"));
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
