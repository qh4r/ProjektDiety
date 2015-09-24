using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalendarControl.UI.ModelData.MonthView;
using Diety.Dialogs;
using Diety.Helpers.Constatnts;
using Diety.LocalEnums;
using Diety.ViewModel.Modules.Interfaces;
using Diety.ViewModel.PropertyGroups;
using Diety.ViewModel.PropertyGroups.Interfaces;

namespace Diety.ViewModel.Modules
{
	public class DialogService : IDialogService
	{
		#region Public Methods

		/// <summary>
		/// Shows the meal details dialog.
		/// </summary>
		/// <param name="eventModel">The eventModel.</param>
		/// <returns></returns>
		public DialogResultType ShowMealDetailsDialog(IMealDetailsDialogModel eventModel)
		{
			MealDetailsDialog dialog = new MealDetailsDialog
			{
				DataContext = eventModel,
				Left = (ConstantValues.ScreenWidth/2 - 200)/ConstantValues.Proportions,
				Top = 30/ConstantValues.Proportions
			};
			var result = dialog.ShowDialog();
			if (result.HasValue && result.Value)
			{
				return DialogResultType.Edit;
			}
			return DialogResultType.Ok;
		}

		#endregion

	}
}
