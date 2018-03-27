using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpreadsheetLogic;
using System.Data;

namespace UnitTests
{
    [TestClass]
    public class ComparisonLogicTests
    {
        [TestMethod]
        public void CsvConvert()
        {
            // arrange  
            DataTable actualTab;
            DataTable expectedTab;
            string[] actual;
            string[] expected;

            string path = @"C:\Users\mwhite\Documents\_A.csv";
            string refPath = @"C:\Users\mwhite\Documents\_A.xlsx";

            ConvertExcel excelConverter = new ConvertExcel();
            ConvertCSV csvConverter = new ConvertCSV();



            // act  
            expectedTab = excelConverter.ReadTable(refPath);
            actualTab = csvConverter.ReadTable(path);

            var firstRowExpect = expectedTab.Rows[0].ItemArray;
            var firstRowActual = actualTab.Rows[0].ItemArray;

            expected = new string[firstRowExpect.Length];
            actual = new string[firstRowActual.Length];

            for (int i = 0; i < firstRowActual.Length; i++)
            {
                expected[i] = firstRowExpect[i].ToString();
                actual[i] = firstRowActual[i].ToString();
            }



            // assert            
            Assert.AreEqual(expected[0], actual[0]);
        }
    }
}
