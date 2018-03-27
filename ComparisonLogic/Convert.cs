using System.Collections.Generic;
using System.Data;
using System.IO;

namespace SpreadsheetLogic
{
    public class Convert
    {
        public DataTable GetTable(string path)
        {
            IConvert converter;
            DataTable tmp = new DataTable();

            switch (Path.GetExtension(path))
            {
                case ".xlsx":
                    converter = new ConvertExcel();
                    tmp = converter.ReadTable(path);
                    break;

                case ".xls":
                    converter = new ConvertExcel();
                    tmp = converter.ReadTable(path);
                    break;

                case ".csv":
                    converter = new ConvertCSV();
                    tmp = converter.ReadTable(path);
                    break;

            }

            return tmp;

        }

        public void WriteTable(DataTable Data, IEnumerable<Cell> Differences, string outputPath)
        {
            IConvert converter;
            switch (Path.GetExtension(outputPath))
            {
                case ".xlsx":
                    converter = new ConvertExcel();
                    converter.WriteTable(Data, Differences, outputPath);
                    break;

                case ".xls":
                    converter = new ConvertExcel();
                    converter.WriteTable(Data, Differences, outputPath);

                    break;

                case ".csv":
                    converter = new ConvertCSV();
                    converter.WriteTable(Data, Differences, outputPath);

                    break;
            }

        }
    }
}
