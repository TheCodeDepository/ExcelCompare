using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;



namespace SpreadsheetLogic
{
    public class ConvertExcel : IConvert
    {




        public DataTable ReadTable(string filePath)
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
