// HomeViewModel.cs
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using TestTaskCrypto.Common;
using TestTaskCrypto.Models;
using TestTaskCrypto.Services;

namespace TestTaskCrypto.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private const int _mainPageCryptsAmount = 10;
        private readonly CoinCapApiService _coinCapApiService;

        public ObservableCollection<CryptoAsset> Crypts { get; }

        public event EventHandler<CryptoAsset> RequestNavigateToCryptoDetails;

        public ICommand ShowDetailsCommand { get; }

        public HomeViewModel()
        {
            _coinCapApiService = new CoinCapApiService();
            Crypts = new ObservableCollection<CryptoAsset>();
            ShowDetailsCommand = new RelayCommand(ShowCryptoDetails);
            InitializeAsync();
        }

        public void ShowCryptoDetails(object parameter)
        {
            CryptoAsset selectedCryptoAsset = parameter as CryptoAsset;
            if (selectedCryptoAsset != null)
            {
                var navigationViewModel = App.Current.MainWindow.DataContext as NavigationViewModel;
                navigationViewModel?.NavigateToCryptoDetails(selectedCryptoAsset);
            }
        }


        private async void InitializeAsync()
        {
            var crypts = await _coinCapApiService.GetTopCrypts(_mainPageCryptsAmount);
            foreach (var crypto in crypts)
            {
                Crypts.Add(crypto);
            }
        }
    }
}
