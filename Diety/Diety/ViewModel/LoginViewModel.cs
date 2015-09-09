using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diety.Helpers;
using Diety.Helpers.Constatnts;
using Diety.ViewModel.Modules.Interfaces;
using DietyCommonTypes.Interfaces;
using DietyDataAccess.Accessors.Interfaces;
using DietyServices.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Threading;

namespace Diety.ViewModel
{
	public class LoginViewModel : ViewModelBase
	{

		#region Private Fields

		/// <summary>
		/// The _main frame navigation service
		/// </summary>
		private readonly IMainFrameNavigationService _mainFrameNavigationService;

		/// <summary>
		/// The _password
		/// </summary>
		private string _password;


		/// <summary>
		/// The _login
		/// </summary>
		private string _login;

		/// <summary>
		/// The _user profiles access
		/// </summary>
		private readonly IUserProfilesAccess _userProfilesAccess;

		/// <summary>
		/// The _error message
		/// </summary>
		private string _errorMessage;

		/// <summary>
		/// The _current user module
		/// </summary>
		private ICurrentUserModule _currentUserModule;

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets or sets the password.
		/// </summary>
		/// <value>
		/// The password.
		/// </value>
		public string Password
		{
			get { return _password; }
			set
			{
				Set(ref _password, value);
				RaisePropertyChanged(() => IsPasswordEmpty);
			}
		}


		/// <summary>
		/// Gets the register command.
		/// </summary>
		/// <value>
		/// The register command.
		/// </value>
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

		/// <summary>
		/// Gets a value indicating whether this instance is password empty.
		/// </summary>
		/// <value>
		/// <c>true</c> if this instance is password empty; otherwise, <c>false</c>.
		/// </value>
		public bool IsPasswordEmpty
		{
			get { return String.IsNullOrEmpty(Password); }
		}

		/// <summary>
		/// Gets the login command.
		/// </summary>
		/// <value>
		/// The login command.
		/// </value>
		public RelayCommand LoginCommand
		{
			get
			{
				return new RelayCommand(() =>
				{
					DispatcherHelper.RunAsync(async () =>
					{
						try
						{
							if (await _currentUserModule.AttemptLogin(Login, Password))
							{
								_mainFrameNavigationService.NavigateTo(PageType.Home);
							}
							else
							{
								ErrorMessage = Messages.WrongUsernameOrPassword;
							}
						}
						catch (Exception e)
						{
							//TODO ERROR POPUP
							ErrorMessage = "Dupa zbita";
						}
					});
				});
			}
		}

		/// <summary>
		/// Gets or sets the error message.
		/// </summary>
		/// <value>
		/// The error message.
		/// </value>
		public string ErrorMessage
		{
			get { return _errorMessage; }
			set { Set(ref _errorMessage, value); }
		}

		/// <summary>
		/// Gets or sets the login.
		/// </summary>
		/// <value>
		/// The login.
		/// </value>
		public string Login
		{
			get { return _login; }
			set { Set(ref _login, value); }
		}

		/// <summary>
		/// Gets the got focus command.
		/// </summary>
		/// <value>
		/// The got focus command.
		/// </value>
		public RelayCommand GotFocusCommand
		{
			get
			{
				return new RelayCommand(() =>
					{
						ErrorMessage = null;
					});
			}
		}

		#endregion

		#region C-tors

		/// <summary>
		/// Initializes a new instance of the <see cref="LoginViewModel"/> class.
		/// </summary>
		/// <param name="mainFrameNavigationService">The main frame navigation service.</param>
		/// <param name="userProfilesAccess">The user profiles access.</param>
		/// <param name="currentUserModule">The current user module.</param>
		public LoginViewModel(IMainFrameNavigationService mainFrameNavigationService, IUserProfilesAccess userProfilesAccess, ICurrentUserModule currentUserModule)
		{
			_mainFrameNavigationService = mainFrameNavigationService;
			_userProfilesAccess = userProfilesAccess;
			_currentUserModule = currentUserModule;
		}

		#endregion

	}
}
