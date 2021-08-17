using System;
using System.Windows.Data;
using System.Globalization;
using System.Windows;

namespace WPFHelper.Converters
{
	/// <summary>
	/// Конвертер <see cref="bool"/> значения в <see cref="Visibility"/>. Если параметр конвертера = "!", то значение инвертируется.
	/// </summary>
	[ValueConversion(typeof(bool), typeof(Visibility), ParameterType = typeof(string))]
	public class BoolToVisible : IValueConverter
	{
		public static readonly BoolToVisible Instance = new BoolToVisible();

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			bool visible = (bool)value;

			if ((parameter as string) == "!")
			{
				visible = !visible;
			}

			return visible ? Visibility.Visible : Visibility.Collapsed;
		}

		//------------------------------------------------------------------------------------------------------
		public object ConvertBack(object value, Type targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
