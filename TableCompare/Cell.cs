using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableCompare
{
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
