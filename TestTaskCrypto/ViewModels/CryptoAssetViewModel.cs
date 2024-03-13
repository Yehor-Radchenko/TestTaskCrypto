using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskCrypto.Common;
using TestTaskCrypto.Models;

namespace TestTaskCrypto.ViewModels
{
    public class CryptoAssetViewModel : BaseViewModel
    {
        private CryptoAsset _cryptoAsset;

        public CryptoAssetViewModel(CryptoAsset model)
        {
            _cryptoAsset = model;
        }

        public string Id
        {
            get { return _cryptoAsset.Id; }
            set
            {
                _cryptoAsset.Id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public int Rank
        {
            get { return _cryptoAsset.Rank; }
            set
            {
                _cryptoAsset.Rank = value;
                OnPropertyChanged(nameof(Rank));
            }
        }

        public string Symbol
        {
            get { return _cryptoAsset.Symbol; }
            set
            {
                _cryptoAsset.Symbol = value;
                OnPropertyChanged(nameof(Symbol));
            }
        }

        public string Name
        {
            get { return _cryptoAsset.Name; }
            set
            {
                _cryptoAsset.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public decimal? Supply
        {
            get { return _cryptoAsset.Supply; }
            set
            {
                _cryptoAsset.Supply = value;
                OnPropertyChanged(nameof(Supply));
            }
        }

        public decimal? MaxSupply
        {
            get { return _cryptoAsset.MaxSupply; }
            set
            {
                _cryptoAsset.MaxSupply = value;
                OnPropertyChanged(nameof(MaxSupply));
            }
        }

        public decimal MarketCapUsd
        {
            get { return _cryptoAsset.MarketCapUsd; }
            set
            {
                _cryptoAsset.MarketCapUsd = value;
                OnPropertyChanged(nameof(MarketCapUsd));
            }
        }

        public decimal VolumeUsd24Hr
        {
            get { return _cryptoAsset.VolumeUsd24Hr; }
            set
            {
                _cryptoAsset.VolumeUsd24Hr = value;
                OnPropertyChanged(nameof(VolumeUsd24Hr));
            }
        }

        public decimal PriceUsd
        {
            get { return _cryptoAsset.PriceUsd; }
            set
            {
                _cryptoAsset.PriceUsd = value;
                OnPropertyChanged(nameof(PriceUsd));
            }
        }

        public decimal СhangePercent24Hr
        {
            get { return _cryptoAsset.СhangePercent24Hr; }
            set
            {
                _cryptoAsset.СhangePercent24Hr = value;
                OnPropertyChanged(nameof(СhangePercent24Hr));
            }
        }

        public decimal Vwap24Hr
        {
            get { return _cryptoAsset.Vwap24Hr; }
            set
            {
                _cryptoAsset.Vwap24Hr = value;
                OnPropertyChanged(nameof(Vwap24Hr));
            }
        }
    }
}
