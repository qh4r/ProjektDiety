using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diety.Helpers;
using DietyCommonTypes.Interfaces;
using DietyDataAccess.Accessors.Interfaces;
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
		/// The _ingredients access
		/// </summary>
		private IIngredientsAccess _ingredientsAccess;

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

		public RelayCommand LoginCommand
		{
			get
			{
				return new RelayCommand(() =>
				{
					DispatcherHelper.RunAsync(async () =>
					{
						var ingredients = await _ingredientsAccess.GetIngredientsList();
						var test = ingredients.Count();
						Debug.WriteLine(test);
					});
				});
			}
		}

		#endregion

		#region C-tors

		/// <summary>
		/// Initializes a new instance of the <see cref="LoginViewModel"/> class.
		/// </summary>
		/// <param name="mainFrameNavigationService">The main frame navigation service.</param>
		public LoginViewModel(IMainFrameNavigationService mainFrameNavigationService, IIngredientsAccess ingredientsAccess)
		{
			_mainFrameNavigationService = mainFrameNavigationService;
			_ingredientsAccess = ingredientsAccess;
		}

		#endregion

	}
}
