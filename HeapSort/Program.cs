using System;

namespace HeapSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { -1, 9, 8, 7, 6 };
            HeapSort heapSort = new HeapSort();
            heapSort.SortRecursively(arr);


            Console.ReadLine();
        }
    }
}
