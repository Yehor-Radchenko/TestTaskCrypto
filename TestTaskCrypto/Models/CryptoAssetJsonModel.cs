using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskCrypto.Models
{
    public class CryptoAssetJsonModel
    {
        public List<CryptoAsset> Data { get; set; }
        public long Timestamp { get; set; }
    }
}
