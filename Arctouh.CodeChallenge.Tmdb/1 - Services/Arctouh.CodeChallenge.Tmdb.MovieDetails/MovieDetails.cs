using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Arctouh.CodeChallenge.Tmdb.Application.Json;
using Arctouh.CodeChallenge.Tmdb.Application.TMDB;
using System.Collections.Generic;
using System.Threading.Tasks;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace Arctouh.CodeChallenge.Tmdb.MovieDetails
{
    public class MovieDetails
    {
        public async Task<APIGatewayProxyResponse> GetMovieDetails(ILambdaContext context)
        {
            var tmdbServices = new TmdbServices();
            var jsonServices = new JsonServices();

            var movieDetail = await tmdbServices.GetMovieDetails(500);

            var dictionary = new Dictionary<string, string>();
            dictionary.Add("Access-Control-Allow-Origin", "*");

            return new APIGatewayProxyResponse
            {
                Body = jsonServices.SerializeObject(movieDetail),
                StatusCode = 200,
                Headers = dictionary
            };
        }
    }
}