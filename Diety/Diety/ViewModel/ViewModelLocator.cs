using System;
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

			SimpleIoc.Default.Register<PasswordProcessingService>();
			SimpleIoc.Default.Register<CurrentUserModule>();

			SimpleIoc.Default.Register<IPasswordProcessingService>(() => SimpleIoc.Default.GetInstance<PasswordProcessingService>());
			SimpleIoc.Default.Register<ICurrentUserModule>(() => SimpleIoc.Default.GetInstance<CurrentUserModule>());

			SimpleIoc.Default.Register<MainViewModel>();
			SimpleIoc.Default.Register<LoginViewModel>();
			SimpleIoc.Default.Register<RegisterUserViewModel>();
			SimpleIoc.Default.Register<HomeViewModel>();
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
		/// Cleanups this instance.
		/// </summary>
		public static void Cleanup()
		{
		}

		#endregion

	}
}