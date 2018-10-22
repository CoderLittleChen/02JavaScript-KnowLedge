using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15字符串转日期
{
    class Program
    {
        static void Main(string[] args)
        {
            string days = "1900/1/1 0:00:00";
            int year = Convert.ToDateTime(days).Year;
            Console.WriteLine(year);
            Console.ReadKey();
        }
    }
}
