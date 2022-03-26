using Microsoft.Extensions.DependencyInjection;
using YZAERU_SG1_21_22_2.Repository.Context;
using YZAERU_SG1_21_22_2.Repository.Interfaces;
using YZAERU_SG1_21_22_2.Repository.Repositories;

namespace YZAERU_SG1_21_22_2.Repository.Infrastructure
{
    public class RepoInitialization
    {
        public static void InitRepoServices(IServiceCollection services)
        {
            services.AddScoped<FilmDbContext>((sp) => new FilmDbContext());

            services.AddScoped<IActorFilmRepository, ActorFilmRepository>();

            services.AddScoped<IActorRepository, ActorRepository>();

            services.AddScoped<IDirectorRepository, DirectorRepository>();

            services.AddScoped<IFilmRepository, FilmRepository>();
        }
    }
}
