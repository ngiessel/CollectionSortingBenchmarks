using CollectionSortingBenchmarks.Interfaces;

namespace CollectionSortingBenchmarks.Sorters.IntArray
{
    public class IntArrayBubbleSorter : IIntArraySorter
    {
        public void Sort(ref int[] collection)
        {
            for (int i = 0; i < collection.Length; i++)
            {
                for (int j = 0; j < collection.Length - 1; j++)
                {
                    if (collection[j] > collection[j + 1])
                    {
                        int temp = collection[j];
                        collection[j] = collection[j + 1];
                        collection[j + 1] = temp;
                    }
                }
            }
        }
    }
}
