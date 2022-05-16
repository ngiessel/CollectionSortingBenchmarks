using CollectionSortingBenchmarks.Interfaces;

namespace CollectionSortingBenchmarks.Sorters
{
    public class ListSorter : ISorter<List<int>>
    {
        public List<int> BubbleSort(List<int> value)
        {
            List<int> result = new(value);
            for (int i = 0; i < result.Count; i++)
            {
                for (int j = 0; j < result.Count - 1; j++)
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

        public List<int> MergeSort(List<int> value)
        {
            var result = MergeSorter.RunMergeSort(value, 0, value.Count - 1);
            return new List<int>(result);
        }        

        public List<int> QuickSort(List<int> value)
        {
            var array = value.ToArray();
            QuickSorter.Quicksort(array, 0, value.Count - 1);
            return array.ToList();
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
            internal static List<int> RunMergeSort(List<int> input, int left, int right)
            {
                if (left == right)
                {
                    List<int> temp = new List<int> { input[left] };
                    return temp;
                }

                int middle = left + (right - left) / 2;
                var leftArray = RunMergeSort(input, left, middle);
                var rightArray = RunMergeSort(input, middle + 1, right);
                var merge = Merge(leftArray, rightArray);
                return merge.ToList();
            }

            private static int[] Merge(List<int> leftList, List<int> rightList)
            {
                int leftLength = leftList.Count;
                int rightLength = rightList.Count;

                int[] target = new int[leftLength + rightLength];
                int targetPos = 0;
                int leftPos = 0;
                int rightPos = 0;

                while (leftPos < leftLength && rightPos < rightLength)
                {
                    if (leftList[leftPos] != null && rightList[rightPos] != null && leftList[leftPos].CompareTo(rightList[rightPos]) <= 0)
                    {
                        target[targetPos++] = leftList[leftPos];
                        leftPos++;
                    }
                    else
                    {
                        target[targetPos++] = rightList[rightPos];
                        rightPos++;
                    }
                }

                while (leftPos < leftLength)
                {
                    target[targetPos++] = leftList[leftPos++];
                }
                while (rightPos < rightLength)
                {
                    target[targetPos++] = rightList[rightPos++];
                }
                return target;
            }
        }
    }
}
