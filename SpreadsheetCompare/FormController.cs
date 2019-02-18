using System;
using System.Data;
using System.Threading;
using SpreadsheetLogic;
using System.DirectoryServices.AccountManagement;
using TableCompare;

namespace SpreadsheetCompare
{
    /// <summary>
    /// The form controller contains all the code the form needs to import compare and display the data.
    /// All logic that does not control form behaviour will be based here.
    /// Author: Martin White
    /// Date created:
    /// Last edit: 24/04/2018
    /// </summary>
    public class FormController
    {
        public ResultContext resultContext { get; set; }
        public DataSet workbookOne { get; set; }
        public DataSet workbookTwo { get; set; }
        public DataTable mergedView { get; set; }
        public DataTable tableOne { get; set; }
        public DataTable tableTwo { get; set; }
        public SortMethod sortMethod { get; set; }
        public int columnIndex { get; set; }
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
        public int SelectedSingleView
        {
            get { return Properties.Settings.Default.selectedSingleView; }
            set { Properties.Settings.Default.selectedSingleView = value; }
        }

        /// <summary>
        /// Background thread callback fields
        /// </summary>
        Thread backgroundThread;
        private event EventHandler<EventArgs> CompareComplete;

        /// <summary>
        /// "_compareComplete" Defines the callback method for the background thread. this will be called when the comparison method is complete.
        /// </summary>
        public FormController(EventHandler<EventArgs> _compareComplete)
        {
            CompareComplete = _compareComplete;
        }

        /// <summary>
        /// This is the entry point for the Compare process where it decides that method to use then deleigates it to a background thread.
        /// </summary>
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
            }
        }

        /// <summary>
        /// Returns a DataSet that contains all the tables and sheets of the target Datasource
        /// </summary>
        internal DataSet GetWorkBook(string path)
        {
            TableImport imp = new TableImport(path.ToLower(), hasHeader);
            DataSet wb = imp.GetDataSet();
            return wb;
        }

        /// <summary>
        ///Return only the first Datatable in the DataSet 
        /// </summary>
        /// <param name="path"></param>
        internal DataTable ReturnFirstDataTable(string path)
        {
            TableImport imp = new TableImport(path.ToLower(), hasHeader);
            DataSet tmp = imp.GetDataSet();
            return tmp.Tables[0];
        }

        /// <summary>
        /// Gets the DataTable from the DataSet using its index and returns it.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="workbook"></param>
        public DataTable GetTableByIndex(int index, DataSet workbook)
        {
            return workbook.Tables[index];
        }

        /// <summary>
        /// Exports Merged view to desired filepath 
        /// </summary>
        internal void ExportMergedTable(string path)
        {
            TableExport tableExport = new TableExport(path, mergedView, resultContext);
            tableExport.Export();
        }        

        /// <summary>
        /// Compare Cell by Cell using the cells index to compare it to another table. this assumes equal rows and columns
        /// </summary>
        internal void CompareTables()
        {
            if (tableOne != null && tableTwo != null)
            {
                CompareByCell comp = new CompareByCell(tableOne, tableTwo);
                resultContext = comp.CompareDateSets();
                mergedView = comp.MergeTables();                
                CompareComplete(this, EventArgs.Empty);
            }

        }

        /// <summary>
        /// Compare Tables row by rows getting back row change Data and Cell changes.
        /// </summary>
        internal void CompareTableRows()
        {
            if (tableOne.Columns.Count == tableTwo.Columns.Count)
            {
                if (tableOne != null && tableTwo != null)
                {
                    CompareByRow comp = new CompareByRow(tableOne, tableTwo, columnIndex);
                    resultContext = comp.CompareTables();
                    mergedView = comp.mergedView;                    
                    CompareComplete(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Validates the user is part of the bristsoft.co.uk Domain, if they are not then the application will exit.
        /// </summary>
        internal bool isValidDomain()
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
                isValid = false;
            }
            return isValid;

        }

        /// <summary>
        /// used to confirm tables are valid and actually contain some Data.
        /// </summary>
        internal bool AreTablesValid()
        {
            if (tableOne.Columns.Count == tableTwo.Columns.Count)
            {
                if (tableOne.Columns.Count < 1 || tableTwo.Columns.Count < 1)
                {
                    return false;
                }
                if (tableOne.Rows.Count < 1 || tableTwo.Rows.Count < 1)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Saves configuration which are altered by user imput for furture use.
        /// </summary>
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
