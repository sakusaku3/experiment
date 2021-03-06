﻿using System;
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

namespace control_scrollviewer
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

        private void ScrollToHalfVerticalOffsetButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.Print(this.scrollViewer.VerticalOffset.ToString());

            System.Diagnostics.Debug.Print(this.scrollViewer.ScrollableHeight.ToString());

            // 垂直スクロールバーの位置を真ん中に設定
            this.scrollViewer.ScrollToVerticalOffset(this.scrollViewer.ScrollableHeight / 2);

            System.Diagnostics.Debug.Print(this.scrollViewer.VerticalOffset.ToString());
        }
    }
}
