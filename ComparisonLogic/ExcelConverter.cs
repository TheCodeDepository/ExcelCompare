using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;



namespace ComparisonLogic
{
    public class ExcelConverter : IConversion
    {


        public void GenerateReport(DataTable data, List<Tuple<int, int>> differences, string outputPath)
        {

            XLWorkbook wb = new XLWorkbook();
            var workSheet = wb.Worksheets.Add(data, "Results");
            foreach (var item in differences)
            {
                workSheet.Cell((item.Item1 + 2), (item.Item2 + 1)).Style.Fill.BackgroundColor = XLColor.Red;
            }
            wb.SaveAs(outputPath);

        }


        public DataTable GetDataTable(string filePath)
        {

            using (XLWorkbook ws = new XLWorkbook(filePath))
            {
                
                IXLWorksheet workSheet = ws.Worksheet(1);

                //Create a new DataTable.
                DataTable dt = new DataTable();

                //Loop through the Worksheet rows.
                bool firstRow = true;
                foreach (IXLRow row in workSheet.Rows())
                {
                    //Use the first row to add columns to DataTable.
                    if (firstRow)
                    {
                        foreach (IXLCell cell in row.Cells())
                        {
                            dt.Columns.Add(cell.Value.ToString());
                        }
                        firstRow = false;
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
                return dt;
            }


        }


    }
}
