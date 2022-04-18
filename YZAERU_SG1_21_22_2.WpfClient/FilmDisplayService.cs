using YZAERU_SG1_21_22_2.WpfClient;
using YZAERU_SG1_21_22_2.WpfClient.BL.Interfaces;
using YZAERU_SG1_21_22_2.WpfClient.Models;

namespace CarShop.WpfClient
{
    public class FilmDisplayService : IFilmDisplayService
    {
        public void Display(FilmModel film)
        {
            var window = new FilmEditorWindow(film, false);

            window.Show();
        }
    }
}
