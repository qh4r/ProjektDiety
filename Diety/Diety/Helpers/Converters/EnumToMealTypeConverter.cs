using System;
using System.Globalization;
using System.Windows.Data;
using DietyCommonTypes.Enums;
using DietyCommonTypes.Extensions;

namespace Diety.Helpers.Converters
{
	public class EnumToMealTypeConverter : IValueConverter
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
			var mealType = value as MealTypes?;
			return mealType.HasValue ? EnumStringValueAttribute.GetStringValue(mealType) : String.Empty;
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
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var mealType = value as string;
			if (mealType != null)
			{
				switch (mealType)
				{
					case "Obiad":
						return MealTypes.Dinner;
					case "Kolacja":
						return MealTypes.Supper;
					case "Œniadanie":
						return MealTypes.Breakfast;
					default:
						return MealTypes.AdditionalMeal;
				}
			}
			return MealTypes.AdditionalMeal;
		}

		#endregion

	}
}