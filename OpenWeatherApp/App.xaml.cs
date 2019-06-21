using Ninject;
using OpenWeatherApp.Services;
using OpenWeatherDataStore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using OpenWeatherApp.ViewModels;
using System.IO;

namespace OpenWeatherApp
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IKernel container;

        public App()
        {
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureContainer();
            ComposeObjects();
            Current.MainWindow.Show();
        }

        private void ConfigureContainer()
        {
            this.container = new StandardKernel();

            string localDataAppPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Assembly.GetExecutingAssembly().GetName().Name);
            System.IO.Directory.CreateDirectory(localDataAppPath);
            string openWeatherMapApiBaseAddress = ConfigurationManager.AppSettings["OpenWeatherMapApiBaseAddress"];
            string openWeatherMapApiAppId = ConfigurationManager.AppSettings["OpenWeatherMapApiAppId"];
            string dataStoreFilePath = Path.Combine(localDataAppPath, ConfigurationManager.AppSettings["DataStoreFileName"]);
            string getCurrentWeatherServiceName = ConfigurationManager.AppSettings["GetCurrentWeatherServiceName"];

            container.Bind<IOpenWeatherDataStoreClient>().To<OpenWeatherDataStoreClient>().InSingletonScope()
                .WithConstructorArgument("dataStoreFilePath", dataStoreFilePath);
            container.Bind<IGetCurrentWeatherServiceController>().To<GetCurrentWeatherServiceController>().InSingletonScope()
                .WithConstructorArgument("openWeatherMapApiBaseAddress", openWeatherMapApiBaseAddress)
                .WithConstructorArgument("openWeatherMapApiAppId", openWeatherMapApiAppId)
                .WithConstructorArgument("dataStoreFilePath", dataStoreFilePath)
                .WithConstructorArgument("getCurrentWeatherServiceName", getCurrentWeatherServiceName);
        }

        private void ComposeObjects()
        {
            Current.MainWindow = this.container.Get<MainWindow>();
            Current.MainWindow.DataContext = this.container.Get<MainWindowViewModel>();
        }
    }
}
