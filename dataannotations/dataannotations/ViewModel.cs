using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace dataannotations
{
    class ViewModel : view_base.ViewModel.ViewModelBase
    {
        [DisplayName("番号")]
        [Range(0, 1000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Number
        {
            get { return this._number; }
            set
            {
                if (this._number == value) return;
                this._number = value;
                this.OnPropertyChanged();
                this.UpdateErrors(value);
            }
        }
        private int _number;

        [Required(ErrorMessage = "{0} is required.")]
        public string StringNumber
        {
            get { return this._stringNumber; }
            set
            {
                if (this._stringNumber == value) return;
                this._stringNumber = value;
                this.OnPropertyChanged();
                this.UpdateErrors(value);
            }
        }
        private string _stringNumber;

        [FileCheckValidate(ErrorMessage = "ファイルがありません")]
        public string FilePath
        {
            get { return this._filepath; }
            set
            {
                if (this._filepath == value) return;
                this._filepath = value;
                this.OnPropertyChanged();
                this.UpdateErrors(value);
            }
        }
        private string _filepath;
    }
}
