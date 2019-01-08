using System;
using System.Collections.Generic;
using System.Linq;

namespace Algo
{
    class TestSol
    {
        static void Main()
        {
            var n = Int32.Parse(Console.ReadLine());
            var list = new List<(int, int)>();
            for(int i=0;i<n;i++)
            {
                var cord = Console.ReadLine().Split(' ').Select(x => Int32.Parse(x)).ToArray();
                list.Add((cord[0], cord[1]));
            }
            var arr = list.ToArray();
            SortAlgo<(int, int)>.Heapsort(arr);
            foreach(var item in arr)
                Console.WriteLine($"{item.Item1} {item.Item2}");
        }

        static long BinarySearch(int[] arr, int x)
        {
            long l = 0;
            long r = arr.Length - 1;
            long mid = 0;
            while (l <= r)
            {
                mid = l + (r - l) / 2;
                if (arr[mid] == x)
                    return mid;

                if (arr[mid] > x)
                {
                    r = mid - 1;
                }
                else
                {
                    l = mid + 1;
                }
            }
            return -1;
        }
    }
}
