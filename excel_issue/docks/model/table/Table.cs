using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace docks.model.table
{
	class Table
	{
		private readonly IReadOnlyList<Cell> cells;

		public int MinRow { get; }
		public int MaxRow { get; }
		public int RowCount => this.MaxRow - this.MinRow + 1;

		public int MinColumn { get; }
		public int MaxColumn { get; }
		public int ColumnCount => this.MaxColumn - this.MinColumn + 1;

		public Table(IEnumerable<Cell> cells)
		{
			this.cells = new List<Cell>(cells);

			if (this.cells.Count == 0) return;
			this.MinRow = cells.Min(x => x.Row);
			this.MinColumn = cells.Min(x => x.Column);
			this.MaxRow = cells.Max(x => x.Row);
			this.MaxColumn = cells.Max(x => x.Column);
		}

		public IList<Row> GetRows()
		{
			return this.GetRowsCore(x => true);
		}

		public IList<Row> GetRowsWithoutBlank()
		{
			return this.GetRowsCore(x => !string.IsNullOrEmpty(x.Value));
		}

		private IList<Row> GetRowsCore(Predicate<Cell> rowPredicate)
		{
			return this.cells
				.GroupBy(x => x.Row)
				.OrderBy(x => x.Key)
				.Select(x => new Row(x.Where(y => rowPredicate(y)).OrderBy(y => y.Column).ToList()))
				.ToList();
		}
	}
}
