using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;

namespace YZAERU_SG1_21_22_2.WpfClient.Infrastructure
{
    public class SimpleIocAsServiceLocator : SimpleIoc, IServiceLocator
    {
        public static SimpleIocAsServiceLocator Instance { get; private set; } = new SimpleIocAsServiceLocator();
    }
}
