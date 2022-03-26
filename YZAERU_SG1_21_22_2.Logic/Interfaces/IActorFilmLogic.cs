using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YZAERU_SG1_21_22_2.Models.Entities;
using YZAERU_SG1_21_22_2.Models.Models;

namespace YZAERU_SG1_21_22_2.Logic.Interfaces
{
    public interface IActorFilmLogic
    {
        
        ActorFilm GetOneActorFilm(int filmId, int actorId);

        IList<ActorFilm> GetAllActorsFilms();

        ActorFilm InsertActorFilm(ActorFilm actorFilm);

        ActorFilm UpdateActorFilm(ActorFilm actorFilm);

        bool DeletActorFilm(int filmId, int actorId);

        IList<DirectorAndActor> GetDirectorAndActors();
        IList<ActorAndMovie> CountFilmsOfActor();
        IList<ActorAndMovie> GetTheActorWhoHasTheActedInMostFilms();
        IList<ActorAndMovie> GetTheActorWhoHasPlayedTheLeastNumberOfFilms();
        FavoritActor GetFavotritActor();
    }
}
