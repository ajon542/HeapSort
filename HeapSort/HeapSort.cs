
namespace HeapSort
{
    /// <summary>
    /// This class contains a combination of heap sorting operations.
    /// </summary>
    /// <remarks>
    /// Recursive and iterative implementations of the algorithm are provided for a max-heap.
    /// </remarks>
    public class HeapSort
    {
        private int heapSize;

        #region Recursive Implementation

        public void SortRecursively(int[] arr)
        {
            heapSize = arr.Length - 1;

            BuildMaxHeapRecursive(arr);
            for (int i = arr.Length - 1; i >= 2; --i)
            {
                Swap(arr, 1, i);
                heapSize--;
                MaxHeapifyRecursive(arr, 1);
            }
        }

        private void BuildMaxHeapRecursive(int[] arr)
        {
            for (int i = (arr.Length / 2); i >= 1; --i)
            {
                MaxHeapifyRecursive(arr, i);
            }
        }

        private void MaxHeapifyRecursive(int[] arr, int i)
        {
            int largest = DetermineLargestChild(arr, i);

            if (largest != i)
            {
                Swap(arr, i, largest);
                MaxHeapifyRecursive(arr, largest);
            }
        }

        #endregion

        #region Iterative Implementation

        public void SortIteratively(int[] arr)
        {
            heapSize = arr.Length - 1;

            BuildMaxHeapIterative(arr);
            for (int i = arr.Length - 1; i >= 2; --i)
            {
                Swap(arr, 1, i);
                heapSize--;
                MaxHeapifyIterative(arr, 1);
            }
        }

        private void BuildMaxHeapIterative(int[] arr)
        {
            for (int i = (arr.Length / 2); i >= 1; --i)
            {
                MaxHeapifyIterative(arr, i);
            }
        }

        private void MaxHeapifyIterative(int[] arr, int i)
        {
            int largest = DetermineLargestChild(arr, i);

            while (largest != i)
            {
                // Determined there was a child with a larger value so swap them.
                Swap(arr, i, largest);

                // Update the index to reflect the change.
                i = largest;

                // Determine if the new parent has a child with a larger value.
                // If not, the loop will terminate.
                largest = DetermineLargestChild(arr, i);
            }
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Determines which child has the largest value. If the parent has the largest
        /// value, it will return the index i.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        private int DetermineLargestChild(int[] arr, int i)
        {
            int largest;
            int l = Left(i);
            int r = Right(i);

            // Determine which child to swap with.
            if ((l <= heapSize) && (arr[l] > arr[i]))
            {
                // Left child has the largest value.
                largest = l;
            }
            else
            {
                // Parent has the largest value.
                largest = i;
            }

            if ((r <= heapSize) && (arr[r] > arr[largest]))
            {
                // Right child has the largest value.
                largest = r;
            }

            return largest;
        }

        private int Parent(int i)
        {
            return i >> 1;
        }

        private int Left(int i)
        {
            return (i << 1);
        }

        private int Right(int i)
        {
            return (i << 1) + 1;
        }

        private void Swap(int[] arr, int a, int b)
        {
            int tmp = arr[a];
            arr[a] = arr[b];
            arr[b] = tmp;
        }

        #endregion
    }
}
