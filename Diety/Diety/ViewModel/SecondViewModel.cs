using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diety.Helpers;
using DietyDataAccess.DataTypes;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Diety.ViewModel
{
	public class SecondViewModel : ViewModelBase
	{
		private string _secondText;
		private IFrameNavigationService _navigationService;

		public string SecondText
		{
			get { return _secondText; }
			set { Set(ref _secondText, value); }
		}

		public RelayCommand GoToStart
		{
			get
			{
				return new RelayCommand(() =>
				{
					_navigationService.GoBack();
				});
			}
		}


		public SecondViewModel(IFrameNavigationService navigationService)
		{
			_navigationService = navigationService;
			SecondText = navigationService.Parameter as String;			
		}
	}
}
