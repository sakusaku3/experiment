using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datagrid_filter
{
    public class Row : BindableBase
    {
        public Dictionary<string, Cell> Cells { get; }

        public Row(Dictionary<string, Cell> cells)
        {
            this.Cells = new Dictionary<string, Cell>(cells);
        }
    }
}
