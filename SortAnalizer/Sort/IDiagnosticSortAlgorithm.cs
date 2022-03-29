using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public interface IDiagnosticSortAlgorithm : ISortAlgorithm
    {
        delegate void Compare(int first, int second);
        public event Compare CompareTwo;

        delegate void Swap(int first, int second);
        public event Swap SwapTwo;

        public int CompareCount { get;  }
        public int SwapCount { get;  }
    }
}
