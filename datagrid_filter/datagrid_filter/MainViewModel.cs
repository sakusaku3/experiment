using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datagrid_filter
{
    class MainViewModel : BindableBase
    {
        public string[] Headers { get; }

        public ObservableCollection<Row> Rows { get; }

        public VariableDataGridViewModel VariableDataGrid { get; }

        public MainViewModel()
        {
            var table1 = new Dictionary<string, Cell>()
            {
                { "AAA", new Cell("A", System.Windows.Media.Color.FromRgb(0,0,0)) },
                { "BBB", new Cell("B", System.Windows.Media.Color.FromRgb(0,0,0)) },
                { "CCC", new Cell("C", System.Windows.Media.Color.FromRgb(0,0,0)) },
            };
            var table2 = new Dictionary<string, Cell>()
            {
                { "AAA", new Cell("D", System.Windows.Media.Color.FromRgb(0,0,0)) },
                { "BBB", new Cell("E", System.Windows.Media.Color.FromRgb(0,0,0)) },
                { "CCC", new Cell("F", System.Windows.Media.Color.FromRgb(0,0,0)) },
            };
            var table3 = new Dictionary<string, Cell>()
            {
                { "AAA", new Cell("G", System.Windows.Media.Color.FromRgb(0,0,0)) },
                { "BBB", new Cell("H", System.Windows.Media.Color.FromRgb(0,0,0)) },
                { "CCC", new Cell("I", System.Windows.Media.Color.FromRgb(0,0,0)) },
            };

            this.Rows = new ObservableCollection<Row>()
            {
                new Row(table1),
                new Row(table2),
                new Row(table3),
            };

            this.Headers = new string[] { "AAA", "BBB", "CCC" };

            this.VariableDataGrid = new VariableDataGridViewModel(this.Headers, this.Rows);
        }
    }
}
