using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadsheetLogic
{
    public class Compare
    {
        private readonly int lColumnCount;
        private readonly int lRowCount;

        private DataTable compare { get; set; }
        private DataTable to { get; set; }
        public DataTable mergedView { get; private set; }

        public Compare(DataTable Compare, DataTable To)
        {
            this.compare = Compare;
            to = To;

            lRowCount = GetLowestRowCount();
            lColumnCount = GetLowestColumnCount();
        }

        public DataTable MergeTables()
        {
            DataTable dt = GetTableWithAllHeaders();
            int rowIndex = 0;
            for (; rowIndex < lRowCount; rowIndex++)
            {
                dt.Rows.Add();
                int colIndex = 0;
                for (; colIndex < lColumnCount; colIndex++)
                {
                    string cellOne = compare.Rows[rowIndex][colIndex].ToString();
                    string cellTwo = to.Rows[rowIndex][colIndex].ToString();


                    if (cellOne != string.Empty)
                    {
                        dt.Rows[rowIndex][colIndex] = cellOne;
                    }
                    else
                    {
                        dt.Rows[rowIndex][colIndex] = cellTwo;
                    }
                }
            }

            return dt;

        }

        //public (ICollection<Cell> CompareDifferences, ICollection<Cell> ToDifferences, ICollection<int> DeletedRows, ICollection<int>AddedRows ,ICollection<Cell> mergedDiffCells, ICollection<int> mergedDeletedRows, ICollection<int> mergedAddedRows) CompareDateSetsByID(int idColIndex)
        //{
        //    mergedView = to.Copy();

        //    List<Cell> compareDiffCells = new List<Cell>();
        //    List<Cell> ToDiffCells = new List<Cell>();
        //    List<int> compareDeletedRows = new List<int>();
        //    List<int> toAddedRows = new List<int>();

        //    List<Cell> mergedDiffCells = new List<Cell>();
        //    List<int> mergedDeletedRows = new List<int>();
        //    List<int> mergedAddedRows = new List<int>();

        //    int lastCommonRecord = 0;
        //    int mergeIndex = 0;

        //    foreach (DataRow row in compare.Rows)
        //    {              
        //        bool exists = false;
        //        foreach (DataRow toRow in to.Rows)
        //        {
        //            if (row[idColIndex].ToString() == toRow[idColIndex].ToString())
        //            {
        //                exists = true;
        //                lastCommonRecord = to.Rows.IndexOf(toRow);
        //                for (int i = 0; i < lColumnCount; i++)
        //                {
        //                    if (row[i].ToString() != toRow[i].ToString())
        //                    {
        //                        compareDiffCells.Add(new Cell(compare.Rows.IndexOf(row), i));
        //                        ToDiffCells.Add(new Cell(to.Rows.IndexOf(toRow), i));
        //                        mergedDiffCells.Add(new Cell(lastCommonRecord,i));
        //                    }
        //                }
        //                break;
        //            }
        //        }

        //        if (!exists)
        //        {

        //            DataRow newRow = mergedView.NewRow();
        //            newRow.ItemArray = row.ItemArray;
        //            compareDeletedRows.Add(compare.Rows.IndexOf(row));
        //            mergeIndex++;
        //            mergedDeletedRows.Add(compare.Rows.IndexOf(row) + mergeIndex);
        //            mergedView.Rows.InsertAt(newRow, lastCommonRecord);
                    
        //            lastCommonRecord++;
        //        }
        //    }  
            
        //    foreach (DataRow toRow in to.Rows)
        //    {
        //        bool exists = false;
        //        foreach (DataRow coRow in compare.Rows)
        //        {
        //            if (toRow[idColIndex].ToString() == coRow[idColIndex].ToString())
        //            {
                        
        //                exists = true;
        //                break;
        //            }

        //        }
        //        if (!exists)
        //        {
        //            mergedAddedRows.Add();
        //            toAddedRows.Add(to.Rows.IndexOf(toRow));
        //        }
        //    }
        //    return (compareDiffCells, ToDiffCells, compareDeletedRows, toAddedRows, mergedDiffCells,mergedAddedRows,mergedDeletedRows);                
        //}

        private DataTable GetTableWithAllHeaders()
        {
            DataTable dt = new DataTable();

            if (compare.Columns.Count >= to.Columns.Count)
            {
                foreach (var item in compare.Columns)
                {
                    dt.Columns.Add(item.ToString());
                }
            }
            else
            {
                foreach (var item in to.Columns)
                {
                    dt.Columns.Add(item.ToString());
                }
            }

            return dt;
        }

        public ICollection<Cell> CompareDateSets()
        {
            var tempListOfCells = new List<Cell>();
            int rowIndex = 0;
            for (; rowIndex < lRowCount; rowIndex++)
            {
                int colIndex = 0;
                for (; colIndex < lColumnCount; colIndex++)
                {
                    string cellOne = compare.Rows[rowIndex][colIndex].ToString();
                    string cellTwo = to.Rows[rowIndex][colIndex].ToString();

                    if (cellOne != cellTwo)
                    {
                        tempListOfCells.Add(new Cell(rowIndex, colIndex));
                    }
                }
            }
            return tempListOfCells;
        }

        private int GetLowestColumnCount()
        {
            int columnCountOne = compare.Columns.Count;
            int columnCountTwo = to.Columns.Count;

            int lowest;

            if (columnCountOne <= columnCountTwo)
            {
                lowest = columnCountOne;
            }
            else
            {
                lowest = columnCountTwo;
            }
            return lowest;
        }

        private int GetLowestRowCount()
        {
            int rowCountOne = compare.Rows.Count;
            int rowCountTwo = to.Rows.Count;
            int lowest;

            if (rowCountOne <= rowCountTwo)
            {
                lowest = rowCountOne;
            }
            else
            {
                lowest = rowCountTwo;
            }

            return lowest;
        }

        //private void NormaliseTables()
        //{
        //    int compColCount = compare.Columns.Count;
        //    int toColCount = to.Columns.Count;

        //    if (compColCount >= toColCount)
        //    {
        //        for (int i = 0; i < (compColCount - toColCount); i++)
        //        {
        //            to.Columns.Add();
        //        }
        //    }
        //    else
        //    {
        //        for (int i = 0; i < (toColCount - compColCount); i++)
        //        {
        //            to.Columns.Add();
        //        }
        //    }

        //    int compRowCount = compare.Rows.Count;
        //    int toRowCount = to.Rows.Count;

        //    if (compRowCount >= toRowCount)
        //    {
        //        for (int i = 0; i < (compRowCount - toRowCount); i++)
        //        {
        //            to.Rows.Add();
        //        }
        //    }
        //    else
        //    {
        //        for (int i = 0; i < (toRowCount - compRowCount); i++)
        //        {
        //            to.Rows.Add();
        //        }
        //    }

        //}

    }

    public class Cell
    {
        public Cell(int X, int Y)
        {
            x = X;
            y = Y;
        }
        public int x { get; }
        public int y { get; }
    }
}
