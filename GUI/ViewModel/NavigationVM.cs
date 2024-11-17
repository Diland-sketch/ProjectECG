using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI.Utilities;
using System.Windows.Input;
using System.Runtime;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Transactions;
using System.Windows.Controls;

namespace GUI.ViewModel
{
     public class NavigationVM : ViewModelBase
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }
        public ICommand HomeCommand { get; set; }
        public ICommand ECGMonitoringsCommand { get; set; }
        public ICommand PatientHistorysCommand { get; set; }
        public ICommand PatientRegistrationsCommand { get; set; }
        public ICommand SearchPatientCommand { get; set; }


        private void Home(object obj) => CurrentView = new HomeVM();
        private void ECGMonitoring(object obj) => CurrentView = new ECGMonitoringVM();
        private void PatientHistory(object obj) => CurrentView = new PatientHistoryVM();
        private void PatientRegistration(object obj) => CurrentView = new PatientRegistrationVM();
        private void SearchPatient(object obj) => CurrentView = new SearchPatient();


        public NavigationVM()
        {
            HomeCommand = new RelayCommand(Home);
            ECGMonitoringsCommand = new RelayCommand(ECGMonitoring);
            PatientHistorysCommand = new RelayCommand(PatientHistory);
            PatientRegistrationsCommand = new RelayCommand(PatientRegistration);
            SearchPatientCommand = new RelayCommand(SearchPatient);


            // Startup Page
            CurrentView = new HomeVM();
        }

    }
}
