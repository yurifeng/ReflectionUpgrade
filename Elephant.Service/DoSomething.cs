using Elephant.Interface;
using System;

namespace Elephant.Service
{
   
    public class DoSomething : IDoSomething
    {
        #region 构造函数
        public DoSomething()
        {
            
        }

        public DoSomething(int x, int y)
        {
            Console.WriteLine("这里是Elephant.Service.DoSomething 构造函数 x+y={0}", x + y);
        }

        public DoSomething(string a, string b)
        {
            Console.WriteLine("这里是Elephant.Service.DoSomething 构造函数 a={0}  b={1}", a, b);
        }
        #endregion 构造函数

        public void Show(string name)
        {
            Console.WriteLine("这里是Elephant.Service.ShowSomething name={0}", name);
        }

        public void ShowSomething()
        {
            Console.WriteLine("这里是Elephant.Service.ShowSomething text={0}", "无参数");
        }

        public void ShowSomething(string text)
        {
            Console.WriteLine("这里是Elephant.Service.ShowSomething text={0}", text);
        }

        public void ShowSomething(int num)
        {
            Console.WriteLine("这里是Elephant.Service.ShowSomething num={0}", num);
        }

        public void ShowSomething(int x, int y)
        {
            Console.WriteLine("这里是Elephant.Service.ShowSomething x={0} y={1}", x, y);
        }

        private void ShowPrivate(string text)
        {
            Console.WriteLine("这里是Elephant.Service.ShowSomething text={0}", text);
        }


        public string Name { get; set; }
        public string Remark { get; set; }


    }
}
