using Newtonsoft.Json;

namespace Arctouh.CodeChallenge.Tmdb.UpcomingMovies.Models
{
    public class InputModel
    {
        [JsonProperty("pagina")]
        public int Pagina { get; set; }
    }
}