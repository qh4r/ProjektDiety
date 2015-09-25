using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using CalendarControl.UI.ModelData.MonthView;
using Diety.Helpers;
using Diety.LocalEnums;
using Diety.ViewModel.Modules;
using Diety.ViewModel.Modules.Interfaces;
using Diety.ViewModel.PropertyGroups;
using DietyCommonTypes.Enums;
using DietyCommonTypes.Interfaces;
using DietyDataAccess.Accessors.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Threading;

namespace Diety.ViewModel
{
	public class HomeViewModel : ViewModelBase
	{

		#region Private Fields

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

		/// <summary>
		/// The _selected day
		/// </summary>
		private DayModel _selectedDay;

		#endregion

		#region Public Properties


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
				RaisePropertyChanged(() => FormattedDateSummary);
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
		/// Gets the formatted date summary.
		/// </summary>
		/// <value>
		/// The formatted date summary.
		/// </value>
		public string FormattedDateSummary
		{
			get { return String.Format("Dziś {0}, {1}", 
				CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(CurrentDate.DayOfWeek), 
				CurrentDate.ToString("dd.MM.yyyy")); }
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
							if (result != null)
							{
								_loadingIndicatiorModule.HideLoadingIndicator();
								ReloadData();
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

		#region C-tors

		/// <summary>
		/// Initializes a new instance of the <see cref="HomeViewModel" /> class.
		/// </summary>
		/// <param name="mainFrameNavigationService">The main frame navigation service.</param>
		/// <param name="pageBaseViewModel">The page base view model.</param>
		/// <param name="mealHistoryRecordsAccess">The meal history records access.</param>
		/// <param name="loadingIndicatiorModule">The loading indicatior module.</param>
		/// <param name="currentUserModule">The current user module.</param>
		/// <param name="dialogService">The dialog service.</param>
		public HomeViewModel(IMainFrameNavigationService mainFrameNavigationService, IPageBaseViewModel pageBaseViewModel,
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

			ReloadData();
		}


		#endregion

		#region Private Methods

		/// <summary>
		/// Reloads the data.
		/// </summary>
		/// <exception cref="System.NotImplementedException"></exception>
		private void ReloadData()
		{
			DispatcherHelper.RunAsync(async () =>
			{
				var newEvents =
					await
						_mealHistoryRecordsAccess.GetMealHistoryRecordsList(
							x => x.Date == CurrentDate.Date && x.Owner.Id == _currentUserModule.CurrentUser.Id);
				var calendarEventDatas = newEvents as IMealHistoryRecord[] ?? newEvents.ToArray();
				var day = new DayModel { Date = CurrentDate, Enabled = true, IsTargetMonth = true, IsToday = true };
				foreach (var plannedEvent in calendarEventDatas.Where(eventData => ExistEventsForDay(eventData, day)))
				{
					day.Meals.Add(plannedEvent);
				}
				SelectedDay = day;
			});
		}

		/// <summary>
		/// Exists the events for day.
		/// </summary>
		/// <param name="eventData">The event data.</param>
		/// <param name="dayInstance">The day instance.</param>
		/// <returns></returns>
		private bool ExistEventsForDay(IMealHistoryRecord eventData, DayModel dayInstance)
		{
			return eventData.Date.Date == dayInstance.Date;
		}

		#endregion
	}
}
