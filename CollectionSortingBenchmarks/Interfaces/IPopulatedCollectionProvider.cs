namespace CollectionSortingBenchmarks.Interfaces
{
    public interface IPopulatedCollectionProvider<CollectionType> where CollectionType : ICollection<int>
    {
        CollectionType Get(int size);
    }
}
