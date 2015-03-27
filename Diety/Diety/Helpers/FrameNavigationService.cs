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
		#region Fields
		private readonly Dictionary<string, Uri> _pagesByKey;
		private readonly List<string> _historic;
		private string _currentPageKey;
		#endregion
		#region Properties
		public string CurrentPageKey
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
		public object Parameter { get; private set; }
		#endregion
		#region Ctors and Methods
		public FrameNavigationService()
		{
			_pagesByKey = new Dictionary<string, Uri>();
			_historic = new List<string>();
		}
		public void GoBack()
		{
			if (_historic.Count > 1)
			{
				_historic.RemoveAt(_historic.Count - 1);
				NavigateTo(_historic.Last(), null);
			}
		}
		public void NavigateTo(string pageKey)
		{
			NavigateTo(pageKey, null);
		}

		public virtual void NavigateTo(string pageKey, object parameter)
		{
			lock (_pagesByKey)
			{
				if (!_pagesByKey.ContainsKey(pageKey))
				{
					throw new ArgumentException(string.Format("Nie ma takiej strony: {0} ", pageKey), "klucz");
				}

				var frame = (Application.Current.MainWindow as MainWindow).MainFrame;

				if (frame != null)
				{
					frame.Source = _pagesByKey[pageKey];
				}
				Parameter = parameter;
				_historic.Add(pageKey);
				CurrentPageKey = pageKey;
			}
		}

		public void Configure(string key, Uri pageType)
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

		#endregion
	}
}