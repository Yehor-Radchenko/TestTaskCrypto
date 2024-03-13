using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TestTaskCrypto.Models
{
    public class CryptoAssetJsonModel
    {
        [JsonPropertyName("data")]
        public List<CryptoAsset> Data { get; set; }

        [JsonPropertyName("timestamp")]
        public long Timestamp { get; set; }
    }
}
