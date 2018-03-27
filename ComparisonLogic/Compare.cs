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
            for (; rowIndex < hRowCount; rowIndex++)
            {
                string[] rowForInserting = new string[hColumnCount];
                int colIndex = 0;
                for (; colIndex < hColumnCount; colIndex++)
                {
                    string cellOne = compare.Rows[rowIndex][colIndex].ToString();
                    string cellTwo = to.Rows[rowIndex][colIndex].ToString();

                    if (cellOne != string.Empty)
                    {
                        rowForInserting[colIndex] = cellOne;
                    }
                    else
                    {
                        rowForInserting[colIndex] = cellTwo;
                    }
                }
                dt.Rows.Add(dt);
            }
            return dt;

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
