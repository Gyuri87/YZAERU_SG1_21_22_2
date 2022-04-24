using CommonServiceLocator;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using YZAERU_SG1_21_22_2.WpfClient.BL.Interfaces;
using YZAERU_SG1_21_22_2.WpfClient.Models;

namespace YZAERU_SG1_21_22_2.WpfClient.ViewModels
{
    public class FilmEditorVM : ViewModelBase
    {
        private FilmModel currentFilm;

        public FilmModel CurrentFilm
        {
            get { return currentFilm; }
            set
            {
                Set(ref currentFilm, value);
                SelectedDirector = AvailableDirectors?.SingleOrDefault(x => x.Id == currentFilm.DirectorId);
            }
        }

        private DirectorModel directorModel;

        public DirectorModel SelectedDirector
        {
            get { return directorModel; }
            set
            {
                Set(ref directorModel, value);
                currentFilm.DirectorId = directorModel?.Id ?? 0;
            }
        }

        public IList<DirectorModel> AvailableDirectors { get; private set; }

        private bool editEnabled;

        public bool EditEnabled
        {
            get { return editEnabled; }
            set
            {
                Set(ref editEnabled, value);
                RaisePropertyChanged(nameof(CancelButtonVisibility));
            }
        }

        public System.Windows.Visibility CancelButtonVisibility => EditEnabled ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;

        public FilmEditorVM(IFilmHandlerService filmHandlerService)
        {
            CurrentFilm = new FilmModel();
            if (IsInDesignModeStatic)
            {
                AvailableDirectors = new List<DirectorModel>()
                {
                    new DirectorModel(1, "George Lucas"),
                    new DirectorModel(2, "Steven Spielberg"),
                    new DirectorModel(3, "Anthony Russo"),
                };

                SelectedDirector = AvailableDirectors[1]; // Should sets the brandId too
                CurrentFilm.Title = "Start Wars";
                CurrentFilm.Length = 120;
            }
            else
            {
                AvailableDirectors = filmHandlerService.GetAllDirectors();
            }
        }

        public FilmEditorVM() : this(IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<IFilmHandlerService>())
        {
        }
    }
}
