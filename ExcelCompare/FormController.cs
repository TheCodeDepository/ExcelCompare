using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading;
using ComparisonLogic;
using SpreadsheetImporter;
using SpreadsheetLogic;

namespace ExcelCompare
{
    public class FormController
    {

        public DataSet workbookOne { get; set; }
        public DataSet workbookTwo { get; set; }
        public DataTable mergedView { get; set; }
        public bool GenerateSpreadsheet { get; set; }
        public bool OpenSpreadsheet { get; set; }
        public DataTable tableOne { get; set; }
        public DataTable tableTwo { get; set; }
        public int diffrenceCount { get; private set; }
        public ICollection<Cell> DiffLocations { get; private set; }

        public (ICollection<Cell> coCells,
                ICollection<Cell> toCells,
                ICollection<Cell> meCells,
                ICollection<int> DeletedRows,
                ICollection<int> AddedRows,
                ICollection<int> meDeletedRows,
                ICollection<int> meAddedRows)
            differencesID
        { get; private set; }
        public int idIndex { get; private set; }

        public FormController(EventHandler<EventArgs> _compareComplete)
        {
            CompareComplete = _compareComplete;
        }


        /*Threading*/
        Thread backgroundThread;
        private event EventHandler<EventArgs> CompareComplete;


        public void CompareThreadGo(SortMethod method)
        {
            switch (method)
            {
                case SortMethod.CellbyCell:
                    backgroundThread = new Thread(new ThreadStart(CompareTables));
                    backgroundThread.Start();
                    break;
                case SortMethod.RowByRow:
                    backgroundThread = new Thread(new ThreadStart(CompareTableRows));
                    backgroundThread.Start();
                    break;
                default:
                    break;
            }

        }


        internal DataSet GetWorkBook(string path)
        {
            TableImport imp = new TableImport();
            imp.HasHeader = true;
            DataSet wb = imp.GetDataSet(path);
            return wb;
        }

        internal void CompareTables()
        {
            if (tableOne != null && tableTwo != null)
            {
                Compare comp = new Compare(tableOne, tableTwo);
                DiffLocations = comp.CompareDateSets();
                mergedView = comp.MergeTables();
                diffrenceCount = DiffLocations.Count;

                CompareComplete(this, EventArgs.Empty);

            }

        }

        internal void CompareTableRows()
        {
            if (tableOne != null && tableTwo != null)
            {
                CompareByRow comp = new CompareByRow(tableOne, tableTwo, 0);
                comp.CompareTables();
                differencesID = (comp.CoCells, comp.ToCells, comp.MeCells, comp.compareDeletedRows, comp.toAddedRows, comp.mergedDeletedRows, comp.mergedAddedRows);             
                mergedView = comp.mergedView;
                diffrenceCount = differencesID.toCells.Count;
                CompareComplete(this, EventArgs.Empty);
            }
        }


        public void ExportMergedTable(string path)
        {
            TableExport tableExport = new TableExport(path, this.mergedView);
            tableExport.differencesArr = new IEnumerable<Cell>[1];
            tableExport.differencesArr[0] = DiffLocations;
            tableExport.ExportXlsx();
        }

        public DataTable GetTableByIndex(int index, DataSet workbook)
        {
            return workbook.Tables[index];
        }

        internal DataTable GetDataTable(string docPathOne)
        {
            TableImport imp = new TableImport();
            imp.HasHeader = true;
            var tmp = imp.GetDataSet(docPathOne);
            return tmp.Tables[0];
        }


    }
    public enum SortMethod
    {
        CellbyCell,
        RowByRow
    }
}
