using System.Collections.Generic;
using YZAERU_SG1_21_22_2.WpfClient.Models;

namespace YZAERU_SG1_21_22_2.WpfClient.BL.Interfaces
{
    public interface IFilmHandlerService
    {
        void AddFilm(IList<FilmModel> collection);
        void ModifyFilm(IList<FilmModel> collection, FilmModel film);
        void DeleteFilm(IList<FilmModel> collection, FilmModel film);
        void ViewFilm(FilmModel film);

        IList<FilmModel> GetAll();
        IList<DirectorModel> GetAllDirectors();
    }
}
