using System;
using System.Linq;
using System.Reflection;

namespace DietyCommonTypes.Extensions
{
	public class UnitTypeValueModyfierAttribute : Attribute
	{
		#region Private Fields

		/// <summary>
		/// The _value
		/// </summary>
		private double _value;

		#endregion


		#region Public Properties

		/// <summary>
		/// Gets the value.
		/// </summary>
		/// <value>
		/// The value.
		/// </value>
		public double Value
		{
			get { return _value; }
		}

		#endregion

		#region C-tors

		/// <summary>
		/// Initializes a new instance of the <see cref="EnumStringValueAttribute"/> class.
		/// </summary>
		/// <param name="value">The value.</param>
		public UnitTypeValueModyfierAttribute(double value)
		{
			_value = value;
		}

		#endregion

		#region Public methods

		/// <summary>
		/// Gets the string value.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static double GetMultiplyerValue(Enum value)
		{
			Type type = value.GetType();
			FieldInfo fi = type.GetField(value.ToString());
			var enumStringValueAttribute =
				fi.GetCustomAttributes(typeof(UnitTypeValueModyfierAttribute), false).FirstOrDefault() as UnitTypeValueModyfierAttribute;
			if (enumStringValueAttribute != null)
			{
				return enumStringValueAttribute.Value;
			}
			else
			{
				return 0.0;
			}
		}

		#endregion

	}
}