using System;

namespace DietyServices.Interfaces
{
    internal interface INavigationService
    {
        void NavigateTo(string destionation);

        void NavigateTo(string destionation, object parameter);

        void NavigateTo(Type destination);

        void NavigateTo(Type destination, object parameter);

        void NavigateBack();
    }
}