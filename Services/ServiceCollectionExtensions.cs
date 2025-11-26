using ImdbProject.Models;
using ImdbProject.Repositories;
using ImdbProject.Repositories.Interfaces;
using ImdbProject.Services.Interfaces;
using ImdbProject.Services.Episodes;
using ImdbProject.Services.Genres;
using ImdbProject.Services.Names;
using ImdbProject.Services.Principals;
using ImdbProject.Services.Ratings;
using ImdbProject.Services.TitleAliases;
using ImdbProject.Services.Titles;
using Microsoft.Extensions.DependencyInjection;
using ImdbProject.ViewModels;

namespace ImdbProject.Services
{
    /// <summary>
    /// Helper class to register IMDB repositories and services in the DI container.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddImdbRepositories(this IServiceCollection services)
        {
            services.AddDbContext<ImdbContext>(ServiceLifetime.Transient);

            services.AddTransient<IEpisodeRepository, EpisodeRepository>();
            services.AddTransient<IGenreRepository, GenreRepository>();
            services.AddTransient<ITitleRepository, TitleRepository>();
            services.AddTransient<INameRepository, NameRepository>();
            services.AddTransient<IPrincipalRepository, PrincipalRepository>();
            services.AddTransient<IRatingRepository, RatingRepository>();
            services.AddTransient<ITitleAliasRepository, TitleAliasRepository>();

            return services;
        }

        public static IServiceCollection AddImdbServices(this IServiceCollection services)
        {
            services.AddTransient<IEpisodeService, EpisodeService>();
            services.AddTransient<ITitleService, TitleService>();
            services.AddTransient<INameService, NameService>();
            services.AddTransient<IPrincipalService, PrincipalService>();
            services.AddTransient<IRatingService, RatingService>();
            services.AddTransient<ITitleAliasService, TitleAliasService>();
            services.AddTransient<IGenreService, GenreService>();

            return services;
        }
        public static IServiceCollection AddViewModels(this IServiceCollection services)
        {
            services.AddSingleton<MainViewModel>();
            services.AddTransient<TitleDetailsViewModel>();
            return services;
        }
    }
}
