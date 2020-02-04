using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;

namespace excel_issue
{
    public partial class ThisAddIn
    {
        private Microsoft.Office.Tools.CustomTaskPane current;

        public void ChangeWindow(DockTypes dockTypes)
        {
            this.current = this.CustomTaskPanes[(int)dockTypes];
            this.current.Visible = true;
        }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            var dock = new DockAdapter();
            dock.Adaptee.DataContext = new docks.DockViewModel(
				new Services.ShowMessageBox(),
				new Services.ExcelControlService());
            this.current = this.CustomTaskPanes.Add(dock, "ReplaceIssues");
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO で生成されたコード

        /// <summary>
        /// デザイナーのサポートに必要なメソッドです。
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
