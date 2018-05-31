using ClosedXML.Excel;
using CsvHelper;
using System.Data;
using System.IO;
using TableCompare;

namespace SpreadsheetLogic
{
    public class TableExport
    {
        public string outputPath { get; }
        public DataTable exportingTable { get; }
        private ResultContext resultContext { get; set; }

        public TableExport(string outputPath, DataTable worksheet, ResultContext ResultContext)
        {
            this.outputPath = outputPath;
            exportingTable = worksheet;
            resultContext = ResultContext;
        }
        public void Export()
        {
            string path = Path.GetExtension(outputPath).ToLower();
            switch (path)
            {
                case ".csv":
                    ExportCsv();
                    break;
                case ".xlsx":
                    ExportXlsx();
                    break;
            }
        }
        private void ExportCsv()
        {
            using (var csv = new CsvWriter(new StreamWriter(outputPath, false)))
            {
                // Write columns
                foreach (DataColumn column in exportingTable.Columns)
                {
                    csv.WriteField(column.ColumnName);
                }
                csv.NextRecord();

                // Write row values
                foreach (DataRow row in exportingTable.Rows)
                {
                    for (var i = 0; i < exportingTable.Columns.Count; i++)
                    {
                        if (row[i].ToString().StartsWith("0"))
                        {
                            csv.WriteField($"=\"{row[i]}\"");
                        }
                        else
                        {
                            csv.WriteField(row[i]);
                        }
                    }
                    csv.NextRecord();
                }
            }
        }
        private void ExportXlsx()
        {
            XLWorkbook wb = new XLWorkbook();
            if (!string.IsNullOrEmpty(exportingTable.TableName.ToString()))
            {
                wb.Worksheets.Add(exportingTable, exportingTable.TableName);
            }
            else
            {
                wb.Worksheets.Add(exportingTable, $"Results");
            }

            if (resultContext != null)
            {

                foreach (IXLWorksheet ws in wb.Worksheets)
                {
                    if (resultContext.meCells != null)
                    {
                        foreach (Cell cell in resultContext.meCells)
                        {
                            wb.Worksheets.Worksheet(ws.Name).Cell((cell.x + 2), (cell.y + 1)).Style.Fill.BackgroundColor = XLColor.Orange;
                        }
                    }

                    if (resultContext.meDeletedRows != null)
                    {
                        foreach (var item in resultContext.meDeletedRows)
                        {
                            for (int i = 1; i <= exportingTable.Columns.Count; i++)
                            {
                                wb.Worksheets.Worksheet(ws.Name).Cell(item + 2, i).Style.Fill.BackgroundColor = XLColor.Red;
                            }
                        }
                    }

                    if (resultContext.meAddedRows != null)
                    {
                        foreach (var item in resultContext.meAddedRows)
                        {
                            for (int i = 1; i <= exportingTable.Columns.Count; i++)
                            {
                                wb.Worksheets.Worksheet(ws.Name).Cell(item + 2, i).Style.Fill.BackgroundColor = XLColor.Green;
                            }
                        }
                    }

                }
            }
            wb.SaveAs(outputPath);
        }
    }
}
