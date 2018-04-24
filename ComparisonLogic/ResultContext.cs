using System.Collections.Generic;

namespace SpreadsheetLogic
{
    public class ResultContext
    {
        public ResultContext(ICollection<Cell> coCells,
        ICollection<Cell> toCells,
        ICollection<Cell> meCells,
        ICollection<int> deletedRows,
        ICollection<int> addedRows,
        ICollection<int> meDeletedRows,
        ICollection<int> meAddedRows)
        {
            this.coCells = coCells;
            this.toCells = toCells;
            this.meCells = meCells;
            this.deletedRows = deletedRows;
            this.addedRows = addedRows;
            this.meDeletedRows = meDeletedRows;
            this.meAddedRows = meAddedRows;
        }

        public ResultContext(ICollection<Cell> coCells, ICollection<Cell> toCells, ICollection<Cell> meCells)
        {
            this.coCells = coCells;
            this.toCells = toCells;
            this.meCells = meCells;
        }

        public ICollection<Cell> coCells { get; private set; }
        public ICollection<Cell> toCells { get; private set; }
        public ICollection<Cell> meCells { get; private set; }
        public ICollection<int> deletedRows { get; private set; }
        public ICollection<int> addedRows { get; private set; }
        public ICollection<int> meDeletedRows { get; private set; }
        public ICollection<int> meAddedRows { get; private set; }

    }
}
