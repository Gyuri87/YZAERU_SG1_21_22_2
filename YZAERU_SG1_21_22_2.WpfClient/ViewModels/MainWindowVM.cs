using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using YZAERU_SG1_21_22_2.WpfClient.BL.Interfaces;
using YZAERU_SG1_21_22_2.WpfClient.Models;

namespace YZAERU_SG1_21_22_2.WpfClient.ViewModels
{
    public class MainWindowVM : ViewModelBase
    {
        private FilmModel currentFilm;

        public FilmModel CurrentFilm
        {
            get { return currentFilm; }
            set { Set(ref currentFilm, value); }
        }

        public ObservableCollection<FilmModel> Films { get; private set; }

        public ICommand AddCommand { get; private set; }
        public ICommand ModifyCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand ViewCommand { get; private set; }

        public ICommand LoadCommand { get; private set; }

        readonly IFilmHandlerService FilmHandlerService;

        public MainWindowVM(IFilmHandlerService FilmHandlerService)
        {
            this.FilmHandlerService = FilmHandlerService;
            Films = new ObservableCollection<FilmModel>();

            if (IsInDesignMode)
            {
                Films.Add(new FilmModel(1, "Star wars 1", 120, 2, "George Lucas","scifi", DateTime.Parse("1977-03-17"), true));
                Films.Add(new FilmModel(2, "Star wars 2", 120, 2, "George Lucas", "scifi", DateTime.Parse("1987-03-17"), true));
                var starWars = new FilmModel(3, "Star wars 3", 120, 2, "George Lucas", "akció", DateTime.Parse("1997-03-17"), true);
                Films.Add(starWars);
                Films.Add(new FilmModel(4, "Star wars 4", 120, 2, "George Lucas", "akció", DateTime.Parse("2007-03-17"), true));
                CurrentFilm = starWars;
            }

            LoadCommand = new RelayCommand(() =>
            {
                var films = this.FilmHandlerService.GetAll();
                Films.Clear();

                foreach (var film in films)
                {
                    Films.Add(film);
                }
            });

            AddCommand = new RelayCommand(() => this.FilmHandlerService.AddFilm(Films));
            ModifyCommand = new RelayCommand(() => this.FilmHandlerService.ModifyFilm(Films, CurrentFilm));
            DeleteCommand = new RelayCommand(() => this.FilmHandlerService.DeleteFilm(Films, CurrentFilm));
            ViewCommand = new RelayCommand(() => this.FilmHandlerService.ViewFilm(CurrentFilm));
        }

        public MainWindowVM() : this(IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<IFilmHandlerService>())
        {
        }
    }
}
