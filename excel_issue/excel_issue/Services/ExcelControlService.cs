using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using e = Microsoft.Office.Interop.Excel;

namespace excel_issue.Services
{
	class ExcelControlService : docks.IExcelControlService
	{
		private e.Application app;

		private readonly static int maxRow = 500;
		private readonly static int maxColumn = 500;

		public ExcelControlService()
		{
			this.app = Globals.ThisAddIn.Application;
		}

		private e.Workbook GetCurrentBook()
		{
			return this.app.ActiveWorkbook;
		}

		public int GetLastColumn(string sheetName, int row = 1)
		{
			var sheet = this.GetSheet(sheetName);
			var l_c = sheet
				.Cells[row, sheet.Columns.Count]
				.End(e.XlDirection.xlToLeft) as e.Range;
			return l_c.Column;
		}

		public int GetLastRow(string sheetName, int column = 1)
		{
			var sheet = this.GetSheet(sheetName);
			var l_c = sheet
				.Cells[sheet.Rows.Count, column]
				.End(e.XlDirection.xlUp) as e.Range;
			return l_c.Row;
		}

		public IList<string> GetSheetNames()
		{
			var names = new List<string>();
			foreach (e.Worksheet s in this.GetCurrentBook().Sheets)
				names.Add(s.Name);
			return names;
		}

		public object[,] GetTable(string sheetName)
		{
			var sheet = this.GetSheet(sheetName);
			return this.GetTableCore(
				sheet, 1, 1, maxRow, maxColumn);
		}

		public object[,] GetTable(
			string sheetName, 
			int startRow, int startColumn, 
			int rowCount, int columnCount)
		{
			var sheet = this.GetSheet(sheetName);
			return this.GetTableCore(
				sheet, 
				startRow, startColumn,
				startRow + rowCount - 1, startColumn + columnCount - 1);
		}

		private object[,] GetTableCore(
			e.Worksheet sheet,
			int startRow, int startColumn, 
			int endRow, int endColumn)
		{
			var startCell = sheet.Cells[startRow, startColumn] as e.Range;
			var endCell = sheet.Cells[endRow, endColumn] as e.Range;
			return sheet.Range[startCell, endCell].Value as object[,];
		}

		public void SetTable(object[,] table, string sheetName)
		{
			var sheet = this.GetSheet(sheetName);
			this.SetTableCore(table, sheet, 1, 1, maxRow, maxColumn);
		}

		public void SetTable(object[,] table, string sheetName, int startRow, int startColumn)
		{
			var endRow = table.GetLength(0) + startRow - 1;
			var endColumn = table.GetLength(1) + startColumn - 1;

			var sheet = this.GetSheet(sheetName);
			this.SetTableCore(table, sheet, startRow, startColumn, endRow, endColumn);
		}

		private void SetTableCore(
			object[,] table,
			e.Worksheet sheet,
			int startRow, int startColumn, 
			int endRow, int endColumn)
		{
			var startCell = sheet.Cells[startRow, startColumn] as e.Range;
			var endCell = sheet.Cells[endRow, endColumn] as e.Range;
			sheet.Range[startCell, endCell].Value = table;
		}

		public string GetCurrentSheetName()
		{
			return this.GetCurrentBook().ActiveSheet.Name;
		}

		private e.Worksheet GetSheet(string sheetName)
		{
			if (this.Exists(sheetName))
			{
				return this.GetCurrentBook().Sheets[sheetName];
			}
			else
			{
				throw new ArgumentException($"不明なシート名:{sheetName}");
			}
		}

		private bool Exists(string sheetName)
		{
			foreach (e.Worksheet s in this.GetCurrentBook().Sheets)
			{
				if (s.Name == sheetName) return true;
			}
			return false;
		}

		public IList<docks.model.table.Cell> GetSelectedRange()
		{
			var cells = new List<docks.model.table.Cell>();
			if (this.app.Selection is e.Range r)
			{
				var startRow = r.Row;
				var startColumn = r.Column;
				var rowCount = r.Rows.Count;
				var columnCount = r.Columns.Count;

				if (rowCount == 1 && columnCount == 1)
				{
					var value = r.Value;
					cells.Add(new docks.model.table.Cell(
						value == null ? string.Empty : value.ToString(),
						startRow, startColumn)
					{ BackgroundColor = Color.FromArgb((int)r.Interior.Color) });
					return cells;
				}

				var range = r.Value as object[,];
				var points = Enumerable.Range(startRow, rowCount)
					.SelectMany(_ => Enumerable.Range(startColumn, columnCount),
					(row, column) => (row, column));

				foreach((int row, int column) in points)
				{
					var c = r.Cells[row - startRow + 1, column - startColumn + 1] as e.Range;
					var v = c.Value;
					cells.Add(new docks.model.table.Cell(
						v == null ? string.Empty : v.ToString(), row, column)
					{ BackgroundColor = Color.FromArgb((int)c.Interior.Color) });
				}

				return cells;
			}
			else
			{
				return cells;
			}
		}

		public void SetTable(IList<docks.model.table.Cell> cells)
		{
			var sheet = this.GetCurrentBook().ActiveSheet as e.Worksheet;
			foreach (var c in cells)
			{
				var range = sheet.Cells[c.Row, c.Column] as e.Range;
				range.Value = c.Value;
				range.Interior.Color = c.BackgroundColor.ToArgb();
			}
		}

		public void SetTable2(IList<docks.model.table.Cell> cells)
		{
			var startRow = cells.Min(x => x.Row);
			var startColumn = cells.Min(x => x.Column);
			var endRow = cells.Max(x => x.Row);
			var endColumn = cells.Max(x => x.Column);

			var table = new object[endRow - startRow + 1, endColumn - startColumn + 1];
			foreach (var c in cells)
			{
				table[c.Row - startRow, c.Column - startColumn] = c.Value;
			}

			var sheet = this.GetCurrentBook().ActiveSheet as e.Worksheet;
			this.SetTableCore(table, sheet, startRow, startColumn, endRow, endColumn);
		}
	}
}
