using System.Collections.Generic;
using System.Data;

namespace TableCompare
{
    public class CompareByCell : ICompareTables
    {
        private readonly int lColumnCount;
        private readonly int lRowCount;

        public DataTable compare { get; private set; }
        public DataTable to { get; private set; }
        public DataTable mergedView { get; private set; }

        public CompareByCell(DataTable Compare, DataTable To)
        {
            compare = Compare;
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

        public ResultContext CompareDateSets()
        {
            List<Cell> Cells = new List<Cell>();
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
                        Cells.Add(new Cell(rowIndex, colIndex));
                    }
                }
            }
            return new ResultContext(Cells,Cells,Cells);

            
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
