using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComparisonLogic;
using System.Data;

namespace ExcelCompare
{
    public class CompareFiles
    {
        private string pathOne;
        private string pathTwo;
        private string outputPath;
        private string outputFormat;

        public List<Tuple<int, int>> DiffLocations { get; private set; }

        public CompareFiles(string filePathOne, string filePathTwo, string outputFilePath, string outputType)
        {
            pathOne = filePathOne;
            pathTwo = filePathTwo;
            outputPath = outputFilePath;
            outputFormat = outputType;

            DiffLocations = new List<Tuple<int, int>>();
            outputFormat = Path.GetExtension(filePathOne);
        }


        public void Compare()
        {
            string fileExtOne = Path.GetExtension(pathOne);

            if (fileExtOne == Path.GetExtension(pathTwo))
            {
                DataTable tmp = new DataTable();


                switch (fileExtOne)
                {
                    case ".xlsx":
                        ExcelConverter xconverter = new ExcelConverter();
                        tmp = CompareDateSets(xconverter.GetDataTable(pathOne), xconverter.GetDataTable(pathTwo));
                        break;

                    case ".xls":
                        CsvConverter csvConverter = new CsvConverter();
                        tmp = CompareDateSets(csvConverter.GetDataTable(pathOne), csvConverter.GetDataTable(pathTwo));
                        break;

                    case ".csv":
                        break;
                    case ".txt":
                        break;
                    default:
                        break;
                }

                GenerateReport(tmp);
            }
        }

        private void GenerateReport(DataTable data)
        {
            switch (outputFormat)
            {
                case ".xlsx":
                    ExcelConverter converter = new ExcelConverter();
                    converter.GenerateXlsx(data, DiffLocations, outputPath);
                    break;
                case ".csv":


                    break;
                default:
                    break;
            }

        }

        private DataTable CompareDateSets(DataTable docOne, DataTable docTwo)
        {
            int docOneCol = docOne.Columns.Count;
            int docTwoCol = docTwo.Columns.Count;
            int docOneRow = docOne.Rows.Count;
            int docTwoRow = docTwo.Rows.Count;
            int rowNum;

            if (docOneRow >= docTwoRow)
            {
                rowNum = docOneRow;
                for (int i = 0; i < (rowNum - docTwoRow); i++)
                {
                    docTwo.Rows.Add();
                }
            }
            else
            {
                rowNum = docTwoRow;
                for (int i = 0; i < (rowNum - docOneRow); i++)
                {
                    docOne.Rows.Add();
                }
            }

            int colNum;
            if (docOneCol >= docTwoCol)
            {
                colNum = docOneCol;
                for (int i = 0; i < (colNum - docTwoCol); i++)
                {
                    docTwo.Rows.Add();
                }
            }
            else
            {
                colNum = docTwoCol;
                for (int i = 0; i < (colNum - docOneCol); i++)
                {
                    docOne.Columns.Add();
                }
            }


            DataTable tmp = new DataTable();
            foreach (var item in docOne.Columns)
            {
                tmp.Columns.Add(item.ToString());
            }

            for (int row = 0; row < rowNum; row++)
            {
                var rowOne = docOne.Rows[row].ItemArray;
                var rowTwo = docTwo.Rows[row].ItemArray;
                string[] tmpRow = new string[colNum];

                for (int col = 0; col < colNum; col++)
                {
                    string docOneCell = rowOne[col].ToString();
                    string docTwoCell = rowTwo[col].ToString();
                    Tuple<int, int> diffLoc = new Tuple<int, int>((row + 1), (col + 1));

                    if (docOneCell != string.Empty && docTwoCell != string.Empty)
                    {
                        if (docOneCell == docTwoCell)
                        {
                            tmpRow[col] = docOneCell;
                        }
                        else
                        {
                            tmpRow[col] = docOneCell;
                            DiffLocations.Add(diffLoc);
                        }
                    }
                    else
                    {

                        if (docOneCell != string.Empty)
                        {
                            tmpRow[col] = docOneCell;
                            DiffLocations.Add(diffLoc);
                        }
                        else if (docTwoCell != string.Empty)
                        {
                            tmpRow[col] = docTwoCell;
                            DiffLocations.Add(diffLoc);
                        }
                    }

                }

                tmp.Rows.Add(tmpRow);
            }

            return tmp;
        }

    }
}
