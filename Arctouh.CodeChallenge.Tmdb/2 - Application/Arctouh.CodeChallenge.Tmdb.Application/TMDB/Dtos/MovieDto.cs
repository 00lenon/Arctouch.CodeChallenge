﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Arctouh.CodeChallenge.Tmdb.Application.TMDB.Dtos
{
    public class MovieDto
    {
        [JsonProperty("backdrop_path")]
        public string Backdrop { get; set; }

        [JsonProperty("poster_path")]
        public string CaminhoDoPoster { get; set; }

        [JsonProperty("release_date")]
        public DateTime? DataDeLancamento { get; set; }

        public List<GeneroDto> Generos { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("genre_ids")]
        public ICollection<int> IdsDosGeneros { get; set; }

        [JsonProperty("title")]
        public string Titulo { get; set; }
    }
}