using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _34double数据类型
{
    class Program
    {
        static void Main(string[] args)
        {
            //double b = 7.99999;
            ////保留两位小数
            //Console.WriteLine(Math.Round(b,2));
            //Console.ReadKey();

            //这里5是字符串长度，不够长用空格补齐，正值代表右对齐，负值表示左对齐  
            //string str = string.Format("{0,5}",111);
            //Console.WriteLine(str);
            //Console.ReadKey();

            int n = 0;
            Test(out n);
            Console.WriteLine(n);
            Console.ReadKey();

        }
        static void Test(out int n)
        {
            n = 10;
        }
    }
}
