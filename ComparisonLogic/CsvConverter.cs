using GenericParsing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparisonLogic
{
    public class CsvConverter
    {
        public void GenerateXlsx(DataTable data, List<Tuple<int, int>> differences, string outputPath)
        {

        }


        public DataTable GetDataTable(string filePath)
        {
            DataSet tmp;
            using (GenericParserAdapter parser = new GenericParserAdapter("MyData.txt"))
            {
                parser.Load(filePath);
                tmp = parser.GetDataSet();
            }
            return tmp.Tables[0];


        }
    }
}
