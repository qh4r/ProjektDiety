using Diety.ViewModel.Modules.Interfaces;
using GalaSoft.MvvmLight;

namespace Diety.ViewModel.Modules
{
	public class LoadingIndicatiorModule : ViewModelBase, ILoadingIndicatiorModule
	{
		#region Private Fields

		/// <summary>
		/// The _is loading visible
		/// </summary>
		private bool _isLoadingVisible;

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets or sets a value indicating whether this instance is loading visible.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance is loading visible; otherwise, <c>false</c>.
		/// </value>
		public bool IsLoadingVisible
		{
			get { return _isLoadingVisible; }
			set { Set(ref _isLoadingVisible, value); }
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Shows the loading indicatior.
		/// </summary>
		public void ShowLoadingIndicatior()
		{
			IsLoadingVisible = true;
		}

		/// <summary>
		/// Hides the loading indicator.
		/// </summary>
		public void HideLoadingIndicator()
		{
			IsLoadingVisible = false;
		}

		#endregion

	}
}