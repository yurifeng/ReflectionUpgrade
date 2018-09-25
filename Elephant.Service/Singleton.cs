using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elephant.Service
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class Singleton
    {
        private Singleton()
        {
            Console.WriteLine("初始化一次");
        }

        private static Singleton Instance = new Singleton();

        public static Singleton CreateInstance()
        {
            return Instance;
        }
    }
}
