using System;
using System.Collections.Generic;
using System.Data;

namespace SpreadsheetLogic
{
    public interface IConvert
    {

        void WriteTable(DataTable data, IEnumerable<Cell> differences, string outputPath);
        DataTable ReadTable(string filePath);
    }
}
