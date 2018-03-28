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

        private readonly int hColumnCount;
        private readonly int hRowCount;

        private DataTable compare { get; set; }
        private DataTable to { get; set; }

        public Compare(DataTable Compare, DataTable To)
        {
            this.compare = Compare;
            to = To;

            lRowCount = GetLowestRowCount();
            lColumnCount = GetLowestColumnCount();
            hRowCount = GetHighestRowCount();
            hColumnCount = GetHighestColumnCount();


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

        private void NormaliseTables()
        {
            int compColCount = compare.Columns.Count;
            int toColCount = to.Columns.Count;

            if (compColCount >= toColCount)
            {
                for (int i = 0; i < (compColCount - toColCount); i++)
                {
                    to.Columns.Add();
                }
            }
            else
            {
                for (int i = 0; i < (toColCount - compColCount); i++)
                {
                    to.Columns.Add();
                }
            }

            int compRowCount = compare.Rows.Count;
            int toRowCount = to.Rows.Count;

            if (compRowCount >= toRowCount)
            {
                for (int i = 0; i < (compRowCount - toRowCount); i++)
                {
                    to.Rows.Add();
                }
            }
            else
            {
                for (int i = 0; i < (toRowCount - compRowCount); i++)
                {
                    to.Rows.Add();
                }
            }

        }

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

        //public ICollection<Cell> CompareColumns()
        //{
            
        //    DataTable tmp = new DataTable();
        //    if (compare.Columns.Count > to.Columns.Count)
        //    {
        //        for (int i = 0; i < compare.Columns.Count; i++)
        //        {
        //            if (compare.Columns[i].ColumnName == to.Columns[i].ColumnName)
        //            {
        //                tmp.Columns.Add(compare.Columns[i]);
        //            }
        //            else 
        //            {
        //                if (compare.Columns.Contains(to.Columns[i].ColumnName))
        //                {
        //                    compare.Columns.IndexOf(compare.Columns[i]);
        //                }
        //            }
         

                    
        //        }
        //    }
        //    else if (compare.Columns.Count < to.Columns.Count)
        //    {

        //    }
        //    else
        //    {

        //    }
        //}

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

        private int GetHighestColumnCount()
        {
            int columnCountOne = compare.Columns.Count;
            int columnCountTwo = to.Columns.Count;

            int highest;

            if (columnCountOne >= columnCountTwo)
            {
                highest = columnCountOne;
            }
            else
            {
                highest = columnCountTwo;
            }
            return highest;
        }

        private int GetHighestRowCount()
        {
            int rowCountOne = compare.Rows.Count;
            int rowCountTwo = to.Rows.Count;
            int highest;

            if (rowCountOne >= rowCountTwo)
            {
                highest = rowCountOne;
            }
            else
            {
                highest = rowCountTwo;
            }

            return highest;
        }

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
