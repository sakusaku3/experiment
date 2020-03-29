using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using view_base.ViewModel;

namespace docks.viewmodel.Tabs
{
	public class MatrixViewModel : ViewModelBase
	{

		public string SelectedField
		{
			get { return this._selectedField; }
			set { this.SetProperty(ref this._selectedField, value); }
		}
		private string _selectedField;

		public int OutStartRow
		{
			get { return this._outStartRow; }
			set { this.SetProperty(ref this._outStartRow, value); }
		}
		private int _outStartRow;

		public int OutStartColumn
		{
			get { return this._outStartColumn; }
			set { this.SetProperty(ref this._outStartColumn, value); }
		}
		private int _outStartColumn;

		private DelegateCommand _getSelectedCommand;
		public DelegateCommand GetSelectedCommand =>
			this._getSelectedCommand ?? 
			(this._getSelectedCommand = new DelegateCommand(
				() => this.displaySelectedField(), 
				() => true));

		private DelegateCommand _createTableCommand;
		public DelegateCommand CreateTableCommand =>
			this._createTableCommand ?? 
			(this._createTableCommand = new DelegateCommand(
				() => this.createTable(), 
				() => true));

        private readonly IExcelControlService excelControl;

		public MatrixViewModel(
			IExcelControlService excelControl)
		{
			this.excelControl = excelControl;
		}

		private void displaySelectedField()
		{
			var cells = this.excelControl.GetSelectedRange();

			if (cells.Count == 0)
			{
				this.SelectedField = "";
				return;
			}

			var minRow = cells.Min(x => x.Row);
			var minColumn = cells.Min(x => x.Column);
			var maxRow = cells.Max(x => x.Row);
			var maxColumn = cells.Max(x => x.Column);

			this.SelectedField = $"(r:{minRow},c:{minColumn})=>(r:{maxRow},c:{maxColumn})";
		}

		private void createTable()
		{
			var cells = this.excelControl.GetSelectedRange();

			if (cells.Count == 0)
			{
				this.SelectedField = "";
				return;
			}

			var cc = new model.table.CombinationCreator(cells);
			var rows = cc.GetRows();

			foreach ((var r, var i) in rows.Select((r, i) => (r, i)))
			{
				r.ResetRowNumber(i + this.OutStartRow);
				r.ResetColumnNumber(this.OutStartColumn);
			}

			var allCells = rows.SelectMany(x => x.Cells).ToList();

			this.excelControl.SetTable(allCells);
		}
	}
}
