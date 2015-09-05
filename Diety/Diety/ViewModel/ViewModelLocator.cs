

using System;
using Diety.Helpers;
using Diety.Views;
using DietyDataAccess.Accessors;
using DietyDataAccess.Accessors.Interfaces;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace Diety.ViewModel
{

    public class ViewModelLocator
    {

	    #region C-tors

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

		    SimpleIoc.Default.Register<MainViewModel>();
		    SimpleIoc.Default.Register<StartViewModel>();
		    SimpleIoc.Default.Register<SecondViewModel>();
	    }

	    #endregion

		private void SetupNavigation()
		{
			var navigationService = new FrameNavigationService();
			navigationService.Configure(PageType.Start, new Uri("/Views/Start.xaml", UriKind.Relative));
			navigationService.Configure(PageType.Second, new Uri("/Views/Second.xaml", UriKind.Relative));


			SimpleIoc.Default.Register<IFrameNavigationService>(() => navigationService);

		}


		public MainViewModel Main
		{
			get
			{
				return ServiceLocator.Current.GetInstance<MainViewModel>();
			}
		}

		public SecondViewModel Second
		{
			get
			{
				return ServiceLocator.Current.GetInstance<SecondViewModel>();
			}
		}

		public StartViewModel Start
		{
			get
			{
				return ServiceLocator.Current.GetInstance<StartViewModel>();
			}
		}
        
        public static void Cleanup()
        {
        }
    }
}