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

namespace grid
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int GRID_SIZE = 10;
        private ScaleTransform scaleTransform = new ScaleTransform();

        public MainWindow()
        {
            InitializeComponent();

            // ScaleTransformのScaleXにスライダーの値をバインディング
            BindingOperations.SetBinding(
                scaleTransform,
                ScaleTransform.ScaleXProperty,
                new Binding("Value") { Source = slider });

            // ScaleTransformのScaleYにスライダーの値をバインディング
            BindingOperations.SetBinding(
                scaleTransform,
                ScaleTransform.ScaleYProperty,
                new Binding("Value") { Source = slider });
        }

        private void canvas_Loaded(object sender, RoutedEventArgs e)
        {
            BuildView();
        }

        private void canvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            BuildView();
        }

        // グリッド模様の構築
        private void BuildView()
        {
            canvas.Children.Clear();

            // 縦線
            for (int i = 0; i < canvas.ActualWidth; i += GRID_SIZE)
            {
                Path path = new Path()
                {
                    Data = new LineGeometry(new Point(i, 0), new Point(i, canvas.ActualHeight)),
                    Stroke = Brushes.Aquamarine,
                    StrokeThickness = 1
                };

                path.Data.Transform = scaleTransform;

                canvas.Children.Add(path);
            }

            // 横線
            for (int i = 0; i < canvas.ActualHeight; i += GRID_SIZE)
            {
                Path path = new Path()
                {
                    Data = new LineGeometry(new Point(0, i), new Point(canvas.ActualWidth, i)),
                    Stroke = Brushes.Aquamarine,
                    StrokeThickness = 1
                };

                path.Data.Transform = scaleTransform;

                canvas.Children.Add(path);
            }
        }
    }
}
