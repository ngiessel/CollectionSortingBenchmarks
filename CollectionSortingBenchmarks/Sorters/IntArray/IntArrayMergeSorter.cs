using CollectionSortingBenchmarks.Interfaces;

namespace CollectionSortingBenchmarks.Sorters.IntArray
{
    public class IntArrayMergeSorter : IIntArraySorter
    {
        public void Sort(ref int[] value)
        {
            value = MergeSort(value, 0, value.Length - 1);
        }
        private int[] MergeSort(int[] input, int left, int right)
        {
            if (left == right)
            {
                int[] temp = new int[] { input[left] };
                return temp;
            }

            int middle = left + (right - left) / 2;
            var leftArray = MergeSort(input, left, middle);
            var rightArray = MergeSort(input, middle + 1, right);
            var merge = Merge(leftArray, rightArray);
            return merge;
        }

        private int[] Merge(int[] leftArray, int[] rightArray)
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
