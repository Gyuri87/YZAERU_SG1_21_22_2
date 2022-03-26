using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using YZAERU_SG1_21_22_2.Logic.Interfaces;
using YZAERU_SG1_21_22_2.Models.Entities;
using YZAERU_SG1_21_22_2.Models.Models;

namespace YZAERU_SG1_21_22_2.Endpoint.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ActorFilmController : Controller
    {
        readonly IActorFilmLogic actorFilmLogic;

        public ActorFilmController(IActorFilmLogic actorFilmLogic)
        {
            this.actorFilmLogic = actorFilmLogic;
        }

        //GET: /api/ActorFilm/GetAll
        [HttpGet]
        [ActionName("GetAll")]
        public IEnumerable<ActorFilm> Get()
        {
            return actorFilmLogic.GetAllActorsFilms();
        }

        //GET: /api/ActorFilm/GetDirectorAndActors
        [HttpGet]
        [ActionName("GetDirectorAndActors")]
        public IEnumerable<DirectorAndActor> GetDirectorAndActors()
        {
            return actorFilmLogic.GetDirectorAndActors();
        }

        //GET: /api/ActorFilm/Count
        [HttpGet]
        [ActionName("Count")]
        public IEnumerable<ActorAndMovie> Count()
        {
            return actorFilmLogic.CountFilmsOfActor();
        }

        //GET: /api/ActorFilm/ActorsMostMovie
        [HttpGet]
        [ActionName("ActorsMostMovie")]
        public IList<ActorAndMovie> GetTheActorWhoHasTheActedInMostFilms()
        {
            return actorFilmLogic.GetTheActorWhoHasTheActedInMostFilms();
        }

        //GET: /api/ActorFilm/ActorsLeastMovie
        [HttpGet]
        [ActionName("ActorsMostMovie")]
        public IList<ActorAndMovie> GetTheActorWhoHasTheActedInLeastFilms()
        {
            return actorFilmLogic.GetTheActorWhoHasPlayedTheLeastNumberOfFilms();
        }

        //GET: /api/ActorFilm/FavoritActor
        [HttpGet]
        [ActionName("FavoritActor")]
        public FavoritActor GetFavoritActor()
        {
            return actorFilmLogic.GetFavotritActor();
        }

    }
}
