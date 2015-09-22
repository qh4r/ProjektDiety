﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using DietyCommonTypes.Interfaces;
using GalaSoft.MvvmLight;

namespace CalendarControl.UI.ModelData.MonthView
{
	public class DayModel : ObservableObject
	{
		#region Statics
		/// <summary>
		/// The day names
		/// </summary>
		private static readonly string[] DayNames = { "Pn", "Wt", "Śr", "Cz", "Pt", "So", "Nd" };
		#endregion

		#region Fields

		/// <summary>
		/// The date
		/// </summary>
		private DateTime _date;

		/// <summary>
		/// The enabled
		/// </summary>
		private bool _enabled;

		/// <summary>
		/// The is target month
		/// </summary>
		private bool _isTargetMonth;

		/// <summary>
		/// The is today
		/// </summary>
		private bool _isToday;

		/// <summary>
		/// The first row day name
		/// </summary>
		private string _firstRowDayName;

		/// <summary>
		/// The is selected
		/// </summary>
		private bool _isSelected;

		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets a value indicating whether this instance is today.
		/// </summary>
		/// <value>
		/// <c>true</c> if this instance is today; otherwise, <c>false</c>.
		/// </value>
		public bool IsToday
		{
			get { return _isToday; }
			set
			{
				Set(ref _isToday, value);
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this instance is target month.
		/// </summary>
		/// <value>
		/// <c>true</c> if this instance is target month; otherwise, <c>false</c>.
		/// </value>
		public bool IsTargetMonth
		{
			get { return _isTargetMonth; }
			set
			{
				Set(ref _isTargetMonth, value);
			}
		}

		/// <summary>
		/// Gets or sets the first name of the row day.
		/// </summary>
		/// <value>
		/// The first name of the row day.
		/// </value>
		public string FirstRowDayName
		{
			get { return _firstRowDayName; }
			set
			{
				Set(ref _firstRowDayName, value);
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="MonthModelDay"/> is enabled.
		/// </summary>
		/// <value>
		///   <c>true</c> if enabled; otherwise, <c>false</c>.
		/// </value>
		public bool Enabled
		{
			get { return _enabled; }
			set
			{
				Set(ref _enabled, value);
			}
		}

		/// <summary>
		/// Gets the is first row.
		/// </summary>
		/// <value>
		/// The is first row.
		/// </value>
		public Visibility IsFirstRow
		{
			get { return String.IsNullOrEmpty(FirstRowDayName) ? Visibility.Collapsed : Visibility.Visible; }
		}

		/// <summary>
		/// Gets or sets the date.
		/// </summary>
		/// <value>
		/// The date.
		/// </value>
		public DateTime Date
		{
			get { return _date; }
			set
			{
				Set(ref _date, value);
			}
		}

		/// <summary>
		/// Gets the day number.
		/// </summary>
		/// <value>
		/// The day number.
		/// </value>
		public string DayNumber
		{
			get { return Date.Day.ToString(); }
		}

		/// <summary>
		/// Gets or sets a value indicating whether this instance is selected.
		/// </summary>
		/// <value>
		/// <c>true</c> if this instance is selected; otherwise, <c>false</c>.
		/// </value>
		public bool IsSelected
		{
			get
			{
				return _isSelected;
			}
			set
			{
				Set(ref _isSelected, value);
			}
		}

		/// <summary>
		/// Gets or sets the events.
		/// </summary>
		/// <value>
		/// The events.
		/// </value>
		public ObservableCollection<IMealHistoryRecord> Events { get; set; }

		/// <summary>
		/// Gets the events count.
		/// </summary>
		/// <value>
		/// The events count.
		/// </value>
		public object EventsCount
		{
			get { return Events.Count; }
		}

		///// <summary>
		///// Gets the first event title.
		///// </summary>
		///// <value>
		///// The first event title.
		///// </value>
		//public object FirstEventTitle
		//{
		//	get { return Events.Count > 0 ? Events.Count == 1 ? Events.First().Subject : "Termine" : null; }
		//}

		//public bool GotForeignEvents
		//{
		//	get { return Events.Any(x => x.IsForeign); }
		//}

		//public bool GotPrivateEvents
		//{
		//	get { return Events.Any(x => !x.IsForeign); }
		//}

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="MonthModelDay"/> class.
		/// </summary>
		public DayModel()
		{
			Events = new ObservableCollection<IMealHistoryRecord>();
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Makes the day name visible.
		/// </summary>
		/// <param name="box">The box.</param>
		public void MakeDayNameVisible(int box)
		{
			FirstRowDayName = DayNames[box];
		}

		#endregion
	}
}
