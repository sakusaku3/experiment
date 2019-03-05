using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using view_base;

namespace datagrid
{
    class TestItem : view_base.ViewModel.ViewModelBase
    {
        public ObservableCollection<Person> Persons
        {
            get { return this._persons; }
            set
            {
                if (this._persons == value) return;
                this._persons = value;
                this.OnPropertyChanged();
            }
        }

        private ObservableCollection<Person> _persons 
            = new ObservableCollection<Person>();

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Link { get; set; } = "https://www.google.com/";
        public Person Person { get; set; }
    }
}

