using CollectionSortingBenchmarks.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionSortingBenchmarks.Sorters.IntList
{
    public class IntListMergeSorter : IIntListSorter
    {
        public void Sort(ref List<int> collection)
        {
            collection = RunMergeSort(collection, 0, collection.Count - 1);            
        }
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