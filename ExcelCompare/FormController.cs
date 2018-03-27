using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using SpreadsheetImporter;
using SpreadsheetLogic;

namespace ExcelCompare
{
    public class FormController
    {

        public DataSet workbookOne { get; set; }
        public DataSet workbookTwo { get; set; }

        public DataTable mergedView { get; set; }


        public DataTable tableOne { get; set; }
        public DataTable tableTwo { get; set; }

        public ICollection<Cell> DiffLocations { get; private set; }


        public event EventHandler<EventArgs> CompareComplete;
        public event EventHandler<EventArgs> ExportComplete;

        //public FormController(string filePathOne, string filePathTwo)
        //{
        //    pathOne = filePathOne;
        //    pathTwo = filePathTwo;
        //}


        internal DataSet GetWorkBook(string path)
        {
            TableImport imp = new TableImport();
            imp.HasHeader = true;
            DataSet wb = imp.GetDataSet(path);
            return wb;
        }

        internal ICollection<string> GetTables(string path)
        {
            TableImport imp = new TableImport();
            imp.HasHeader = true;
            return imp.SheetNames(path);
        }

        internal void CompareTables()
        {
            if (tableOne != null && tableTwo != null)
            {
                Compare comp = new Compare(tableOne, tableTwo);
                DiffLocations = comp.CompareDateSets();
                mergedView = comp.MergeTables();
                CompareComplete(this, EventArgs.Empty);
            }

        }

        public DataTable GetTableByIndex(int index,DataSet workbook)
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
}
