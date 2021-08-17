using System;
using System.Windows.Input;
using System.ComponentModel;
using System.Diagnostics;


namespace WPFHelper
{
	/// <summary>
	/// A command whose sole purpose is to
	/// relay its functionality to other
	/// objects by invoking delegates. The
	/// default return value for the CanExecute
	/// method is 'true'.
	/// </summary>
	public class RelayCommand : ICommand, INotifyPropertyChanged
	{
		#region Fields

		readonly Action<object> _execute;
		readonly Predicate<object> _canExecute;

		string _description;
		bool _isVisible = false;

		public event PropertyChangedEventHandler PropertyChanged;
		private EventHandler _internalCanExecuteChanged;

		#endregion // Fields

		// ----   ----   ----   ----   ----   ----   ----   ----    ----   ----    ----    ----

		#region Constructors

		/// <summary>
		/// Creates a new command that can always execute.
		/// </summary>
		/// <param name="execute">The execution logic.</param>
		public RelayCommand(string descr, Action<object> execute)
			: this(descr, execute, null)
		{
		}
		// ----   ----   ----   ----   ----   ----   ----   ----    ----   ----    ----    ----

		/// <summary>
		/// Creates a new command.
		/// </summary>
		/// <param name="execute">The execution logic.</param>
		/// <param name="canExecute">The execution status logic.</param>
		public RelayCommand(string descr, Action<object> execute, Predicate<object> canExecute)
		{
			if (execute == null)
				throw new ArgumentNullException(nameof(execute));

			_description = descr;
			_execute = execute;
			_canExecute = canExecute;
		}

		#endregion // Constructors
		// ----   ----   ----   ----   ----   ----   ----   ----    ----   ----    ----    ----


		public bool IsVisible
		{
			get { return (_isVisible); }
			set
			{
				if (_isVisible != value)
				{
					_isVisible = value;
					if (PropertyChanged != null)
						PropertyChanged(this, new PropertyChangedEventArgs("IsVisible"));
				}
			}
		}
		// ----   ----   ----   ----   ----   ----   ----   ----    ----   ----    ----    ----
		public string Description
		{
			get { return (_description); }
			set
			{
				if (_description != value)
				{
					_description = value;
					if (PropertyChanged != null)
						PropertyChanged(this, new PropertyChangedEventArgs("Description"));
				}
			}
		}
		// ----   ----   ----   ----   ----   ----   ----   ----    ----   ----    ----    ----

		#region ICommand Members
		[DebuggerStepThrough]
		public bool CanExecute(object parameter)
		{
			return _canExecute == null ? true : _canExecute(parameter);
		}

		public event EventHandler CanExecuteChanged
		{
			add
			{
				_internalCanExecuteChanged += value;
				CommandManager.RequerySuggested += value;
			}

			remove
			{
				_internalCanExecuteChanged -= value;
				CommandManager.RequerySuggested -= value;
			}
		}

		public void Execute(object parameter)
		{
			_execute(parameter);
		}

		#endregion // ICommand Members

		/// <summary>
		/// This method can be used to raise the CanExecuteChanged handler.
		/// This will force WPF to re-query the status of this command directly.
		/// </summary>
		public void RaiseCanExecuteChanged()
		{
			if (_canExecute != null)
			{
				OnCanExecuteChanged();
			}
		}

		/// <summary>
		/// This method is used to walk the delegate chain and well WPF that
		/// our command execution status has changed.
		/// </summary>
		protected virtual void OnCanExecuteChanged()
		{
			EventHandler eCanExecuteChanged = _internalCanExecuteChanged;
			if (eCanExecuteChanged != null)
				eCanExecuteChanged(this, EventArgs.Empty);
		}
	}
}
