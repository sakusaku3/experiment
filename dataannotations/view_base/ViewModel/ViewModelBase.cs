using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace view_base.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        /// <summary>
        /// プロパティ変更イベントハンドラ
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// プロパティの変更の通知
        /// </summary>
		public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Dictionary<string, string[]> errors = new Dictionary<string, string[]>();

        // エラー情報が変更された際に発生するイベント
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        // ErrorsChangedイベントを発生させる
        protected virtual void RaiseErrorsChanged([CallerMemberName]string propertyName = "")
        {
            this.ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        // エラーメッセージを取得する
        public System.Collections.IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrWhiteSpace(propertyName)) return null;
            if (!this.errors.ContainsKey(propertyName)) return null;
            return this.errors[propertyName];
        }

        // エラーの有無
        public bool HasErrors
        {
            get { return this.errors.Values.Any(x => x != null); }
        }

        // エラー情報を更新する。
        protected void UpdateErrors(object value, [CallerMemberName]string propertyName = "")
        {
            if (string.IsNullOrWhiteSpace(propertyName)) return;

            var results = new List<ValidationResult>();

            if (Validator.TryValidateProperty(
                value,
                new ValidationContext(this, null, null) { MemberName = propertyName },
                results))
            {
                // エラー無し
                this.errors[propertyName] = null;
            }
            else
            {
                this.errors[propertyName] = results.Select(x => x.ErrorMessage).ToArray();
            }

            this.RaiseErrorsChanged(propertyName);
        }
    }
}
