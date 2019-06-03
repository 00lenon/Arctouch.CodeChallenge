using Arctouh.CodeChallenge.Tmdb.Application.Base;
using System.Net.Http;
using System.Threading.Tasks;

namespace Arctouh.CodeChallenge.Tmdb.Application.Json
{
    public interface IJsonServices
    {
        Task<TRetorno> DeserializarRetorno<TRetorno>(HttpResponseMessage result) where TRetorno : BaseDto, new();

        string SerializeObject<T>(T objeto);
    }
}