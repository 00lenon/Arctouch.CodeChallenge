using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Arctouch.CodeChallenge.Tmdb.Ioc;
using Arctouh.CodeChallenge.Tmdb.Application.Json;
using Arctouh.CodeChallenge.Tmdb.Application.TMDB;
using Arctouh.CodeChallenge.Tmdb.UpcomingMovies.Models;
using System.Threading.Tasks;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace Arctouh.CodeChallenge.Tmdb.UpcomingMovies
{
    public class UpcomingMovies
    {
        public async Task<APIGatewayProxyResponse> GetUpcomingMovies(InputModel input, ILambdaContext context)
        {
            var serviceProvider = Ioc.GetServiceProvider();

            var tmdbServices = (ITmdbServices)serviceProvider.GetService(typeof(ITmdbServices));
            var jsonServices = (IJsonServices)serviceProvider.GetService(typeof(IJsonServices));

            var upcoming = await tmdbServices.GetUpcomingMovies(input.Pagina);

            return new APIGatewayProxyResponse
            {
                Body = jsonServices.SerializeObject(upcoming),
                StatusCode = 200,
            };
        }
    }
}