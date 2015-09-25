using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using CalendarControl.UI.ModelData.MonthView;
using Diety.Helpers;
using Diety.Helpers.Converters;
using Diety.LocalEnums;
using Diety.ViewModel.Modules;
using Diety.ViewModel.Modules.Interfaces;
using Diety.ViewModel.PropertyGroups;
using DietyCommonTypes.Enums;
using DietyCommonTypes.Extensions;
using DietyCommonTypes.Interfaces;
using DietyDataAccess.Accessors.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Threading;

namespace Diety.ViewModel
{
	public class CalendarViewModel : ViewModelBase
	{
		#region Constants
		/// <summary>
		/// The first day of month
		/// </summary>
		private const int FirstDayOfMonth = 1;

		/// <summary>
		/// The july
		/// </summary>
		private const int July = 7;

		/// <summary>
		/// The january
		/// </summary>
		private const int January = 1;

		#endregion

		#region Fields

		/// <summary>
		/// The _main frame navigation service
		/// </summary>
		private IMainFrameNavigationService _mainFrameNavigation;

		/// <summary>
		/// The _page base model
		/// </summary>
		private IPageBaseViewModel _pageBaseModel;


		/// <summary>
		/// The _date time
		/// </summary>
		private DateTime _dateTime;

		/// <summary>
		/// The _selected day
		/// </summary>
		private DayModel _selectedDay;

		/// <summary>
		/// The _selected month
		/// </summary>
		private MonthModel _selectedMonth;

		/// <summary>
		/// The _leading month
		/// </summary>
		private MonthModel _leadingMonth;

		/// <summary>
		/// The _meal history records access
		/// </summary>
		private IMealHistoryRecordsAccess _mealHistoryRecordsAccess;

		/// <summary>
		/// The _loading indicatior module
		/// </summary>
		private ILoadingIndicatiorModule _loadingIndicatiorModule;

		/// <summary>
		/// The _current user module
		/// </summary>
		private ICurrentUserModule _currentUserModule;

		/// <summary>
		/// The _dialog service
		/// </summary>
		private IDialogService _dialogService;

		#endregion

		#region Properties


		/// <summary>
		/// Gets or sets the page base model.
		/// </summary>
		/// <value>
		/// The page base model.
		/// </value>
		public IPageBaseViewModel PageBaseModel
		{
			get { return _pageBaseModel; }
			set { Set(ref _pageBaseModel, value); }
		}

		/// <summary>
		/// Gets or sets the days.
		/// </summary>
		/// <value>
		/// The days.
		/// </value>
		public ObservableCollection<DayModel> Days { get; set; }

		/// <summary>
		/// Gets or sets the months.
		/// </summary>
		/// <value>
		/// The months.
		/// </value>
		public ObservableCollection<MonthModel> Months { get; set; }

		/// <summary>
		/// Gets or sets the current date.
		/// </summary>
		/// <value>
		/// The current date.
		/// </value>
		public DateTime CurrentDate
		{
			get { return _dateTime; }
			set
			{
				Set(ref _dateTime, value);
			}
		}

		/// <summary>
		/// Gets or sets the selected month.
		/// </summary>
		/// <value>
		/// The selected month.
		/// </value>
		public MonthModel SelectedMonth
		{
			get { return _selectedMonth; }
			set
			{
				Set(ref _selectedMonth, value);
			}
		}

		/// <summary>
		/// Gets or sets the leading month.
		/// </summary>
		/// <value>
		/// The leading month.
		/// </value>
		public MonthModel LeadingMonth
		{
			get { return _leadingMonth; }
			set
			{
				Set(ref _leadingMonth, value);
			}
		}

		/// <summary>
		/// Gets or sets the selected day.
		/// </summary>
		/// <value>
		/// The selected day.
		/// </value>
		public DayModel SelectedDay
		{
			get { return _selectedDay; }
			set
			{
				Set(ref _selectedDay, value);
			}
		}

