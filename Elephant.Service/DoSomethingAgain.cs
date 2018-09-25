using Elephant.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elephant.Service
{
    
    public class DoSomethingAgain : IDoSomething
    {
        public DoSomethingAgain()
        {
            Console.WriteLine("这里是Elephant.Service.DoSomethingAgain 无参构造 ");
        }

        public DoSomethingAgain(int x, int y)
        {
            Console.WriteLine("这里是Elephant.Service.DoSomethingAgain 构造函数 x+y={0}", x + y);
        }

        public DoSomethingAgain(string a, string b)
        {
            Console.WriteLine("这里是Elephant.Service.DoSomethingAgain 构造函数 a={0}  b={1}", a, b);
        }

        public void ShowSomething(string text)
        {
            Console.WriteLine("这里是Elephant.Service.DoSomethingAgain.ShowSomething text={0}", text);
        }


        public string Name { get; set; }
        public string Remark { get; set; }


    }
}
