using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Diety.Helpers;
using Diety.ViewModel.Modules.Interfaces;
using DietyCommonTypes.Interfaces;
using DietyDataAccess.Accessors.Interfaces;
using DietyServices.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;

namespace Diety.ViewModel.Modules
{
	class CurrentUserModule : ViewModelBase, ICurrentUserModule
	{
		
		#region Private Fields

		/// <summary>
		/// The _password processing service
		/// </summary>
		private IPasswordProcessingService _passwordProcessingService;

		/// <summary>
		/// The _current user
		/// </summary>
		private IUserProfile _currentUser;

		/// <summary>
		/// The _user profiles access
		/// </summary>
		private readonly IUserProfilesAccess _userProfilesAccess;

		/// <summary>
		/// The _main frame navigation service
		/// </summary>
		private IMainFrameNavigationService _mainFrameNavigationService;

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets the current user.
		/// </summary>
		/// <value>
		/// The current user.
		/// </value>
		public IUserProfile CurrentUser
		{
			get { return _currentUser; }
			set { Set(ref _currentUser, value); }
		}

		#endregion

		#region C-tors

		/// <summary>
		/// Initializes a new instance of the <see cref="CurrentUserModule" /> class.
		/// </summary>
		/// <param name="passwordProcessingService">The password processing service.</param>
		/// <param name="userProfilesAccess">The user profiles access.</param>
		/// <param name="mainFrameNavigationService">The main frame navigation service.</param>
		public CurrentUserModule(IPasswordProcessingService passwordProcessingService, IUserProfilesAccess userProfilesAccess, IMainFrameNavigationService mainFrameNavigationService)
		{
			_passwordProcessingService = passwordProcessingService;
			_userProfilesAccess = userProfilesAccess;
			_mainFrameNavigationService = mainFrameNavigationService;
		}

		#endregion

		#region Private Methods

		/// <summary>
		/// Tries the password.
		/// </summary>
		/// <param name="login">The login.</param>
		/// <param name="password">The password.</param>
		/// <param name="user">The user.</param>
		/// <returns></returns>
		private bool TryPassword(string login, string password, IUserProfile user)
		{
			var realPass = _passwordProcessingService.DecryptPassword(login, user.HashedPassword);
			return (String.Equals(password, realPass));
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Processes the passowrd.
		/// </summary>
		/// <param name="login">The login.</param>
		/// <param name="password">The password.</param>
		/// <returns></returns>
		public async Task<bool> AttemptLogin(string login, string password)
		{
			var user = await _userProfilesAccess.GetUserProfileByName(login);
			if (user != null)
			{
				if (TryPassword(login, password, user))
				{
					CurrentUser = user;
					return true;
				}
				return false;
			}
			return false;
		}

		/// <summary>
		/// Logs the out.
		/// </summary>
		public void LogOut()
		{
			CurrentUser = null;
			_mainFrameNavigationService.NavigateTo(PageType.Login);
		}

		#endregion
	}
}
