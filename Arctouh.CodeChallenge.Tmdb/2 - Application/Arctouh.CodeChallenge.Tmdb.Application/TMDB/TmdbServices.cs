using Arctouh.CodeChallenge.Tmdb.Application.Json;
using Arctouh.CodeChallenge.Tmdb.Application.TMDB.Dtos;
using Arctouh.CodeChallenge.Tmdb.Application.TmdbHttpClient;
using System.Threading.Tasks;

namespace Arctouh.CodeChallenge.Tmdb.Application.TMDB
{
    public class TmdbServices : ITmdbServices
    {
        private const string _movieDetailsUrl = "movie/";
        private const string _searchMoviesUrl = "search/movie";
        private const string _upcomingMoviesUrl = "movie/upcoming";
        private readonly IJsonServices _jsonServices;
        private readonly ITmdbHttpClientServices _tmdbHttpClientServices;

        public TmdbServices()
        {
            _jsonServices = new JsonServices();
            _tmdbHttpClientServices = new TmdbHttpClientServices();
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
            return await _jsonServices.DeserializarRetorno<MoviesResult>(result);
        }

        public async Task<MoviesResult> SearchUpcomingMovies(string query, int pagina = 1)
        {
            if (pagina <= 0) pagina = 1;
            var result = await _tmdbHttpClientServices.Get($"{_searchMoviesUrl}?query={query}&page={pagina}");
            return await _jsonServices.DeserializarRetorno<MoviesResult>(result);
        }
    }
}