		/// <summary>
		/// Gets or sets the events data.
		/// </summary>
		/// <value>
		/// The events data.
		/// </value>
		public IEnumerable<IMealHistoryRecord> EventsData { get; set; }

		#endregion

		#region Commands

		/// <summary>
		/// Gets the select day command.
		/// </summary>
		/// <value>
		/// The select day command.
		/// </value>
		public GalaSoft.MvvmLight.Command.RelayCommand<DayModel> SelectDayCommand
		{
			get
			{
				return new GalaSoft.MvvmLight.Command.RelayCommand<DayModel>(day =>
				{
					if (SelectedDay != null) SelectedDay.IsSelected = false;
					day.IsSelected = true;
					SelectedDay = day;
				});
			}
		}

		/// <summary>
		/// Gets the rotate months command.
		/// </summary>
		/// <value>
		/// The rotate months command.
		/// </value>
		public GalaSoft.MvvmLight.Command.RelayCommand<int> RotateMonthsCommand
		{
			get
			{
				return new GalaSoft.MvvmLight.Command.RelayCommand<int>((offset) =>
				{
					RefreshMonths(LeadingMonth.MonthDate.AddMonths(offset));
					UpdateSelectedMonth(LeadingMonth);
				});
			}
		}

		/// <summary>
		/// Gets the show events command.
		/// </summary>
		/// <value>
		/// The show events command.
		/// </value>
		public GalaSoft.MvvmLight.Command.RelayCommand<DayModel> ShowEventsCommand
		{
			get
			{
				return new GalaSoft.MvvmLight.Command.RelayCommand<DayModel>(day =>
				{
					//TODO
					//MessageBox.Show(day.Meals.First().Description, day.Meals.First().Subject);
				}, day => day.IsTargetMonth);
			}
		}

		/// <summary>
		/// Gets the select month command.
		/// </summary>
		/// <value>
		/// The select month command.
		/// </value>
		public GalaSoft.MvvmLight.Command.RelayCommand<MonthModel> SelectMonthCommand
		{
			get
			{
				return new GalaSoft.MvvmLight.Command.RelayCommand<MonthModel>(UpdateSelectedMonth);
			}
		}

		/// <summary>
		/// Gets the add meal.
		/// </summary>
		/// <value>
		/// The add meal.
		/// </value>
		public RelayCommand<MealTypes> AddMeal
		{
			get
			{
				return new RelayCommand<MealTypes>(mealType =>
					{
						_mainFrameNavigation.NavigateTo(PageType.MealSelection, new MealNavigationData
						{
							MealFilterType = mealType,
							SelectedDate = SelectedDay.Date
						});
					});
			}
		}

