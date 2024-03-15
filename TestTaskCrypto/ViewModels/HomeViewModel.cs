using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using TestTaskCrypto.Common;
using TestTaskCrypto.Models;
using TestTaskCrypto.Services;

namespace TestTaskCrypto.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private const int _mainPageCryptsAmount = 10;
        private readonly CoinCapApiService _coinCapApiService;
        private bool _isSearching;

        public ObservableCollection<CryptoAsset> Crypts { get; }
        public ICommand ShowDetailsCommand { get; }
        public ICommand SearchCryptCommand { get; }

        public bool IsSearching
        {
            get => _isSearching;
            set
            {
                if (_isSearching != value)
                {
                    _isSearching = value;
                    OnPropertyChanged(nameof(IsSearching));
                }
            }
        }

        private string _searchQuery;
        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                if (_searchQuery != value)
                {
                    _searchQuery = value;
                    OnPropertyChanged(nameof(SearchQuery));
                    SearchCryptCommand.Execute(null);
                }
            }
        }

        public HomeViewModel()
        {
            _coinCapApiService = new CoinCapApiService();
            Crypts = new ObservableCollection<CryptoAsset>();
            ShowDetailsCommand = new RelayCommand(ShowCryptoDetails);
            SearchCryptCommand = new RelayCommand(async obj => await UpdateSearchResultsAsync());
            InitializeAsync();
        }

        private async Task UpdateSearchResultsAsync()
        {
            IsSearching = true;
            await Application.Current.Dispatcher.InvokeAsync(async () =>
            {
                if (!string.IsNullOrWhiteSpace(SearchQuery))
                {
                    var results = await _coinCapApiService.SearchCrypt(SearchQuery);
                    Crypts.Clear();
                    foreach (var coin in results)
                    {
                        Crypts.Add(coin);
                    }
                }
                else
                {
                    Crypts.Clear();
                    InitializeAsync();
                }
                IsSearching = false;
            });
        }

        private async void InitializeAsync()
        {
            IsSearching = true;
            var crypts = await _coinCapApiService.GetTopCrypts(_mainPageCryptsAmount);
            Crypts.Clear();
            foreach (var crypto in crypts)
            {
                Crypts.Add(crypto);
            }
            IsSearching = false;
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
    }
}
