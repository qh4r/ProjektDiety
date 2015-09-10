using Diety.Helpers;
using Diety.ViewModel.Modules.Interfaces;
using GalaSoft.MvvmLight.CommandWpf;

namespace Diety.ViewModel
{
	public interface IPageBaseViewModel
	{	

		#region Public Properties

		/// Gets or sets the current user.
		/// </summary>
		/// <value>
		/// The current user.
		/// </value>
		ICurrentUserModule UserModule { get; set; }

		/// <summary>
		/// Gets the go home command.
		/// </summary>
		/// <value>
		/// The go home command.
		/// </value>
		RelayCommand GoHomeCommand { get; }

		/// <summary>
		/// Gets the log out command.
		/// </summary>
		/// <value>
		/// The log out command.
		/// </value>
		RelayCommand LogOutCommand { get; }

		/// <summary>
		/// Gets or sets the main frame navigation.
		/// </summary>
		/// <value>
		/// The main frame navigation.
		/// </value>
		IMainFrameNavigationService MainFrameNavigation { get; set; }

		/// <summary>
		/// Gets the navigate to tab command.
		/// </summary>
		/// <value>
		/// The navigate to tab command.
		/// </value>
		RelayCommand<PageType> NavigateToTabCommand { get; }

		#endregion

	}
}