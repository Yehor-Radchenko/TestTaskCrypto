using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using TestTaskCrypto.Models;

namespace TestTaskCrypto.Services
{
    public class CoinCapApiService
    {
        public async Task<IEnumerable<CryptoAsset>?> GetTopCrypts(int cryptsAmount)
        {
            using (var httpClient = new HttpClient()) 
            {
                var apiRequest = $"https://api.coincap.io/v2/assets/?limit={cryptsAmount}";

                var cryptoAssets = await httpClient.GetFromJsonAsync<IEnumerable<CryptoAsset>>(apiRequest);

                return cryptoAssets;
            }
        }

        public async Task<IEnumerable<CryptoAsset>?> SearchCrypt(string searchingValue)
        {
            using (var httpClient = new HttpClient())
            {
                //api search by asset id (bitcoin) or symbol (BTC)
                var apiRequest = $"https://api.coincap.io/v2/assets/?search={searchingValue}";

                var cryptoAssets = await httpClient.GetFromJsonAsync<IEnumerable<CryptoAsset>?>(apiRequest);

                return cryptoAssets;
            }
        }
    }
}
