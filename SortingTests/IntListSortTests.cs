using CollectionSortingBenchmarks.Sorters.IntList;

using System.Collections.Generic;

using Xunit;

namespace SortingTests
{
    public class IntListSortTests
    {
        [Fact]
        public void TestBubbleSort()
        {
            var array = new List<int> { 3, 1, 2, 4, 5, 7, 8, 6, 10, 9 };
            var expected = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var sorter = new IntListBubbleSorter();

            sorter.Sort(ref array);

            Assert.Equal(expected, array);
        }
        [Fact]
        public void TestMergeSort()
        {
            var array = new List<int> { 3, 1, 2, 4, 5, 7, 8, 6, 10, 9 };
            var expected = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var sorter = new IntListMergeSorter();

            sorter.Sort(ref array);
            
            Assert.Equal(expected, array);
        }
        [Fact]
        public void TestQuickSort()
        {
            var array = new List<int> { 3, 1, 2, 4, 5, 7, 8, 6, 10, 9 };
            var expected = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var sorter = new IntListQuickSorter();

            sorter.Sort(ref array);

            Assert.Equal(expected, array);
        }        
    }
}
