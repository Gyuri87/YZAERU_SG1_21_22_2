using YZAERU_SG1_21_22_2.WpfClient.BL.Interfaces;
using YZAERU_SG1_21_22_2.WpfClient.Models;

namespace YZAERU_SG1_21_22_2.WpfClient
{
    public class FilmEditorViaWindowService : IFilmEditorService
    {
        public FilmModel EditFilm(FilmModel film)
        {
            var window = new FilmEditorWindow(film);

            if (window.ShowDialog() == true)
            {
                return window.Film;
            }

            return null;
        }
    }
}
