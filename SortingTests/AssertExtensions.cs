using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace CollectionSortingBenchmarks.Tests
{
    internal static class AssertExtensions
    {
        internal static void IsSorted(IEnumerable<int> collection)
        {
            var collectionAsArray = collection.ToArray();
            var sorted = collection.OrderBy(x => x).ToArray();
            for (int i = 0; i < sorted.Length; i++)
            {
                if (sorted[i] != collectionAsArray[i])
                {
                    throw new Exception("Collection is not sorted");
                }
            }
        }
    }
}
