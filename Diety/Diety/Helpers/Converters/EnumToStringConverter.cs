using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using DietyCommonTypes.Enums;
using DietyCommonTypes.Extensions;

namespace Diety.Helpers.Converters
{
	public class EnumToStringConverter : IValueConverter
	{
		#region Public Methods

		/// <summary>
		/// Converts a value.
		/// </summary>
		/// <param name="value">The value produced by the binding source.</param>
		/// <param name="targetType">The type of the binding target property.</param>
		/// <param name="parameter">The converter parameter to use.</param>
		/// <param name="culture">The culture to use in the converter.</param>
		/// <returns>
		/// A converted value. If the method returns null, the valid null value is used.
		/// </returns>
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var enumObject = value as ObservableCollection<MealTypes>;
			if (enumObject != null)
			{
				return enumObject.Select(x => EnumStringValueAttribute.GetStringValue(x));
			}
			return null;
		}

		/// <summary>
		/// Converts a value.
		/// </summary>
		/// <param name="value">The value that is produced by the binding target.</param>
		/// <param name="targetType">The type to convert to.</param>
		/// <param name="parameter">The converter parameter to use.</param>
		/// <param name="culture">The culture to use in the converter.</param>
		/// <returns>
		/// A converted value. If the method returns null, the valid null value is used.
		/// </returns>
		/// <exception cref="System.NotImplementedException"></exception>
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		#endregion

	}
}