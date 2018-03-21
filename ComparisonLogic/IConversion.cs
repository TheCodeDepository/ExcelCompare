using System;
using System.Collections.Generic;
using System.Data;

namespace ComparisonLogic
{
    public interface IConversion
    {
        event Action<int> reportProgress;
        void GenerateReport(DataTable data, List<Tuple<int, int>> differences, string outputPath);
        DataTable GetDataTable(string filePath);
    }
}
