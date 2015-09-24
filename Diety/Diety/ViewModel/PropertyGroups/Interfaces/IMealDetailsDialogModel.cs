using DietyCommonTypes.Interfaces;

namespace Diety.ViewModel.PropertyGroups.Interfaces
{
	public interface IMealDetailsDialogModel
	{
		#region Properties

		/// <summary>
		/// Gets or sets the meal.
		/// </summary>
		/// <value>
		/// The meal.
		/// </value>
		IMealHistoryRecord Meal { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance is past.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance is past; otherwise, <c>false</c>.
		/// </value>
		bool IsPast { get; set; }

		#endregion

	}
}