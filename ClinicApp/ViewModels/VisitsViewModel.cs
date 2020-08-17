using ClinicApp.Data;
using ClinicApp.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ClinicApp.ViewModels
{
    class VisitsViewModel : ViewModelBase
    {
        private bool _isActive;
        private Patient _selectedPatient;
        private Visit _selectedVisit;
        private RelayCommand _addVisit;
        private RelayCommand _removeVisit;
        private RelayCommand _saveChanges;

        public ClinicContext ClinicContext { get; }

        public Patient SelectedPatient
        {
            get => _selectedPatient;
            set
            {
                _selectedPatient = value;
                IsActive = true;
                RaisePropertyChanged();
            }
        }

        public bool IsActive { 
            get => _isActive; 
            set { 
                _isActive = value; 
                RaisePropertyChanged(); 
            } 
        }

        public Visit SelectedVisit
        {
            get => _selectedVisit;
            set
            {
                _selectedVisit = value;
                RaisePropertyChanged();
            }
        }
        public VisitsViewModel()
        {
            ClinicContext = App.Services.GetInstance<ClinicContext>();
            ClinicContext.Patients.Load();
            ClinicContext.Visits.Load();
        }

        

        public RelayCommand SaveChanges =>
            _saveChanges ??
            (_saveChanges = new RelayCommand(
                () =>
                {
                    ClinicContext.SaveChanges();
                }));

        public RelayCommand AddVisit =>
            _addVisit ??
            (_addVisit = new RelayCommand(
                () =>
                {
                    if (SelectedPatient != null)
                    {
                        Visit visit = new Visit() { Diagnosis = "", VisitTime = new DateTime(1920, 1, 1), VisitType = VisitType.Primary, PatientId = SelectedPatient.Id };
                        ClinicContext.Visits.Add(visit);
                        SelectedVisit = visit;
                        ClinicContext.SaveChanges();
                    }
                    else IsActive = false;
                }));

        public RelayCommand RemoveVisit =>
            _removeVisit ??
            (_removeVisit = new RelayCommand(
                () =>
                {
                    if (SelectedVisit != null)
                    {
                        ClinicContext.Visits.Remove(SelectedVisit);
                        ClinicContext.SaveChanges();
                    }
                }));
    }
}
