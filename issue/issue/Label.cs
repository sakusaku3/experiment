using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace issue
{
    public class Label : ViewModelBase
    {
		public string Name
		{
			get { return this._name; }
			set { if (this._name != value) { this._name = value; this.OnPropertyChanged(); } }
		}
		private string _name = "";

        public DelegateCommand FilterCommand
        {
            get
            {
                return this._filterCommand = this._filterCommand ??
                        new DelegateCommand(
                            () => this.filterExecute(this.Name),
                            () => !string.IsNullOrWhiteSpace(this.Name)
                            );
            }
        }
        private DelegateCommand _filterCommand;

        private Action<string> filterExecute;

        public Label(
            string p_name,
            Action<string> p_filterExecute
            )
        {
            this.Name = p_name;
            this.filterExecute = p_filterExecute;
        }
    }
}
