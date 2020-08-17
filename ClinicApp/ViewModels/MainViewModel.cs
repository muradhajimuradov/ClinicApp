using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicApp.Data;
using ClinicApp.Models;
using GalaSoft.MvvmLight.Messaging;

namespace ClinicApp.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set => Set(ref _currentViewModel, value);
        }

        public MainViewModel()
        {

        }

        private RelayCommand _goToPatientsCommand;
        public RelayCommand GoToPatientsCommand => _goToPatientsCommand = new RelayCommand(
            () => CurrentViewModel = App.Services.GetInstance<PatientsViewModel>());

        private RelayCommand _goToVisitsCommand;
        public RelayCommand GoToVisitsCommand => _goToVisitsCommand = new RelayCommand(
            () => CurrentViewModel = App.Services.GetInstance<VisitsViewModel>());
    }
}
