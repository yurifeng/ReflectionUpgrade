using Elephant.Service;


using Elephant.Interface;
using System;
using System.Diagnostics;
using System.Reflection;

namespace MyReflection
{
    /// <summary>
    /// 1 dll-IL-metadata-反射
    /// 2 反射加载dll，读取module、类、方法、特性
    /// 3 反射创建对象，反射+简单工厂+配置文件  选修：破坏单例 创建泛型
    /// 4 反射调用方法，选修:调用私有方法
    /// 5 反射属性赋值
    /// 6 反射的好处和局限
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            {
                

                #region 常规方式
                //DoSomething doSomething = new DoSomething();
                //doSomething.Name = "樂活當下";
                //doSomething.Remark = "vip学员";
                //doSomething.ShowSomething(3, 4);
                #endregion 常规方式

                #region 反射加载dll

                //1 加载dll
                //根据dll的名称去动态加载  加载默认为当前exe的路径
                //<1>性能最好
                Assembly assembly = Assembly.Load("Elephant.Service");

                //<2>先滤清依赖,再调用Load(比Load性能差一点点)
                //Assembly assembly1 = Assembly.LoadFrom("Elephant.Service.dll");//根据dll的路径去动态加载  加载默认为当前exe的路径 
                //Assembly assembly2 = Assembly.LoadFrom(@"E:\online6\20160623Advanced6Course2Reflection\MyReflection\Elephant.Service\bin\Debug\Elephant.Service.dll"); // 或者可以是完整路径

                //<3>不管依赖,直接引用(运行时可能有问题)
                //Assembly assembly4 = Assembly.LoadFile(@"E:\online6\20160623Advanced6Course2Reflection\MyReflection\Elephant.Service\bin\Debug\Elephant.Service.dll"); // 一定要是绝对路径

                Console.WriteLine("*****************************************");

                //加载所有的Assembly里面的模块
                foreach (Module module in assembly.GetModules())
                {
                    Console.WriteLine("{0}", module.Name);
                }

                Console.WriteLine("*****************************************");

                //加载Assembly里面所有的类型
                foreach (Type type in assembly.GetTypes())
                {
                    Console.WriteLine("{0}", type.Name);
                }

                #endregion 反射加载dll

                #region 反射创建对象

                //2 根据完整名称(namespace+class)  获取指定类型
                Type typeDoSomething = assembly.GetType("Elephant.Service.DoSomething");
                Console.WriteLine("*****************************************");

                foreach (ConstructorInfo construct in typeDoSomething.GetConstructors())
                {
                    Console.WriteLine("{0}", construct.ToString());
                }

                //3 创建对象，实例化，默认调用无参构造函数
                object objectDoSomething = Activator.CreateInstance(typeDoSomething);


                //typeDoSomething.ShowSomething("haha");

                //object objectDoSomething1 = Activator.CreateInstance(typeDoSomething, new object[] { 3, 4 });
                //object objectDoSomething2 = Activator.CreateInstance(typeDoSomething, new object[] { "╰つ Ｈ ♥. 花心胡萝卜", "翻滚吧，甲鱼牛宝宝(58-随风逍遥-男)" });
                //object objectDoSomething3 = Activator.CreateInstance(typeDoSomething, new object[] { 3, "♡木云得" });//会报错

                //接口=(接口)实例
                IDoSomething iDoSomething = (IDoSomething)objectDoSomething;
                iDoSomething.ShowSomething("fireboy(89-duboy-男)");

                #region 接口 = 简单工厂.创建对象

                Console.WriteLine("*************CreateObjectExtend********************");
                IDoSomething doSomethingExtend = ObjectFactory.CreateObjectExtend();
                doSomethingExtend.ShowSomething("风雨同舟");

                #endregion


                //破坏单例
                //Type typeSingleton = assembly.GetType("Elephant.Service.Singleton");
                //object objectSingleton1 = Activator.CreateInstance(typeSingleton,true);
                //object objectSingleton2 = Activator.CreateInstance(typeSingleton, true);
                //object objectSingleton3= Activator.CreateInstance(typeSingleton, true);
                //object objectSingleton4= Activator.CreateInstance(typeSingleton, true);

                //泛型实例
                //Type typeGenericClass = assembly.GetType("Elephant.Service.GenericClass`1");
                //typeGenericClass=typeGenericClass.MakeGenericType(new Type[] { typeDoSomething });
                //object objectGenericClass = Activator.CreateInstance(typeGenericClass);

                #endregion 反射创建对象



                #region 反射调用方法

                //4 找到方法
                //typeDoSomething已经是对象的实例,调用GetMethod("方法名")方法,得到MethodInfo
                MethodInfo show = typeDoSomething.GetMethod("Show");

                //5 调用方法
                //方法开始调用了,invoke(实例,参数)
                show?.Invoke(objectDoSomething, new object[] { "AQ" });

                //重载方法的调用
                {
                    MethodInfo method = typeDoSomething.GetMethod("ShowSomething", new Type[] { });
                    method.Invoke(objectDoSomething, null);
                }
                {
                    MethodInfo method = typeDoSomething.GetMethod("ShowSomething", new Type[] { typeof(string) });
                    method.Invoke(objectDoSomething, new object[] { "凯瑞" });
                }
                {
                    MethodInfo method = typeDoSomething.GetMethod("ShowSomething", new Type[] { typeof(int) });
                    method.Invoke(objectDoSomething, new object[] { 11 });
                }
                //突破private限制
                {
                    MethodInfo method = typeDoSomething.GetMethod("ShowPrivate", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                    method.Invoke(objectDoSomething, new object[] { "唰中国" });
                }

                #endregion 反射调用方法



                #region 反射设置属性
                Console.WriteLine("*****************************************");
                foreach (PropertyInfo propertyInfo in typeDoSomething.GetProperties())
                {
                    Console.WriteLine("{0}", propertyInfo.Name);
                    propertyInfo.SetValue(objectDoSomething, "电脑");
                }
                #endregion 反射设置属性
            }


            #region 测试性能
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                Assembly assembly = Assembly.Load("Elephant.Service");
                Type typeDoSomething = assembly.GetType("Elephant.Service.DoSomething");
                object objectDoSomething = Activator.CreateInstance(typeDoSomething);
                for (int i = 0; i < 100000; i++)
                {

                    foreach (PropertyInfo propertyInfo in typeDoSomething.GetProperties())
                    {
                        propertyInfo.SetValue(objectDoSomething, "电脑");
                    }
                }
                stopwatch.Stop();
                Console.WriteLine("反射{0}ms", stopwatch.ElapsedMilliseconds);
            }

            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                for (int i = 0; i < 100000; i++)
                {
                    DoSomething doSomething = new DoSomething();
                    doSomething.Name = "樂活當下";
                    doSomething.Remark = "vip学员";
                }
                stopwatch.Stop();
                Console.WriteLine("常规{0}ms", stopwatch.ElapsedMilliseconds);
            }
            #endregion 测试性能


            Console.ReadLine();
        }
    }
}
