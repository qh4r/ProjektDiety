using System;
using System.Linq;
using System.Reflection;

namespace DietyCommonTypes.Extensions
{
	public class EnumStringValueAttribute : Attribute
	{
		#region Private Fields

		/// <summary>
		/// The _value
		/// </summary>
		private string _value;

		#endregion


		#region Public Properties

		/// <summary>
		/// Gets the value.
		/// </summary>
		/// <value>
		/// The value.
		/// </value>
		public string Value
		{
			get { return _value; }
		}

		#endregion

		#region C-tors

		/// <summary>
		/// Initializes a new instance of the <see cref="EnumStringValueAttribute"/> class.
		/// </summary>
		/// <param name="value">The value.</param>
		public EnumStringValueAttribute(string value)
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
		public static string GetStringValue(Enum value)
		{
			Type type = value.GetType();
			FieldInfo fi = type.GetField(value.ToString());
			var enumStringValueAttribute =
				fi.GetCustomAttributes(typeof(EnumStringValueAttribute), false).FirstOrDefault() as EnumStringValueAttribute;
			if (enumStringValueAttribute != null)
			{
				return enumStringValueAttribute.Value;
			}
			else
			{
				return String.Empty;
			}
		}

		#endregion

	}
}
