using System.Diagnostics;
using System.Windows.Input;
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
            set
            {
                _selectedCryptoAsset = value;
                ExplorerUrl = _selectedCryptoAsset?.Explorer;
                OnPropertyChanged();
            }
        }

        private string _explorerUrl;
        public string ExplorerUrl
        {
            get { return _explorerUrl; }
            set { _explorerUrl = value; OnPropertyChanged(); }
        }

        public ICommand OpenExplorerCommand { get; private set; }

        public CryptoDetailsViewModel(CryptoAsset selectedCryptoAsset)
        {
            SelectedCryptoAsset = selectedCryptoAsset;
            OpenExplorerCommand = new RelayCommand(OpenExplorer);
        }

        private void OpenExplorer(object parameter)
        {
            if (!string.IsNullOrEmpty(ExplorerUrl))
            {
                Process.Start(new ProcessStartInfo(ExplorerUrl) { UseShellExecute = true });
            }
        }
    }

}
