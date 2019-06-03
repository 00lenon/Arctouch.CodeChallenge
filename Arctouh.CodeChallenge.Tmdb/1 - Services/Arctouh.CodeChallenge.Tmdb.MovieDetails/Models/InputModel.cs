using Newtonsoft.Json;

namespace Arctouh.CodeChallenge.Tmdb.MovieDetails.Models
{
    public class InputModel
    {
        [JsonProperty("movieId")]
        public int MovieId { get; set; }
    }
}