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
        private DelegateCommand _showMessageCommand;
        public DelegateCommand ShowMessageCommand
        {
            get
            {
                return this._showMessageCommand ?? 
                    (this._showMessageCommand = new DelegateCommand(
                        () => this.showMessage.ShowMessage("pushed"), () => true));
            }
        }

        private DelegateCommand _replaceIssue;
        public DelegateCommand ReplaceIssue
        {
            get
            {
                return this._replaceIssue ?? 
                    (this._replaceIssue = new DelegateCommand(
                        this.replaceExecute, () => true));
            }
        }

        private readonly IShowMessageService showMessage;

        private readonly IExcelControlService excelControl;

        private readonly ReplaceControl replaceControl;

        public DockViewModel(
			IShowMessageService showMessage,
			IExcelControlService excelControl)
        {
            this.showMessage = showMessage;
			this.excelControl = excelControl;
			this.replaceControl = new ReplaceControl(excelControl);
        }

		private void replaceExecute()
		{
			try
			{
				this.replaceControl.Replace(this.excelControl.GetCurrentSheetName());
			}
			catch
			{

			}
		}
    }
}
