using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace issue
{
    public class Issue
    {
		public string ID { get; }
		public string Contents { get; }

		public Issue(string id, string contents)
		{
			this.ID = id;
			this.Contents = contents;
		}
	}
}
