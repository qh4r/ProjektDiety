using System.Windows.Navigation;
using Diety.Helpers;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace Diety.ViewModel
{
	public class StartViewModel : ViewModelBase
	{		
		private string _test;
		private IFrameNavigationService _navigationService;

		public string Test
		{
			get { return _test; }
			set { Set(ref _test, value); }
		}

		public RelayCommand GoToSecond
		{
			get
			{
				return new RelayCommand(() =>
				{
					_navigationService.NavigateTo("Second", "Odbior halo!");
				});
			}
		}

		public StartViewModel(IFrameNavigationService navigationService)
		{
			_navigationService = navigationService;
			Test = "Hello";
		}
	}
}