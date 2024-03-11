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
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private readonly CoinCapApiService _coinCapApiService;
        public IEnumerable<CryptoAsset>? Crypts { get; set; }

        public ApplicationViewModel() 
        {
            _coinCapApiService = new CoinCapApiService();
            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            Crypts = await _coinCapApiService.GetTop10Crypts();
        }

        private RelayCommand loadCommand;

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
