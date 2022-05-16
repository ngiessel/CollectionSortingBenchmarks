using BenchmarkDotNet.Attributes;

using CollectionSortingBenchmarks.Interfaces;

namespace CollectionSortingBenchmarks.Benchmarks
{

    [MemoryDiagnoser]
    public abstract class SorterBenchmarkBase<CollectionType> where CollectionType : ICollection<int>
    {
        private ISorter<CollectionType> _sorter;
        private CollectionType _collection;
            
        [Params(10, 30, 100, 500, 5000)] //30, 100, 500, 5000
        public int Size { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            var sorterType = typeof(Program).Assembly.GetTypes()
                .Where(x =>
                    !x.IsAbstract &&
                    !x.IsInterface &&
                    x.GetInterfaces().Any(i =>
                        i.IsGenericType &&
                        i == typeof(ISorter<CollectionType>))).FirstOrDefault();

            var providerType = typeof(Program).Assembly.GetTypes()
                .Where(x =>
                    !x.IsAbstract &&
                    !x.IsInterface &&
                    x.GetInterfaces().Any(i =>
                        i.IsGenericType &&
                        i == typeof(IPopulatedCollectionProvider<CollectionType>))).FirstOrDefault();

            
            if (sorterType is null || providerType is null)
            {
                throw new InvalidOperationException($"Sorter or PopulatedCollectionProvider of {typeof(CollectionType)} not found");
            }
                
            _sorter = (Activator.CreateInstance(sorterType) as ISorter<CollectionType>)!;            
            var provider = (Activator.CreateInstance(providerType) as IPopulatedCollectionProvider<CollectionType>)!;            
            
            _collection = provider.Get(Size);
        }

        [Benchmark]
        public void BubbleSort()
        {
            var sorted = _sorter.BubbleSort(_collection);
        }

        [Benchmark]
        public void MergeSort()
        {
            var sorted = _sorter.MergeSort(_collection);
        }

        [Benchmark]
        public void QuickSort()
        {
            var sorted = _sorter.QuickSort(_collection);
        }
    }
}
