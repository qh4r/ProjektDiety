using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using Diety.Helpers;
using Diety.ViewModel.PropertyGroups;
using DietyCommonTypes.Enums;
using DietyCommonTypes.Interfaces;
using DietyDataAccess.Accessors.Interfaces;
using DietyDataAccess.DataTypes.WrapperInterfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Threading;

namespace Diety.ViewModel
{
	public class MealSelectionViewModel : ViewModelBase
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
		/// The _recipes collection
		/// </summary>
		private ObservableCollection<IRecipe> _recipesCollection;

		/// <summary>
		/// The _recipes access
		/// </summary>
		private IRecipesAccess _recipesAccess;

		/// <summary>
		/// The _filtered recipes collection
		/// </summary>
		private ObservableCollection<IRecipe> _filteredRecipesCollection;

		/// <summary>
		/// The _selected recipe
		/// </summary>
		private IRecipeWrapper _selectedRecipe;

		/// <summary>
		/// The _filter text
		/// </summary>
		private string _filterText;

		/// <summary>
		/// The _displayed meals type
		/// </summary>
		private MealTypes _displayedMealsType;

		/// <summary>
		/// The _selected date
		/// </summary>
		private DateTime _selectedDate;

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
		/// Gets or sets the recipes collection.
		/// </summary>
		/// <value>
		/// The recipes collection.
		/// </value>
		public ObservableCollection<IRecipe> RecipesCollection
		{
			get { return _recipesCollection; }
			set { Set(ref _recipesCollection, value); }
		}

		/// <summary>
		/// Gets or sets the filtered recipes collection.
		/// </summary>
		/// <value>
		/// The filtered recipes collection.
		/// </value>
		public ObservableCollection<IRecipe> FilteredRecipesCollection
		{
			get { return _filteredRecipesCollection; }
			set
			{
				Set(ref _filteredRecipesCollection, value);
				RaisePropertyChanged(() => NoData);
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
			get { return FilteredRecipesCollection == null || !FilteredRecipesCollection.Any(); }
		}

		/// <summary>
		/// Gets or sets the selected recipe.
		/// </summary>
		/// <value>
		/// The selected recipe.
		/// </value>
		public IRecipeWrapper SelectedRecipe
		{
			get { return _selectedRecipe; }
			set { Set(ref _selectedRecipe, value); }
		}

		/// <summary>
		/// Gets the select recipe command.
		/// </summary>
		/// <value>
		/// The select recipe command.
		/// </value>
		public RelayCommand<IRecipeWrapper> SelectRecipeCommand
		{
			get
			{
				return new RelayCommand<IRecipeWrapper>(recipe =>
				{
					if (SelectedRecipe != null)
					{
						SelectedRecipe.IsSelectedInverted = false;
					}
					SelectedRecipe = recipe;
					SelectedRecipe.IsSelectedInverted = true;
				});
			}
		}

		/// <summary>
		/// Gets or sets the filter text.
		/// </summary>
		/// <value>
		/// The filter text.
		/// </value>
		public string FilterText
		{
			get { return _filterText; }
			set
			{
				Set(ref _filterText, value);
				FilterIngredientsAction();
			}
		}

		/// <summary>
		/// Gets or sets the type of the displayed meals.
		/// </summary>
		/// <value>
		/// The type of the displayed meals.
		/// </value>
		public MealTypes DisplayedMealsType
		{
			get { return _displayedMealsType; }
			set { Set(ref _displayedMealsType, value); }
		}

		/// <summary>
		/// Gets or sets the selected date.
		/// </summary>
		/// <value>
		/// The selected date.
		/// </value>
		public DateTime SelectedDate
		{
			get { return _selectedDate; }
			set { Set(ref _selectedDate, value); }
		}

		#endregion

		#region C-tors

		/// <summary>
		/// Initializes a new instance of the <see cref="HomeViewModel"/> class.
		/// </summary>
		/// <param name="mainFrameNavigationService">The main frame navigation service.</param>
		/// <param name="pageBaseViewModel">The page base view model.</param>
		/// <param name="recipesAccess">The recipes access.</param>
		public MealSelectionViewModel(IMainFrameNavigationService mainFrameNavigationService, IPageBaseViewModel pageBaseViewModel, IRecipesAccess recipesAccess)
		{
			_mainFrameNavigation = mainFrameNavigationService;
			_recipesAccess = recipesAccess;
			PageBaseModel = pageBaseViewModel;
			var mealData = _mainFrameNavigation.Parameter as MealNavigationData;
			if (mealData != null)
			{
				DisplayedMealsType = mealData.MealFilterType;
				SelectedDate = mealData.SelectedDate;
			}
			DispatcherHelper.RunAsync(async () =>
			{
				var recipes = await _recipesAccess.GetRecipesList(x => x.MealType == DisplayedMealsType, x => x.Name);
				RecipesCollection = new ObservableCollection<IRecipe>(recipes);
				FilteredRecipesCollection = new ObservableCollection<IRecipe>(RecipesCollection.Where(x => true));
			});

		}		

		#endregion

		#region Private Methods

		/// <summary>
		/// Filters the ingredients action.
		/// </summary>
		private void FilterIngredientsAction()
		{
			var filteredList = new ObservableCollection<IRecipe>();
			foreach (var element in RecipesCollection.Where(element => element.Name.ToLower().Contains(FilterText.ToLower() ?? "")))
			{
				filteredList.Add(element);
			}
			FilteredRecipesCollection = filteredList;
		}

		#endregion

	}
}
