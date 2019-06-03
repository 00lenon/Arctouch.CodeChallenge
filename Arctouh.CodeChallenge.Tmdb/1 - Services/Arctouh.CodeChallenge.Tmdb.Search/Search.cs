using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Arctouh.CodeChallenge.Tmdb.Application.Json;
using Arctouh.CodeChallenge.Tmdb.Application.TMDB;
using System.Threading.Tasks;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace Arctouh.CodeChallenge.Tmdb.Search
{
    public class Search
    {
        public async Task<APIGatewayProxyResponse> SearchMovies(ILambdaContext context)
        {
            var tmdbServices = new TmdbServices();
            var jsonServices = new JsonServices();

            var searchResult = await tmdbServices.SearchUpcomingMovies("pokemon", 1);

            return new APIGatewayProxyResponse
            {
                Body = jsonServices.SerializeObject(searchResult),
                StatusCode = 200
            };
        }
    }
}