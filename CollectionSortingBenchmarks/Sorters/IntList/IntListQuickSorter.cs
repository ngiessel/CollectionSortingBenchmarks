using CollectionSortingBenchmarks.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionSortingBenchmarks.Sorters.IntList
{
    public class IntListQuickSorter : IIntListSorter
    {
        public void Sort(ref List<int> collection)
        {
            Quicksort(collection, 0, collection.Count - 1);
        }
        private void Quicksort(List<int> array, int left, int right)
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
}
