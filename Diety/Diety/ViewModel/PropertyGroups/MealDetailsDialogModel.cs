using Diety.ViewModel.PropertyGroups.Interfaces;
using DietyCommonTypes.Interfaces;
using GalaSoft.MvvmLight;

namespace Diety.ViewModel.PropertyGroups
{
	public class MealDetailsDialogModel : ViewModelBase, IMealDetailsDialogModel
	{		
		#region Private Fields

		/// <summary>
		/// The _meal
		/// </summary>
		private IMealHistoryRecord _meal;

		/// <summary>
		/// The _is past
		/// </summary>
		private bool _isPast;

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets or sets the meal.
		/// </summary>
		/// <value>
		/// The meal.
		/// </value>
		public IMealHistoryRecord Meal
		{
			get { return _meal; }
			set { Set(ref _meal, value); }
		}

		/// <summary>
		/// Gets or sets a value indicating whether this instance is past.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance is past; otherwise, <c>false</c>.
		/// </value>
		public bool IsPast
		{
			get { return _isPast; }
			set { Set(ref _isPast, value); }
		}

		#endregion
	}
}