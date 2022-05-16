using CollectionSortingBenchmarks.Sorters;

using System.Collections.Generic;

using Xunit;

namespace CollectionSortingBenchmarks.Tests
{
    public class ListSorterTests
    {
        [Fact]
        public void TestBubbleSort()
        {
            var sorter = new ListSorter();
            var list = new List<int>{ 5, 4, 3, 2, 1 };
            var result = sorter.BubbleSort(list);
            AssertExtensions.IsSorted(result);
        }

        [Fact]
        public void TestMergeSort()
        {
            var sorter = new ListSorter();
            var list = new List<int> { 5, 4, 3, 2, 1 };
            var result = sorter.MergeSort(list);
            AssertExtensions.IsSorted(result);
        }

        [Fact]
        public void TestQuickSort()
        {
            var sorter = new ListSorter();
            var list = new List<int> { 5, 4, 3, 2, 1 };
            var result = sorter.QuickSort(list);
            AssertExtensions.IsSorted(result);
        }
    }
}