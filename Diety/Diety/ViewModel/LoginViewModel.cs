using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diety.Helpers;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace Diety.ViewModel
{
	public class LoginViewModel : ViewModelBase
	{

		#region Private Fields

		/// <summary>
		/// The _main frame navigation service
		/// </summary>
		private IMainFrameNavigationService _mainFrameNavigationService;

		#endregion

		#region Public Properties

		#endregion

		#region C-tors

		/// <summary>
		/// Initializes a new instance of the <see cref="LoginViewModel"/> class.
		/// </summary>
		/// <param name="mainFrameNavigationService">The main frame navigation service.</param>
		public LoginViewModel(IMainFrameNavigationService mainFrameNavigationService)
		{
			_mainFrameNavigationService = mainFrameNavigationService;
		}

		#endregion

		public RelayCommand RegisterCommand
		{
			get
			{
				return new RelayCommand(() =>
					{
						_mainFrameNavigationService.NavigateTo(PageType.RegisterUser);
					});
			}
		}
	}
}
