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
            DateTime dateTime1 = Convert.ToDateTime("2018-09-26 08:17");
            DateTime dateTime2 = Convert.ToDateTime("2018-09-26 19:40");
            //日期直接相减
            Console.WriteLine(dateTime2 - dateTime1);
            //Console.WriteLine(DateTime.Now.AddDays(-5));

            //Console.WriteLine(DateTime.Now.Date.AddYears(-1));

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
