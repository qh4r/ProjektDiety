using System;
using GalaSoft.MvvmLight;

namespace Diety.ViewModel.PropertyGroups
{
	public class MonthModel : ObservableObject
	{
		#region Statics

		/// <summary>
		/// The months names
		/// </summary>
		private static readonly string[] MonthsNames =
        {
            "Styczeń", "Luty", "Marzec", "Kwiecień", "Maj", "Czerwiec", "Lipiec", "Sierpień",
            "Wrzesień", "Październik", "Listopad", "Grudzień"
        };

		#endregion

		#region Fields

		/// <summary>
		/// The _month date
		/// </summary>
		private DateTime _monthDate;

		/// <summary>
		/// The _is selected
		/// </summary>
		private bool _isSelected;

		#endregion

		#region Properties

		/// <summary>
		/// Gets the name of the visible.
		/// </summary>
		/// <value>
		/// The name of the visible.
		/// </value>
		public string VisibleName
		{
			get { return MonthsNames[Int32.Parse(_monthDate.Month.ToString()) - 1]; }
		}

		/// <summary>
		/// Gets or sets the month date.
		/// </summary>
		/// <value>
		/// The month date.
		/// </value>
		public DateTime MonthDate
		{
			get { return _monthDate; }
			set { _monthDate = new DateTime(value.Year, value.Month, 1); }
		}

		/// <summary>
		/// Gets or sets a value indicating whether this instance is selected.
		/// </summary>
		/// <value>
		/// <c>true</c> if this instance is selected; otherwise, <c>false</c>.
		/// </value>
		public bool IsSelected
		{
			get { return _isSelected; }
			set
			{
				Set(ref _isSelected, value);
			}
		}

		#endregion
	}
}