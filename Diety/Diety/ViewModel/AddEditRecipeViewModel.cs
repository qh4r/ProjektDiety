using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Diety.Helpers;
using Diety.ViewModel.Modules.Interfaces;
using DietyCommonTypes.Enums;
using DietyCommonTypes.Interfaces;
using DietyDataAccess.Accessors.Interfaces;
using DietyDataAccess.DataTypes;
using DietyDataAccess.DataTypes.WrapperInterfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
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

		/// <summary>
		/// The _selected meal type
		/// </summary>
		private MealTypes _selectedMealType;

		/// <summary>
		/// The _description
		/// </summary>
		private string _description;

		/// <summary>
		/// The _name
		/// </summary>
		private string _name;

		/// <summary>
		/// The _filter text
		/// </summary>
		private string _filterText;

		/// <summary>
		/// The _new recipe
		/// </summary>
		private IRecipeWrapper _selectedRecipe;

		/// <summary>
		/// The _unit types collection
		/// </summary>
		private ObservableCollection<UnitTypes> _unitTypesCollection;

		/// <summary>
		/// The _recipes access
		/// </summary>
		private IRecipesAccess _recipesAccess;

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
		/// Gets or sets the new recipe.
		/// </summary>
		/// <value>
		/// The new recipe.
		/// </value>
		public IRecipeWrapper SelectedRecipe
		{
			get { return _selectedRecipe; }
			set { Set(ref _selectedRecipe, value); }
		}

		/// <summary>
		/// Gets the select ingredient command.
		/// </summary>
		/// <value>
		/// The select ingredient command.
		/// </value>
		public RelayCommand<IIngredient> SelectIngredientCommand
		{
			get
			{
				return new RelayCommand<IIngredient>(ingredient =>
					{
						var components = SelectedRecipe.ComponentsList.ToList();
						if (components.All(x => x.Ingredient.Id != ingredient.Id))
						{
							//SelectedRecipe.AddComponent();
							components.Add(new RecipeComponent(ingredient));
							SelectedRecipe.ComponentsList = components;
						}
					});
			}
		}

		/// <summary>
		/// Gets or sets the unit types collection.
		/// </summary>
		/// <value>
		/// The unit types collection.
		/// </value>
		public ObservableCollection<UnitTypes> UnitTypesCollection
		{
			get { return _unitTypesCollection; }
			set { Set(ref _unitTypesCollection, value); }
		}

		/// <summary>
		/// Gets the remove component.
		/// </summary>
		/// <value>
		/// The remove component.
		/// </value>
		public RelayCommand<IRecipeComponent> RemoveComponent
		{
			get
			{
				return new RelayCommand<IRecipeComponent>(component =>
					{
						var components = SelectedRecipe.ComponentsList.ToList();
						components.Remove(component);
						SelectedRecipe.ComponentsList = components;
					});
			}
		}

		/// <summary>
		/// Gets the cancel command.
		/// </summary>
		/// <value>
		/// The cancel command.
		/// </value>
		public RelayCommand CancelCommand
		{
			get
			{
				return new RelayCommand(() =>
					{
						_mainFrameNavigation.GoBack();
					});
			}
		}

		/// <summary>
		/// Gets the save recipe command.
		/// </summary>
		/// <value>
		/// The save recipe command.
		/// </value>
		public RelayCommand SaveRecipeCommand
		{
			get
			{
				return new RelayCommand(async () =>
				{
					if (CheckForErrors())
					{						
						await SaveRecipe();
					}
				});
			}
		}

		/// <summary>
		/// Gets the name got focus.
		/// </summary>
		/// <value>
		/// The name got focus.
		/// </value>
		public RelayCommand NameGotFocus
		{
			get { return new RelayCommand(() =>
			{
				SelectedRecipe.NameError = false;
			}); }
		}

		/// <summary>
		/// Gets or sets a value indicating whether [editm mode enabled].
		/// </summary>
		/// <value>
		///   <c>true</c> if [editm mode enabled]; otherwise, <c>false</c>.
		/// </value>
		public bool EditModeEnabled { get; set; }


		/// <summary>
		/// Gets or sets the previous components list.
		/// </summary>
		/// <value>
		/// The previous components list.
		/// </value>
		public IEnumerable<IRecipeComponent> PreviousComponentsList { get; set; }


		#endregion

		#region C-tors

		/// <summary>
		/// Initializes a new instance of the <see cref="HomeViewModel" /> class.
		/// </summary>
		/// <param name="mainFrameNavigationService">The main frame navigation service.</param>
		/// <param name="pageBaseViewModel">The page base view model.</param>
		/// <param name="ingredientsAccess">The recipe components access.</param>
		/// <param name="loadingIndicatiorModule">The loading indicatior module.</param>
		/// <param name="recipesAccess">The recipes access.</param>
		public AddEditRecipeViewModel(IMainFrameNavigationService mainFrameNavigationService, IPageBaseViewModel pageBaseViewModel,
			IIngredientsAccess ingredientsAccess, ILoadingIndicatiorModule loadingIndicatiorModule, IRecipesAccess recipesAccess)
		{
			_mainFrameNavigation = mainFrameNavigationService;
			_ingredientsAccess = ingredientsAccess;
			_loadingIndicatiorModule = loadingIndicatiorModule;
			_recipesAccess = recipesAccess;
			PageBaseModel = pageBaseViewModel;

			MealTypesCollection = new ObservableCollection<MealTypes>();
			foreach (MealTypes value in Enum.GetValues(typeof(MealTypes)))
			{
				MealTypesCollection.Add(value);
			}

			UnitTypesCollection = new ObservableCollection<UnitTypes>();
			foreach (UnitTypes value in Enum.GetValues(typeof(UnitTypes)))
			{
				UnitTypesCollection.Add(value);
			}

			var param = _mainFrameNavigation.Parameter as IRecipeWrapper;
			if (param != null)
			{
				EditModeEnabled = true;
				SelectedRecipe = param;
				PreviousComponentsList = param.ComponentsList;
			}
			else
			{
				EditModeEnabled = false;
				SelectedRecipe = new Recipe();
			}
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

		#region Private Methods

		/// <summary>
		/// Filters the ingredients action.
		/// </summary>
		private void FilterIngredientsAction()
		{
			var filteredList = new ObservableCollection<IIngredient>();
			foreach (var element in AllIngredients.Where(element => element.Name.ToLower().Contains(FilterText.ToLower() ?? "")))
			{
				filteredList.Add(element);
			}
			FilteredIngredients = filteredList;
		}

		/// <summary>
		/// Checks for errors.
		/// </summary>
		/// <returns></returns>
		private bool CheckForErrors()
		{
			bool noErrors = true;
			if(String.IsNullOrWhiteSpace(SelectedRecipe.Name))
			{
				noErrors = false;
				SelectedRecipe.NameError = true;
			}
			if (SelectedRecipe.ComponentsList == null || !SelectedRecipe.ComponentsList.Any())
			{
				SelectedRecipe.ComponentsError = true;
				return false;
			}
			try
			{
				foreach (var recipeComponent in SelectedRecipe.ComponentsList)
				{

					var component = (RecipeComponent) recipeComponent;
					double checkValue;
					if (!Double.TryParse(component.AmountText, out checkValue))
					{
						component.AmountError = true;
						noErrors = false;
					}
				}
			}
			catch (InvalidCastException e)
			{				
				Debug.WriteLine(e.Message);
				return false;
			}
			return noErrors;
		}

		/// <summary>
		/// Saves the recipe.
		/// </summary>
		/// <returns></returns>
		private async Task SaveRecipe()
		{
			try
			{
				_loadingIndicatiorModule.ShowLoadingIndicatior();
				IRecipe added = null;
				if (EditModeEnabled)
				{
					added = await _recipesAccess.UpdateRecipe(SelectedRecipe, PreviousComponentsList);
				}
				else
				{
					added  = await _recipesAccess.AddRecipe(SelectedRecipe);
				}
				if (added != null)
				{
					_mainFrameNavigation.GoBack();
				}
				_loadingIndicatiorModule.HideLoadingIndicator();
			}
			catch (Exception e)
			{
				_loadingIndicatiorModule.HideLoadingIndicator();
				//TODO message popup
			}
		}

		#endregion

	}
}
