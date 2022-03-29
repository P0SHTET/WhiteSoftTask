using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort.Algorithms
{
    public class BubbleSort : IDiagnosticSortAlgorithm
    {
        public BubbleSort()
        {
            SetDefault();
        }

        public int CompareCount { get ; private set; }
        public int SwapCount { get ; private set; }

        public event IDiagnosticSortAlgorithm.Compare CompareTwo;
        public event IDiagnosticSortAlgorithm.Swap SwapTwo;

        public IList<IComparable> Sort(IList<IComparable> array)
        {
            SetDefault();

            List<IComparable> arrayList = array.ToList();

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

        private void SetDefault()
        {
            CompareCount = 0;
            SwapCount = 0;
        }
    }
}
