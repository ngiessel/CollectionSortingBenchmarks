using CollectionSortingBenchmarks.Sorters.IntArray;

using Xunit;

namespace SortingTests
{
    public class IntArraySortTests
    {
        [Fact]
        public void TestBubbleSort()
        {
            int[] array = new int[] { 3, 1, 2, 4, 5, 7, 8, 6, 10, 9 };
            int[] expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var sorter = new IntArrayBubbleSorter();

            sorter.Sort(ref array);

            Assert.Equal(expected, array);
        }
        [Fact]
        public void TestMergeSort()
        {
            int[] array = new int[] { 3, 1, 2, 4, 5, 7, 8, 6, 10, 9 };
            int[] expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var sorter = new IntArrayMergeSorter();

            sorter.Sort(ref array);
            
            Assert.Equal(expected, array);
        }
        [Fact]
        public void TestQuickSort()
        {
            int[] array = new int[] { 3, 1, 2, 4, 5, 7, 8, 6, 10, 9 };
            int[] expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var sorter = new IntArrayQuickSorter();

            sorter.Sort(ref array);

            Assert.Equal(expected, array);
        }        
    }
}
