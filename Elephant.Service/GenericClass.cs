using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elephant.Service
{
    public class GenericClass<T>
    {
        public GenericClass()
        {
            Console.WriteLine("GenericClass被构造,T={0}", typeof(T).FullName);
        }

        public void DoNothing()
        {

        }
    }
}
