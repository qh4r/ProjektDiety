using System;
using System.Xml.Serialization;
using Diety.Helpers;
using Diety.ViewModel.Modules;
using Diety.ViewModel.Modules.Interfaces;
using Diety.ViewModel.PropertyGroups;
using Diety.ViewModel.PropertyGroups.Interfaces;
using Diety.Views;
using DietyServices;
using DietyDataAccess.Accessors;
using DietyDataAccess.Accessors.Interfaces;
using DietyServices.Interfaces;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace Diety.ViewModel
{

	public class ViewModelLocator
	{

		#region C-tors

		/// <summary>
		/// Initializes a new instance of the <see cref="ViewModelLocator" /> class.
		/// </summary>
		public ViewModelLocator()
		{
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			SetupNavigation();

			SimpleIoc.Default.Register<IngredientsAccess>();
			SimpleIoc.Default.Register<MealHistoryRecordsAccess>();
			SimpleIoc.Default.Register<RecipeComponentsAccess>();
			SimpleIoc.Default.Register<RecipesAccess>();
			SimpleIoc.Default.Register<TrainingHistoryRecordsAccess>();
			SimpleIoc.Default.Register<TrainingsAccess>();
			SimpleIoc.Default.Register<UserProfilesAccess>();
			SimpleIoc.Default.Register<WeightHistoryRecordsAccess>();

			SimpleIoc.Default.Register<IIngredientsAccess>(() => SimpleIoc.Default.GetInstance<IngredientsAccess>());
			SimpleIoc.Default.Register<IMealHistoryRecordsAccess>(() => SimpleIoc.Default.GetInstance<MealHistoryRecordsAccess>());
			SimpleIoc.Default.Register<IRecipeComponentsAccess>(() => SimpleIoc.Default.GetInstance<RecipeComponentsAccess>());
			SimpleIoc.Default.Register<IRecipesAccess>(() => SimpleIoc.Default.GetInstance<RecipesAccess>());
			SimpleIoc.Default.Register<ITrainingHistoryRecordsAccess>(() => SimpleIoc.Default.GetInstance<TrainingHistoryRecordsAccess>());
			SimpleIoc.Default.Register<ITrainingsAccess>(() => SimpleIoc.Default.GetInstance<TrainingsAccess>());
			SimpleIoc.Default.Register<IUserProfilesAccess>(() => SimpleIoc.Default.GetInstance<UserProfilesAccess>());
			SimpleIoc.Default.Register<IWeightHistoryRecordsAccess>(() => SimpleIoc.Default.GetInstance<WeightHistoryRecordsAccess>());

			SimpleIoc.Default.Register<PageBaseViewModel>();
			SimpleIoc.Default.Register<PasswordProcessingService>();
			SimpleIoc.Default.Register<CurrentUserModule>();
			SimpleIoc.Default.Register<LoadingIndicatiorModule>();

			SimpleIoc.Default.Register<IPageBaseViewModel>(() => SimpleIoc.Default.GetInstance<PageBaseViewModel>());
			SimpleIoc.Default.Register<IPasswordProcessingService>(() => SimpleIoc.Default.GetInstance<PasswordProcessingService>());
			SimpleIoc.Default.Register<ICurrentUserModule>(() => SimpleIoc.Default.GetInstance<CurrentUserModule>());
			SimpleIoc.Default.Register<ILoadingIndicatiorModule>(() => SimpleIoc.Default.GetInstance<LoadingIndicatiorModule>());

			SimpleIoc.Default.Register<MainViewModel>();
			SimpleIoc.Default.Register<LoginViewModel>();
			SimpleIoc.Default.Register<RegisterUserViewModel>();
			SimpleIoc.Default.Register<HomeViewModel>();
			SimpleIoc.Default.Register<RecipesViewModel>();
			SimpleIoc.Default.Register<StatisticsViewModel>();
			SimpleIoc.Default.Register<CalendarViewModel>();
			SimpleIoc.Default.Register<AddEditRecipeViewModel>();
			SimpleIoc.Default.Register<MealSelectionViewModel>();

		}

		#endregion

		#region Private Methods

		/// <summary>
		/// Setups the navigation.
		/// </summary>
		private void SetupNavigation()
		{
			var navigationService = new MainFrameNavigationService();
			navigationService.Configure(PageType.Login, new Uri("/Views/Login.xaml", UriKind.Relative));
			navigationService.Configure(PageType.RegisterUser, new Uri("/Views/RegisterUser.xaml", UriKind.Relative));
			navigationService.Configure(PageType.Home, new Uri("/Views/Home.xaml", UriKind.Relative));
			navigationService.Configure(PageType.Calendar, new Uri("/Views/Calendar.xaml", UriKind.Relative));
			navigationService.Configure(PageType.Statistics, new Uri("/Views/Statistics.xaml", UriKind.Relative));
			navigationService.Configure(PageType.Recipes, new Uri("/Views/Recipes.xaml", UriKind.Relative));
			navigationService.Configure(PageType.AddEditRecipe, new Uri("/Views/AddEditRecipe.xaml", UriKind.Relative));
			navigationService.Configure(PageType.MealSelection, new Uri("/Views/MealSelection.xaml", UriKind.Relative));



			SimpleIoc.Default.Register<IMainFrameNavigationService>(() => navigationService);

		}

		#endregion


		#region Public Methods

		/// <summary>
		/// Gets the main.
		/// </summary>
		/// <value>
		/// The main.
		/// </value>
		public MainViewModel Main
		{
			get { return SimpleIoc.Default.GetInstance<MainViewModel>(); }
		}

		/// <summary>
		/// Gets the login.
		/// </summary>
		/// <value>
		/// The login.
		/// </value>
		public LoginViewModel Login
		{
			get { return SimpleIoc.Default.GetInstance<LoginViewModel>(); }
		}

		/// <summary>
		/// Gets the register user.
		/// </summary>
		/// <value>
		/// The register user.
		/// </value>
		public RegisterUserViewModel RegisterUser
		{
			get { return SimpleIoc.Default.GetInstanceWithoutCaching<RegisterUserViewModel>(); }
		}

		/// <summary>
		/// Gets the home.
		/// </summary>
		/// <value>
		/// The home.
		/// </value>
		public HomeViewModel Home
		{
			get { return SimpleIoc.Default.GetInstance<HomeViewModel>(); }
		}

		/// <summary>
		/// Gets the calendar.
		/// </summary>
		/// <value>
		/// The calendar.
		/// </value>
		public CalendarViewModel Calendar
		{
			get { return SimpleIoc.Default.GetInstanceWithoutCaching<CalendarViewModel>(); }
		}

		/// <summary>
		/// Gets the recipes.
		/// </summary>
		/// <value>
		/// The recipes.
		/// </value>
		public RecipesViewModel Recipes
		{
			get { return SimpleIoc.Default.GetInstanceWithoutCaching<RecipesViewModel>(); }
		}

		/// <summary>
		/// Gets the statistics.
		/// </summary>
		/// <value>
		/// The statistics.
		/// </value>
		public StatisticsViewModel Statistics
		{
			get { return SimpleIoc.Default.GetInstance<StatisticsViewModel>(); }
		}

		/// <summary>
		/// Gets the add edit recipe.
		/// </summary>
		/// <value>
		/// The add edit recipe.
		/// </value>
		public AddEditRecipeViewModel AddEditRecipe
		{
			get { return SimpleIoc.Default.GetInstanceWithoutCaching<AddEditRecipeViewModel>(); }
		}

		/// <summary>
		/// Gets the meal selection.
		/// </summary>
		/// <value>
		/// The meal selection.
		/// </value>
		public MealSelectionViewModel MealSelection
		{
			get { return SimpleIoc.Default.GetInstanceWithoutCaching<MealSelectionViewModel>(); }
		}


		/// <summary>
		/// Cleanups this instance.
		/// </summary>
		public static void Cleanup()
		{
		}

		#endregion

	}
}