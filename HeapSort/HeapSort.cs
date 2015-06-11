
namespace HeapSort
{
    public class HeapSort
    {
        private int heapSize;
        
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

        public void Sort(int[] arr)
        {
            heapSize = arr.Length - 1;

            BuildMaxHeapRecursive(arr);
            for(int i = arr.Length - 1; i >= 2; --i)
            {
                Swap(arr, 1, i);
                heapSize--;
                MaxHeapifyRecursive(arr, 1);
            }
        }

        /// <summary>
        /// In order to maintain the max-heap property, we call the procedure MaxHeapify.
        /// Its inputs are an array A and an index i into the array. When it is called, MaxHeapify
        /// assumes that the binary trees rooted at LEFT(i) and RIGHT(i) are maxheaps,
        /// but that A[i] might be smaller than its children, thus violating the max-heap
        /// property. MaxHeapify lets the value at A[i] “float down” in the max-heap so
        /// that the subtree rooted at index i obeys the max-heap property.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="i"></param>
        private void MaxHeapifyRecursive(int[] arr, int i)
        {
            int largest = DetermineLargestChild(arr, i);

            if (largest != i)
            {
                Swap(arr, i, largest);
                MaxHeapifyRecursive(arr, largest);
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

        private void BuildMaxHeapRecursive(int[] arr)
        {
            for (int i = (arr.Length/2); i >= 1; --i)
            {
                MaxHeapifyRecursive(arr, i);
            }
        }

        private void BuildMaxHeapIterative(int[] arr)
        {
            for (int i = (arr.Length / 2); i >= 1; --i)
            {
                MaxHeapifyIterative(arr, i);
            }
        }

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

            // TODO: Potential array bounds error.
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

        private void Swap(int[] arr, int a, int b)
        {
            int tmp = arr[a];
            arr[a] = arr[b];
            arr[b] = tmp;
        }
    }
}
