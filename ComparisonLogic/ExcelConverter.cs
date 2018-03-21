using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;



namespace ComparisonLogic
{
    public class ExcelConverter : IConversion
    {

        public event Action<int> reportProgress;

        public void GenerateReport(DataTable data, List<Tuple<int, int>> differences, string outputPath)
        {

            XLWorkbook wb = new XLWorkbook();
            var workSheet = wb.Worksheets.Add(data, "Results");

            int count = data.Rows.Count / differences.Count * 100;
            reportProgress(count);

            foreach (var item in differences)
            {
                workSheet.Cell(item.Item1, item.Item2).Style.Fill.BackgroundColor = XLColor.Red;        
            }
            wb.SaveAs(outputPath);

        }


        public DataTable GetDataTable(string filePath)
        {


            DataSet ds = new DataSet();
            string constring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=\"Excel 12.0;HDR=YES;\"";

            OleDbConnection con = new OleDbConnection(constring);
            con.Open();


            DataTable obj = con.GetSchema("Tables");
            string tableName = "Sheet1";

            foreach (DataRow item in obj.Rows)
            {
                tableName = item["TABLE_NAME"].ToString();
            }

            string sqlquery = $"Select * From [{tableName}]";
            con.Close();

            OleDbDataAdapter da = new OleDbDataAdapter(sqlquery, con);

            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            return dt;

        }


    }
}
