using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskCrypto.Models
{
    public class CryptoAsset
    {
        public string Id { get; set; }
        public int Rank { get; set; }
    
        /// <summary>
        /// Most common symbol used to identify this asset on an exchange
        /// </summary>
        public string Symbol { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Available supply for trading
        /// </summary>
        public decimal? Supply { get; set; }

        /// <summary>
        /// Total quantity of asset issued
        /// </summary>
        public decimal? MaxSupply { get; set; }

        /// <summary>
        /// supply x price
        /// </summary>
        public decimal? MarketCapUsd { get; set; }

        /// <summary>
        /// Volume-weighted price based on real-time market data, 
        /// translated to USD
        /// </summary>
        public decimal? VolumeUsd24Hr { get; set; }

        public decimal? PriceUsd { get; set; }

        /// <summary>
        /// The direction and value change in the last 24 hours
        /// </summary>
        public decimal? ChangePercent24Hr {  get; set; }

        /// <summary>
        /// Volume Weighted Average Price in the last 24 hours
        /// </summary>
        public decimal? Vwap24Hr { get; set; }

        public string? Explorer {  get; set; }
    }
}

