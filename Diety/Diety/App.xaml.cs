using System.Windows;
using GalaSoft.MvvmLight.Threading;

namespace Diety
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		/// <summary>
		/// Initializes the <see cref="App"/> class.
		/// </summary>
		static App()
		{
			DispatcherHelper.Initialize();
		}
	}
}
