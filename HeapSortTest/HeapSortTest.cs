﻿namespace HeapSortTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using HeapSort;

    [TestClass]
    public class HeapSortTest
    {
        private PrivateObject Init(int heapSize)
        {
            PrivateObject target = new PrivateObject(typeof(HeapSort));
            target.SetField("heapSize", heapSize);
            return target;
        }

        [TestMethod]
        public void TestMethod1()
        {
            int[] arr1 = { -1, 4 };
            int[] arr2 = { -1, 4 };
            int[] expected = { -1, 4 };

            PrivateObject sort = Init(arr1.Length - 1);
            sort.Invoke("MaxHeapifyRecursive", arr1, 1);
            sort.Invoke("MaxHeapifyIterative", arr2, 1);

            CollectionAssert.AreEqual(arr1, arr2);
            CollectionAssert.AreEqual(arr1, expected);
        }

        [TestMethod]
        public void TestMethod2()
        {
            int[] arr1 = { -1, 4, 10 };
            int[] arr2 = { -1, 4, 10 };
            int[] expected = { -1, 10, 4 };

            PrivateObject sort = Init(arr1.Length - 1);
            sort.Invoke("MaxHeapifyRecursive", arr1, 1);
            sort.Invoke("MaxHeapifyIterative", arr2, 1);

            CollectionAssert.AreEqual(arr1, arr2);
            CollectionAssert.AreEqual(arr1, expected);
        }

        [TestMethod]
        public void TestMethod3()
        {
            int[] arr1 = { -1, 4, 10, 16 };
            int[] arr2 = { -1, 4, 10, 16 };
            int[] expected = { -1, 16, 10, 4 };

            PrivateObject sort = Init(arr1.Length - 1);
            sort.Invoke("MaxHeapifyRecursive", arr1, 1);
            sort.Invoke("MaxHeapifyIterative", arr2, 1);

            CollectionAssert.AreEqual(arr1, arr2);
            CollectionAssert.AreEqual(arr1, expected);
        }


        [TestMethod]
        public void TestMethod4()
        {
            int[] arr1 = { -1, 16, 4, 10, 14, 7, 9, 3, 2, 8, 1 };
            int[] arr2 = { -1, 16, 4, 10, 14, 7, 9, 3, 2, 8, 1 };
            int[] expected = { -1, 16, 14, 10, 8, 7, 9, 3, 2, 4, 1 };

            PrivateObject sort = Init(arr1.Length - 1);
            sort.Invoke("MaxHeapifyRecursive", arr1, 2);
            sort.Invoke("MaxHeapifyIterative", arr2, 2);

            CollectionAssert.AreEqual(arr1, arr2);
            CollectionAssert.AreEqual(arr1, expected);
        }

        [TestMethod]
        public void TestMethod5()
        {
            int[] arr1 = { -1, 1, 2, 3, 4, 5, 6, 7 };
            int[] arr2 = { -1, 1, 2, 3, 4, 5, 6, 7 };
            int[] expected = { -1, 7, 5, 6, 4, 2, 1, 3 };

            PrivateObject sort = Init(arr1.Length - 1);
            sort.Invoke("BuildMaxHeapRecursive", arr1);
            sort.Invoke("BuildMaxHeapIterative", arr2);

            CollectionAssert.AreEqual(arr1, arr2);
            CollectionAssert.AreEqual(arr1, expected);
        }

        [TestMethod]
        public void TestMethod6()
        {
            int[] arr1 = { -1, 4 };
            int[] arr2 = { -1, 4 };
            int[] expected = { -1, 4 };

            PrivateObject sort = Init(arr1.Length - 1);
            sort.Invoke("BuildMaxHeapRecursive", arr1);
            sort.Invoke("BuildMaxHeapIterative", arr2);

            CollectionAssert.AreEqual(arr1, arr2);
            CollectionAssert.AreEqual(arr1, expected);
        }

        [TestMethod]
        public void TestMethod7()
        {
            int[] arr1 = { -1, 4, 10, 16 };
            int[] arr2 = { -1, 4, 10, 16 };
            int[] expected = { -1, 16, 10, 4 };

            PrivateObject sort = Init(arr1.Length - 1);
            sort.Invoke("BuildMaxHeapRecursive", arr1);
            sort.Invoke("BuildMaxHeapIterative", arr2);

            CollectionAssert.AreEqual(arr1, arr2);
            CollectionAssert.AreEqual(arr1, expected);
        }

        [TestMethod]
        public void TestMethod8()
        {
            const int ItemCount = 1000;

            Random rnd = new Random();

            int[] arr1 = new int[ItemCount];
            int[] arr2 = new int[ItemCount];

            for (int i = 0; i < ItemCount; ++i)
            {
                int random = rnd.Next(ItemCount);
                arr1[i] = random;
                arr2[i] = random;
            }

            PrivateObject sort = Init(arr1.Length - 1);
            sort.Invoke("BuildMaxHeapRecursive", arr1);
            sort.Invoke("BuildMaxHeapIterative", arr2);

            CollectionAssert.AreEqual(arr1, arr2);
        }

        [TestMethod]
        public void TestMethod9()
        {
            const int ItemCount = 1000;

            Random rnd = new Random();

            int[] arr1 = new int[ItemCount];
            int[] arr2 = new int[ItemCount];

            for (int i = 0; i < ItemCount; ++i)
            {
                int random = rnd.Next(ItemCount);
                arr1[i] = random;
                arr2[i] = random;
            }

            HeapSort sort = new HeapSort();
            sort.SortRecursively(arr1);
            sort.SortIteratively(arr2);

            CollectionAssert.AreEqual(arr1, arr2);
        }
    }
}
