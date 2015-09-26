using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Diety.Helpers;
using Diety.ViewModel.Modules;
using Diety.ViewModel.Modules.Interfaces;
using Diety.ViewModel.PropertyGroups;
using DietyCommonTypes.Interfaces;
using DietyDataAccess.Accessors.Interfaces;
using DietyDataAccess.DataTypes;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace Diety.ViewModel
{
	public class StatisticsViewModel : ViewModelBase
	{
		#region Events

		/// <summary>
		/// Occurs when [load data].
		/// </summary>
		public event Action<IEnumerable<ChartData>> LoadData;

		/// <summary>
		/// Occurs when [add record].
		/// </summary>
		public event Action<ChartData> AddRecord;

		#endregion

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
		/// The _loading indicatior module
		/// </summary>
		private ILoadingIndicatiorModule _loadingIndicatiorModule;

		/// <summary>
		/// The _current user module
		/// </summary>
		private ICurrentUserModule _currentUserModule;

		/// <summary>
		/// The _weight history records access
		/// </summary>
		private IWeightHistoryRecordsAccess _weightHistoryRecordsAccess;

		/// <summary>
		/// The _weight
		/// </summary>
		private string _weight;

		/// <summary>
		/// The _weight error message
		/// </summary>
		private string _weightErrorMessage;

		/// <summary>
		/// The _chart record collection
		/// </summary>
		private ObservableCollection<ChartData> _chartRecordCollection;

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
		/// Gets the page loaded command.
		/// </summary>
		/// <value>
		/// The page loaded command.
		/// </value>
		public RelayCommand PageLoadedCommand
		{
			get
			{
				return new RelayCommand(async () =>
				{
					//double lastVal = 20;
					//DateTime lastDate = DateTime.Now;

					//for (int i = 0; i < 100; ++i)
					//{
					//	ChartData obj = new ChartData { Date = lastDate.AddDays(1), Value = lastVal++ };
					//	ChartRecordsCollection.Add(obj);
					//	lastDate = obj.Date;
					//}
					//OnLoadData(ChartRecordsCollection);

					try
					{
						_loadingIndicatiorModule.ShowLoadingIndicatior();

						var result = await _weightHistoryRecordsAccess.GetWeightHistoryRecordsList(x => x.Owner.Id == _currentUserModule.CurrentUser.Id);
						var weightHistoryRecords = result as IWeightHistoryRecord[] ?? result.ToArray();
						if (result != null && weightHistoryRecords.Any())
						{
							ChartRecordsCollection = new ObservableCollection<ChartData>(weightHistoryRecords.Select(x => new ChartData
							{
								Date = x.Date,
								Value = x.Weight
							}));
							//OnLoadData(ChartRecordsCollection);
						}

						_loadingIndicatiorModule.HideLoadingIndicator();
					}
					catch (Exception e)
					{
						_loadingIndicatiorModule.HideLoadingIndicator();
						//TODO errorpopup
					}
				});
			}
		}

		/// <summary>
		/// Gets or sets the chart records collection.
		/// </summary>
		/// <value>
		/// The chart records collection.
		/// </value>
		public ObservableCollection<ChartData> ChartRecordsCollection
		{
			get { return _chartRecordCollection; }
			set { Set(ref _chartRecordCollection, value); }
		}

		/// <summary>
		/// Gets or sets the weight.
		/// </summary>
		/// <value>
		/// The weight.
		/// </value>
		public string Weight
		{
			get { return _weight; }
			set { Set(ref _weight, value); }
		}

		/// <summary>
		/// Gets the weight got focus.
		/// </summary>
		/// <value>
		/// The weight got focus.
		/// </value>
		public RelayCommand WeightGotFocus
		{
			get
			{
				return new RelayCommand(() =>
				{
					WeightErrorMessage = null;
				});
			}
		}

		/// <summary>
		/// Gets or sets the weight error message.
		/// </summary>
		/// <value>
		/// The weight error message.
		/// </value>
		public string WeightErrorMessage
		{
			get { return _weightErrorMessage; }
			set
			{
				Set(ref _weightErrorMessage, value);
				RaisePropertyChanged(() => WeightError);
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether [weight error].
		/// </summary>
		/// <value>
		///   <c>true</c> if [weight error]; otherwise, <c>false</c>.
		/// </value>
		public bool WeightError
		{
			get { return !String.IsNullOrEmpty(WeightErrorMessage); }
		}

		/// <summary>
		/// Gets the weight lost focus.
		/// </summary>
		/// <value>
		/// The weight lost focus.
		/// </value>
		public RelayCommand WeightLostFocus
		{
			get
			{
				return new RelayCommand(() =>
				{
					if (String.IsNullOrWhiteSpace(Weight))
					{
						WeightErrorMessage = "Waga musi zostać wypełniona";
					}
					else
					{
						WeightErrorMessage = CheckForNumeric(Weight) ? null : "Proszę podać liczbę zmiennoprzecinkową";
					}
				});
			}
		}

		/// <summary>
		/// Gets the add measurement.
		/// </summary>
		/// <value>
		/// The add measurement.
		/// </value>
		public RelayCommand AddMeasurement
		{
			get
			{
				return new RelayCommand(async () =>
					{
						try
						{
							_loadingIndicatiorModule.ShowLoadingIndicatior();

							var dateNow = DateTime.Now;
							var doubleValue = Double.Parse(Weight);

							var result = await _weightHistoryRecordsAccess.AddMealRecord(
								new WeightHistoryRecord
								{
									Date = dateNow,
									Weight = doubleValue,
									Owner = _currentUserModule.CurrentUser
								});
							if (result != null && result.Id != 0)
							{
								ChartRecordsCollection.Add(new ChartData
								{
									Date = dateNow,
									Value = doubleValue
								});
							}

							_loadingIndicatiorModule.HideLoadingIndicator();
						}
						catch (Exception e)
						{
							_loadingIndicatiorModule.HideLoadingIndicator();
							//TODO errorpopup
						}
					}, () => !WeightError);
			}
		}

		#endregion

		#region C-tors

		/// <summary>
		/// Initializes a new instance of the <see cref="HomeViewModel" /> class.
		/// </summary>
		/// <param name="mainFrameNavigationService">The main frame navigation service.</param>
		/// <param name="pageBaseViewModel">The page base view model.</param>
		/// <param name="weightHistoryRecordsAccess">The weight history records access.</param>
		/// <param name="loadingIndicatiorModule">The loading indicatior module.</param>
		/// <param name="currentUserModule">The current user module.</param>
		public StatisticsViewModel(IMainFrameNavigationService mainFrameNavigationService, IPageBaseViewModel pageBaseViewModel,
			IWeightHistoryRecordsAccess weightHistoryRecordsAccess, ILoadingIndicatiorModule loadingIndicatiorModule,
			ICurrentUserModule currentUserModule)
		{
			_mainFrameNavigation = mainFrameNavigationService;
			PageBaseModel = pageBaseViewModel;
			_loadingIndicatiorModule = loadingIndicatiorModule;
			_currentUserModule = currentUserModule;
			_weightHistoryRecordsAccess = weightHistoryRecordsAccess;

			ChartRecordsCollection = new ObservableCollection<ChartData>();

		}

		#endregion

		#region EventHandlers

		/// <summary>
		/// Called when [load data].
		/// </summary>
		/// <param name="chartData">The chart data.</param>
		protected void OnLoadData(IEnumerable<ChartData> chartData)
		{
			var handler = LoadData;
			if (handler != null) handler(chartData);
		}

		#endregion

		#region Private Methods

		/// <summary>
		/// Checks for numeric.
		/// </summary>
		/// <param name="number">The number.</param>
		/// <returns></returns>
		/// <exception cref="System.NotImplementedException"></exception>
		private bool CheckForNumeric(string number)
		{
			double convertedNumber;
			return Double.TryParse(number.Replace('.', ','), out convertedNumber);
		}

		/// <summary>
		/// Called when [add record].
		/// </summary>
		/// <param name="obj">The object.</param>
		protected void OnAddRecord(ChartData obj)
		{
			var handler = AddRecord;
			if (handler != null) handler(obj);
		}

		#endregion
	}
}
