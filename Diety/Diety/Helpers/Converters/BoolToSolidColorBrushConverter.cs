using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Diety.Helpers.Converters
{
	public class BoolToSolidColorBrushConverter : IValueConverter
	{
		#region Public Properties

		/// <summary>
		/// Gets or sets the color of the normal.
		/// </summary>
		/// <value>
		/// The color of the normal.
		/// </value>
		public SolidColorBrush NormalColor { get; set; }

		/// <summary>
		/// Gets or sets the color of the active.
		/// </summary>
		/// <value>
		/// The color of the active.
		/// </value>
		public SolidColorBrush ActiveColor { get; set; }

		#endregion

		#region Public Methods

		/// <summary>
		/// Converts the specified value.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="targetType">Type of the target.</param>
		/// <param name="parameter">The parameter.</param>
		/// <param name="culture">The culture.</param>
		/// <returns></returns>
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var input = value as bool?;
			if (input.HasValue)
			{
				return input.Value ? ActiveColor : NormalColor;
			}
			return NormalColor;
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