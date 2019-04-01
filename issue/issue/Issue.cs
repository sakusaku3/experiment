using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace issue
{
    public class Issue : ViewModelBase
    {
		public string Name
		{
			get { return this._name; }
			set { if (this._name != value) { this._name = value; this.OnPropertyChanged(); } }
		}
		private string _name = "";

        public ObservableCollection<Label> Labels { get; set; }
        = new ObservableCollection<Label>();

        public Issue(string p_name) { this.Name = p_name; }
    }
}
