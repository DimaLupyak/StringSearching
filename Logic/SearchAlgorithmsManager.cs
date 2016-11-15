using StringSearch;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Logic
{
    public class SearchAlgorithmsManager
    {
        private List<SearchAlgorithmItem> algorithms;     
        
        #region Singleton

        private static readonly Object lockObject = new Object();
        private static SearchAlgorithmsManager instance = null;    

        public static SearchAlgorithmsManager Instance
        {
            get
            {
                if (instance != null) return instance;
                Monitor.Enter(lockObject);
                SearchAlgorithmsManager temp = new SearchAlgorithmsManager();
                Interlocked.Exchange(ref instance, temp);
                Monitor.Exit(lockObject);
                return instance;
            }
        }
        #endregion

        private SearchAlgorithmsManager()
        {
            algorithms = new List<SearchAlgorithmItem>();
            
                string[] dllFileNames = null;
                if (Directory.Exists(@"Plugins"))
                {
                    dllFileNames = Directory.GetFiles(@"Plugins", "*.dll");
                }
                foreach (string dllFile in dllFileNames)
                {
                    Assembly assembly = Assembly.LoadFrom(dllFile);
                    var algorithmTypes = assembly.GetTypes().Where(x => x.GetCustomAttribute(typeof(StringSearchAlgorithmAttribute)) != null);

                    foreach (Type algorithmType in algorithmTypes)
                    {
                        SearchAlgorithmItem newItem = new SearchAlgorithmItem();
                        var attribure = algorithmType.GetCustomAttribute(typeof(StringSearchAlgorithmAttribute)) as StringSearchAlgorithmAttribute;
                        var descriptionAttribure = algorithmType.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;
                        newItem.Algorithm = assembly.CreateInstance(algorithmType.FullName, true) as ISearchAlgorithm;
                        newItem.Name = attribure.Name;
                        newItem.Version = attribure.Version;
                        newItem.Description = descriptionAttribure.Description;
                        algorithms.Add(newItem);
                    }
                }
              
        }

        public List<SearchAlgorithmItem> GetAll()
        {
            return algorithms;
        }
    }
}
