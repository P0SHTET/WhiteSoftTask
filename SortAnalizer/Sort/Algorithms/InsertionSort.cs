using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort.Algorithms
{
    public class InsertionSort : IDiagnosticSortAlgorithm
    {
        public InsertionSort()
        {
            SetDefault();
        }

        public int CompareCount { get; private set; }

        public int SwapCount { get; private set; }

        public event IDiagnosticSortAlgorithm.Compare CompareTwo;
        public event IDiagnosticSortAlgorithm.Swap SwapTwo;

        public IList<IComparable> Sort(IList<IComparable> array)
        {
            SetDefault();

            List<IComparable> arrayList = new List<IComparable>();
            arrayList.Add(0);
            arrayList.AddRange(array);

            for (int i = 1; i < arrayList.Count; i++)
            {
                int j = i;

                while (j > 0 && CompareElements(arrayList, j - 1, i)) 
                {
                    SwapCount++;
                    SwapTwo?.Invoke(j - 1, j);

                    arrayList[j] = arrayList[j - 1];
                    j--;
                }

                arrayList[j] = arrayList[i];
            }

            return arrayList.Skip(1).ToList();
        }

        private void SetDefault()
        {
            CompareCount = 0;
            SwapCount = 0;
        }

        private bool CompareElements(List<IComparable> arrayList, int first, int second)
        {
            CompareCount++;
            CompareTwo?.Invoke(first, second);

            return arrayList[first].CompareTo(arrayList[second]) > 0;
        }
    }
}
