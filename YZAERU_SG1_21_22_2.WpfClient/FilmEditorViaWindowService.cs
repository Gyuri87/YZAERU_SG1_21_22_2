using YZAERU_SG1_21_22_2.WpfClient.BL.Interfaces;
using YZAERU_SG1_21_22_2.WpfClient.Models;

namespace YZAERU_SG1_21_22_2.WpfClient
{
    public class FilmEditorViaWindowService : IFilmEditorService
    {
        public FilmModel EditFilm(FilmModel car)
        {
            var window = new FilmEditorWindow(car);

            if (window.ShowDialog() == true)
            {
                return window.Film;
            }

            return null;
        }
    }
}
