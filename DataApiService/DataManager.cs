using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DataApiService.Utils;
using Newtonsoft.Json;

namespace DataApiService
{
    public interface IDataManager
    {
        Task<T> GetItems<T>(string pointName, Dictionary<string, string> getParams = null);
        Task<T> GetPostItems<T>(string pointName, Dictionary<string, string> getParams);
        void Auth(string login, string password);
    }

    public class BaseApiOptions
    {
        public string Token { get; set; }
        public string BaseUrl { get; set; }
        public string GetUrlApiService(string controllerName)
        {
            if (string.IsNullOrEmpty(Token))
            {
                throw new ArgumentNullException("Token не получен");
            }

            return $"{BaseUrl}/{controllerName}?token={Token}";
        }



    }
    public class TokenResponse
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("owner_id")]
        public int Owner_id { get; set; }

        [JsonPropertyName("role_id")]
        public int Role_id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("user_id")]
        public int User_id { get; set; }
    }
    public class DataManager:IDataManager
    {
        private BaseApiOptions _options;
        private WebClient _client;

        public DataManager(BaseApiOptions options)
        {
            _options = options;

            _client = new WebClient();
            _client.Headers.Add(HttpRequestHeader.Accept, "application/json");
        }

        private async Task<T> GetRequestAsync<T>(string url, Dictionary<string, string> pars)
        {
            var paramString = pars.ToGetParameters();
            var destUrl = $"{url}?{paramString}";
            var responseData = await _client.DownloadDataTaskAsync(new Uri(destUrl));
            var result = JsonConvert.DeserializeObject<T>(System.Text.Encoding.UTF8.GetString(responseData));
            return result;
        }

        private async Task<string> GetServiceToken(string url, string login, string password)
        {
            var authUrl = $"{url}/token";
            var responce = await GetRequestAsync<TokenResponse>(authUrl, new Dictionary<string, string>()
            {
                {"login",login },
                {"password",password }
            });
            return responce.Token;
        }

        public void Auth(string login, string password)
        {
            _options.Token = GetServiceToken(_options.BaseUrl, login, password).Result;
        }

        public async Task<T> GetItems<T>(string pointName, Dictionary<string, string> getParams = null)
        {
            try
            {
                string urlService = _options.GetUrlApiService(pointName);
                var paramString = getParams.ToGetParameters();

                var url = new Uri($"{urlService}{paramString}");

                var responseData = await _client.DownloadDataTaskAsync(url);
                var jsonStr = System.Text.Encoding.UTF8.GetString(responseData);
                var result = JsonConvert.DeserializeObject<T>(jsonStr);
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<T> GetPostItems<T>(string pointName, Dictionary<string, string> getParams)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string urlService = _options.GetUrlApiService(pointName);
                    string paramString = JsonConvert.SerializeObject(getParams);

                    var content = new StringContent(paramString, Encoding.UTF8, "application/json-patch+json");

                    var response = await client.PostAsync(urlService, content);
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<T>(responseContent);
                    return result;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
