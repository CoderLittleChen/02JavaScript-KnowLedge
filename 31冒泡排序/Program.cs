using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31冒泡排序
{
    class Program
    {
        static void Main(string[] args)
        {
            //冒泡排序
            int temp = 0;
            int[] nums = { 11, 2, 33, 4, 55, 6, 9, 3 };

            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = 0; j < nums.Length - 1 - i; j++)
                {
                    if (nums[j] > nums[j + 1])
                    {
                        temp = nums[j + 1];
                        nums[j + 1] = nums[j];
                        nums[j] = temp;
                    }
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write(nums[i]+"  ");
            }
            
            Console.ReadKey();

        }
    }
}
