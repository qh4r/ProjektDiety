using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Diety.Helpers;
using Diety.ViewModel.Modules;
using Diety.ViewModel.Modules.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace Diety.ViewModel
{
	public class HomeViewModel : ViewModelBase
	{
		
		#region Private Fields

		/// <summary>
		/// The _main frame navigation service
		/// </summary>
		private IMainFrameNavigationService _mainFrameNavigationService;

		/// <summary>
		/// The _current user
		/// </summary>
		private ICurrentUserModule _userModule;

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets or sets the current user.
		/// </summary>
		/// <value>
		/// The current user.
		/// </value>
		public ICurrentUserModule UserModule
		{
			get { return _userModule; }
			set { Set(ref _userModule, value); }
		}

		/// <summary>
		/// Gets the go home command.
		/// </summary>
		/// <value>
		/// The go home command.
		/// </value>
		public RelayCommand GoHomeCommand
		{
			get { return new RelayCommand(() =>
			{
				_mainFrameNavigationService.NavigateTo(PageType.Home);
			}); }
		}

		/// <summary>
		/// Gets the log out command.
		/// </summary>
		/// <value>
		/// The log out command.
		/// </value>
		public RelayCommand LogOutCommand
		{
			get { return new RelayCommand(() =>
			{
				UserModule.LogOut();
			}); }
		}

		#endregion

		#region C-tors

		/// <summary>
		/// Initializes a new instance of the <see cref="HomeViewModel"/> class.
		/// </summary>
		/// <param name="mainFrameNavigationService">The main frame navigation service.</param>
		/// <param name="userModule">The current user module.</param>
		public HomeViewModel(IMainFrameNavigationService mainFrameNavigationService, ICurrentUserModule userModule)
		{
			_mainFrameNavigationService = mainFrameNavigationService;
			UserModule = userModule;			
		}		

		#endregion
	}
}