		/// <summary>
		/// Gets the show details dialog.
		/// </summary>
		/// <value>
		/// The show details dialog.
		/// </value>
		public RelayCommand<IMealHistoryRecord> ShowDetailsDialog
		{
			get
			{
				return new RelayCommand<IMealHistoryRecord>(async meal =>
				{
					var dialogResult = _dialogService.ShowMealDetailsDialog(new MealDetailsDialogModel
					{
						IsPast = SelectedDay.IsPast,
						Meal = meal
					});
					if (dialogResult == DialogResultType.Delete)
					{
						try
						{
							_loadingIndicatiorModule.ShowLoadingIndicatior();
							var result = await _mealHistoryRecordsAccess.DeleteMeal(meal);
							if(result != null)
							{
								_loadingIndicatiorModule.HideLoadingIndicator();
								await RefreshDays(SelectedDay.Date);
							}							
						}
						catch (Exception e)
						{
							//TODO popuperror
							_loadingIndicatiorModule.HideLoadingIndicator();
						}
					}

				});
			}
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="HomeViewModel" /> class.
		/// </summary>
		/// <param name="mainFrameNavigationService">The main frame navigation service.</param>
		/// <param name="pageBaseViewModel">The page base view model.</param>
		/// <param name="mealHistoryRecordsAccess">The meal history records access.</param>
		/// <param name="loadingIndicatiorModule">The loading indicatior module.</param>
		/// <param name="currentUserModule">The current user module.</param>
		/// <param name="dialogService">The dialog service.</param>
		public CalendarViewModel(IMainFrameNavigationService mainFrameNavigationService, IPageBaseViewModel pageBaseViewModel,
			IMealHistoryRecordsAccess mealHistoryRecordsAccess, ILoadingIndicatiorModule loadingIndicatiorModule,
			ICurrentUserModule currentUserModule, IDialogService dialogService)
		{
			CurrentDate = DateTime.Today;
			_mainFrameNavigation = mainFrameNavigationService;
			PageBaseModel = pageBaseViewModel;
			_mealHistoryRecordsAccess = mealHistoryRecordsAccess;
			_loadingIndicatiorModule = loadingIndicatiorModule;
			_currentUserModule = currentUserModule;
			_dialogService = dialogService;

			Days = new ObservableCollection<DayModel>();
			Months = new ObservableCollection<MonthModel>();
			InitializeDate();
			DispatcherHelper.RunAsync(async () =>
			{
				await BuildCalendar(DateTime.Today);
			});

		}

		#endregion

		#region Private Methods

		/// <summary>
		/// Updates the selected month.
		/// </summary>
		/// <param name="newMonth">The new month.</param>
		private void UpdateSelectedMonth(MonthModel newMonth)
		{
			if (SelectedMonth != null) SelectedMonth.IsSelected = false;
			newMonth.IsSelected = true;
			SelectedMonth = newMonth;
			DispatcherHelper.RunAsync(async () =>
			{
				await RefreshDays(newMonth.MonthDate);
			});
		}

		/// <summary>
		/// Builds the calendar.
		/// </summary>
		/// <param name="targetMonthDate">The target month date.</param>
		private async Task BuildCalendar(DateTime targetMonthDate)
		{
			RefreshMonths(targetMonthDate);
			await RefreshDays(targetMonthDate);
		}

		/// <summary>
		/// Initializes the date.
		/// </summary>
		private void InitializeDate()
		{

			CurrentDate = DateTime.Today;
			UpdateSelectedMonth(new MonthModel { MonthDate = new DateTime(CurrentDate.Year, CurrentDate.Month, FirstDayOfMonth) });
		}

		/// <summary>
		/// Refreshes the months.
		/// </summary>
		/// <param name="targetMonth">The target month.</param>
		private void RefreshMonths(DateTime targetMonth)
		{
			Months.Clear();
			DateTime iteratedMonthField = new DateTime(targetMonth.Year, Int32.Parse(targetMonth.Month.ToString()) < July ? January : July, FirstDayOfMonth);
			for (int field = 0; field < 6; field++)
			{
				MonthModel monthInstance = new MonthModel { MonthDate = iteratedMonthField };
				if (field == 0) LeadingMonth = monthInstance;
				if (SelectedMonth.MonthDate == monthInstance.MonthDate)
					UpdateSelectedMonth(monthInstance);
				Months.Add(monthInstance);
				iteratedMonthField = iteratedMonthField.AddMonths(1);
			}
		}

		/// <summary>
		/// Refreshes the days.
		/// </summary>
		/// <param name="targetDate">The target date.</param>
		private async Task RefreshDays(DateTime targetDate)
		{
			_loadingIndicatiorModule.ShowLoadingIndicatior();
			DayModel dayInstance;
			DateTime displayedDayDate = GetCorrectStartingDate(targetDate);
			//TODO
			//EventsData = EventService.GetEventsList(displayedDayDate);
			var newEvents = await _mealHistoryRecordsAccess.GetMealHistoryRecordsList(x => x.Date >= displayedDayDate && x.Date <= displayedDayDate.AddDays(42) && x.Owner.Id == _currentUserModule.CurrentUser.Id);
			if (newEvents != null)
			{
				Days.Clear();
				EventsData = newEvents;
			}

			//EventsData = new List<IMealHistoryRecord>();
			//for performance improvement.
			var calendarEventDatas = EventsData as IMealHistoryRecord[] ?? EventsData.ToArray();
			for (int box = 0; box < 42; box++)
			{
				if (IsCurrentlySelected(displayedDayDate))
				{
					dayInstance = SelectedDay;
					dayInstance.IsTargetMonth = targetDate.Month == displayedDayDate.Month;
				}
				else
				{
					dayInstance = InitializeDayInstance(displayedDayDate, box);
				}
				dayInstance.Meals.Clear();
				foreach (var plannedEvent in calendarEventDatas.Where(eventData => ExistEventsForDay(eventData, dayInstance)))
				{
					dayInstance.Meals.Add(plannedEvent);
				}
				if (SelectedDay == null && dayInstance.IsToday)
				{
					dayInstance.IsSelected = true;
					SelectedDay = dayInstance;
				}

				Days.Add(dayInstance);
				displayedDayDate = displayedDayDate.AddDays(1);
			}
			_loadingIndicatiorModule.HideLoadingIndicator();
		}

		/// <summary>
		/// Determines whether [is currently selected] [the specified displayed day date].
		/// </summary>
		/// <param name="displayedDayDate">The displayed day date.</param>
		/// <returns></returns>
		private bool IsCurrentlySelected(DateTime displayedDayDate)
		{
			return SelectedDay != null && SelectedDay.Date == displayedDayDate;
		}

		/// <summary>
		/// Initializes the day instance.
		/// </summary>
		/// <param name="displayedDayDate">The displayed day date.</param>
		/// <param name="box">The box.</param>
		/// <returns></returns>
		private DayModel InitializeDayInstance(DateTime displayedDayDate, int box)
		{
			var dayInstance = new DayModel { Date = displayedDayDate, Enabled = true, IsTargetMonth = SelectedMonth.MonthDate.Month == displayedDayDate.Month };
			if (box < 7) dayInstance.MakeDayNameVisible(box);
			dayInstance.IsToday = displayedDayDate == DateTime.Today;
			return dayInstance;
		}

		/// <summary>
		/// Gets the correct starting date.
		/// </summary>
		/// <param name="targetDate">The target date.</param>
		/// <returns></returns>
		private DateTime GetCorrectStartingDate(DateTime targetDate)
		{
			var displayedDayDate = GetFirstDayOfMonth(targetDate);
			int offset = CalculateFirstDayToDisplayOffest(displayedDayDate);
			return displayedDayDate.AddDays(-offset);
		}

		/// <summary>
		/// Gets the events for day.
		/// </summary>
		/// <param name="eventData">The event data.</param>
		/// <param name="dayInstance">The day instance.</param>
		/// <returns></returns>
		private bool ExistEventsForDay(IMealHistoryRecord eventData, DayModel dayInstance)
		{
			return eventData.Date.Date == dayInstance.Date;
		}

		/// <summary>
		/// Gets the first day of month.
		/// </summary>
		/// <param name="targetDate">The target date.</param>
		/// <returns></returns>
		private DateTime GetFirstDayOfMonth(DateTime targetDate)
		{
			return new DateTime(targetDate.Year, targetDate.Month, FirstDayOfMonth);
		}

		/// <summary>
		/// Calculates the first day of month offest.
		/// </summary>
		/// <param name="iteratedDayField">The iterated day field.</param>
		/// <returns></returns>
		private int CalculateFirstDayToDisplayOffest(DateTime iteratedDayField)
		{
			var offset = (DayOfWeekNumber(iteratedDayField.DayOfWeek) + 6) % 7;
			return offset == 0 ? offset + 7 : offset;
		}

		/// <summary>
		/// Days the of week number.
		/// </summary>
		/// <param name="dow">The dow.</param>
		/// <returns></returns>
		private int DayOfWeekNumber(DayOfWeek dow)
		{
			return Convert.ToInt32(dow.ToString("D"));
		}

		#endregion

		#region Public Methods
		#endregion
	}
}
