using Arctouh.CodeChallenge.Tmdb.Application.Json;
using Arctouh.CodeChallenge.Tmdb.Application.TMDB;
using Arctouh.CodeChallenge.Tmdb.Application.TmdbHttpClient;
using Microsoft.Extensions.DependencyInjection;

namespace Arctouch.CodeChallenge.Tmdb.Ioc
{
    public static class Ioc
    {
        public static ServiceProvider GetServiceProvider()
        {
            var services = new ServiceCollection();
            services.AddScoped<ITmdbServices, TmdbServices>();
            services.AddScoped<IJsonServices, JsonServices>();
            services.AddScoped<ITmdbHttpClientServices, TmdbHttpClientServices>();

            return services.BuildServiceProvider();
        }
    }
}