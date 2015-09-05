using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Views;

namespace Diety.Helpers
{
	public interface IFrameNavigationService
	{
		#region Events

		/// <summary>
		/// Occurs when [release all event].
		/// </summary>
		event Action ReleaseAllEvent;

		#endregion

		#region Properties

		/// <summary>
		/// Gets the parameter.
		/// </summary>
		/// <value>
		/// The parameter.
		/// </value>
		object Parameter { get; }

		#endregion

		#region Methods

		/// <summary>
		/// Reloads this instance.
		/// </summary>
		void Reload();

		/// <summary>
		/// Goes the back.
		/// </summary>
		void GoBack();

		/// <summary>
		/// Navigates to without history.
		/// </summary>
		/// <param name="pageKey">The page key.</param>
		void NavigateTo(PageType pageKey);

		/// <summary>
		/// Navigates to without history.
		/// </summary>
		/// <param name="pageKey">The page key.</param>
		/// <param name="parameter">The parameter.</param>
		void NavigateTo(PageType pageKey, object parameter);

		#endregion
	}

	public enum PageType
	{
		Start,
		Second
	}
}
