using CollectionSortingBenchmarks.Interfaces;

namespace CollectionSortingBenchmarks.Sorters.IntArray
{
    public class IntArrayQuickSorter : IIntArraySorter
    {
        public void Sort(ref int[] collection)
        {
            Quicksort(collection!, 0, collection.Length - 1);
        }

        private void Quicksort(int[] array, int left, int right)
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

