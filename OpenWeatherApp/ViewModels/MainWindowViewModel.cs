
using OpenWeatherApp.Models;
using OpenWeatherApp.Services;
using OpenWeatherDataStore;
using OpenWeatherDataStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OpenWeatherApp.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        MainWindowModel model = default;
        readonly IGetCurrentWeatherServiceController getCurrentWeatherServiceController;
        readonly IOpenWeatherDataStoreClient openWeatherDataStoreClient;

        public ICommand StartGetCurrentWeatherServiceCommand { get; }
        public ICommand StopGetCurrentWeatherServiceCommand { get; }
        public ICommand RefreshWeatherDataCommand { get; }

        public MainWindowModel Model {
            get => model;
            set {
                model = value;
                RaisePropertyChanged(nameof(Model));
            }
        }

        public MainWindowViewModel(IGetCurrentWeatherServiceController getCurrentWeatherServiceController, IOpenWeatherDataStoreClient openWeatherDataStoreClient)
        {
            this.getCurrentWeatherServiceController = getCurrentWeatherServiceController;
            this.openWeatherDataStoreClient = openWeatherDataStoreClient;

            StartGetCurrentWeatherServiceCommand = new RelayCommand(o => getCurrentWeatherServiceController.StartService(), o => getCurrentWeatherServiceController.CanBeStarted);
            StopGetCurrentWeatherServiceCommand = new RelayCommand(o => getCurrentWeatherServiceController.StopService(), o => getCurrentWeatherServiceController.CanBeStopped);
            RefreshWeatherDataCommand = new RelayCommand(o => RefreshWeatherData(), o => true);
            RefreshWeatherData();
        }

        private void RefreshWeatherData()
        {
            WeatherDataModel weatherDataModel = openWeatherDataStoreClient.GetLastWeatherData();
            if(weatherDataModel != null)
            {
                Model = new MainWindowModel()
                {
                    Country = weatherDataModel.Country,
                    Location = weatherDataModel.Location,
                    Temp = weatherDataModel.Temp,
                    LastUpdate = weatherDataModel.CreatedAt.ToLocalTime()
                };
            }
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
