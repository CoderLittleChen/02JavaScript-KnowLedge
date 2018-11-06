using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _29反射
{
    class Program
    {
        static void Main(string[] args)
        {
            //可以通过Type类得到一个类的内部信息或者反射创建一个对象，一般有三种方式
            //1、type.typeof()  
            //2、Type.GetType()
            //3、常见的还有一种是  先拿到程序集的路径，通过程序集对象assembly.GetType()来  获得Type对象
            //然后通过Activator.CreateInstance()来创建对象实例    在通过强制转换   转换成原来的类对象

            //Type type = typeof(ClassA);
            //ClassA obj = (ClassA)Activator.CreateInstance(type);
            //Console.WriteLine(obj.Say());
            //Console.ReadKey();


            //merge   合并   
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type type = assembly.GetType();
            Console.WriteLine(assembly.FullName);


            //ClassA a = (ClassA)Activator.CreateInstance(type);
            ////Console.WriteLine(type.FullName);
            ////Console.WriteLine(a.Say());
            //foreach (Type item in type)
            //{

            //}

            //Console.WriteLine(type.c);
            Console.ReadKey();



        }
        public static void Say()
        {
            Console.WriteLine("你会玩个锤子");
        }
    }
}
