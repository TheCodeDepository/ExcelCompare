using SpreadsheetLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparisonLogic
{
    public class CompareByRow : ICompareTables
    {
        public CompareByRow(DataTable compare, DataTable to, int referenceColumnIndex)
        {
            this.compare = compare;
            this.to = to;
            this.RefColIndex = referenceColumnIndex;

            CoCells = new List<Cell>();
            ToCells = new List<Cell>();
            MeCells = new List<Cell>();

            compareDeletedRows = new List<int>();
            toAddedRows = new List<int>();
            mergedDeletedRows = new List<int>();
            mergedAddedRows = new List<int>();
        }

        public DataTable compare { get; private set; }

        public DataTable to { get; private set; }

        public DataTable mergedView { get; private set; }

        public int RefColIndex { get; set; }


        public List<Cell> CoCells { get; private set; }
        public List<Cell> ToCells { get; private set; }
        public List<Cell> MeCells { get; private set; }

        public List<int> compareDeletedRows { get; private set; }
        public List<int> toAddedRows { get; private set; }
        public List<int> mergedDeletedRows { get; private set; }
        public List<int> mergedAddedRows { get; private set; }

        public void CompareTables()
        {
            mergedView = to.Copy();
            DeletedRowsAndTables();
            string lastindex = to.Rows[0][0].ToString();
            int lastMeRow = 0;


            foreach (DataRow toRow in to.Rows)
            {

                bool exists = false;
                string toI = toRow[RefColIndex].ToString();
                foreach (DataRow coRow in compare.Rows)
                {
                    if (toI == coRow[RefColIndex].ToString())
                    {
                        lastindex = toI;
                        exists = true;
                        break;
                    }

                }
                if (!exists)
                {
                    for (int i = lastMeRow; i < mergedView.Rows.Count; i++)
                    {
                        if (mergedView.Rows[i][0].ToString() == lastindex)
                        {
                            mergedAddedRows.Add((i + 1));
                            lastMeRow = to.Rows.IndexOf(toRow);
                            lastindex = mergedView.Rows[i + 1][0].ToString();
                            break;
                        }
                    }

                    toAddedRows.Add(to.Rows.IndexOf(toRow));
                }
            }
        }

        private void DeletedRowsAndTables()
        {
            int numOfColumns = compare.Columns.Count;
            int lastCommonRecord = 0;
            int mergeIndex = 0;
            bool exists = false;

            foreach (DataRow coRow in compare.Rows)
            {

                foreach (DataRow toRow in to.Rows)
                {

                    if (coRow[RefColIndex].ToString() == toRow[RefColIndex].ToString())
                    {
                        exists = true;
                        lastCommonRecord = to.Rows.IndexOf(toRow);

                        for (int i = 0; i < numOfColumns; i++)
                        {

                            if (coRow[i].ToString() != toRow[i].ToString())
                            {
                                CoCells.Add(new Cell(compare.Rows.IndexOf(coRow), i));
                                ToCells.Add(new Cell(lastCommonRecord, i));
                                MeCells.Add(new Cell(lastCommonRecord + mergeIndex, i));
                            }

                        }
                        break;

                    }
                }

                if (!exists)
                {

                    DataRow newRow = mergedView.NewRow();
                    newRow.ItemArray = coRow.ItemArray;

                    mergeIndex++;
                    mergedView.Rows.InsertAt(newRow, lastCommonRecord + mergeIndex);
                    mergedDeletedRows.Add(lastCommonRecord + mergeIndex);

                    compareDeletedRows.Add(compare.Rows.IndexOf(coRow));
                    lastCommonRecord++;
                }
                exists = false;
            }
        }
    }
}
