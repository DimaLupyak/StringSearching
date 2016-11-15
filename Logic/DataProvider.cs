using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public static class DataProvider
    {
        static public string GetStringFromFile(string path)
        {
            string text;
            try
            {
                StreamReader streamReader = new StreamReader(path);
                text = streamReader.ReadToEnd();                
            }
            catch (Exception e)
            {
                text = "" + e.Message;
            }
            return text;
        }
    }
}
