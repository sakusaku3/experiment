using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace docks.model.table
{
	class CombinationCreator
	{
		private IList<Cell> cells;
		public CombinationCreator(IList<Cell> cells)
		{
			this.cells = cells;
		}

		public IList<Row> GetRows()
		{
			var t = new Table(this.cells);
			var rows = t.GetRowsWithoutBlank();
			var header = new Row(rows.Select(x => this.cloneCell(x.Cells[0])));
			var combinationRows = this.getRows(rows).ToList();
			combinationRows.Insert(0, header);
			return combinationRows;
		}

		private IEnumerable<Row> getRows(IList<Row> rows)
		{
			var rest = rows.Skip(1).ToArray();
			if (rest.Length != 0)
			{
				foreach (var c in rows[0].Cells.Skip(1))
				{
					foreach (var r in getRows(rest))
					{
						r.InsertPrevious(this.cloneCell(c));
						yield return r;
					}
				}
			}
			else
			{
				foreach (var c in rows[0].Cells.Skip(1))
				{
					yield return new Row(this.cloneCell(c));
				}
			}
		}

		private Cell cloneCell(Cell other)
		{
			return new Cell(other.Value, 0, 0) { BackgroundColor = other.BackgroundColor };
		}
	}
}
