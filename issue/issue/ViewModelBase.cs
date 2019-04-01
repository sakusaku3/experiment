using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace issue
{
    public class ViewModelBase : IDataModel
    {
        #region IDataModel メンバー
        public event PropertyChangedEventHandler PropertyChanged;

        PropertyChangedEventHandler IDataModel.PropertyChangedHandler
        {
            get { return this.PropertyChanged; }
        }

        public List<IDisposable> Disposables { get; set; }
        #endregion
    }
}
