using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using TestTaskCrypto.Models;
using Newtonsoft.Json;

namespace TestTaskCrypto.Services
{
    public class CoinCapApiService
    {
        public async Task<IEnumerable<CryptoAsset>?> GetTopCrypts(int cryptsAmount)
        {
            using (var httpClient = new HttpClient())
            {
                var apiRequest = $"https://api.coincap.io/v2/assets/?limit={cryptsAmount}";

                var response = await httpClient.GetAsync(apiRequest);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var cryptoAssetsJson = JsonConvert.DeserializeObject<CryptoAssetJsonModel>(responseContent);

                    return cryptoAssetsJson.Data;
                }
                else
                {
                    // Handle error response
                    return null;
                }
            }
        }

        public async Task<IEnumerable<CryptoAsset>?> SearchCrypt(string searchingValue)
        {
            using (var httpClient = new HttpClient())
            {
                var apiRequest = $"https://api.coincap.io/v2/assets/?search={searchingValue}";

                var response = await httpClient.GetAsync(apiRequest);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var cryptoAssetsJson = System.Text.Json.JsonSerializer.Deserialize<CryptoAssetJsonModel>(responseContent);

                    return cryptoAssetsJson.Data;
                }
                else
                {
                    // Handle error response
                    return null;
                }
            }
        }
    }
}
