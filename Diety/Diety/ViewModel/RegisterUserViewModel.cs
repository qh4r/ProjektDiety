using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diety.Helpers;
using Diety.ViewModel.Modules.Interfaces;
using DietyDataAccess.DataTypes;
using Diety.ViewModel.PropertyGroups;
using Diety.ViewModel.PropertyGroups.Interfaces;
using DietyDataAccess.Accessors.Interfaces;
using DietyServices.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Threading;

namespace Diety.ViewModel
{
	public class RegisterUserViewModel : ViewModelBase
	{

		#region Private Fields

		/// <summary>
		/// The _password
		/// </summary>
		private string _password;

		/// <summary>
		/// The _frame navigation
		/// </summary>
		private IMainFrameNavigationService _frameNavigation;

		/// <summary>
		/// The _repeat password
		/// </summary>
		private string _repeatPassword;

		/// <summary>
		/// The _error status
		/// </summary>
		private IRehabilitationErrorStatus _errorStatus;

		/// <summary>
		/// The _user profiles access
		/// </summary>
		private IUserProfilesAccess _userProfilesAccess;

		/// <summary>
		/// The _user name
		/// </summary>
		private string _userName;

		/// <summary>
		/// The _weight
		/// </summary>
		private string _weight;

		/// <summary>
		/// The _height
		/// </summary>
		private string _height;

		/// <summary>
		/// The _password processing service
		/// </summary>
		private readonly IPasswordProcessingService _passwordProcessingService;

		/// <summary>
		/// The _loading module
		/// </summary>
		private ILoadingIndicatiorModule _loadingModule;

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets or sets the error status.
		/// </summary>
		/// <value>
		/// The error status.
		/// </value>
		public IRehabilitationErrorStatus ErrorStatus
		{
			get { return _errorStatus; }
			set { Set(ref _errorStatus, value); }
		}

		public string Password
		{
			get { return _password; }
			set
			{
				Set(ref _password, value);
				RaisePropertyChanged(() => IsPasswordEmpty);
				RaisePropertyChanged(() => IsRegistrationPossible);
			}
		}

