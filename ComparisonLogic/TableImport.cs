using ClosedXML.Excel;
using GenericParsing;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadsheetImporter
{
    public class TableImport
    {

        public bool HasHeader { get; set; }
        public string filePath { get; private set; }

        public void Dispose()
        {
            Dispose();
        }

        public DataSet GetDataSet(string filePath)
        {
            this.filePath = filePath;

            DataSet tmp = new DataSet();

            switch (Path.GetExtension(filePath))
            {
                case ".xlsx":
                    tmp = ImportExcel();
                    break;

                case ".csv":
                    tmp = ImportCSV();
                    break;

            }
            return tmp;
        }

        public ICollection<string> SheetNames(string path)
        {
            List<string> tmp = new List<string>();
            using (XLWorkbook ws = new XLWorkbook(path))
            {
                foreach (var item in ws.Worksheets)
                {
                    tmp.Add(item.Name);
                }
            }
            return tmp;
        }

        private DataSet ImportCSV()
        {
            DataSet tmp;
            using (GenericParserAdapter parser = new GenericParserAdapter())
            {
                parser.ColumnDelimiter = ',';
                parser.SetDataSource(filePath);
                parser.FirstRowHasHeader = HasHeader;
                tmp = parser.GetDataSet();
            }
            return tmp;
        }

        private DataSet ImportExcel()
        {
            using (XLWorkbook ws = new XLWorkbook(filePath))
            {
                DataSet ds = new DataSet(Path.GetFileNameWithoutExtension(filePath));
                //IXLWorksheet workSheet = ws.Worksheet(1);
                foreach (IXLWorksheet workSheet in ws.Worksheets)
                {

                    bool hasHeader = HasHeader;
                    bool nullTable = false;
                    //Create a new DataTable.
                    DataTable dt = new DataTable(workSheet.Name);
                    //Loop through the Worksheet rows.
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
                            foreach (IXLCell cell in row.Cells())
                            {
                                dt.Columns.Add(cell.Value.ToString());
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
                        ds.Tables.Add(dt);
                    }
                }
                return ds;
            }

        }

   
    }
}
