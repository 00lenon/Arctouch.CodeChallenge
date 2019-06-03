using Arctouh.CodeChallenge.Tmdb.Application.Json;
using Arctouh.CodeChallenge.Tmdb.Application.TMDB.Dtos;
using Arctouh.CodeChallenge.Tmdb.Application.TmdbHttpClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arctouh.CodeChallenge.Tmdb.Application.TMDB
{
    public class TmdbServices : ITmdbServices
    {
        private const string _genresUrl = "genre/movie/list";
        private const string _movieDetailsUrl = "movie/";
        private const string _searchMoviesUrl = "search/movie";
        private const string _upcomingMoviesUrl = "movie/upcoming";
        private readonly IJsonServices _jsonServices;
        private readonly ITmdbHttpClientServices _tmdbHttpClientServices;

        public TmdbServices(IJsonServices jsonServices, ITmdbHttpClientServices tmdbHttpClientServices)
        {
            _jsonServices = jsonServices;
            _tmdbHttpClientServices = tmdbHttpClientServices;
        }

        public async Task<MovieDetailsDto> GetMovieDetails(int movieId)
        {
            var result = await _tmdbHttpClientServices.Get($"{_movieDetailsUrl}{movieId}");
            return await _jsonServices.DeserializarRetorno<MovieDetailsDto>(result);
        }

        public async Task<MoviesResult> GetUpcomingMovies(int pagina = 1)
        {
            if (pagina <= 0) pagina = 1;
            var result = await _tmdbHttpClientServices.Get($"{_upcomingMoviesUrl}?page={pagina}");
            var movies = await _jsonServices.DeserializarRetorno<MoviesResult>(result);
            UpdateGenres(movies);
            return movies;
        }

        public async Task<MoviesResult> SearchUpcomingMovies(string query, int pagina = 1)
        {
            if (pagina <= 0) pagina = 1;
            var result = await _tmdbHttpClientServices.Get($"{_searchMoviesUrl}?query={query}&page={pagina}");
            var movies = await _jsonServices.DeserializarRetorno<MoviesResult>(result);
            UpdateGenres(movies);
            return movies;
        }

        private async Task<GeneroResultDto> GetGenres()
        {
            var result = await _tmdbHttpClientServices.Get(_genresUrl);
            return await _jsonServices.DeserializarRetorno<GeneroResultDto>(result);
        }

        private async void UpdateGenres(MoviesResult movies)
        {
            if (movies == null || !movies.Results.Any()) return;
            var genres = await GetGenres();
            foreach (var movie in movies.Results)
            {
                movie.Generos = new List<GeneroDto>();
                movie.Generos.AddRange(movie.IdsDosGeneros.Select(x => new GeneroDto { Id = x, Nome = genres.Generos.FirstOrDefault(g => g.Id == x)?.Nome }).ToList());
            }
        }
    }
}