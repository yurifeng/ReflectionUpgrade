using Elephant.Interface;
using System;
using System.Configuration;
using System.Reflection;

namespace MyReflection
{
    public class ObjectFactory
    {
        private static string ClassName = ConfigurationManager.AppSettings["ClassName"];
        private static string DllName = ConfigurationManager.AppSettings["DllName"];

        //可配置
        public static IDoSomething CreateObjectExtend()
        {
            Assembly assembly = Assembly.Load(DllName);
            Type typeSome = assembly.GetType(ClassName);
            object oObject = Activator.CreateInstance(typeSome);
            return (IDoSomething)oObject;
        }
    }
}
