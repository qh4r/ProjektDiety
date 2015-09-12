using System;
using Diety.Helpers;
using Diety.ViewModel.Modules;
using Diety.ViewModel.Modules.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace Diety.ViewModel
{
	public class PageBaseViewModel : ViewModelBase, IPageBaseViewModel
	{
		#region Private Fields

		/// <summary>
		/// The _main frame navigation service
		/// </summary>
		private IMainFrameNavigationService _mainFrameNavigation;

		/// <summary>
		/// The _current user
		/// </summary>
		private ICurrentUserModule _userModule;

		/// <summary>
		/// The _loading module
		/// </summary>
		private ILoadingIndicatiorModule _loadingModule;

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
			get
			{
				return new RelayCommand(() =>
				{
					MainFrameNavigation.NavigateTo(PageType.Home);
				});
			}
		}

		/// <summary>
		/// Gets the log out command.
		/// </summary>
		/// <value>
		/// The log out command.
		/// </value>
		public RelayCommand LogOutCommand
		{
			get
			{
				return new RelayCommand(() =>
				{
					UserModule.LogOut();
				});
			}
		}

		/// <summary>
		/// Gets or sets the main frame navigation.
		/// </summary>
		/// <value>
		/// The main frame navigation.
		/// </value>
		public IMainFrameNavigationService MainFrameNavigation
		{
			get { return _mainFrameNavigation; }
			set { Set(ref _mainFrameNavigation, value); }
		}

		/// <summary>
		/// Gets the navigate to tab command.
		/// </summary>
		/// <value>
		/// The navigate to tab command.
		/// </value>
		public RelayCommand<PageType> NavigateToTabCommand
		{
			get
			{
				return new RelayCommand<PageType>(pageType =>
				{
					MainFrameNavigation.NavigateTo(pageType);
				});
			}
		}

		/// <summary>
		/// Gets or sets the loading module.
		/// </summary>
		/// <value>
		/// The loading module.
		/// </value>
		public ILoadingIndicatiorModule LoadingModule
		{
			get { return _loadingModule; }
			set { Set(ref _loadingModule, value); }
		}

		#endregion

		#region C-tors

		/// <summary>
		/// Initializes a new instance of the <see cref="PageBaseViewModel" /> class.
		/// </summary>
		/// <param name="mainFrameNavigationService">The main frame navigation service.</param>
		/// <param name="userModule">The user module.</param>
		/// <param name="loadingIndicatiorModule">The loading indicatior module.</param>
		public PageBaseViewModel(IMainFrameNavigationService mainFrameNavigationService, ICurrentUserModule userModule,
			ILoadingIndicatiorModule loadingIndicatiorModule)
		{
			MainFrameNavigation = mainFrameNavigationService;
			UserModule = userModule;
			LoadingModule = loadingIndicatiorModule;
		}		

		#endregion
	}
}