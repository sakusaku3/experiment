using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace docks
{
	public interface IExcelControlService
	{
		string GetCurrentSheetName();
		IList<string> GetSheetNames();
		int GetLastRow(string sheetName, int column = 1);
		int GetLastColumn(string sheetName, int row = 1);

		object[,] GetTable(string sheetName);
		object[,] GetTable(string sheetName, int startRow, int startColumn, int rowCount, int columnCount);

		void SetTable(object[,] table, string sheetName);
		void SetTable(object[,] table, string sheetName, int startRow, int startColumn);

		IList<model.table.Cell> GetSelectedRange();
		void SetTable(IList<model.table.Cell> cells);
	}
}
