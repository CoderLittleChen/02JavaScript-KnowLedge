using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _20保留小数
{
    class Program
    {
        static void Main(string[] args)
        {
            //保留小数的几种方法
            //1、将数值类型转成字符串类型的时候  设置ToString()的参数

            //string str = "3323.0000000000";
            //decimal value = Convert.ToDecimal(str);
            //Console.WriteLine(value.ToString("0.00"));
            //Console.WriteLine(value.ToString("0.0"));
            //Console.ReadKey();

            //string str = "本次数据\n继续 ";
            //Console.WriteLine(str);
            //Console.ReadKey();

            //string str = "001";
            //Console.WriteLine(Convert.ToInt32(str));
            //Console.ReadKey();

            //Dictionary<string, string> dic = new Dictionary<string, string>();
            //dic.Add("1", "张三");
            //dic.Add("2", "李四");
            //foreach (KeyValuePair<string,string> item in dic)
            //{
            //    Console.WriteLine(item.Key+"--"+item.Value);
            //}
            //Console.ReadKey();

            //string str = "ZC211808230005";
            //Console.WriteLine(str.Substring(0, 2));
            //Console.ReadKey();

            //DateTime dateTime1 = Convert.ToDateTime("2018-08-10 08:30");
            //DateTime dateTime2 = Convert.ToDateTime("2018-08-10 08:31");
            //double hours = (dateTime2 - dateTime1).TotalHours;
            ////实现中国式的四舍五入
            //Console.WriteLine(hours);
            //Console.WriteLine(Math.Abs(Math.Round(hours, 1, MidpointRounding.AwayFromZero)));
            //Console.ReadKey();

            //List<string> list = new List<string>();
            //list.Add("张三");
            //list.Add("李四");
            //list.Add("王五");
            //list.Add("赵六");
            //string str = string.Join(";\r\n", list.ToArray());
            //Console.WriteLine(str);
            //Console.ReadKey();

            //Console.WriteLine("dsad" +"\r\n打撒大所");

            //string str1 = "2018-09-12 15:22";
            //string str2 = Convert.ToDateTime(str1).ToString("yyyyMMdd");
            //Console.WriteLine(str2);


            //Console.WriteLine(DateTime.Now.Day);

            //int year = DateTime.Now.Year;
            //DateTime dateTime = Convert.ToDateTime((year.ToString() + "-08-01"));
            //Console.WriteLine(dateTime.ToString("yyyy-MM-dd"));

            //string str = "2018-09-06 14:49";
            //Console.WriteLine(Convert.ToDateTime(str).ToString("yyyy-MM-dd"));

            //DateTime dateTime1 = Convert.ToDateTime("2018-09-06 04:49");
            //DateTime dateTime2 = Convert.ToDateTime("2018-09-10 17:49");
            //Console.WriteLine((dateTime2 - dateTime1).TotalDays);

            //DateTime dateTime = DateTime.Now;
            //if (dateTime >= dateTime1 && dateTime <= dateTime2)
            //{
            //    Console.WriteLine(111);
            //}
            //else
            //{
            //    Console.WriteLine(22);
            //}

            //DateTime dateTime = DateTime.Now;
            //DateTime d1 = new DateTime(dateTime.Year, dateTime.Month, 1);
            //DateTime d2 = d1.AddMonths(1);
            //Console.WriteLine(d1);
            //Console.WriteLine(d2);

            //string str = "pei假（小时）";
            //int n = str.IndexOf("假");

            //Console.WriteLine(n);
            //Console.WriteLine(str.Substring(0, n + 1));


            //List<string> list = new List<string>() { "张三", "李四" }; 


            string str1 = "2018-09-09";   
            string str2 = "2018-09-12";
            DateTime dateTime1 = Convert.ToDateTime(str1);
            DateTime dateTime2 = Convert.ToDateTime(str2);
            //这种计算日期的方式    算出来是9  10  11，3天，和直接相减的结果是一致的
            int days = (dateTime2 - dateTime1).Days;
            Console.WriteLine(days);

            Console.ReadKey();

        }
    }
}
