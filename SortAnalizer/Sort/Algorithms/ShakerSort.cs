using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort.Algorithms
{
    public class ShakerSort : IDiagnosticSortAlgorithm
    {
        public ShakerSort()
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

            List<IComparable> arrayList = array.ToList();

            int left = 0, right = arrayList.Count - 1;

            while (left < right)
            {
                for (int i = left; i < right; i++)
                {
                    CompareCount++;
                    CompareTwo?.Invoke(i, i + 1);

                    if (arrayList[i].CompareTo(arrayList[i + 1]) > 0)
                    {
                        SwapCount++;
                        SwapTwo?.Invoke(i, i + 1);

                        var temp = arrayList[i + 1];
                        arrayList[i + 1] = arrayList[i];
                        arrayList[i] = temp;
                    }
                }
                right--;

                for (int i = right; i > left; i--)
                {
                    CompareCount++;
                    CompareTwo?.Invoke(i - 1, i);

                    if (arrayList[i - 1].CompareTo(arrayList[i]) > 0)
                    {
                        SwapCount++;
                        SwapTwo?.Invoke(i, i + 1);

                        var temp = arrayList[i];
                        arrayList[i] = arrayList[i - 1];
                        arrayList[i - 1] = temp;
                    }
                }
                left++;
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
