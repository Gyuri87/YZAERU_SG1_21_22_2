using System;
using System.Windows;
using YZAERU_SG1_21_22_2.WpfClient.Models;
using YZAERU_SG1_21_22_2.WpfClient.ViewModels;

namespace YZAERU_SG1_21_22_2.WpfClient
{
    /// <summary>
    /// Interaction logic for FilmEditorWindow.xaml
    /// </summary>
    public partial class FilmEditorWindow : Window
    {
        public FilmModel Film { get; set; }
        bool enableEdit;

        public FilmEditorWindow(FilmModel film = null, bool enableEdit = true)
        {
            InitializeComponent();
            Film = film == null
                ? new FilmModel() { RelaseYear = DateTime.Now }
                : new FilmModel(film);

            this.enableEdit = enableEdit;
        }

        private void OkClick(object sender, RoutedEventArgs e)
        {
            if (enableEdit)
            {
                DialogResult = true;
            }
            else
            {
                Close();
            }
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            if (enableEdit)
            {
                DialogResult = false;
            }
            else
            {
                Close();
            }
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            var vm = (FilmEditorVM)Resources["VM"];
            vm.CurrentFilm = Film;
            vm.EditEnabled = enableEdit;
        }
    }
}
