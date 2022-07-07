namespace CollectionSortingBenchmarks.Interfaces
{
    public interface ISorter<CollectionType> where CollectionType : ICollection<int>
    {
        void Sort(ref CollectionType collection);
    }
}
