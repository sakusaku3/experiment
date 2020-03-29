using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace docks.model.table
{
	class Row
	{
		public IReadOnlyList<Cell> Cells => this._cells;
		private List<Cell> _cells;

		public Row(Cell cell)
		{
			this._cells = new List<Cell>() { cell };
		}

		public Row(IEnumerable<Cell> cells)
		{
			this._cells = new List<Cell>(cells);
		}

		public void InsertPrevious(Cell cell)
		{
			this._cells.Insert(0, cell);
		}

		public void AddFollowing(Cell cell)
		{
			this._cells.Add(cell);
		}

		public void ResetRowNumber(int row)
		{
			this._cells.ForEach(x => x.Row = row);
		}

		public void ResetColumnNumber(int startColumn)
		{
			foreach ((var c, var i) in this._cells.Select((c, i) => (c, i)))
			{
				c.Column = startColumn + i;
			}
		}
	}
}
