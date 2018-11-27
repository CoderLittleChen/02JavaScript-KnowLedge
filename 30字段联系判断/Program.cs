using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30字段联系判断
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] nums = { 1, 3, 41, 5, 6, 7, 9, 12 };
            //int count = 0;
            //for (int i = 0; i < nums.Length - 1; i++)
            //{
            //    if (nums[i + 1] - nums[i] == 1)
            //    {
            //        count++;
            //    }
            //}
            //if (count >= 3)
            //{
            //    Console.WriteLine("存在3个或3个以上的连续数字");
            //}
            //else
            //{
            //    Console.WriteLine("连续数字不超过3个");
            //}
            //Console.ReadKey();

            //int[] nums = { 2, 1, 33, 4, 9, 77, 50, 62 };
            //int temp = 0;
            //for (int i = 0; i < nums.Length - 1; i++)
            //{
            //    for (int j = 0; j < nums.Length - i - 1; j++)
            //    {
            //        if (nums[j] > nums[j + 1])
            //        {
            //            temp = nums[j + 1];
            //            nums[j + 1] = nums[j];
            //            nums[j] = temp;
            //        }
            //    }
            //}
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    Console.Write(nums[i] + "  ");
            //}
            //Console.ReadKey();

            //string str = "陪产假";
            //if (str.Contains("产假"))
            //{
            //    Console.WriteLine(11);
            //}
            //else
            //{
            //    Console.WriteLine(222);
            //}
            //Console.ReadKey();

            Console.WriteLine(DateTime.Now.AddMonths(-5).ToString("yyyy-MM"));
            Console.ReadKey();

        }
    }
}
