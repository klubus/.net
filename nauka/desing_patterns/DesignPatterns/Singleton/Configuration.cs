using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class Configuration
    {
        private static Configuration _instance = null;
        public string StringProperty;
        public int IntProperty;
        private static object obj = new object();

        private Configuration()
        {
        }

        public static Configuration GetInstance()
        {
            // lock helps working on multiple threads
            lock (obj)
            {
                if (_instance == null)
                {
                    _instance = new Configuration();
                }
            }

            return _instance;
        }

    };
}
