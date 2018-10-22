using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[5] { 11, 2, 39, 46, 77 };
            Console.WriteLine("-----排序前--------");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + "  ");
            }
            Console.WriteLine();
            array = QuickSort(array);
            Console.WriteLine("-----排序后--------");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + "  ");
            }

            int n = Partition(array, 2, 3);
            Console.WriteLine(n);

            Console.ReadKey();
        }

        public static int[] QuickSort(int[] array)
        {
            Sort(array, 0, array.Length - 1);
            return array;
        }


        public static void Sort(int[] array, int p, int r)
        {
            int q = 0;
            if (p < r)
            {
                q = Partition(array, p, r);
                Sort(array, p, q - 1);
                Sort(array, q + 1, r);
            }
        }


        //int[] array = new int[5] { 11, 2, 39, 46, 77 };
        //p=2   r=3   x=46  j=1    
        public static int Partition(int[] array, int p, int r)
        {
            int x = array[r];
            int j = p - 1;

            for (int i = p; i <= r - 1; i++)
            {
                if (array[i] <= x)
                {
                    j++;
                    Swap(array, j, i);
                }
            }

            Swap(array, j + 1, r);
            return j + 1;
        }


        public static void Swap(int[] array, int i, int j)
        {
            int t = array[i];
            array[i] = array[j];
            array[j] = t;
        }



    }
}
