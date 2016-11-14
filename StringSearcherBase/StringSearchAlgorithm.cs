using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSearch
{
    [AttributeUsage(AttributeTargets.Class)]
    public class StringSearchAlgorithmAttribute : Attribute
    {       
        public string Name { get; set; }
        public string Version { get; set; }

        public StringSearchAlgorithmAttribute(string name)
        {
            Name = name;
        }
    }
}
