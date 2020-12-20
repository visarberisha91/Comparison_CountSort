using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace ComparisonCountSort
{
    class Program
    {
        static void Comparisoncountsort(int[] arr)
        {
            int n = arr.Length;

            int[] output = new int[n];
            int[] count = new int[256];
            for (int i = 0; i < 256; ++i)
                count[i] = 0;
            for (int i = 0; i < n; ++i)
                ++count[arr[i]]; 
            for (int i = 1; i <= 255; ++i)
                count[i] += count[i - 1];
            for (int i = n - 1; i >= 0; i--)
            {
                output[count[arr[i]] - 1] = arr[i];
                --count[arr[i]];
            }
            for (int i = 0; i < n; ++i)
                arr[i] = output[i];
        }

        public static int[] DistributionCountSort(int[] input, int l, int u)
        {
            var d = new int[u - l + 1]; // count array ku i shtojme numrimet
            var S = new int[input.Length];

            for (int j = 0; j <= (u - l); j++)
            {
                d[j] = 0;
            }
            //gjetja e frekuences
            for (int i = 0; i <= input.Length - 1; i++)
            {
                d[input[i] - l] = d[input[i] - l] + 1;
            }
            //mbledhja e elementeve paraprake (cumulative frequency distribution)
            for (int j = 1; j <= (u - l); j++)
            {
                d[j] = d[j - 1] + d[j];
            }

            //vendosja sipas frekuences ne array-in perfundimtar s[]
            for (int i = input.Length - 1; i >= 0; i--)
            {
                int j = input[i] - l;
                S[d[j] - 1] = input[i];
                d[j] = d[j] - 1;
            }

            return S;
        }




        public static void Main()
        {
            int[] thearray; 
            long start = Stopwatch.GetTimestamp();
            Thread.Sleep(5000);
            int size = 1000000;
            thearray = new int[size];
            Random ran = new Random();
            for (int i = 0; i < size; i++)
            {
                thearray[i] = ran.Next(10, 20);
            }
            int u = thearray.Max();
            int l = thearray.Min();
            var sortedArray = DistributionCountSort(thearray, l, u);
            for (int i = 0; i < sortedArray.Length; ++i)
                Console.Write(sortedArray[i]);

            long end = Stopwatch.GetTimestamp();
            Console.WriteLine("Elapsed Time is {0} ticks", (end - start));

        }
    }
}
