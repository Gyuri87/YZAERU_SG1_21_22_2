using CommonServiceLocator;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using YZAERU_SG1_21_22_2.WpfClient.BL.Implementation;
using YZAERU_SG1_21_22_2.WpfClient.BL.Interfaces;
using YZAERU_SG1_21_22_2.WpfClient.Infrastructure;

namespace YZAERU_SG1_21_22_2.WpfClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIocAsServiceLocator.Instance);

            SimpleIocAsServiceLocator.Instance.Register<IFilmEditorService, FilmEditorViaWindowService>();
            SimpleIocAsServiceLocator.Instance.Register<IFilmDisplayService, FilmDisplayService>();
            SimpleIocAsServiceLocator.Instance.Register(() => Messenger.Default);
            SimpleIocAsServiceLocator.Instance.Register<IFilmHandlerService, DirectorHandlerService>();
        }
    }
}
