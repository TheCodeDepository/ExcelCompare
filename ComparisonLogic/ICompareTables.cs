using System.Data;

namespace SpreadsheetLogic
{
    interface ICompareTables
    {
        DataTable compare { get; }
        DataTable to { get; }
        DataTable mergedView { get;  }

    }
}
