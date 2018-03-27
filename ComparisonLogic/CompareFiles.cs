using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace SpreadsheetLogic
{
    public class CompareFiles
    {
        private string pathOne;
        private string pathTwo;

        public DataTable mergedResults { get; set; }
        public DataTable docOne { get; set; }
        public DataTable docTwo { get; set; }
        public List<Tuple<int, int>> DiffLocations { get; private set; }

        public event EventHandler<EventArgs> CompareComplete;
        public event EventHandler<EventArgs> ReportComplete;


        public CompareFiles(string filePathOne, string filePathTwo)
        {
            pathOne = filePathOne;
            pathTwo = filePathTwo;
        }

        public void CompareDocuments()
        {
            docOne = (pathOne);
            docTwo = GetDataTable(pathTwo);

            mergedResults = CompareDateSets(docOne, docTwo);

            if (CompareComplete != null)
                CompareComplete(this, EventArgs.Empty);
        }

        public bool AreFilesinUse()
        {
            //FileStream stream = null;
            //try
            //{
            //    stream = new FileStream(pathOne, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            //    stream = new FileStream(pathTwo, FileMode.Open, FileAccess.ReadWrite, FileShare.None);           

            //}
            //catch (IOException)
            //{
            //    //the file is unavailable because it is:
            //    //still being written to
            //    //or being processed by another thread
            //    //or does not exist (has already been processed)
            //    return true;
            //}
            //finally
            //{
            //    if (stream != null)
            //        stream.Close();
            //}
            return false;
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
                    docTwo.Columns.Add();
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
