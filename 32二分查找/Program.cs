using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _32二分查找
{
    class Program
    {
        static void Main(string[] args)
        {
            // 5/2=2.5  当转换成int类型的时候  会直接向下取整  就是2
            //int test = (5) / 2;
            //Console.WriteLine(test);
            //Console.Read();


            //二分查找要求线性表必须采用顺序存储结构，且表中元素按照关键字有序排列
            int[] nums = { 1, 4, 9, 11, 44, 56, 89, 222 };
            int target = 44;
            int index = BinarySearch(nums, target);
            Console.WriteLine(index);
            Console.ReadKey();  


        }

        /// <summary>
        /// 二分查找  找到该值在数组中的坐标    
        /// </summary>
        /// <param name="array"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        static int BinarySearch(int[] array, int key)
        {
            int left = 0;
            int right = array.Length - 1;
            while (left <= right)
            {
                //拿到中间值     
                int mid = (left + right) / 2;
                int midValue = array[mid];
                if (midValue == key)
                {
                    return mid;
                }
                else if (key < midValue)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;   
                }
            }

            return -1;

        }

    }
}
