using System.Data;

namespace TableCompare
{
    interface ICompareTables
    {
        DataTable compare { get; }
        DataTable to { get; }
        DataTable mergedView { get;  }

    }
}
