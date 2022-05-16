namespace CollectionSortingBenchmarks.Interfaces
{
    public interface ISorter<CollectionType> where CollectionType : ICollection<int>
    {
        public CollectionType QuickSort(CollectionType value);
        public CollectionType BubbleSort(CollectionType value);
        public CollectionType MergeSort(CollectionType value);
    }
}
