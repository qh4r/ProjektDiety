using Diety.Helpers;
using GalaSoft.MvvmLight;

namespace Diety.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IFrameNavigationService navigationService)
        {
			navigationService.NavigateTo("Start");
        }
    }
}