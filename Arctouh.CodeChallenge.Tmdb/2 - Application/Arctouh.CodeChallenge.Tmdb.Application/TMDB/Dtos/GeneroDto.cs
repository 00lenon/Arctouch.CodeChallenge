using Newtonsoft.Json;

namespace Arctouh.CodeChallenge.Tmdb.Application.TMDB.Dtos
{
    public class GeneroDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Nome { get; set; }
    }
}