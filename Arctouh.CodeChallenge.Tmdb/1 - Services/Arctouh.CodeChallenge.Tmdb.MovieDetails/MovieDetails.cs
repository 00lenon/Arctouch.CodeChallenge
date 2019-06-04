using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Arctouch.CodeChallenge.Tmdb.Ioc;
using Arctouh.CodeChallenge.Tmdb.Application.Json;
using Arctouh.CodeChallenge.Tmdb.Application.TMDB;
using Arctouh.CodeChallenge.Tmdb.MovieDetails.Models;
using System.Threading.Tasks;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace Arctouh.CodeChallenge.Tmdb.MovieDetails
{
    public class MovieDetails
    {
        public async Task<APIGatewayProxyResponse> GetMovieDetails(InputModel input, ILambdaContext context)
        {
            var serviceProvider = Ioc.GetServiceProvider();

            var tmdbServices = (ITmdbServices)serviceProvider.GetService(typeof(ITmdbServices));
            var jsonServices = (IJsonServices)serviceProvider.GetService(typeof(IJsonServices));
            var movieDetail = await tmdbServices.GetMovieDetails(input.MovieId);

            return new APIGatewayProxyResponse
            {
                Body = jsonServices.SerializeObject(movieDetail),
                StatusCode = 200
            };
        }
    }
}