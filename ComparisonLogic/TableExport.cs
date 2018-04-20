using ClosedXML.Excel;
using CsvHelper;
using SpreadsheetLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace SpreadsheetImporter
{
    public class TableExport
    {
        public string outputPath { get; }
        public Format outputFormat { get; set; }
        public int tableIndex { get; set; }

        public DataSet workbook { get; }
        public IEnumerable<Cell> Cells { get; set; }

    

        public TableExport(string outputPath, DataTable worksheet)
        {
            this.outputPath = outputPath;
            workbook = new DataSet();
            this.workbook.Tables.Add(worksheet);
        }

        public TableExport(string outputPath, DataSet workbook)
        {
            this.outputPath = outputPath;
            this.workbook = workbook;

        }



        public void Export()
        {
            if (workbook != null)
            {
                if (!string.IsNullOrEmpty(outputFormat.ToString()))
                {
                    switch (outputFormat)
                    {
                        case Format.CSV:
                            ExportCsv();
                            break;
                        case Format.XLSX:
                            ExportXlsx();
                            break;
                    }
                }
                else
                {
                    string path = Path.GetExtension(outputPath);
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
            }
        }

      
        public void ExportCsv()
        {
            DataTable worksheet;

            if (tableIndex > 0)
            {
                worksheet = workbook.Tables[0];
            }
            else
            {
                worksheet = workbook.Tables[tableIndex];
            }
            using (var csv = new CsvWriter(new StreamWriter(outputPath, false)))
            {
                // Write columns
                foreach (DataColumn column in worksheet.Columns)
                {
                    csv.WriteField(column.ColumnName);
                }
                csv.NextRecord();

                // Write row values
                foreach (DataRow row in worksheet.Rows)
                {
                    for (var i = 0; i < worksheet.Columns.Count; i++)
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


    
        public void ExportXlsx()
        {

            XLWorkbook wb = new XLWorkbook();

            int sheetIndexer = 1;
            foreach (DataTable table in workbook.Tables)
            {
                if (!string.IsNullOrEmpty(table.TableName.ToString()))
                {
                    wb.Worksheets.Add(table, table.TableName);
                }
                else
                {
                    wb.Worksheets.Add(table, $"Sheet{sheetIndexer}");
                }
            }

            if (Cells != null)
            {
                int i = 0;
                foreach (IXLWorksheet ws in wb.Worksheets)
                {
                    
                    foreach (Cell cell in Cells)
                    {
                        wb.Worksheets.Worksheet(ws.Name).Cell((cell.x + 2), (cell.y + 1)).Style.Fill.BackgroundColor = XLColor.ForestGreen;
                    }
                    i++;
                }

            }
           
            wb.SaveAs(outputPath);

        }
        public void ExportXlsxWithColorCoding(ICollection<int> meDeletedRows, ICollection<int> meAddedRows)
        {

            XLWorkbook wb = new XLWorkbook();

            int sheetIndexer = 1;
            foreach (DataTable table in workbook.Tables)
            {
                if (!string.IsNullOrEmpty(table.TableName.ToString()))
                {
                    wb.Worksheets.Add(table, table.TableName);
                }
                else
                {
                    wb.Worksheets.Add(table, $"Sheet{sheetIndexer}");
                }
            }

            if (Cells != null)
            {
           
                foreach (IXLWorksheet ws in wb.Worksheets)
                {

                    foreach (Cell cell in Cells)
                    {
                        wb.Worksheets.Worksheet(ws.Name).Cell((cell.x + 2), (cell.y + 1)).Style.Fill.BackgroundColor = XLColor.ForestGreen;
                    }
                    foreach (var item in meDeletedRows)
                    {
                        wb.Worksheets.Worksheet(ws.Name).Row(item).Style.Fill.BackgroundColor = XLColor.Orange;
                    }
                    foreach (var item in meAddedRows)
                    {
                        wb.Worksheets.Worksheet(ws.Name).Row(item).Style.Fill.BackgroundColor = XLColor.Green;

                    }


                }

            }

            wb.SaveAs(outputPath);
        }
    }

   


public enum Format
    {
        CSV,
        XLSX
    }

}
