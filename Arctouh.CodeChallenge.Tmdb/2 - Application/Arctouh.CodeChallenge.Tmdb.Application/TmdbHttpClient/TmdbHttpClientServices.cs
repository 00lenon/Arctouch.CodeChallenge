using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Arctouh.CodeChallenge.Tmdb.Application.TmdbHttpClient
{
    public class TmdbHttpClientServices : ITmdbHttpClientServices
    {
        private const string _apiKey = "1f54bd990f1cdfb230adb312546d765d";
        private readonly HttpClient _httpClient;

        public TmdbHttpClientServices()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.themoviedb.org/3/")
            };
        }

        public Task<HttpResponseMessage> Get(string url)
        {
            url = AddApiInfo(url);
            return _httpClient.GetAsync(url);
        }

        private string AddApiInfo(string url)
        {
            if (string.IsNullOrWhiteSpace(url)) return $"?api_key={_apiKey}";
            return $"{url}{(url.Contains('?') ? "&" : "?")}api_key={_apiKey}";
        }
    }
}