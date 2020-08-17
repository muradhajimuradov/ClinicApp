using ClinicApp.Data;
using ClinicApp.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.ViewModels
{
    class PatientsViewModel : ViewModelBase
    {
        public ClinicContext ClinicContext { get; }
        private Patient _selectedPatient;
        public Patient SelectedPatient
        {
            get => _selectedPatient;
            set
            {
                _selectedPatient = value;
                RaisePropertyChanged();
            }
        }

        public PatientsViewModel()
        {
            ClinicContext = App.Services.GetInstance<ClinicContext>();
            ClinicContext.Patients.Load();
        }

        private RelayCommand _addPatient;
        private RelayCommand _removePatient;
        private RelayCommand _saveChanges;

        public RelayCommand SaveChanges =>
            _saveChanges ??
            (_saveChanges = new RelayCommand(
                () =>
                {
                    ClinicContext.SaveChanges();
                }));

        public RelayCommand AddPatient =>
            _addPatient ??
            (_addPatient = new RelayCommand(
                () =>
                {
                    Patient patient = new Patient { FullName = "", BirthDate = new DateTime(1920, 1, 1), Address = "", Gender = Gender.Male, Phone = "" };
                    ClinicContext.Patients.Add(patient);
                    SelectedPatient = patient;
                    //SelectedPatient = ClinicContext.Patients.LastOrDefault();
                    ClinicContext.SaveChanges();
                }));

        public RelayCommand RemovePatient =>
            _removePatient ??
            (_removePatient = new RelayCommand(
                () =>
                {
                    if (SelectedPatient != null)
                    {
                        ClinicContext.Patients.Remove(SelectedPatient);
                        ClinicContext.SaveChanges();
                    }
                }));
    }
}