		/// <summary>
		/// Gets or sets the repeat password.
		/// </summary>
		/// <value>
		/// The repeat password.
		/// </value>
		public string RepeatPassword
		{
			get { return _repeatPassword; }
			set
			{
				Set(ref _repeatPassword, value);
				RaisePropertyChanged(() => IsRepeatPasswordEmpty);
				RaisePropertyChanged(() => IsRegistrationPossible);
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
		/// Gets the is repeat password empty.
		/// </summary>
		/// <value>
		/// The is repeat password empty.
		/// </value>
		public bool IsRepeatPasswordEmpty
		{
			get { return String.IsNullOrEmpty(RepeatPassword); }
		}

		/// <summary>
		/// Gets the username got focus.
		/// </summary>
		/// <value>
		/// The username got focus.
		/// </value>
		public RelayCommand UsernameGotFocus
		{
			get
			{
				return new RelayCommand(() =>
					{
						ErrorStatus.UsernameErrorMessage = null;
					});
			}
		}

		/// <summary>
		/// Gets the username lost focus.
		/// </summary>
		/// <value>
		/// The username lost focus.
		/// </value>
		public RelayCommand UsernameLostFocus
		{
			get
			{
				return new RelayCommand(async () =>
				{
					await UsernameLostFocusAction();
				});
			}
		}

		private async Task UsernameLostFocusAction()
		{
			if (UserName != null && UserName.Length > 3)
			{
				DispatcherHelper.RunAsync(async () =>
				{
					try
					{
						LoadingModule.ShowLoadingIndicatior();


						var user = await _userProfilesAccess.GetUserProfileByName(UserName);
						if (user != null)
						{
							ErrorStatus.UsernameErrorMessage = "Użytkownik o podanym loginie jest już zarejestrowany";
						}
						//await Task.Delay(1000);
						LoadingModule.HideLoadingIndicator();

					}
					catch (Exception e)
					{
						//TODO ERROR POPUP
						ErrorStatus.UsernameErrorMessage = "Dupa zbita";
					}
				});
			}
			else
			{
				ErrorStatus.UsernameErrorMessage = "Nazwa użytkownika musi zawierać od 3 do 20 znaków";
			}
		}

		/// <summary>
		/// Gets the password got focus.
		/// </summary>
		/// <value>
		/// The password got focus.
		/// </value>
		public RelayCommand PasswordGotFocus
		{
			get
			{
				return new RelayCommand(() =>
				{
					ErrorStatus.PasswordErrorMessage = null;
				});
			}
		}


		/// <summary>
		/// Gets the password lost focus.
		/// </summary>
		/// <value>
		/// The password lost focus.
		/// </value>
		public RelayCommand PasswordLostFocus
		{
			get
			{
				return new RelayCommand(() =>
				{
					ErrorStatus.PasswordErrorMessage = String.Equals(Password, RepeatPassword, StringComparison.CurrentCulture) ? null : "Hasła nie są identyczne";
				});
			}
		}

		/// <summary>
		/// Gets the weight got focus.
		/// </summary>
		/// <value>
		/// The weight got focus.
		/// </value>
		public RelayCommand WeightGotFocus
		{
			get
			{
				return new RelayCommand(() =>
				{
					ErrorStatus.WeightErrorMessage = null;
				});
			}
		}


		/// <summary>
		/// Gets the weight lost focus.
		/// </summary>
		/// <value>
		/// The weight lost focus.
		/// </value>
		public RelayCommand WeightLostFocus
		{
			get
			{
				return new RelayCommand(() =>
				{
					if (String.IsNullOrWhiteSpace(Weight))
					{
						ErrorStatus.WeightErrorMessage = "Waga musi zostać wypełniona";
					}
					else
					{
						ErrorStatus.WeightErrorMessage = CheckForNumeric(Weight) ? null : "Proszę podać liczbę zmiennoprzecinkową";
					}
				});
			}
		}

		/// <summary>
		/// Gets the heigth got focus.
		/// </summary>
		/// <value>
		/// The heigth got focus.
		/// </value>
		public RelayCommand HeigthGotFocus
		{
			get
			{
				return new RelayCommand(() =>
				{
					ErrorStatus.HeightErrorMessage = null;
				});
			}
		}


		/// <summary>
		/// Gets the height lost focus.
		/// </summary>
		/// <value>
		/// The height lost focus.
		/// </value>
		public RelayCommand HeightLostFocus
		{
			get
			{
				return new RelayCommand(() =>
				{
					if (String.IsNullOrWhiteSpace(Height))
					{
						ErrorStatus.HeightErrorMessage = "Wzrost musi zostać wypełniony";
					}
					else
					{
						ErrorStatus.HeightErrorMessage = CheckForNumeric(Height) ? null : "Proszę podać liczbę zmiennoprzecinkową";
					}

				});
			}
		}

		/// <summary>
		/// Gets or sets the name of the user.
		/// </summary>
		/// <value>
		/// The name of the user.
		/// </value>
		public string UserName
		{
			get { return _userName; }
			set
			{
				Set(ref _userName, value);
				RaisePropertyChanged(() => IsRegistrationPossible);
			}
		}

		/// <summary>
		/// Gets or sets the weight.
		/// </summary>
		/// <value>
		/// The weight.
		/// </value>
		public string Weight
		{
			get { return _weight; }
			set
			{
				Set(ref _weight, value);
				RaisePropertyChanged(() => IsRegistrationPossible);
			}
		}

		/// <summary>
		/// Gets or sets the height.
		/// </summary>
		/// <value>
		/// The height.
		/// </value>
		public string Height
		{
			get { return _height; }
			set
			{
				Set(ref _height, value);
				RaisePropertyChanged(() => IsRegistrationPossible);
			}
		}

		/// <summary>
		/// Gets the go back command.
		/// </summary>
		/// <value>
		/// The go back command.
		/// </value>
		/// <exception cref="System.NotImplementedException"></exception>
		public RelayCommand GoBackCommand
		{
			get
			{
				return new RelayCommand(() =>
					{
						_frameNavigation.GoBack();
					});
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
					DispatcherHelper.RunAsync(async () =>
					{
						try
						{
							LoadingModule.ShowLoadingIndicatior();
							var hasedPassword = _passwordProcessingService.EncryptString(UserName, Password);
							var newUser = new UserProfile
							{
								HashedPassword = hasedPassword,
								UserName = UserName,
								Height = Double.Parse(Height),
								Weight = Double.Parse(Weight)
							};
							var createdUser = await _userProfilesAccess.AddUser(newUser);
							if (createdUser != null)
							{
								_frameNavigation.GoBack();
							}
							LoadingModule.HideLoadingIndicator();
						}
						catch (Exception e)
						{
							LoadingModule.HideLoadingIndicator();
							Debug.WriteLine(e.Message);
							//TODO popup error
						}
					});
				}, () => IsRegistrationPossible);
			}
		}

		/// <summary>
		/// Gets a value indicating whether [registration possible].
		/// </summary>
		/// <value>
		///   <c>true</c> if [registration possible]; otherwise, <c>false</c>.
		/// </value>
		public bool IsRegistrationPossible
		{
			get
			{
				return ErrorStatus.NoErrors && !String.IsNullOrWhiteSpace(Password)
					&& !String.IsNullOrWhiteSpace(UserName) && !String.IsNullOrWhiteSpace(Weight)
					&& !String.IsNullOrWhiteSpace(Height) && !String.IsNullOrWhiteSpace(RepeatPassword);
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
		/// Initializes a new instance of the <see cref="RegisterUserViewModel" /> class.
		/// </summary>
		/// <param name="frameNavigation">The frame navigation.</param>
		/// <param name="userProfilesAccess">The user profiles access.</param>
		/// <param name="passwordProcessingService">The password processing service.</param>
		/// <param name="loadingIndicatiorModule">The loading indicatior module.</param>
		public RegisterUserViewModel(IMainFrameNavigationService frameNavigation,
			IUserProfilesAccess userProfilesAccess, IPasswordProcessingService passwordProcessingService,
			ILoadingIndicatiorModule loadingIndicatiorModule)
		{
			_frameNavigation = frameNavigation;
			ErrorStatus = new RehabilitationErrorStatus();
			_userProfilesAccess = userProfilesAccess;
			_passwordProcessingService = passwordProcessingService;
			LoadingModule = loadingIndicatiorModule;
		}



		#endregion

		#region Private Methods

		/// <summary>
		/// Checks for numeric.
		/// </summary>
		/// <param name="number">The number.</param>
		/// <returns></returns>
		/// <exception cref="System.NotImplementedException"></exception>
		private bool CheckForNumeric(string number)
		{
			double convertedNumber;
			return Double.TryParse(number.Replace('.', ','), out convertedNumber);
		}

		#endregion


	}
}
