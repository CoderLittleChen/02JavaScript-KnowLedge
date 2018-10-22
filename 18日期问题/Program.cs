using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18日期问题
{
    class Program
    {
        static void Main(string[] args)
        {
            //string date = DateTime.Now.ToString("yyyy-MM-dd");
            //Console.WriteLine(date);
            //Console.WriteLine(DateTime.MinValue);
            //Console.ReadKey();

            //List<string> list = new List<string>();
            //list.Add("1111");
            //list.Add("2222");
            //list.Add("3333");
            //list.Add("5555");
            //list.Add("4444");
            //list.Add("6666");
            //string[] s = new string[4];

            //Console.WriteLine(list.ToString());
            //Console.ReadKey();

            //string str = "2018-01-30  08:30";
            //DateTime dateTime = Convert.ToDateTime(str).AddMonths(1);
            //Console.WriteLine(dateTime.ToString());
            //Console.ReadKey();


            //string[] arr = new string[3];
            //arr[0] = "张三";
            //arr[1] = "李四";
            //arr[2] = "王五";
            //string result = string.Join(",",arr);
            //Console.WriteLine(result);
            //Console.ReadKey();

            //DateTime dateTime1 = new DateTime(2018, 08, 16, 10, 30, 20);
            //DateTime dateTime2 = new DateTime(2018, 08, 22, 13, 30, 20);
            //int hours = (dateTime2 - dateTime1).Hours;
            ////double hours = (dateTime2 - dateTime1).TotalHours;
            //Console.WriteLine(hours);
            //Console.ReadKey();

            //DateTime dateTime = DateTime.Now;
            //Console.WriteLine(dateTime.Month);
            //Console.ReadKey();
            //Console.WriteLine("dsad".Substring(0, 2));

            //string str1 = "2018-10-08 11:30";
            //string str2 = "2018-10-08 12:00";
            //DateTime dateTime1 = Convert.ToDateTime(str1);
            //DateTime dateTime2 = Convert.ToDateTime(str2);
            ////double hours = (dateTime2 - dateTime1).TotalHours;
            //double hours = 0.19;
            //hours = Math.Round(hours, 1, MidpointRounding.AwayFromZero);
            //Console.WriteLine(hours);

            //DateTime dateTime = Convert.ToDateTime("2018-10-10 10:49");
            ////这里小时的表示字符  HH  24小时   hh   12小时
            //Console.WriteLine(FormateDateFloor(dateTime).ToString("yyyy-MM-dd HH:mm"));
            //Console.WriteLine(FormatDateCeiling(dateTime).ToString("yyyy-MM-dd HH:mm"));
            //Console.ReadKey();


            //DateTime dateTime = DateTime.Now;
            //DateTime endDate = dateTime.AddDays(1 - dateTime.Day).AddMonths(1).AddDays(-1);
            
            //
            DateTime dateTime1 = Convert.ToDateTime("2018-10-10");
            DateTime dateTime2 = Convert.ToDateTime("2018-10-15");
            for (int i = 0; i < (dateTime2 - dateTime1).Days + 1; i++)
            {
                Console.WriteLine(dateTime1.AddDays(i));
            }
            Console.WriteLine((dateTime2 - dateTime1).Days);
            Console.ReadKey();

        }



        /// <summary>
        /// 格式化日期  分钟数向下取整      10:09  → 10:00
        /// </summary>
        /// <param name="dateTime">日期参数</param>
        /// <returns></returns>
        public static DateTime FormateDateFloor(DateTime dateTime)
        {
            //2018-10-10  10:09     
            int min = dateTime.Minute;
            if (min != 30 && min != 0)
            {
                if (min > 0 && min < 30)
                {
                    dateTime = dateTime.AddMinutes(-min);
                }
                else
                {
                    dateTime = dateTime.AddMinutes(-min).AddMinutes(30);
                }
            }
            return dateTime;

        }

        /// <summary>
        /// 格式化日期  分钟数向上取整       10:09   →   10:30
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime FormatDateCeiling(DateTime dateTime)
        {
            int min = dateTime.Minute;
            if (min != 30 && min != 0)
            {
                if (min > 0 && min < 30)
                {
                    dateTime = dateTime.AddMinutes(-min).AddMinutes(30);
                }
                else
                {
                    dateTime = dateTime.AddMinutes(-min).AddHours(1);
                }
            }
            return dateTime;
        }


    }
}
