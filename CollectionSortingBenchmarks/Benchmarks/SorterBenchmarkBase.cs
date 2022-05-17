using BenchmarkDotNet.Attributes;

using CollectionSortingBenchmarks.Interfaces;

namespace CollectionSortingBenchmarks.Benchmarks
{

    [MemoryDiagnoser]
    public abstract class SorterBenchmarkBase<SorterType, CollectionType> where CollectionType : ICollection<int> where SorterType : ISorter<CollectionType>
    {
        private ISorter<CollectionType> _sorter;
        private IPopulatedCollectionProvider<CollectionType> _provider;
        private CollectionType _collection;
            
        [Params(10, 30, 100, 500, 5000)] //30, 100, 500, 5000
        public int Size { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            var providerType = typeof(Program).Assembly.GetTypes()
                .FirstOrDefault(x =>
                    !x.IsAbstract &&
                    !x.IsInterface &&
                    x.GetInterfaces().Any(i =>
                        i.IsGenericType &&
                        i == typeof(IPopulatedCollectionProvider<CollectionType>)));
            
            if (providerType is null)
            {
                throw new InvalidOperationException($"Sorter or PopulatedCollectionProvider of {typeof(CollectionType)} not found");
            }
                
            _sorter = (Activator.CreateInstance(typeof(SorterType)) as ISorter<CollectionType>)!;
            _provider = (Activator.CreateInstance(providerType) as IPopulatedCollectionProvider<CollectionType>)!;
            
            _collection = _provider.Get(Size);
        }
        
        [IterationSetup]
        public void IterationSetup()
        {
            _collection = _provider.Get(Size);
        }

        [Benchmark]
        public void Sort()
        {            
            _sorter.Sort(ref _collection);
        }
    }
}
