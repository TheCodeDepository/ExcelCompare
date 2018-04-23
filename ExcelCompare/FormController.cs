using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading;
using ComparisonLogic;
using SpreadsheetImporter;
using SpreadsheetLogic;
using System.DirectoryServices.AccountManagement;

namespace ExcelCompare
{
    public class FormController
    {
        public (ICollection<Cell> coCells,
        ICollection<Cell> toCells,
        ICollection<Cell> meCells,
        ICollection<int> DeletedRows,
        ICollection<int> AddedRows,
        ICollection<int> meDeletedRows,
        ICollection<int> meAddedRows) ViewContext
        { get; private set; }
        public DataSet workbookOne { get; set; }
        public DataSet workbookTwo { get; set; }
        public DataTable mergedView { get; set; }
        public DataTable tableOne { get; set; }
        public DataTable tableTwo { get; set; }
        public int diffrenceCount { get; private set; }
        public ICollection<Cell> DiffLocations { get; private set; }


        public bool hasHeader
        {
            get { return Properties.Settings.Default.hasHeader; }
            set { Properties.Settings.Default.hasHeader = value; }
        }
        public bool GenerateSpreadsheet
        {
            get { return Properties.Settings.Default.generateSpreadsheet; }
            set { Properties.Settings.Default.generateSpreadsheet = value; }
        }
        public bool OpenSpreadsheet
        {
            get { return Properties.Settings.Default.openSpreadsheet; }
            set { Properties.Settings.Default.openSpreadsheet = value; }
        }
        public SortMethod sortMethod
        {
            get;
            set;
        }

        internal bool AreColumnsEqual()
        {
            if (tableOne.Columns.Count == tableTwo.Columns.Count)
            {
                return true;
            }
            return false;
        }

        public FormController(EventHandler<EventArgs> _compareComplete)
        {
            CompareComplete = _compareComplete;
        }


        /*Threading*/
        Thread backgroundThread;
        private event EventHandler<EventArgs> CompareComplete;


        public void CompareThreadGo()
        {
            switch (sortMethod)
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
            imp.HasHeader = hasHeader;
            DataSet wb = imp.GetDataSet(path);
            return wb;
        }
        internal DataTable GetDataTable(string docPathOne)
        {
            TableImport imp = new TableImport();
            imp.HasHeader = hasHeader;
            var tmp = imp.GetDataSet(docPathOne);
            return tmp.Tables[0];
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
            if (tableOne.Columns.Count == tableTwo.Columns.Count)
            {
                if (tableOne != null && tableTwo != null)
                {
                    CompareByRow comp = new CompareByRow(tableOne, tableTwo, 0);
                    comp.CompareTables();
                    ViewContext = (comp.CoCells, comp.ToCells, comp.MeCells, comp.compareDeletedRows, comp.toAddedRows, comp.mergedDeletedRows, comp.mergedAddedRows);
                    mergedView = comp.mergedView;
                    diffrenceCount = ViewContext.toCells.Count;
                    CompareComplete(this, EventArgs.Empty);

                }
            }


        }


        public void ExportMergedTable(string path)
        {
            TableExport tableExport = new TableExport(path, this.mergedView);
            tableExport.Cells = DiffLocations;
            tableExport.ExportXlsx();
        }

        public DataTable GetTableByIndex(int index, DataSet workbook)
        {
            return workbook.Tables[index];
        }



        internal void ExportMergedTableWithRowData(string outputPath)
        {
            TableExport tableExport = new TableExport(outputPath, mergedView);
            tableExport.Cells = ViewContext.meCells;
            tableExport.ExportXlsxWithColorCoding(ViewContext.meDeletedRows, ViewContext.meAddedRows);

        }

        internal bool ValidateDomain()
        {

            bool isValid = false;
            try
            {

                using (var domainContext = new PrincipalContext(ContextType.Domain, "britsoft.co.uk"))
                {
                    using (var foundUser = UserPrincipal.FindByIdentity(domainContext, IdentityType.SamAccountName, Environment.UserName))
                    {
                        if (foundUser != null)
                        {
                            isValid = true;

                        }
                    }
                }

            }
            catch (Exception)
            {


            }
            return isValid;

        }

        internal void SaveConfig()
        {
            Properties.Settings.Default.Save();
        }
    }
    public enum SortMethod
    {
        CellbyCell,
        RowByRow
    }
}
