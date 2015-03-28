

using System;
using Diety.Helpers;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace Diety.ViewModel
{

    public class ViewModelLocator
    {

		public ViewModelLocator()
		{
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			SetupNavigation();

			SimpleIoc.Default.Register<MainViewModel>();			
			SimpleIoc.Default.Register<StartViewModel>();
			SimpleIoc.Default.Register<SecondViewModel>();	
		}
		private void SetupNavigation()
		{
			var navigationService = new FrameNavigationService();
			navigationService.Configure("Start", new Uri("../Views/Start.xaml", UriKind.Relative));
			navigationService.Configure("Second", new Uri("../Views/Second.xaml", UriKind.Relative));


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