using TableCompare;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SpreadsheetCompare
{
    public class GridColorController
    {
        DataGridView me;
        DataGridView co;
        DataGridView to;
        DataGridView si;

        ResultContext result;

        public GridColorController(DataGridView Me, DataGridView Co, DataGridView To, DataGridView Si, ResultContext Result)
        {
            me = Me;
            co = Co;
            to = To;
            si = Si;
            result = Result;
        }
        public void PushColorsToTables()
        {
            PushMerged();
            PushSideBySide();
            SetGridViewSortState(me, DataGridViewColumnSortMode.NotSortable);
            SetGridViewSortState(co, DataGridViewColumnSortMode.NotSortable);
            SetGridViewSortState(to, DataGridViewColumnSortMode.NotSortable);

        }
        public void SetColumnWidth()
        {
            me.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            co.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            to.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public void PushSingleView(int index)
        {
            switch (index)
            {
    
                case 0:
                    PushCoView(si);
                    break;
                case 1:
                    PushToView(si);
                    break;
                default:
                    break;
            }
            SetGridViewSortState(si, DataGridViewColumnSortMode.NotSortable);

        }
        public void PushMerged()
        {
            if (result.meCells != null)
            {
                ProcessDifferences(me, result.meCells);
            }
            if (result.meDeletedRows != null)
            {
                ProcessDeletedRows(me, result.meDeletedRows);
            }
            if (result.meAddedRows != null)
            {
                ProcessNewRows(me, result.meAddedRows);
            }
        }
        public void PushSideBySide()
        {
            PushCoView(co);
            PushToView(to);
        }
        private void PushCoView(DataGridView gridView)
        {
            if (result.coCells != null)
            {
                ProcessDifferences(gridView, result.coCells);
            }
            if (result.deletedRows != null)
            {
                ProcessDeletedRows(gridView, result.deletedRows);
            }
        }
        private void PushToView(DataGridView gridView)
        {
            if (result.toCells != null)
            {
                ProcessDifferences(gridView, result.toCells);
            }
            if (result.addedRows != null)
            {
                ProcessNewRows(gridView, result.addedRows);
            }
        }
        private void ProcessNewRows(DataGridView grid, ICollection<int> indexList)
        {
            DataGridViewCellStyle diffStyle = new DataGridViewCellStyle();
            diffStyle.BackColor = Color.Green;
            diffStyle.ForeColor = Color.White;
            foreach (int item in indexList)
            {
                for (int i = 0; i < grid.ColumnCount; i++)
                {
                    grid.Rows[item].Cells[i].Style = diffStyle;
                }

            }
        }
        private void ProcessDeletedRows(DataGridView grid, ICollection<int> indexList)
        {
            DataGridViewCellStyle diffStyle = new DataGridViewCellStyle();
            diffStyle.BackColor = Color.Red;
            diffStyle.ForeColor = Color.White;
            foreach (int item in indexList)
            {
                for (int i = 0; i < grid.ColumnCount; i++)
                {
                    grid.Rows[item].Cells[i].Style = diffStyle;
                }

            }
        }
        private void SetGridViewSortState(DataGridView dgv, DataGridViewColumnSortMode sortMode)
        {
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.SortMode = sortMode;
            }
        }
        private void ProcessDifferences(DataGridView ResultView, ICollection<Cell> collection)
        {
            DataGridViewCellStyle diffStyle = new DataGridViewCellStyle();
            diffStyle.BackColor = Color.Orange;
            diffStyle.ForeColor = Color.Black;

            foreach (var item in collection)
            {
                ResultView.Rows[item.x].Cells[item.y].Style = diffStyle;
            }
        }
    }
}
