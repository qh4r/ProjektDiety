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
		private readonly IMainFrameNavigationService _mainFrameNavigationService;

		/// <summary>
		/// The _password
		/// </summary>
		private string _password;

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
				RaisePropertyChanged("IsPasswordEmpty");
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

	}
}
