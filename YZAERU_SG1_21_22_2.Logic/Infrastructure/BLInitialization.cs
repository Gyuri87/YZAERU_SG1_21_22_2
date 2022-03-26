using Microsoft.Extensions.DependencyInjection;
using YZAERU_SG1_21_22_2.Logic.Interfaces;
using YZAERU_SG1_21_22_2.Logic.Services;
using YZAERU_SG1_21_22_2.Repository.Infrastructure;

namespace YZAERU_SG1_21_22_2.Logic.Infrastructure
{
    public class BLInitialization
    {
        public static void InitBLServices(IServiceCollection services)
        {
            RepoInitialization.InitRepoServices(services);

            services.AddScoped<IActorFilmLogic, ActorFilmLogic>();
            services.AddScoped<IActorLogic, ActorLogic>();
            services.AddScoped<IDirectorLogic, DirectorLogic>();
            services.AddScoped<IFilmLogic, FilmLogic>();
        }
    }
}
