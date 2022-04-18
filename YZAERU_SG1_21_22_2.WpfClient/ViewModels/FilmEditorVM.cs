using CommonServiceLocator;
using GalaSoft.MvvmLight;
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
                //SelectedBrand = AvailableBrands?.SingleOrDefault(x => x.Id == currentFilm.Id);
            }
        }

        //private BrandModel brandModel;

        //public BrandModel SelectedBrand
        //{
        //    get { return brandModel; }
        //    set
        //    {
        //        Set(ref brandModel, value);
        //        currentFilm.BrandId = brandModel?.Id ?? 0;
        //    }
        //}

        //public IList<BrandModel> AvailableBrands { get; private set; }

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

        public FilmEditorVM(IFilmHandlerService carHandlerService)
        {
            CurrentFilm = new FilmModel();

            //if (IsInDesignModeStatic)
            //{
            //    AvailableBrands = new List<BrandModel>()
            //    {
            //        new BrandModel(1, "Mazda"),
            //        new BrandModel(2, "Opel"),
            //        new BrandModel(3, "BMW"),
            //    };

            //    SelectedBrand = AvailableBrands[1]; // Should sets the brandId too
            //    CurrentFilm.Model = "Astra G";
            //    CurrentFilm.Price = 1750;
            //}
            //else
            //{
            //    AvailableBrands = carHandlerService.GetAllBrands();
            //}
        }

        public FilmEditorVM() : this(IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<IFilmHandlerService>())
        {
        }
    }
}
