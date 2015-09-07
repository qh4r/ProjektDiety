using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Diety.Helpers.Extensions
{
	public class PasswordBoxExtensions
	{
		#region Attached Properties

		// Using a DependencyProperty as the backing store for BindablePassword.  This enables animation, styling, binding, etc...
		/// <summary>
		/// The bindable password property
		/// </summary>
		public static readonly DependencyProperty BindablePasswordProperty =
			DependencyProperty.RegisterAttached("BindablePassword", typeof (string), typeof (PasswordBoxExtensions),
				new PropertyMetadata(null));

		// Using a DependencyProperty as the backing store for TrackPassword.  This enables animation, styling, binding, etc...
		/// <summary>
		/// The track password property
		/// </summary>
		public static readonly DependencyProperty TrackPasswordProperty =
			DependencyProperty.RegisterAttached("TrackPassword", typeof (bool), typeof (PasswordBoxExtensions),
				new PropertyMetadata(false, PropertyChangedCallback));


		#endregion

		#region Public Accesors

		/// <summary>
		/// Gets the bindable password.
		/// </summary>
		/// <param name="obj">The object.</param>
		/// <returns></returns>
		public static string GetBindablePassword(DependencyObject obj)
		{
			return (string) obj.GetValue(BindablePasswordProperty);
		}

		/// <summary>
		/// Sets the bindable password.
		/// </summary>
		/// <param name="obj">The object.</param>
		/// <param name="value">The value.</param>
		public static void SetBindablePassword(DependencyObject obj, string value)
		{
			obj.SetValue(BindablePasswordProperty, value);
		}

		/// <summary>
		/// Gets the track password.
		/// </summary>
		/// <param name="obj">The object.</param>
		/// <returns></returns>
		public static bool GetTrackPassword(DependencyObject obj)
		{
			return (bool) obj.GetValue(TrackPasswordProperty);
		}

		/// <summary>
		/// Sets the track password.
		/// </summary>
		/// <param name="obj">The object.</param>
		/// <param name="value">if set to <c>true</c> [value].</param>
		public static void SetTrackPassword(DependencyObject obj, bool value)
		{
			obj.SetValue(TrackPasswordProperty, value);
		}

		#endregion


		
		#region Private Methods

		/// <summary>
		/// Properties the changed callback.
		/// </summary>
		/// <param name="dependencyObject">The dependency object.</param>
		/// <param name="dependencyPropertyChangedEventArgs">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
		private static void PropertyChangedCallback(DependencyObject dependencyObject,
			DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
		{
			var passwordBox = dependencyObject as PasswordBox;
			if (passwordBox != null)
			{
				if (GetTrackPassword(dependencyObject))
				{
					passwordBox.PasswordChanged += (sender, args) =>
					{
						SetBindablePassword(dependencyObject, passwordBox.Password);
					};
				}
			}
		}

		#endregion

	}
}
