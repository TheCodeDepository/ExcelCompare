using ClosedXML.Excel;
using GenericParsing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace SpreadsheetLogic
{
    public class TableImport
    {

        public bool hasHeader { get; set; }
        public string path { get; private set; }

        public TableImport(string filePath, bool hasHeader)
        {
            this.path = filePath;
            this.hasHeader = hasHeader;
        }

        public List<string> GetTableNames()
        {
            List<string> names = new List<string>();

            switch (Path.GetExtension(path))
            {
                case ".xlsx":
                    names = GetXlsxTablesNames();
                    break;

                case ".csv":
                    names = GetCSVTablesNames();
                    break;

                default:
                    names = GetSQLTablesNames();
                    break;
            }
            return names;
        }

        private List<string> GetCSVTablesNames()
        {
            var csv = new List<string>();
            csv.Add("Is .CSV");
            return csv;
        }

        private List<string> GetSQLTablesNames()
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(path))
            {
                using (SqlCommand command = new SqlCommand($"SELECT [TABLE_NAME] FROM information_schema.tables ORDER BY TABLE_NAME;", connection))
                {
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(table);
                }
            }
            List<string> names = new List<string>();
            foreach (DataRow i in table.Rows)
            {
                names.Add(i[0].ToString());
            }
            return names;
        }

        private List<string> GetXlsxTablesNames()
        {
            List<string> names = new List<string>();
            using (XLWorkbook ws = new XLWorkbook(path))
            {
                foreach (IXLWorksheet sheet in ws.Worksheets)
                {
                    names.Add(sheet.Name);
                }
            }
            return names;
        }

        public DataTable GetDataTable(string sheetName = null)
        {
            DataTable dataTable = new DataTable();

            switch (Path.GetExtension(path))
            {
                case ".xlsx":
                    dataTable = ImportXlsxTable(sheetName);
                    break;

                case ".csv":
                    dataTable = ImportCSVTable();
                    break;

                default:
                    dataTable = ImportSQLTable(sheetName);
                    break;

            }
            return dataTable;
        }

        private DataTable ImportCSVTable()
        {
            DataTable table;
            using (GenericParserAdapter parser = new GenericParserAdapter())
            {
                parser.ColumnDelimiter = ',';
                parser.SetDataSource(path);
                parser.FirstRowHasHeader = hasHeader;
                table = parser.GetDataTable();
            }
            return table;
        }

        private DataTable ImportXlsxTable(string sheetName)
        {
            DataTable table = new DataTable();
            using (XLWorkbook ws = new XLWorkbook(path))
            {
                var workSheet = ws.Worksheet(sheetName);
                bool nullTable = false;
                //Create a new DataTable.
                DataTable dt = new DataTable(workSheet.Name);
                //Loop through the Worksheet rows.
                if (!hasHeader)
                {
                    for (int i = 0; i < workSheet.ColumnsUsed().Count(); i++)
                    {
                        dt.Columns.Add($"Column{i}");
                    }
                }

                foreach (IXLRow row in workSheet.Rows())
                {
                    //Use the first row to add columns to DataTable.
                    if (hasHeader)
                    {
                        if (row.Cells().Count() < 2 || workSheet.RowsUsed().Count() < 2)
                        {
                            nullTable = true;
                            break;
                        }
                        for (int i = 1; i <= workSheet.ColumnsUsed().Count(); i++)
                        {
                            if (i <= row.CellsUsed().Count())
                            {
                                dt.Columns.Add(row.Cell(i).Value.ToString());
                            }
                            else
                            {
                                dt.Columns.Add($"Filler {i}");
                            }
                        }
                        hasHeader = false;
                    }
                    else
                    {
                        //Add rows to DataTable.
                        dt.Rows.Add();
                        int i = 0;
                        foreach (IXLCell cell in row.Cells())
                        {
                            dt.Rows[dt.Rows.Count - 1][i] = cell.Value.ToString();
                            i++;
                        }
                    }
                }
                if (!nullTable)
                {
                    table = dt;
                }

                return dt;
            }

        }

        private DataTable ImportSQLTable(string sheetName)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(path))
            {
                using (SqlCommand command = new SqlCommand($"SELECT * FROM [{sheetName}]", connection))
                {
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(table);
                }
            }
            return table;
        }
    }
}
