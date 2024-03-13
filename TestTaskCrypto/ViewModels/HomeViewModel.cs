using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TestTaskCrypto.Common;
using TestTaskCrypto.Models;
using TestTaskCrypto.Services;

namespace TestTaskCrypto.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private const int _mainPageCryptsAmount = 10;

        private readonly CoinCapApiService _coinCapApiService;

        private ObservableCollection<CryptoAsset> _crypts;
        public ObservableCollection<CryptoAsset> Crypts
        {
            get => _crypts;
            set
            {
                _crypts = value;
                OnPropertyChanged(nameof(Crypts));
            }
        }

        public HomeViewModel()
        {
            _coinCapApiService = new CoinCapApiService();
            Crypts = new ObservableCollection<CryptoAsset>(); 
            InitializeAsync();
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
