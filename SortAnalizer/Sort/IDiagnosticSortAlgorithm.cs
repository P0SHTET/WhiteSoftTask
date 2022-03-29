using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    internal interface IDiagnosticSortAlgorithm<T> : ISortAlgorithm<T> where T : IComparable 
    {
        delegate (int, int) Compare();
        public event Compare CompareTwo;

        delegate (int, int) Swap();
        public event Swap SwapTwo;
    }
}
