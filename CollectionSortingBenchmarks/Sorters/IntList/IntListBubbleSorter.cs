using CollectionSortingBenchmarks.Interfaces;

namespace CollectionSortingBenchmarks.Sorters.IntList
{
    public class IntListBubbleSorter : IIntListSorter
    {
        public void Sort(ref List<int> collection)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                for (int j = 0; j < collection.Count - 1; j++)
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
