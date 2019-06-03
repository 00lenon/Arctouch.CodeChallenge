using System.Net.Http;
using System.Threading.Tasks;

namespace Arctouh.CodeChallenge.Tmdb.Application.TmdbHttpClient
{
    public interface ITmdbHttpClientServices
    {
        Task<HttpResponseMessage> Get(string url);
    }
}