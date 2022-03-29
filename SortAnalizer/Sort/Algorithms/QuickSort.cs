//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Sort.Algorithms
//{
//    public class QuickSort<T> : IDiagnosticSortAlgorithm<T> where T : IComparable
//    {
//        public InsertionSort()
//        {
//            SetDefault();
//        }

//        public int CompareCount { get; private set; }

//        public int SwapCount { get; private set; }

//        public event IDiagnosticSortAlgorithm<T>.Compare CompareTwo;
//        public event IDiagnosticSortAlgorithm<T>.Swap SwapTwo;

//        public IEnumerable<T> Sort(IEnumerable<T> array)
//        {
//            SetDefault();

//            List<T> arrayList = array.ToList();


//        }

//        private void SetDefault()
//        {
//            CompareCount = 0;
//            SwapCount = 0;
//        }
//    }
//}
