using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort.Algorithms
{
    internal class BubbleSort<T> : IDiagnosticSortAlgorithm<T> where T : IComparable
    {
        public BubbleSort()
        {
        }

        public int CompareCount { get ; private set; }
        public int SwapCount { get ; private set; }

        public event IDiagnosticSortAlgorithm<T>.Compare CompareTwo;
        public event IDiagnosticSortAlgorithm<T>.Swap SwapTwo;

        public IEnumerable<T> Sort(IEnumerable<T> array)
        {
            List<T> arrayList = array.ToList();

            for (int i = 0; i < arrayList.Count; i++)
            {
                for (int j = i + 1; j < arrayList.Count; j++)
                {
                    CompareCount++;
                    CompareTwo?.Invoke(i, j);
                    
                    if (arrayList[i].CompareTo(arrayList[j]) > 0)
                    {
                        SwapCount++;
                        SwapTwo?.Invoke(i, j);

                        var temp = arrayList[i];
                        arrayList[i] = arrayList[j];
                        arrayList[j] = temp;
                    }
                }
            }

            return arrayList;
        }
    }
}
