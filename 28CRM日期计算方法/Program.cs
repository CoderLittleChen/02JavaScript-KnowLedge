using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _28CRM日期计算方法
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dateTime1 = Convert.ToDateTime("2018-12-17 08:30:02");
            DateTime dateTime2 = Convert.ToDateTime("2018-12-17 17:30:00");
            Console.WriteLine(dateTime2-dateTime1); 

            ////日期直接相减
            //Console.WriteLine((dateTime2 - dateTime1).TotalHours);
            ////Console.WriteLine(DateTime.Now.AddDays(-5));
            ////Console.WriteLine(DateTime.Now.Date.AddYears(-1));

            //double b = 0.50;
            //b = Math.Round(b, 1,MidpointRounding.AwayFromZero);
            //Console.WriteLine(b);

            //通过TimeOfDay来获取当前日期的时间部分           
            //Console.WriteLine(dateTime1.TimeOfDay);
            //if (2 >= 2 && 2 <= 8)
            //{
            //    Console.WriteLine(1111);
            //}
            //Console.WriteLine(DateTime.MinValue);
            //string str = null;
            //double b = 8;
            //Console.WriteLine(b.ToString("0.00"));
            //Console.WriteLine(str);

            //string str = "1";
            //Console.WriteLine(str.PadLeft(8,' '));
            //Console.Write("1111");
            //Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm"));


            //string str = "2018-01-01 00:00:00";
            //Console.WriteLine(Convert.ToDateTime(str).TimeOfDay.TotalSeconds);


            Console.ReadKey();
        }

        //public static double time(DateTime sbim, DateTime xbim)
        //{
        //    TimeSpan ts;
        //    double a = 0;
        //    //出勤时长= 下班时间 - 上班时间(减一小时午休时间)
        //    if (xbim.Hour > 12 && sbim.Hour < 12)
        //    {
        //        ts = xbim - sbim;
        //        if (ts.Minutes >= 30)
        //        { a = 0.5; }
        //        else
        //        { a = 0; }
        //        a = ts.Hours - 1 + a;
        //    }
        //    if (sbim.Hour > 12 || xbim.Hour < 12)
        //    {
        //        ts = xbim - sbim;
        //        if (ts.Minutes >= 30)
        //        { a = 0.5; }
        //        else
        //        { a = 0; }
        //        a = ts.Hours + a;
        //    }
        //    if (sbim.Hour == 12 && xbim.Hour > 12)
        //    {
        //        DateTime dsb = (sbim.ToString("yyyy-MM-dd") + " 13:00").ToDateTime(DateTime.Now).ToString("yyyy-MM-dd HH:mm").ToDateTime();
        //        ts = xbim - dsb;
        //        if (ts.Minutes >= 30)
        //        { a = 0.5; }
        //        else
        //        { a = 0; }
        //        a = ts.Hours + a;
        //    }
        //    if (sbim.Hour < 12 && xbim.Hour == 12)
        //    {
        //        DateTime xb = (xbim.ToString("yyyy-MM-dd") + " 12:00").ToDateTime(DateTime.Now).ToString("yyyy-MM-dd HH:mm").ToDateTime();
        //        ts = xb - sbim;
        //        if (ts.Minutes >= 30)
        //        { a = 0.5; }
        //        else
        //        { a = 0; }
        //        a = ts.Hours + a;
        //    }
        //    if (sbim.Hour == 12 && xbim.Hour == 12)
        //    {
        //        a = 0;
        //    }
        //    return a;
        //}
    }
}
