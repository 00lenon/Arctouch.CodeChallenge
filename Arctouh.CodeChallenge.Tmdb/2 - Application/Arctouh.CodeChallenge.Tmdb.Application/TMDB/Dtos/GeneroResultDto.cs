using Arctouh.CodeChallenge.Tmdb.Application.Base;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Arctouh.CodeChallenge.Tmdb.Application.TMDB.Dtos
{
    public class GeneroResultDto : BaseDto
    {
        [JsonProperty("genres")]
        public ICollection<GeneroDto> Generos { get; set; }
    }
}