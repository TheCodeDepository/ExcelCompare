using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace ComparisonLogic
{
    public class CompareFiles
    {
        private string pathOne;
        private string pathTwo;
           
        public DataTable mergedResults { get; set; }
        public DataTable docOne { get; set; }
        public DataTable docTwo { get; set; }
        public List<Tuple<int, int>> DiffLocations { get; private set; }

        public CompareFiles(string filePathOne, string filePathTwo)
        {
            pathOne = filePathOne;
            pathTwo = filePathTwo;
        }

        public void Go()
        {
            docOne = GetDataTable(pathOne);
            docTwo = GetDataTable(pathTwo);
            mergedResults = CompareDateSets(docOne, docTwo);

        }



        private DataTable GetDataTable(string path)
        {
            string ext = Path.GetExtension(path);
            DataTable tmp = new DataTable();

            switch (ext)
            {
                case ".xlsx":
                    ExcelConverter xconverter = new ExcelConverter();
                    tmp = xconverter.GetDataTable(path);
                    break;

                case ".xls":
                    ExcelConverter exconverter = new ExcelConverter();
                    tmp = exconverter.GetDataTable(path);
                    break;

                case ".csv":
                    CsvConverter csvConverter = new CsvConverter();
                    tmp = csvConverter.GetDataTable(path);
                    break;

                case ".txt":
                    break;

            }
            return tmp;

        }

        public void GenerateReport(string outputPath)
        {
            IConversion converter;
            switch (Path.GetExtension(outputPath))
            {
                case ".xlsx":
                    converter = new ExcelConverter();
                    converter.GenerateReport(mergedResults, DiffLocations, outputPath);
                    break;

                case ".xls":
                    converter = new ExcelConverter();
                    converter.GenerateReport(mergedResults, DiffLocations, outputPath);
                    break;

                case ".csv":
                    converter = new CsvConverter();
                    converter.GenerateReport(mergedResults, DiffLocations, outputPath);
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

            DiffLocations = new List<Tuple<int, int>>();
            DataTable resultTable = new DataTable();
            foreach (var item in docOne.Columns)
            {
                resultTable.Columns.Add(item.ToString());
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
                    Tuple<int, int> diffLoc = new Tuple<int, int>(row, col);

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
                        if (docOneCell == docTwoCell)
                        {
                            tmpRow[col] = docOneCell;
                        }
                        else if (docOneCell != string.Empty)
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

                resultTable.Rows.Add(tmpRow);
            }


            return resultTable;
        }

    }
}
