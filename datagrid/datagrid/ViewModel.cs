using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using v = view_base.ViewModel;

namespace datagrid
{
    class ViewModel
    {
        // コンストラクタ
        public ViewModel()
        {
            DoubleClickCommand = new v.DelegateCommand(this.MyDoubleClickCommand, x => true);
                
            //
            myList = new ObservableCollection<TestItem>();
            myList.Add( new TestItem { Id = 1, Name = "7of9", Age = 30, Gender = "Female"});
            myList.Add( new TestItem { Id = 2, Name = "Janeway", Age = 50, Gender = "Female" });
            myList.Add( new TestItem { Id = 3, Name = "Chakotay", Age = 40, Gender = "Female" });
        }

        public ObservableCollection<TestItem> myList { get; set; }

        public ICommand DoubleClickCommand { get; private set; }

        public void MyDoubleClickCommand(object param)
        {
            if (param == null)
            {
                return;
            }
            var clc = (TestItem)param;
            MessageBox.Show("Double click on " + clc.Name);
        }
    }
}
