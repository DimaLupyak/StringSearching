using System;

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
