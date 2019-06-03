using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Arctouh.CodeChallenge.Tmdb.Application.Json;
using Arctouh.CodeChallenge.Tmdb.Application.TMDB;
using System.Collections.Generic;
using System.Threading.Tasks;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace Arctouh.CodeChallenge.Tmdb.UpcomingMovies
{
    public class UpcomingMovies
    {
        public async Task<APIGatewayProxyResponse> GetUpcomingMovies(ILambdaContext context)
        {
            var tmdbServices = new TmdbServices();
            var jsonServices = new JsonServices();
            //pagina = pagina.HasValue ? pagina : 1;

            var upcoming = await tmdbServices.GetUpcomingMovies(1);
            var dictionary = new Dictionary<string, string>
            {
                { "Access-Control-Allow-Origin", "*" },
                { "Access-Control-Allow-Credentials", "true" },
                { "Access-Control-Allow-Methods", "GET,HEAD,OPTIONS,POST,PUT" },
                { "Access-Control-Allow-Headers", "Access-Control-Allow-Headers, Access-Control-Allow-Origin, Origin,Accept, X-Requested-With, Content-Type, Access-Control-Request-Method, Access-Control-Request-Headers" }
            };
            return new APIGatewayProxyResponse
            {
                Body = jsonServices.SerializeObject(upcoming),
                StatusCode = 200,
                Headers = dictionary,
            };
        }
    }
}