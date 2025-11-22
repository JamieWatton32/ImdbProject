using ImdbProject.Models;
using ImdbProject.Repositories;
using ImdbProject.Services.Episodes;
using ImdbProject.Services.Genres;
using ImdbProject.Services.Names;
using ImdbProject.Services.Principals;
using ImdbProject.Services.Ratings;
using ImdbProject.Services.Titles;
using ImdbProject.Services.TitleAliases;
using Microsoft.Extensions.DependencyInjection;

namespace ImdbProject.Services
{
    /// <summary>
    /// Helper class to register IMDB repositories and services in the DI container.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddImdbRepositories(this IServiceCollection services)
        {
            services.AddSingleton<ImdbContext>();

 
            services.AddSingleton<EpisodeRepository>();
            services.AddSingleton<GenreRepository>();
            services.AddSingleton<TitleRepository>();
            services.AddSingleton<NameRepository>();
            services.AddSingleton<PrincipalRepository>();
            services.AddSingleton<RatingRepository>();
            services.AddSingleton<TitleAliasRepository>();

            return services;
        }

        public static IServiceCollection AddImdbServices(this IServiceCollection services)
        {
            services.AddSingleton<EpisodeService>();
            services.AddSingleton<GenreService>();
            services.AddSingleton<TitleService>();
            services.AddSingleton<NameService>();
            services.AddSingleton<PrincipalService>();
            services.AddSingleton<RatingService>();
            services.AddSingleton<TitleAliasService>();

            return services;
        }
    }
}
