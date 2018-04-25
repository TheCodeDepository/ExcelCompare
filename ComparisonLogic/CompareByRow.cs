using System.Collections.Generic;
using System.Data;

namespace SpreadsheetLogic
{
    /// <summary>
    /// This Class contain the logic that compare both the "Compare" and "To" documents together outputting lists of indexes that corresponding with changes on the table.
    /// The merged view is also generated here simultaneously for use on the Form.
    /// </summary>
    public class CompareByRow : ICompareTables
    {
        public DataTable compare { get; private set; }
        public DataTable to { get; private set; }
        public DataTable mergedView { get; private set; }
        public int RefColIndex { get; set; }

        public List<Cell> coCells { get; private set; }
        public List<Cell> toCells { get; private set; }
        public List<Cell> meCells { get; private set; }

        public List<int> coDeletedRows { get; private set; }
        public List<int> toAddedRows { get; private set; }
        public List<int> meDeletedRows { get; private set; }
        public List<int> meAddedRows { get; private set; }

        public CompareByRow(DataTable compare, DataTable to, int referenceColumnIndex)
        {
            this.compare = compare;
            this.to = to;
            this.RefColIndex = referenceColumnIndex;

            coCells = new List<Cell>();
            toCells = new List<Cell>();
            meCells = new List<Cell>();

            coDeletedRows = new List<int>();
            toAddedRows = new List<int>();
            meDeletedRows = new List<int>();
            meAddedRows = new List<int>();
        }

        public ResultContext CompareTables()
        {
            mergedView = to.Copy();
            DeletedRowsAndTables();
            string lastindex = to.Rows[0][RefColIndex].ToString();
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
                        if (mergedView.Rows[i][RefColIndex].ToString() == lastindex)
                        {
                            meAddedRows.Add((i + 1));
                            lastMeRow = to.Rows.IndexOf(toRow);
                            lastindex = mergedView.Rows[i + 1][RefColIndex].ToString();
                            break;
                        }
                    }

                    toAddedRows.Add(to.Rows.IndexOf(toRow));
                }
            }
            return new ResultContext(coCells, toCells, meCells, coDeletedRows, toAddedRows, meDeletedRows, meAddedRows);
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
                                coCells.Add(new Cell(compare.Rows.IndexOf(coRow), i));
                                toCells.Add(new Cell(lastCommonRecord, i));
                                meCells.Add(new Cell(lastCommonRecord + mergeIndex, i));
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
                    meDeletedRows.Add(lastCommonRecord + mergeIndex);

                    coDeletedRows.Add(compare.Rows.IndexOf(coRow));
                    lastCommonRecord++;
                }
                exists = false;
            }
        }
    }
}
