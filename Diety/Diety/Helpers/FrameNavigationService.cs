using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DietyUI;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;

namespace Diety.Helpers
{
	class FrameNavigationService : ObservableObject, IFrameNavigationService
	{
		#region Public Events

		/// <summary>
		/// Occurs when [release all event].
		/// </summary>
		public event Action ReleaseAllEvent;

		#endregion

		#region Fields

		/// <summary>
		/// The _pages by key
		/// </summary>
		private readonly Dictionary<PageType, Uri> _pagesByKey;

		/// <summary>
		/// The _historic
		/// </summary>
		private readonly List<PageType> _historic;

		/// <summary>
		/// The _current page key
		/// </summary>
		private PageType _currentPageKey;

		#endregion

		#region Properties

		/// <summary>
		/// The key corresponding to the currently displayed page.
		/// </summary>
		public PageType CurrentPageKey
		{
			get
			{
				return _currentPageKey;
			}

			private set
			{
				if (_currentPageKey == value)
				{
					return;
				}

				_currentPageKey = value;
				Set(ref _currentPageKey, value);
			}
		}

		/// <summary>
		/// Gets the parameter.
		/// </summary>
		/// <value>
		/// The parameter.
		/// </value>
		public object Parameter
		{
			get;
			private set;
		}

		#endregion Properties

		#region Ctors

		/// <summary>
		/// Initializes a new instance of the <see cref="FrameNavigation" /> class.
		/// </summary>
		/// <param name="breadCrumbsModule">The bread crumbs module.</param>
		public FrameNavigationService()
		{
			_pagesByKey = new Dictionary<PageType, Uri>();
			_historic = new List<PageType>();
		}

		#endregion Ctors

		#region Private Methods

		/// <summary>
		/// Executes the navigate.
		/// </summary>
		/// <param name="pageKey">The page key.</param>
		/// <param name="parameter">The parameter.</param>
		/// <exception cref="System.ArgumentException"></exception>
		private void ExecuteNavigate(PageType pageKey, object parameter)
		{
			lock (_pagesByKey)
			{
				OnReleaseAllEvents();
				if (!_pagesByKey.ContainsKey(pageKey))
				{
					throw new ArgumentException(string.Format("Key no found: {0} ", pageKey));
				}

				var mainWindow = Application.Current.MainWindow as MainWindow;
				if (mainWindow != null)
				{
					var frame = mainWindow.MainFrame;

					Parameter = parameter;

					if (frame != null)
					{
						frame.Navigate(_pagesByKey[pageKey]);
					}
				}
				CurrentPageKey = pageKey;
			}
		}

		/// <summary>
		/// Navigates to without history.
		/// </summary>
		/// <param name="pageKey">The page key.</param>
		private void NavigateToWithoutHistory(PageType pageKey)
		{
			NavigateToWithoutHistory(pageKey, null);
		}

		/// <summary>
		/// Navigates to with no history.
		/// </summary>
		/// <param name="pageKey">The page key.</param>
		/// <param name="parameter">The parameter.</param>
		/// <exception cref="System.ArgumentException">klucz</exception>
		private void NavigateToWithoutHistory(PageType pageKey, object parameter)
		{
			ExecuteNavigate(pageKey, parameter);
		}

		/// <summary>
		/// Called when [release all events].
		/// </summary>
		private void OnReleaseAllEvents()
		{
			if (ReleaseAllEvent != null)
			{
				ReleaseAllEvent();
			}
		}

		#endregion

		#region Public methods

		/// <summary>
		/// If possible, instructs the navigation service
		/// to discard the current page and display the previous page
		/// on the navigation stack.
		/// </summary>
		public void GoBack()
		{
			if (_historic.Count > 1)
			{
				//var frame = RehabilitationFrame.RehabilitationsFrameInstance;
				_historic.RemoveAt(_historic.Count - 1);
				NavigateToWithoutHistory(_historic.Last(), null);
				//frame.GoBack();
			}
		}

		/// <summary>
		/// Instructs the navigation service to display a new page
		/// corresponding to the given key. Depending on the platforms,
		/// the navigation service might have to be configured with a
		/// key/page list.
		/// </summary>
		/// <param name="pageKey">The key corresponding to the page
		/// that should be displayed.</param>
		public void NavigateTo(PageType pageKey)
		{
			NavigateTo(pageKey, null);
		}

		/// <summary>
		/// Instructs the navigation service to display a new page
		/// corresponding to the given key, and passes a parameter
		/// to the new page.
		/// Depending on the platforms, the navigation service might
		/// have to be Configure with a key/page list.
		/// </summary>
		/// <param name="pageKey">The key corresponding to the page
		/// that should be displayed.</param>
		/// <param name="parameter">The parameter that should be passed
		/// to the new page.</param>
		/// <exception cref="System.ArgumentException">klucz</exception>
		public void NavigateTo(PageType pageKey, object parameter)
		{
			ExecuteNavigate(pageKey, parameter);
			_historic.Add(pageKey);
		}

		/// <summary>
		/// Configures the specified key.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="pageType">Type of the page.</param>
		public void Configure(PageType key, Uri pageType)
		{
			lock (_pagesByKey)
			{
				if (_pagesByKey.ContainsKey(key))
				{
					_pagesByKey[key] = pageType;
				}
				else
				{
					_pagesByKey.Add(key, pageType);
				}
			}
		}

		/// <summary>
		/// Reloads this instance.
		/// </summary>
		public void Reload()
		{
			if (_historic.Count > 0)
			{
				NavigateToWithoutHistory(_historic.Last(), Parameter);
			}
		}

		#endregion Public methods
	}
}