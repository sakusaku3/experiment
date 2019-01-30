using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace view_base.ViewModel
{
	public class DelegateCommand : ICommand
	{
		#region fields
		private Action execute;
		private Action<object> executeOnArg;
		private Func<bool> canExecute;
		private Func<object, bool> canExecuteOnArg;
		#endregion

		#region events
		public event EventHandler CanExecuteChanged;
		#endregion

		#region constructor
		public DelegateCommand(
			Action p_execute,
			Func<bool> p_canExecute
			)
		{
			this.execute = p_execute;
			this.canExecute = p_canExecute;
		}

		public DelegateCommand(
			Action<object> p_executeOnArg,
			Func<object, bool> p_canExecuteOnArg
			)
		{
			this.executeOnArg = p_executeOnArg;
			this.canExecuteOnArg = p_canExecuteOnArg;
		}
		#endregion

		#region methods
		public bool CanExecute(object p_parameter)
		{
			if (this.canExecute != null) return this.canExecute();
			if (this.canExecuteOnArg != null) return this.canExecuteOnArg(p_parameter);
			throw new NullReferenceException();
		}

		public void Execute(object p_parameter)
		{
			this.execute?.Invoke();
			this.executeOnArg?.Invoke(p_parameter);
		}
		#endregion
	}
}
