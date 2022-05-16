using CollectionSortingBenchmarks.Interfaces;

namespace CollectionSortingBenchmarks.PopulatedCollectionProviders
{
    public class PopulatedIntListProvider : IPopulatedCollectionProvider<List<int>>
    {
        private readonly Random _rnd = new Random();

        public List<int> Get(int size)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < size; i++)
            {
                list.Add(_rnd.Next(0, int.MaxValue));
            }
            return list;
        }
    }
}
