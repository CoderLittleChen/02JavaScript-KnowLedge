using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05LeetCode_1_两数之和_
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 4, 6, 7, 8, 19, 2 };
            int[] indexNums = Sum(nums, 8);
            foreach (var item in indexNums)
            {
                Console.Write(item + "  ");
            }
            Console.ReadKey();
        }
        static int[] Sum(int[] nums, int target)
        {
            List<int> listIndex = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        if (i!=j)
                        {
                            if (!listIndex.Contains(i) && !listIndex.Contains(j))
                            {
                                listIndex.Add(i);
                                listIndex.Add(j);
                            }
                        }
                        continue;
                    }
                }
            }
            return listIndex.ToArray();
        }
    }
}
