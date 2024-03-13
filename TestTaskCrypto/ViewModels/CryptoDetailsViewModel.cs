using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskCrypto.Common;
using TestTaskCrypto.Models;

namespace TestTaskCrypto.ViewModels
{
    public class CryptoDetailsViewModel : BaseViewModel
    {
        private CryptoAsset _selectedCryptoAsset;
        public CryptoAsset SelectedCryptoAsset
        {
            get { return _selectedCryptoAsset; }
            set { _selectedCryptoAsset = value; OnPropertyChanged(); }
        }

        public CryptoDetailsViewModel(CryptoAsset selectedCryptoAsset)
        {
            SelectedCryptoAsset = selectedCryptoAsset;
        }
    }
}
