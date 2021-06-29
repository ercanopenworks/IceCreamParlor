using System;
using System.Collections.Generic;
using System.Linq;

namespace IceCreamParlor
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine().Trim());

            for (int tItr = 0; tItr < t; tItr++)
            {
                int m = Convert.ToInt32(Console.ReadLine().Trim());

                int n = Convert.ToInt32(Console.ReadLine().Trim());

                List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

                int[] result = iceCreamParlor(m, arr);

                Console.WriteLine(String.Join(" ", result));
            }
        }

        private static int[] iceCreamParlor(int m, List<int> arr)
        {
            List<int> sortedMenu = new List<int>();
            sortedMenu.AddRange(arr);

            sortedMenu.Sort();
            for (int i = 1; i < sortedMenu.Count; i++)
            {
                int complement = m - sortedMenu[i-1];
                int location = sortedMenu.BinarySearch(complement);
                if(location>0 && location< sortedMenu.Count && sortedMenu[location] == complement)
                {
                    int[] indices = getIndicesFromValues(arr, sortedMenu[i-1], complement);
                    return indices;
                }
            }

            return null;
            
        }

        private static int[] getIndicesFromValues(List<int> arr, int value1, int value2)
        {
            int index1 = IndexOf(arr, value1, -1);
            int index2 = IndexOf(arr, value2, index1-1);

            int[] indices = { Math.Min(index1, index2), Math.Max(index1, index2) };

            return indices;
        }

        private static int IndexOf(List<int> arr, int value, int excludeItem)
        {
            for (int i = 0; i < arr.Count-1; i++)
            {
                if (arr[i] == value && i != excludeItem)
                    return i+1;
            }
            return -1;
        }
    }
}
