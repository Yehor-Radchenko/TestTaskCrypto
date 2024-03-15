using System;
using System.Windows.Input;
using TestTaskCrypto.Common;
using TestTaskCrypto.Models;

namespace TestTaskCrypto.ViewModels
{
    public class NavigationViewModel : BaseViewModel
    {
        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ICommand HomeCommand { get; }
        public ICommand ConvertCommand { get; }

        public NavigationViewModel()
        {
            HomeCommand = new RelayCommand(Home);
            ConvertCommand = new RelayCommand(Convert);

            CurrentView = new HomeViewModel();
        }

        private void Home(object obj) => CurrentView = new HomeViewModel();
        private void Convert(object obj) => CurrentView = new ConvertViewModel();

        public void NavigateToCryptoDetails(CryptoAsset cryptoAsset)
        {
            CurrentView = new CryptoDetailsViewModel(cryptoAsset);
        }
    }
}
