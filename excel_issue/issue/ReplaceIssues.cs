using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace issue
{
	public class ReplaceIssues
	{
		private readonly Regex id = new Regex(@"^\[#(?<id>\d+)\]");

		private readonly IList<Issue> issues;

		public ReplaceIssues(IEnumerable<Issue> issues)
		{
			this.issues = new List<Issue>(issues);
		}

		public void Replace(object[,] table)
		{
			for (int row = 1; row < table.GetLength(0); row++)
			{
				for (int column = 1; column < table.GetLength(1); column++)
				{
					if (table[row, column] == null) continue;

					var value = table[row, column].ToString();

					var match = id.Match(value);
					if (!match.Success) continue;

					var idValue = match.Groups["id"];

					var v = this.issues.FirstOrDefault(x => x.ID == idValue.Value);
					if (v == null) continue;

					table[row, column] = $"[#{v.ID}] {v.Contents}";
				}
			}
		}
	}
}
