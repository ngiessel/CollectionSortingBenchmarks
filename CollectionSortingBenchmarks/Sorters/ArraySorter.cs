using CollectionSortingBenchmarks.Interfaces;

namespace CollectionSortingBenchmarks.Sorters
{
    public class ArraySorter : ISorter<int[]>
    {
        public int[] BubbleSort(int[] value)
        {
            var result = new int[value.Length];
            value.CopyTo(result, 0);
            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < result.Length - 1; j++)
                {
                    if (result[j] > result[j + 1])
                    {
                        int temp = result[j];
                        result[j] = result[j + 1];
                        result[j + 1] = temp;
                    }
                }
            }
            return result;
        }

        public int[] MergeSort(int[] value)
        {
            var result = MergeSorter.RunMergeSort(value, 0, value.Length - 1);
            return result;
        }        

        public int[] QuickSort(int[] value)
        {
            var result = new int[value.Length];
            value.CopyTo(result, 0);
            QuickSorter.Quicksort(result, 0, value.Length - 1);
            return result;
        }

        private static class QuickSorter
        {
            public static void Quicksort(int[] array, int left, int right)
            {
                int i = left, j = right;
                int pivot = array[(left + right) / 2];

                while (i <= j)
                {
                    while (array[i].CompareTo(pivot) < 0)
                    {
                        i++;
                    }

                    while (array[j].CompareTo(pivot) > 0)
                    {
                        j--;
                    }

                    if (i <= j)
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;

                        i++;
                        j--;
                    }
                }

                if (left < j)
                {
                    Quicksort(array, left, j);
                }
                
                if (i < right)
                {
                    Quicksort(array, i, right);
                }
            }
        }
    
        private static class MergeSorter
        {
            internal static int[] RunMergeSort(int[] input, int left, int right)
            {
                if (left == right)
                {
                    int[] temp = new int[] { input[left] };
                    return temp;
                }

                int middle = left + (right - left) / 2;
                var leftArray = RunMergeSort(input, left, middle);
                var rightArray = RunMergeSort(input, middle + 1, right);
                var merge = Merge(leftArray, rightArray);
                return merge;
            }

            private static int[] Merge(int[] leftArray, int[] rightArray)
            {
                int leftLength = leftArray.Length;
                int rightLength = rightArray.Length;

                int[] target = new int[leftLength + rightLength];
                int targetPos = 0;
                int leftPos = 0;
                int rightPos = 0;

                while (leftPos < leftLength && rightPos < rightLength)
                {
                    if (leftArray[leftPos] != null && rightArray[rightPos] != null && leftArray[leftPos].CompareTo(rightArray[rightPos]) <= 0)
                    {
                        target[targetPos++] = leftArray[leftPos];
                        leftPos++;
                    }
                    else
                    {
                        target[targetPos++] = rightArray[rightPos];
                        rightPos++;
                    }
                }

                while (leftPos < leftLength)
                {
                    target[targetPos++] = leftArray[leftPos++];
                }
                while (rightPos < rightLength)
                {
                    target[targetPos++] = rightArray[rightPos++];
                }
                return target;
            }
        }
    }
}
