using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using Application = System.Windows.Forms.Application;

namespace Diety.Helpers.Constatnts
{
	public static class ConstantValues
	{
		#region Public Properties

		/// <summary>
		/// Gets or sets the height of the screen.
		/// </summary>
		/// <value>
		/// The height of the screen.
		/// </value>
		public static int ScreenHeight { get; set; }

		/// <summary>
		/// Gets or sets the width of the screen.
		/// </summary>
		/// <value>
		/// The width of the screen.
		/// </value>
		public static int ScreenWidth { get; set; }

		/// <summary>
		/// Gets or sets the proportions.
		/// </summary>
		/// <value>
		/// The proportions.
		/// </value>
		public static double Proportions { get; set; }

		#endregion

		#region C-tors

		/// <summary>
		/// Initializes the <see cref="ConstantValues"/> class.
		/// </summary>
		static ConstantValues()
		{
			ScreenHeight = Screen.PrimaryScreen.Bounds.Height;
			ScreenWidth = Screen.PrimaryScreen.Bounds.Width;
			PresentationSource presentationSource = PresentationSource.FromVisual(System.Windows.Application.Current.MainWindow);
			if (presentationSource == null)
			{
				Proportions = 1.0;
			}
			else
			{
				CompositionTarget composition = presentationSource.CompositionTarget;
				Proportions = composition != null ? composition.TransformToDevice.M11 : 1.0;
			}
		}

		#endregion
	}
}
