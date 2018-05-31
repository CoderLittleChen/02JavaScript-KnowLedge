using _14类库;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _13反射加载程序集_创建实例
{
    class Program
    {
        static void Main(string[] args)
        {
            //这里Load()方法首先会全局程序集缓存查找，然后到应用的跟目录查找，最后会到
            //应用程序的私有路径查找

            //程序集名称即dll名称

            //这种直接加载一直到程序运行结束都会占用dll文件，在此期间不能够对dll文件
            //进行升级，或者修改
            //Assembly assembly = Assembly.Load("程序集");  
            //Assembly assembly = Assembly.LoadFile("指定物理路径来加载");

            //不占用文件的方式
            //首先把dll加载到内存中，然后在加载成Assembly,这样的话，只要加载完成，即使dll被删除，程序也会照样运行
            //Assembly assembly = Assembly.Load(File.ReadAllBytes("path"));

            //这里LoadFrom可以通过文件名或路径两种方式来加载，而LoadFile只能通过文件路径来加载
            //Assembly assembly = Assembly.LoadFrom("");

            //注意这里加载类库  名称要把dll文件去掉 否则会找不到
            Assembly assembly = Assembly.Load("14类库");
            if (assembly != null)
            {
                object obj = assembly.CreateInstance("_14类库.Test");
                Test test = obj as Test;
                Console.WriteLine(test.Id);

                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("False");
            }
            Console.ReadKey();

        }
    }
}
