using GenericParsing;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using CsvHelper;

namespace ComparisonLogic
{
    public class CsvConverter : IConversion
    {
        public event Action<int> reportProgress;

        public void GenerateReport(DataTable data, List<Tuple<int, int>> differences, string outputPath)
        {            

            using (var csv = new CsvWriter(new StreamWriter(outputPath, false)))
            {
                // Write columns
                foreach (DataColumn column in data.Columns)
                {
                    csv.WriteField(column.ColumnName);
                }
                csv.NextRecord();

                // Write row values

                int count = 0;
                int rowCount = data.Rows.Count;
                int onePercent = rowCount / 100;

                foreach (DataRow row in data.Rows)
                {
                    for (var i = 0; i < data.Columns.Count; i++)
                    {
                        if (row[i].ToString().StartsWith("0"))
                        {
                            csv.WriteField($"=\"{row[i]}\"");
                        }
                        else
                        {
                            csv.WriteField(row[i]);
                        }
                        if (rowCount % onePercent == 0)
                        {
                            reportProgress(count);
                        }
                    }
                    csv.NextRecord();
                }
            }

        }


        public DataTable GetDataTable(string filePath)
        {
            //StreamReader sr = new StreamReader(filePath, false);

            //DataTable personList = new DataTable();

            //using (var csv = new CsvReader(sr))
            //{
            //    foreach (var header in csv.Hea)
            //    {
            //        personList.Columns.Add(header);
            //    }

            //    while (csv.Read())
            //    {
            //        var row = personList.NewRow();
            //        foreach (DataColumn col in personList.Columns)
            //        {
            //            row[col.ColumnName] = csv.GetField(col.DataType, col.ColumnName);
            //        }
            //        personList.Rows.Add(row);
            //    }
            //}


            DataTable tmp;
            using (GenericParserAdapter parser = new GenericParserAdapter())
            {
                parser.ColumnDelimiter = ',';
                parser.SetDataSource(filePath);
                parser.FirstRowHasHeader = true;
                tmp = parser.GetDataTable();

            }
            return tmp;

        }
    }
}
