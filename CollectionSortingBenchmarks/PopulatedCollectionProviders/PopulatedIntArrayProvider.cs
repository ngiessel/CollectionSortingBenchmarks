using CollectionSortingBenchmarks.Interfaces;

namespace CollectionSortingBenchmarks.PopulatedCollectionProviders
{
    public class PopulatedIntArrayProvider : IPopulatedCollectionProvider<int[]>
    {
        private readonly Random _rnd = new Random();

        public int[] Get(int size)
        {
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = _rnd.Next(0, int.MaxValue);
            }
            return array;
        }
    }
}
