using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datagrid_filter
{
    class VariableDataGridViewModel : BindableBase
    {
        public ObservableCollection<string> Headers { get; set; }
        public ObservableCollection<Row> Rows { get; set; }

        public VariableDataGridViewModel(
            IEnumerable<string> p_headers,
            IEnumerable<Row> p_rows)
        {
            this.Headers = new ObservableCollection<string>(p_headers);
            this.Rows = new ObservableCollection<Row>(p_rows);
        }
    }
}
