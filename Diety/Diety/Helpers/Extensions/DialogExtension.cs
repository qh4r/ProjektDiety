using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Diety.Helpers.Extensions
{
	/// <summary>
	/// Helper class containing dialog result attached behavior.
	/// </summary>
	public static class DialogExtension
	{
		#region Properties

		/// <summary>
		/// The dialog result dependency property
		/// </summary>
		public static readonly DependencyProperty DialogResultProperty = DependencyProperty.RegisterAttached("DialogResult", typeof(bool?), typeof(DialogExtension), new PropertyMetadata(null, DialogResultChanged));

		#endregion Properties

		#region Private methods

		/// <summary>
		/// Sets new dialog window result.
		/// </summary>
		/// <param name="d">The d.</param>
		/// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
		private static void DialogResultChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var window = d as Window;
			if (window != null)
			{
				window.DialogResult = e.NewValue as bool?;
			}
		}

		#endregion Private methods

		#region Public methods

		/// <summary>
		/// Sets the dialog result.
		/// </summary>
		/// <param name="target">The target.</param>
		/// <param name="value">The value.</param>
		public static void SetDialogResult(Window target, bool? value)
		{
			target.SetValue(DialogResultProperty, value);
		}

		#endregion Public methods
	}
}
