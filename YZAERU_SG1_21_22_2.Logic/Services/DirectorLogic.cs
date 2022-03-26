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
    public class DirectorLogic : IDirectorLogic
    {
        private IDirectorRepository directorRepository;
        private IFilmRepository filmRepository;

        public DirectorLogic(IDirectorRepository directorRepository, IFilmRepository filmRepository)
        {
            this.directorRepository = directorRepository;
            this.filmRepository = filmRepository;
        }

        public IList<Director> GetAllDirectors()
        {
            return this.directorRepository.ReadAll().ToList();
        }

        public Director GetOneDirector(int id)
        {
            return this.directorRepository.GetById(id);
        }

        public DirectorAndFilm GetAllDirectorAndDirectedMovie()
        {
            throw new NotImplementedException("Még nincs kész");
        }

        public bool DeletDirector(int directorId)
        {
            var film = this.directorRepository.GetById(directorId);

            if (film != null)
            {
                this.directorRepository.Delete(film);

                return true;
            }
            else
            {
                return false;
            }
        }

        public Director UpdateDirector(Director director)
        {
            return this.directorRepository.Update(director);
        }

        public Director InsertDirector(Director director)
        {
            return this.directorRepository.Insert(director);
        }

        public IList<DirectorAndFilmCounter> CountMoviesOfDirector()
        {
            var list = new List<DirectorAndFilmCounter>();

            list = (from film in this.filmRepository.ReadAll()
                    join directors in this.directorRepository.ReadAll()
                         on film.DirectorId equals directors.Id
                    group directors by directors.Name into grp
                    select new DirectorAndFilmCounter()
                    {
                        Count = grp.Count(),
                        DirectorName = grp.Key,
                    }).ToList();

            return list;
        }

        public Task<IList<DirectorAndFilmCounter>> CountMoviesOfDirectorAsync()
        {
            return new Task<IList<DirectorAndFilmCounter>>(() => this.CountMoviesOfDirector());
        }
    }
}
