using Arctouh.CodeChallenge.Tmdb.Application.Base;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Arctouh.CodeChallenge.Tmdb.Application.TMDB.Dtos
{
    public class MoviesResult : BaseDto
    {
        [JsonProperty("page")]
        public int Pagina { get; set; }

        [JsonProperty("total_pages")]
        public int TotalDePaginas { get; set; }

        [JsonProperty("results")]
        public ICollection<MovieDto> UpcomingMovies { get; set; }
    }
}