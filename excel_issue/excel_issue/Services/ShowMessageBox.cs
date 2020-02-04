using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using e = Microsoft.Office.Interop.Excel;

namespace excel_issue.Services
{
    class ShowMessageBox : docks.IShowMessageService
    {
        public void ShowMessage(string message)
        {
			var app = Globals.ThisAddIn.Application;

			foreach (e.Shape s in app.Selection.ShapeRange)
			{
				MessageBox.Show($"top:{s.TopLeftCell.Row}, left:{s.TopLeftCell.Column}, buttom:{s.BottomRightCell.Row}, right:{s.BottomRightCell.Column}");
			}
        }
    }
}
