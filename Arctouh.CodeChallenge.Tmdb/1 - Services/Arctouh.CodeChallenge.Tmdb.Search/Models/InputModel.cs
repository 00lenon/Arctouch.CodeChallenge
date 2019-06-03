using Newtonsoft.Json;

namespace Arctouh.CodeChallenge.Tmdb.Search.Models
{
    public class InputModel
    {
        [JsonProperty("pagina")]
        public int Pagina { get; set; }

        [JsonProperty("queryString")]
        public string QueryString { get; set; }
    }
}