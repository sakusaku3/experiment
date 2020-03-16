using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace datagrid_filter
{
    /// <summary>
    /// VariableDataGrid.xaml の相互作用ロジック
    /// </summary>
    public partial class VariableDataGrid : UserControl
    {
        private CollectionViewSource viewSource;

        public VariableDataGrid()
        {
            this.DataContextChanged += VariableDataGrid_DataContextChanged;
            this.InitializeComponent();
        }

        private void VariableDataGrid_DataContextChanged(
            object sender, 
            DependencyPropertyChangedEventArgs e)
        {
            this.InitializeDataGrid();
        }

        private void InitializeDataGrid()
        {
            if (this.DataContext is VariableDataGridViewModel vm)
            {
                foreach (var header in vm.Headers)
                {
                    this.PART_datagrid.Columns.Add(new DataGridTextColumn()
                    {
                        Header = header,
                        IsReadOnly = true,
                        CanUserSort = true,
                        Binding = new Binding($"Cells[{header}].Value"),
                    });
                }

                this.viewSource = new CollectionViewSource() { Source = vm.Rows };
                this.PART_datagrid.ItemsSource = this.viewSource.View;
            }
        }
    }
}
