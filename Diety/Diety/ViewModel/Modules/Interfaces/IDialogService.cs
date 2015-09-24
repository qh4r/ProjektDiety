using CalendarControl.UI.ModelData.MonthView;
using Diety.LocalEnums;
using Diety.ViewModel.PropertyGroups;
using Diety.ViewModel.PropertyGroups.Interfaces;

namespace Diety.ViewModel.Modules.Interfaces
{
	public interface IDialogService
	{
		#region Methods

		/// <summary>
		/// Shows the meal details dialog.
		/// </summary>
		/// <param name="day">The day.</param>
		/// <returns></returns>
		DialogResultType ShowMealDetailsDialog(IMealDetailsDialogModel day);

		#endregion

	}
}