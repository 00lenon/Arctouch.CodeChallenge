using Arctouh.CodeChallenge.Tmdb.Application.Base;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Arctouh.CodeChallenge.Tmdb.Application.Json
{
    public class JsonServices : IJsonServices
    {
        public async Task<TRetorno> DeserializarRetorno<TRetorno>(HttpResponseMessage result) where TRetorno : BaseDto, new()
        {
            return result.StatusCode == HttpStatusCode.OK
                ? JsonConvert.DeserializeObject<TRetorno>(await result.Content.ReadAsStringAsync())
                : await TratarRetornosNaoEsperadosDoMs<TRetorno>(result);
        }

        public string SerializeObject<T>(T objeto)
        {
            if (objeto == null) return null;
            return JsonConvert.SerializeObject(objeto);
        }

        private Task<string> GetDetalhesDoErro(HttpResponseMessage result)
        {
            return result.Content.ReadAsStringAsync();
        }

        private async Task<TRetorno> TratarRetornosNaoEsperadosDoMs<TRetorno>(HttpResponseMessage result) where TRetorno : BaseDto, new()
        {
            switch (result.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    return new TRetorno { MensagemDeErro = "A rota solicitada não foi localizada." };

                case HttpStatusCode.InternalServerError:
                    return new TRetorno
                    {
                        MensagemDeErro = $"Ocorreu um erro interno. Mensagem do erro: {await GetDetalhesDoErro(result)}"
                    };

                default:
                    return new TRetorno { MensagemDeErro = $"Ocorreu um erro não identificado. Mensagem de erro: {await GetDetalhesDoErro(result)}" };
            }
        }
    }
}