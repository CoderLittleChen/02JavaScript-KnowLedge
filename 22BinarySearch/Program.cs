using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[4] { 2, 11, 39, 46 };
            //首先明确需要的参数   一个是int数组，一个是要查找的元素
            //一定要注意的是   这里要求线性表采用顺序存储结构   表中元素按照关键字有序排列
            //这里是  线性表采用顺序存储结构  表中元素按照有序排列  
            Console.WriteLine(BinarySearch(array, 11));
            Console.ReadKey();
        }

        public static int BinarySearch(int[] array, int key)
        {
            int low = 0;
            int high = array.Length - 1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                int midVal = array[mid];
                if (midVal < key)
                {
                    low = mid + 1;
                }
                else if (midVal > key)
                {
                    high = mid + 1;
                }
                else
                {
                    //找到元素   返回1
                    return 1;
                }
            }
            return -1;

        }

    }
}
