using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Diety.Helpers;
using Diety.ViewModel.Modules;
using DietyCommonTypes.Interfaces;
using DietyDataAccess.Accessors.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Threading;

namespace Diety.ViewModel
{
	public class RecipesViewModel : ViewModelBase
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
		/// Gets the add recipe.
		/// </summary>
		/// <value>
		/// The add recipe.
		/// </value>
		public RelayCommand AddRecipe
		{
			get { return new RelayCommand(() =>
			{
				_mainFrameNavigation.NavigateTo(PageType.AddEditRecipe);
			}); }
		}

		#endregion

		#region C-tors

		/// <summary>
		/// Initializes a new instance of the <see cref="HomeViewModel"/> class.
		/// </summary>
		/// <param name="mainFrameNavigationService">The main frame navigation service.</param>
		/// <param name="pageBaseViewModel">The page base view model.</param>
		/// <param name="recipesAccess">The recipes access.</param>
		public RecipesViewModel(IMainFrameNavigationService mainFrameNavigationService, IPageBaseViewModel pageBaseViewModel, IRecipesAccess recipesAccess)
		{
			_mainFrameNavigation = mainFrameNavigationService;
			_recipesAccess = recipesAccess;
			PageBaseModel = pageBaseViewModel;
			DispatcherHelper.RunAsync(async () =>
			{				
				var recipes = await _recipesAccess.GetRecipesList(null, x => x.Name);
				RecipesCollection = new ObservableCollection<IRecipe>(recipes);
				FilteredRecipesCollection = new ObservableCollection<IRecipe>(RecipesCollection.Where(x => true));
			});

			//FilteredRecipesCollection.CollectionChanged += (sender, args) =>
			//{
			//	RaisePropertyChanged(() => NoData);
			//};

		}		

		#endregion
	}
}
