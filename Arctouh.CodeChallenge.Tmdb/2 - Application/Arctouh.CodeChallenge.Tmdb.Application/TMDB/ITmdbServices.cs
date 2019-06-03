using Arctouh.CodeChallenge.Tmdb.Application.TMDB.Dtos;
using System.Threading.Tasks;

namespace Arctouh.CodeChallenge.Tmdb.Application.TMDB
{
    public interface ITmdbServices
    {
        Task<MovieDetailsDto> GetMovieDetails(int movieId);

        Task<MoviesResult> GetUpcomingMovies(int pagina = 0);

        Task<MoviesResult> SearchUpcomingMovies(string query, int pagina = 0);
    }
}