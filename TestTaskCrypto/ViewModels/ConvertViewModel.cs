using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TestTaskCrypto.Common;
using TestTaskCrypto.Models;
using TestTaskCrypto.Services;


namespace TestTaskCrypto.ViewModels {
    public class ConvertViewModel : BaseViewModel
    {
        private const int _topCryptsAmount = 5;
        private readonly CoinCapApiService _coinCapApiService;
        public ObservableCollection<CryptoAsset> Crypts { get; }
        private CryptoAsset? _fromCurrency;
        private decimal _fromCurrencyAmount;
        private CryptoAsset? _toCurrency;
        private decimal _toCurrencyAmount;
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
                    if (!string.IsNullOrWhiteSpace(_searchQuery))
                    {
                        UpdateCryptsAsync();
                    }
                    else
                    {
                        LoadTopCryptsAsync();
                    }
                }
            }
        }

        public CryptoAsset FromCurrency
        {
            get { return _fromCurrency; }
            set 
            {
                _fromCurrency = value;
                OnPropertyChanged();
            }
        }

        public decimal FromCurrencyAmount
        {
            get { return _fromCurrencyAmount; }
            set { _fromCurrencyAmount = value; OnPropertyChanged(); }
        }

        public CryptoAsset ToCurrency
        {
            get { return _toCurrency; }
            set { _toCurrency = value; OnPropertyChanged(); }
        }

        public ICommand SearchCryptCommand { get; }

        public ConvertViewModel()
        {
            _coinCapApiService = new CoinCapApiService();
            Crypts = new ObservableCollection<CryptoAsset>();
            LoadTopCrypts();
        }

        private async void LoadTopCrypts()
        {
            var crypts = await _coinCapApiService.GetTopCrypts(_topCryptsAmount);
            Crypts.Clear();
            foreach (var crypto in crypts)
            {
                Crypts.Add(crypto);
            }
        }

        private async Task LoadTopCryptsAsync()
        {
            var crypts = await _coinCapApiService.GetTopCrypts(_topCryptsAmount);
            UpdateCrypts(crypts);
        }

        private async Task UpdateCryptsAsync()
        {
            if (string.IsNullOrWhiteSpace(SearchQuery))
            {
                await LoadTopCryptsAsync();
            }
            else
            {
                var results = await _coinCapApiService.SearchCrypt(SearchQuery);
                UpdateCrypts(results);
            }
        }


        private void UpdateCrypts(IEnumerable<CryptoAsset> newCrypts)
        {
            Crypts.Clear();
            foreach (var crypto in newCrypts)
            {
                Crypts.Add(crypto);
            }
        }

        private decimal? CryptConvert(CryptoAsset fromCrypt, decimal fromCryptAmount, CryptoAsset toCrypt)
        {
            var result = fromCrypt.PriceUsd * fromCryptAmount / toCrypt.PriceUsd;
            return result;
        }
    }
}
