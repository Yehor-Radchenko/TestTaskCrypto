using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TestTaskCrypto.Models;
using TestTaskCrypto.Services;

namespace TestTaskCrypto.ViewModels
{
    public class ApplicationViewModel : BaseViewModel
    {
        private const int _mainPageCryptsAmount = 10;

        private readonly CoinCapApiService _coinCapApiService;

        public IEnumerable<CryptoAsset>? Crypts { get; set; }

        public ApplicationViewModel() 
        {
            _coinCapApiService = new CoinCapApiService();
            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            Crypts = await _coinCapApiService.GetTopCrypts(_mainPageCryptsAmount);
        }

        private RelayCommand loadCommand;
    }
}
