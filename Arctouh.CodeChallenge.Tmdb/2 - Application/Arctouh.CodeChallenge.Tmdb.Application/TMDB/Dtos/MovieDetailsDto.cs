using Arctouh.CodeChallenge.Tmdb.Application.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Arctouh.CodeChallenge.Tmdb.Application.TMDB.Dtos
{
    public class MovieDetailsDto : BaseDto
    {
        [JsonProperty("poster_path")]
        public string CaminhoDoPoster { get; set; }

        [JsonProperty("release_date")]
        public DateTime DataDeLancamento { get; set; }

        [JsonProperty("genres")]
        public ICollection<GeneroDto> Generos { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("overview")]
        public string Resumo { get; set; }

        [JsonProperty("title")]
        public string Titulo { get; set; }
    }
}