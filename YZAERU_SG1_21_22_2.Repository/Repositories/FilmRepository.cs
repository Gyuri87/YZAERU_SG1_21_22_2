using System.Linq;
using YZAERU_SG1_21_22_2.Models.Entities;
using YZAERU_SG1_21_22_2.Repository.Context;
using YZAERU_SG1_21_22_2.Repository.Interfaces;

namespace YZAERU_SG1_21_22_2.Repository.Repositories
{
    public class FilmRepository : MovieRepository<Film, int>, IFilmRepository
    {

        public FilmRepository(FilmDbContext context) : base(context)
        {
        }

        public override Film GetById(int id)
        {
            return this.ReadAll().SingleOrDefault(film => film.Id == id);
        }
    }
}
