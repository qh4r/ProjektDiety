using System;
using DietyCommonTypes.Enums;

namespace Diety.ViewModel.PropertyGroups
{
	public class MealNavigationData
	{
		#region Public Properties

		/// <summary>
		/// Gets or sets the type of the meal filter.
		/// </summary>
		/// <value>
		/// The type of the meal filter.
		/// </value>
		public MealTypes MealFilterType { get; set; }

		/// <summary>
		/// Gets or sets the selected data.
		/// </summary>
		/// <value>
		/// The selected data.
		/// </value>
		public DateTime SelectedDate { get; set; }

		#endregion

	}
}