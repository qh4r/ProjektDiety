using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Diety.Helpers;
using Diety.ViewModel.Modules.Interfaces;
using DietyCommonTypes.Enums;
using DietyCommonTypes.Interfaces;
using DietyDataAccess.Accessors.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Threading;

namespace Diety.ViewModel
{
	public class AddEditRecipeViewModel : ViewModelBase
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
		/// The _meal types collection
		/// </summary>
		private ObservableCollection<MealTypes> _mealTypesCollection;

		/// <summary>
		/// The _filtered recipe components
		/// </summary>
		private ObservableCollection<IIngredient> _filteredIngredients;

		/// <summary>
		/// The _all recipe components
		/// </summary>
		private ObservableCollection<IIngredient> _allRecipeComponents;

		/// <summary>
		/// The _recipe components access
		/// </summary>
		private IIngredientsAccess _ingredientsAccess;

		/// <summary>
		/// The _loading indicatior module
		/// </summary>
		private ILoadingIndicatiorModule _loadingIndicatiorModule;

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
		/// Gets or sets the type of the meal.
		/// </summary>
		/// <value>
		/// The type of the meal.
		/// </value>
		public ObservableCollection<MealTypes> MealTypesCollection
		{
			get { return _mealTypesCollection; }
			set { Set(ref _mealTypesCollection, value); }
		}


		/// <summary>
		/// Gets or sets the filtered recipe components.
		/// </summary>
		/// <value>
		/// The filtered recipe components.
		/// </value>
		public ObservableCollection<IIngredient> FilteredIngredients
		{
			get { return _filteredIngredients; }
			set
			{
				Set(ref _filteredIngredients, value);
				RaisePropertyChanged(() => NoData);
			}
		}


		/// <summary>
		/// Gets or sets all recipe components.
		/// </summary>
		/// <value>
		/// All recipe components.
		/// </value>
		public ObservableCollection<IIngredient> AllIngredients
		{
			get { return _allRecipeComponents; }
			set
			{
				Set(ref _allRecipeComponents, value);				
			}
		}

		/// <summary>
		/// Gets a value indicating whether [no data].
		/// </summary>
		/// <value>
		///   <c>true</c> if [no data]; otherwise, <c>false</c>.
		/// </value>
		public bool NoData
		{
			get { return FilteredIngredients == null || !FilteredIngredients.Any(); }
		}

		#endregion

		#region C-tors

		/// <summary>
		/// Initializes a new instance of the <see cref="HomeViewModel" /> class.
		/// </summary>
		/// <param name="mainFrameNavigationService">The main frame navigation service.</param>
		/// <param name="pageBaseViewModel">The page base view model.</param>
		/// <param name="ingredientsAccess">The recipe components access.</param>
		/// <param name="loadingIndicatiorModule">The loading indicatior module.</param>
		public AddEditRecipeViewModel(IMainFrameNavigationService mainFrameNavigationService, IPageBaseViewModel pageBaseViewModel,
			IIngredientsAccess ingredientsAccess, ILoadingIndicatiorModule loadingIndicatiorModule)
		{
			_mainFrameNavigation = mainFrameNavigationService;
			_ingredientsAccess = ingredientsAccess;
			_loadingIndicatiorModule = loadingIndicatiorModule;
			PageBaseModel = pageBaseViewModel;
			
			MealTypesCollection = new ObservableCollection<MealTypes>
			{
				MealTypes.Breakfast,
				MealTypes.Dinner,
				MealTypes.Supper,
				MealTypes.AdditionalMeal
			};

			DispatcherHelper.RunAsync(async () =>
			{
				_loadingIndicatiorModule.ShowLoadingIndicatior();
				var components = await _ingredientsAccess.GetIngredientsList(x => true, x => x.Name);
				AllIngredients = new ObservableCollection<IIngredient>(components);
				FilteredIngredients = new ObservableCollection<IIngredient>(AllIngredients.Where(x => true));
				_loadingIndicatiorModule.HideLoadingIndicator();
			});
		}

		#endregion

	}
}
