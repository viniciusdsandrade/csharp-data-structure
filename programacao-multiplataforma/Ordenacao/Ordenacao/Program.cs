namespace Ordenando{ 

    class Program
    {

        static void Main(string[] args)
        {
            int[] array = { 64, 34, 25, 12, 22, 11, 90 };
            float[] floatArray = { 0.897f, 0.565f, 0.656f, 0.1234f, 0.665f, 0.3434f };

            Console.WriteLine("Original Array:");
            PrintArray(array);
            PrintArray(floatArray);
            Console.WriteLine();

            // Testando Bubble Sort
            BubbleSort(array);
            BubbleSort(floatArray);
            Console.WriteLine("Sorted Array (Bubble Sort):");
            PrintArray(array);
            PrintArray(floatArray);
            Console.WriteLine();

            // Testando Merge Sort
            MergeSort(array);
            MergeSort(floatArray);
            Console.WriteLine("Sorted Array (Merge Sort):");
            PrintArray(array);
            PrintArray(floatArray);
            Console.WriteLine();

            // Testando Quick Sort
            QuickSort(array, 0, array.Length - 1);
            QuickSort(floatArray, 0, floatArray.Length - 1);
            Console.WriteLine("Sorted Array (Quick Sort):");
            PrintArray(array);
            PrintArray(floatArray);
            Console.WriteLine();
        }

        static void PrintArray<T>(T[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        // Bubble Sort
        public static void BubbleSort<T>(T[] array) where T : IComparable<T>
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j].CompareTo(array[j + 1]) > 0)
                    {
                        T temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        // Insertion Sort
        public static void InsertionSort<T>(T[] array) where T : IComparable<T>
        {
            int n = array.Length;
            for (int i = 1; i < n; ++i)
            {
                T key = array[i];
                int j = i - 1;

                while (j >= 0 && array[j].CompareTo(key) > 0)
                {
                    array[j + 1] = array[j];
                    j = j - 1;
                }
                array[j + 1] = key;
            }
        }

        // Selection Sort
        public static void SelectionSort<T>(T[] array) where T : IComparable<T>
        {
            int n = array.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int minIdx = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (array[j].CompareTo(array[minIdx]) < 0)
                    {
                        minIdx = j;
                    }
                }
                T temp = array[minIdx];
                array[minIdx] = array[i];
                array[i] = temp;
            }
        }

        // Merge Sort
        public static void MergeSort<T>(T[] array) where T : IComparable<T>
        {
            if (array.Length <= 1)
                return;

            int middle = array.Length / 2;
            T[] left = new T[middle];
            T[] right = new T[array.Length - middle];

            Array.Copy(array, 0, left, 0, middle);
            Array.Copy(array, middle, right, 0, array.Length - middle);

            MergeSort(left);
            MergeSort(right);
            Merge(left, right, array);
        }

        private static void Merge<T>(T[] left, T[] right, T[] result) where T : IComparable<T>
        {
            int leftIndex = 0, rightIndex = 0, resultIndex = 0;

            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (left[leftIndex].CompareTo(right[rightIndex]) <= 0)
                {
                    result[resultIndex++] = left[leftIndex++];
                }
                else
                {
                    result[resultIndex++] = right[rightIndex++];
                }
            }

            while (leftIndex < left.Length)
            {
                result[resultIndex++] = left[leftIndex++];
            }

            while (rightIndex < right.Length)
            {
                result[resultIndex++] = right[rightIndex++];
            }
        }

        // Quick Sort
        public static void QuickSort<T>(T[] array, int low, int high) where T : IComparable<T>
        {
            if (low < high)
            {
                int pi = Partition(array, low, high);
                QuickSort(array, low, pi - 1);
                QuickSort(array, pi + 1, high);
            }
        }

        private static int Partition<T>(T[] array, int low, int high) where T : IComparable<T>
        {
            T pivot = array[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (array[j].CompareTo(pivot) < 0)
                {
                    i++;
                    T temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }

            T temp1 = array[i + 1];
            array[i + 1] = array[high];
            array[high] = temp1;

            return i + 1;
        }

        // Heap Sort
        public static void HeapSort<T>(T[] array) where T : IComparable<T>
        {
            int n = array.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(array, n, i);

            for (int i = n - 1; i >= 0; i--)
            {
                T temp = array[0];
                array[0] = array[i];
                array[i] = temp;

                Heapify(array, i, 0);
            }
        }

        private static void Heapify<T>(T[] array, int n, int i) where T : IComparable<T>
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && array[left].CompareTo(array[largest]) > 0)
                largest = left;

            if (right < n && array[right].CompareTo(array[largest]) > 0)
                largest = right;

            if (largest != i)
            {
                T temp = array[i];
                array[i] = array[largest];
                array[largest] = temp;

                Heapify(array, n, largest);
            }
        }

        // Shell Sort
        public static void ShellSort<T>(T[] array) where T : IComparable<T>
        {
            int n = array.Length;
            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i += 1)
                {
                    T temp = array[i];
                    int j;
                    for (j = i; j >= gap && array[j - gap].CompareTo(temp) > 0; j -= gap)
                    {
                        array[j] = array[j - gap];
                    }
                    array[j] = temp;
                }
            }
        }

        // Counting Sort
        public static void CountingSort(int[] array)
        {
            int n = array.Length;
            int[] output = new int[n];

            int max = array[0];
            for (int i = 1; i < n; i++)
            {
                if (array[i] > max)
                    max = array[i];
            }

            int[] count = new int[max + 1];

            for (int i = 0; i < max + 1; ++i)
                count[i] = 0;

            for (int i = 0; i < n; i++)
                ++count[array[i]];

            for (int i = 1; i <= max; i++)
                count[i] += count[i - 1];

            for (int i = n - 1; i >= 0; i--)
            {
                output[count[array[i]] - 1] = array[i];
                --count[array[i]];
            }

            for (int i = 0; i < n; i++)
                array[i] = output[i];
        }

        // Radix Sort
        public static void RadixSort(int[] array)
        {
            int max = GetMax(array);
            for (int exp = 1; max / exp > 0; exp *= 10)
                CountSort(array, exp);
        }

        private static int GetMax(int[] array)
        {
            int n = array.Length;
            int max = array[0];
            for (int i = 1; i < n; i++)
            {
                if (array[i] > max)
                    max = array[i];
            }
            return max;
        }

        private static void CountSort(int[] array, int exp)
        {
            int n = array.Length;
            int[] output = new int[n];
            int[] count = new int[10];

            for (int i = 0; i < 10; i++)
                count[i] = 0;

            for (int i = 0; i < n; i++)
                count[(array[i] / exp) % 10]++;

            for (int i = 1; i < 10; i++)
                count[i] += count[i - 1];

            for (int i = n - 1; i >= 0; i--)
            {
                output[count[(array[i] / exp) % 10] - 1] = array[i];
                count[(array[i] / exp) % 10]--;
            }

            for (int i = 0; i < n; i++)
                array[i] = output[i];
        }

        // Bucket Sort
        public static void BucketSort(float[] array)
        {
            int n = array.Length;
            List<float>[] buckets = new List<float>[n];

            for (int i = 0; i < n; i++)
                buckets[i] = new List<float>();

            foreach (float num in array)
            {
                int bucketIndex = (int)(num * n);
                buckets[bucketIndex].Add(num);
            }

            foreach (List<float> bucket in buckets)
            {
                bucket.Sort();
            }

            int index = 0;
            foreach (List<float> bucket in buckets)
            {
                foreach (float num in bucket)
                {
                    array[index++] = num;
                }
            }
        }
    }
}
