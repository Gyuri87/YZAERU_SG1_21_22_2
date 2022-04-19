using System.Collections.Generic;
using YZAERU_SG1_21_22_2.Models.Entities;
using YZAERU_SG1_21_22_2.Models.Models;

namespace YZAERU_SG1_21_22_2.Logic.Interfaces
{

    public interface IFilmLogic
    {

        Film GetOneFilm(int id);

        IList<Film> GetAllFilms();

        IList<DirectorAndFilm> GetMoviesWithDirector();

        bool DeletFilm(int filmId);

        Film InsertFilm(Film film);

        Film UpdateFilm(Film film);

        IList<Film> GetMostLongestMovie();
    }
}
