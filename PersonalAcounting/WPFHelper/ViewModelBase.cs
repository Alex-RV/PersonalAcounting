using System;
using System.ComponentModel;
using System.Diagnostics;

namespace WPFHelper
{
	/// <summary>
	/// Базовая VM 
	/// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
		public virtual string DisplayName { get; protected set; }

		public bool WasDisposed { get; private set; }

		protected virtual bool ThrowOnInvalidPropertyName { get; private set; }


		public void VerifyPropertyName(string propertyName)
		{
			// Verify that the property name matches a real,
			// public, instance property on this object.
			if (TypeDescriptor.GetProperties(this)[propertyName] == null)
			{
				string msg = "Invalid property name: " + propertyName;

				if (this.ThrowOnInvalidPropertyName)
					throw new Exception(msg);
				else
					Debug.Fail(msg);
			}
		}



		#region INotifyPropertyChanged Members

		/// <summary>
		/// Raised when a property on this object has a new value.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// Raises this object's PropertyChanged event.
		/// </summary>
		/// <param name="propertyName">The property that has a new value.</param>
		protected virtual void OnPropertyChanged(string propertyName)
		{
			this.VerifyPropertyName(propertyName);
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}


		#endregion INotifyPropertyChanged Members


		#region IDisposable Members
		//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
		/// <summary>
		/// Метод Dispose, вызывается при желании вручную освободить используемые объектом ресурсы. Используется в подавляющем большинстве случаев при работе с native ресурсами,
		/// как альтернатива методу Finalize (деструктору), который вызывается сборщиком мусора довольно поздно (объект попадает автоматом в поколение на уровень выше) и в произвольное время.
		/// Позволяет освободить ресурсы сразу после завершения работы с ними.
		/// </summary>
		public void Dispose()
		{
			//Защита от повторного запуска Dispose(). 
			//Базовая VM источника окон(DockingWindowAndSourceViewModel) всегда запускает Dispose(), но некоторые его дочерние классы тоже его запускают,т.к. раньше базовый класс не всегда запускал Dispose()
			if (!WasDisposed)
			{
				OnDispose();
				return;
			}
		}



		/// <summary>
		/// Child classes can override this method to perform clean-up logic, such as removing event handlers. НЕ будет вызван автоматом!
		/// </summary>
		protected virtual void OnDispose()
		{
			WasDisposed = true;
		}

		#endregion IDisposable Members


	}
}
