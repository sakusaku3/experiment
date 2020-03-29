using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace docks
{
	public class ReplaceControl
	{
		private IExcelControlService excelControl;

		public ReplaceControl(IExcelControlService excelControl)
		{
			this.excelControl = excelControl;
		}

		public void Replace(string currentSheetName)
		{
			var issues = this.GetIssues();
			var replaceIssues = new issue.ReplaceIssues(issues);

			var table = this.excelControl.GetTable(currentSheetName);
			replaceIssues.Replace(table);

			this.excelControl.SetTable(table, currentSheetName);
		}

		private static readonly int idColumn = 1;

		private static readonly int contentsColumn = 2;

		private static readonly string issuesSheet = "issues";

		private IList<issue.Issue> GetIssues()
		{
			var lastRow = this.excelControl.GetLastRow(issuesSheet, 1);
			var lastColumn = this.excelControl.GetLastColumn(issuesSheet, 1);
			var table = this.excelControl.GetTable(issuesSheet, 1, 1, lastRow, lastColumn);

			var issues = new List<issue.Issue>();
			for (int row = 2; row <= table.GetLength(0); row++)
			{
				if (table[row, idColumn] == null) continue;
				issues.Add(getIssue(row));
			}
			return issues;

			issue.Issue getIssue(int row)
			{
				return new issue.Issue(
					table[row, idColumn].ToString(), 
					table[row, contentsColumn] == null ? "" : table[row, contentsColumn].ToString());
			}
		}
	}
}
