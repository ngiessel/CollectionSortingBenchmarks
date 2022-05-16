using CollectionSortingBenchmarks.Sorters;

using Xunit;

namespace CollectionSortingBenchmarks.Tests
{
    public class ArraySorterTests
    {
        [Fact]
        public void TestBubbleSort()
        {
            var sorter = new ArraySorter();
            var list = new int[]{ 5, 4, 3, 2, 1 };
            var result = sorter.BubbleSort(list);
            AssertExtensions.IsSorted(result);
        }

        [Fact]
        public void TestMergeSort()
        {
            var sorter = new ArraySorter();
            var list = new int []{ 5, 4, 3, 2, 1 };
            var result = sorter.MergeSort(list);
            AssertExtensions.IsSorted(result);
        }

        [Fact]
        public void TestQuickSort()
        {
            var sorter = new ArraySorter();
            var list = new int[] { 5, 4, 3, 2, 1 };
            var result = sorter.QuickSort(list);
            AssertExtensions.IsSorted(result);
        }
    }
}