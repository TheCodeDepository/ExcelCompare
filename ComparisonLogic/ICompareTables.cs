using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparisonLogic
{
    interface ICompareTables
    {
        DataTable compare { get; }
        DataTable to { get; }
        DataTable mergedView { get;  }

        void CompareTables();

    }
}
