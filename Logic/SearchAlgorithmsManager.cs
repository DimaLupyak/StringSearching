using StringSearch;
using System;
using System.Collections.Generic;
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
        private Dictionary<string, ISearchAlgorithm> algorithms;     
        
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
            algorithms = new Dictionary<string, ISearchAlgorithm>();
            
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
                        ISearchAlgorithm iSearchAlgorithm = assembly.CreateInstance(algorithmType.FullName, true) as ISearchAlgorithm;
                        string algorithmName = (algorithmType.GetCustomAttribute(typeof(StringSearchAlgorithmAttribute)) as StringSearchAlgorithmAttribute).Name;
                        algorithms.Add(algorithmName, iSearchAlgorithm);
                    }
                }
              
        }

        public IEnumerable<ISearchAlgorithm> GetAll()
        {
            return algorithms.Values;
        }

        public IEnumerable<string> GetNames()
        {
            return algorithms.Keys;
        }

        public ISearchAlgorithm Get(string name)
        {
            return algorithms.Keys.Contains(name) ? algorithms[name] : null;
        }
    }
}
