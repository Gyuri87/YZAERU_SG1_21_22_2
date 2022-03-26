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
    public class FilmLogic : IFilmLogic
    {
        private IFilmRepository filmRepository;
        private IDirectorRepository directorRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="FilmLogic"/> class.
        /// </summary>
        /// <param name="filmRepositorys">Instance of FilmRepositorys.</param>
        /// <param name="directorRepository">Instance of DirectorRepository.</param>
        public FilmLogic(IFilmRepository filmRepositorys, IDirectorRepository directorRepository)
        {
            this.filmRepository = filmRepositorys;
            this.directorRepository = directorRepository;
        }

        public IList<Film> GetAllFilms()
        {
            return this.filmRepository.ReadAll().ToList();
        }

        public Film GetOneFilm(int id)
        {
            return this.filmRepository.GetById(id);
        }

        public bool DeletFilm(int filmId)
        {
            var film = this.filmRepository.GetById(filmId);

            if (film != null)
            {
                this.filmRepository.Delete(film);

                return true;
            }
            else
            {
                return false;
            }
        }

        public IList<DirectorAndFilm> GetMoviesWithDirector()
        {
            var list = from film in this.filmRepository.ReadAll()
                       join director in this.directorRepository.ReadAll()
                           on film.DirectorId equals director.Id
                       select new DirectorAndFilm(director.Name, film.Title);

            return list.ToList();
        }

        public Film UpdateFilm(Film film)
        {
            return this.filmRepository.Update(film);
        }

        public Film InsertFilm(Film film)
        {
            return this.filmRepository.Insert(film);
        }

        public IList<Film> GetMostLongestMovie()
        {
            IList<Film> list = new List<Film>();
            var maxNumber = this.filmRepository.ReadAll().OrderByDescending(film => film.Length).First().Length;

            foreach (var item in this.filmRepository.ReadAll())
            {
                if (item.Length == maxNumber)
                {
                    list.Add(item);
                }
            }

            return list;
        }

        public Task<IList<Film>> GetMostLongestMovieAsync()
        {
            return new Task<IList<Film>>(() => this.GetMostLongestMovie());
        }
    }
}
