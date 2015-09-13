using DietyCommonTypes.Extensions;

namespace DietyCommonTypes.Enums
{
	public enum MealTypes
	{
		/// <summary>
		/// The dinner
		/// </summary>
		[EnumStringValue("Obiad")]
		Dinner,

		/// <summary>
		/// The supper
		/// </summary>	
		[EnumStringValue("Kolacja")]
		Supper,
		
		/// <summary>
		/// The breakfast
		/// </summary>
		[EnumStringValue("Śniadanie")]
		Breakfast,

		/// <summary>
		/// The additional meal
		/// </summary>
		[EnumStringValue("Dodatkowy posiłek")]
		AdditionalMeal,
	}
}
