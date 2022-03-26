using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YZAERU_SG1_21_22_2.Logic.Interfaces;
using YZAERU_SG1_21_22_2.Models.Entities;
using YZAERU_SG1_21_22_2.Models.Models;
using YZAERU_SG1_21_22_2.Repository.Interfaces;

namespace YZAERU_SG1_21_22_2.Logic.Services
{
    public class ActorFilmLogic : IActorFilmLogic
    {

        private IActorFilmRepository actorFilmRepository;

        private IDirectorRepository directorRepository;

        private IFilmRepository filmRepository;

        private IActorRepository actorRepository;

        public ActorFilmLogic(IActorFilmRepository actorFilmRepository, IDirectorRepository directorRepository, IFilmRepository filmRepository, IActorRepository actorRepository)
        {
            this.actorFilmRepository = actorFilmRepository;
            this.directorRepository = directorRepository;
            this.filmRepository = filmRepository;
            this.actorRepository = actorRepository;
        }

        public bool DeletActorFilm(int filmId, int actorId)
        {
            var actorFilm = this.actorFilmRepository.GetByFilmIdAndActorId(filmId, actorId);

            if (actorFilm != null)
            {
                this.actorFilmRepository.Delete(actorFilm);
                return true;
            }
            else
            {
                return false;
            }
        }

        public IList<ActorFilm> GetAllActorsFilms()
        {
            return this.actorFilmRepository.ReadAll().ToList();
        }

        public ActorFilm GetOneActorFilm(int filmId, int actorId)
        {
            return this.actorFilmRepository.GetByFilmIdAndActorId(filmId, actorId);
        }

        public ActorFilm InsertActorFilm(ActorFilm actorFilm)
        {
            return this.actorFilmRepository.Insert(actorFilm);
        }

        public ActorFilm UpdateActorFilm(ActorFilm actorFilm)
        {
            return this.actorFilmRepository.Update(actorFilm);
        }

        public IList<DirectorAndActor> GetDirectorAndActors()
        {
            var list = new List<DirectorAndActor>();

            list = (from actor in this.actorRepository.ReadAll()
                    join actorfilm in this.actorFilmRepository.ReadAll()
                         on actor.Id equals actorfilm.ActorId
                    join film in this.filmRepository.ReadAll()
                        on actorfilm.FilmId equals film.Id
                    join director in this.directorRepository.ReadAll()
                         on film.DirectorId equals director.Id
                    select new DirectorAndActor() { DirectorName = director.Name, ActorName = actor.Name }).ToList();

            return list;
        }

        public IList<ActorAndMovie> CountFilmsOfActor()
        {
            IList<ActorAndMovie> list = new List<ActorAndMovie>();

            var listFilms = from actor in this.actorRepository.ReadAll()
                            join actorFilm in this.actorFilmRepository.ReadAll()
                                 on actor.Id equals actorFilm.ActorId
                            join film in this.filmRepository.ReadAll()
                                 on actorFilm.FilmId equals film.Id
                            select new
                            {
                                ActorName = actor.Name,
                                MovieName = film.Title,
                            };

            list = (from actors in listFilms
                    group actors by actors.ActorName into grp
                    select new ActorAndMovie()
                    {
                        ActorName = grp.Key,
                        MovieName = "Film",
                        Count = grp.Count(),
                    }).ToList();

            return list;
        }

        public IList<ActorAndMovie> GetTheActorWhoHasTheActedInMostFilms()
        {
            var maxNumber = this.CountFilmsOfActor().OrderByDescending(x => x.Count).First().Count;

            IList<ActorAndMovie> list = new List<ActorAndMovie>();

            foreach (var item in this.CountFilmsOfActor())
            {
                if (item.Count == maxNumber)
                {
                    list.Add(item);
                }
            }

            return list;
        }

        public IList<ActorAndMovie> GetTheActorWhoHasPlayedTheLeastNumberOfFilms()
        {
            var minNumber = this.CountFilmsOfActor().OrderBy(x => x.Count).First().Count;

            IList<ActorAndMovie> list = new List<ActorAndMovie>();

            foreach (var item in this.CountFilmsOfActor())
            {
                if (item.Count == minNumber)
                {
                    list.Add(item);
                }
            }

            return list;
        }

        public Task<IList<DirectorAndActor>> GetDirectorAndActorsAsync()
        {
            return new Task<IList<DirectorAndActor>>(() => this.GetDirectorAndActors());
        }

        public FavoritActor GetFavotritActor()
        {
            var list = new List<DirectorAndActor>();
            /**
             * group by a rendezőre egy count hogy rendezőként hány darab színész van.
             * két névtelen object (Rendező és színész szerint egy group)
             */
            list = (from actor in this.actorRepository.ReadAll()
                    join actorfilm in this.actorFilmRepository.ReadAll()
                         on actor.Id equals actorfilm.ActorId
                    join film in this.filmRepository.ReadAll()
                        on actorfilm.FilmId equals film.Id
                    join director in this.directorRepository.ReadAll()
                         on film.DirectorId equals director.Id
                    select new DirectorAndActor() { DirectorName = director.Name, ActorName = actor.Name }).ToList();

            var countList = from actorAndDriect in list
                            group actorAndDriect by (actorAndDriect.ActorName, actorAndDriect.DirectorName) into grp
                            select new
                            {
                                count = grp.Count(),
                                director = grp.Key.DirectorName,
                                actor = grp.Key.ActorName,
                            };

            var favoritActor = (from actorAndDirectorGroup in countList
                                group actorAndDirectorGroup by actorAndDirectorGroup.director into gpr
                                select new FavoritActor()
                                {
                                    MovieNumber = gpr.Max(x => x.count),
                                    ActorName = gpr.Where(x => x.count == gpr.Max(x => x.count)).Select(x => x.actor).FirstOrDefault(),
                                }).OrderByDescending(x => x.MovieNumber).First();

            return favoritActor;
        }
    }
}
