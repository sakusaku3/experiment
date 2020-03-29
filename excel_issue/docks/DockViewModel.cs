using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using view_base.ViewModel;

namespace docks
{
    public class DockViewModel : ViewModelBase
    {
		public viewmodel.Tabs.IssueViewModel IssueViewModel { get; set; }
		public viewmodel.Tabs.MatrixViewModel MatrixViewModel { get; set; }

		public DockViewModel(
			IShowMessageService showMessage,
			IExcelControlService excelControl)
        {
			this.IssueViewModel = new viewmodel.Tabs.IssueViewModel(showMessage, excelControl);
			this.MatrixViewModel = new viewmodel.Tabs.MatrixViewModel(excelControl);
        }
    }
}
