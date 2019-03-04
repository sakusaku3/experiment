using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace datagrid
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private DataGridRow draggedItem;
        private bool isDragging;

        private void dataGrid1_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var l_row = UIHelpers.TryFindFromPoint<DataGridRow>((UIElement)sender, e.GetPosition(dataGrid1));
            if (l_row == null || l_row.IsEditing) return;

            this.isDragging = true;
            this.draggedItem = l_row;
            Console.WriteLine("dragging");
        }

        private void dataGrid1_PreviewMouseMove(object sender, MouseEventArgs e)
        {
			if (e.LeftButton != MouseButtonState.Pressed || !this.isDragging) return;

			// ドラッグ操作を開始する
			DragDrop.DoDragDrop(this.draggedItem, this.draggedItem.DataContext, DragDropEffects.All);

			this.isDragging = false;
			e.Handled = true;
            Console.WriteLine("moving");
        }

        public void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Hyperlink link = (Hyperlink)e.OriginalSource;
            Process.Start(link.NavigateUri.AbsoluteUri);
        }
    }
}
