using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Person> people;

        private CollectionViewSource viewSource;

        private Predicate<Person> predicate;

        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            var r = new Random();
            // 適当なデータを30件作成
            this.people = new ObservableCollection<Person>(
                Enumerable
                .Range(1, 30)
                .Select(i => new Person
                {
                    Name = "tanaka" + i,
                    // Salaryは1-500000の間
                    Salary = r.Next(500000)
                }));

            this.viewSource = new CollectionViewSource() { Source = this.people };
            this.predicate = p => true;
            this.viewSource.Filter += ViewSource_Filter;

            // Salaryプロパティでソート
            this.viewSource.View.SortDescriptions.Add(
                new SortDescription("Salary", ListSortDirection.Descending));

            // dataGridに設定
            this.dataGrid.ItemsSource = this.viewSource.View;
        }

        private void ViewSource_Filter(object sender, FilterEventArgs e)
        {
            if (e.Item is Person p)
            {
                if (this.predicate.Invoke(p))
                    e.Accepted = true;
                else
                    e.Accepted = false;
            }
        }

        private void ShuffleButton_Click(object sender, RoutedEventArgs e)
        {
            // Salaryプロパティの値を適当に設定しなおす
            if (this.people == null) return;

            var r = new Random();
            foreach (var p in this.people)
            {
                p.Salary = r.Next(500000);
            }
        }

        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            this.predicate = p => p.Salary % 2 == 0;
            this.viewSource.View.Refresh();
        }

        private void NonFilter_Click(object sender, RoutedEventArgs e)
        {
            this.predicate = p => true;
            this.viewSource.View.Refresh();
        }
    }
}
