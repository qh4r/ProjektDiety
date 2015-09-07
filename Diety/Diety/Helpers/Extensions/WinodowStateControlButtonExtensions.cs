using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Diety.Helpers.Extensions
{
	public class WinodowStateControlButtonExtensions
	{


		public static bool GetIsMinimize(DependencyObject obj)
		{
			return (bool)obj.GetValue(IsMinimizeProperty);
		}

		public static void SetIsMinimize(DependencyObject obj, bool value)
		{
			obj.SetValue(IsMinimizeProperty, value);
		}

		// Using a DependencyProperty as the backing store for IsMinimize.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty IsMinimizeProperty =
			DependencyProperty.RegisterAttached("IsMinimize", typeof(bool), typeof(WinodowStateControlButtonExtensions), new PropertyMetadata(false, PropertyChangedCallback));



		public static bool GetIsMaximize(DependencyObject obj)
		{
			return (bool)obj.GetValue(IsMaximizeProperty);
		}

		public static void SetIsMaximize(DependencyObject obj, bool value)
		{
			obj.SetValue(IsMaximizeProperty, value);
		}

		// Using a DependencyProperty as the backing store for IsMaximize.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty IsMaximizeProperty =
			DependencyProperty.RegisterAttached("IsMaximize", typeof(bool), typeof(WinodowStateControlButtonExtensions), new PropertyMetadata(false, PropertyChangedCallback));



		public static bool GetIsClose(DependencyObject obj)
		{
			return (bool)obj.GetValue(IsCloseProperty);
		}

		public static void SetIsClose(DependencyObject obj, bool value)
		{
			obj.SetValue(IsCloseProperty, value);
		}

		// Using a DependencyProperty as the backing store for IsClose.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty IsCloseProperty =
			DependencyProperty.RegisterAttached("IsClose", typeof(bool), typeof(WinodowStateControlButtonExtensions), new PropertyMetadata(false, PropertyChangedCallback));




		/// <summary>
		/// Properties the changed callback.
		/// </summary>
		/// <param name="dependencyObject">The dependency object.</param>
		/// <param name="dependencyPropertyChangedEventArgs">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
		private static void PropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
		{
			var button = dependencyObject as Button;
			if (button != null)
			{
				if (GetIsClose(dependencyObject))
				{
					button.Click += (sender, args) =>
					{
						Application.Current.MainWindow.Close();
					};
				}
				if (GetIsMaximize(dependencyObject))
				{
					button.Click += (sender, args) =>
					{
						if (Application.Current.MainWindow.WindowState == WindowState.Maximized)
						{
							Application.Current.MainWindow.WindowState = WindowState.Normal;
						}
						else
						{
							Application.Current.MainWindow.WindowState = WindowState.Maximized;
						}
					};
				}
				if (GetIsMinimize(dependencyObject))
				{
					button.Click += (sender, args) =>
					{
						Application.Current.MainWindow.WindowState = WindowState.Minimized;
					};
				}
			}
		}
	}
}
