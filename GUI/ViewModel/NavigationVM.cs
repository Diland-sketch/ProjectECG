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
        public ICommand CancelCommand { get; }
        public ICommand HomeCommand { get; set; }
        public ICommand ECGMonitoringsCommand { get; set; }
        public ICommand PatientHistorysCommand { get; set; }
        public ICommand PatientRegistrationsCommand { get; set; }
        public ICommand PatientUpdatesCommand { get; }
        public ICommand PatientDeletesCommand { get; }
        public ICommand PatientSearchCommand { get; }
        public ICommand NavigationCrudPatientsCommand { get; }
        

        private void Cancel(object obj)
        {
            CurrentView = new HomeVM();
        }
       

        private void Home(object obj) => CurrentView = new HomeVM();
        private void ECGMonitoring(object obj) => CurrentView = new ECGMonitoringVM();
        private void PatientHistory(object obj) => CurrentView = new PatientHistoryVM();
        private void PatientRegistration(object obj) => CurrentView = new PatientRegistrationVM();
        private void PatientUpdate(object obj) => CurrentView = new UpdatePatientVM();
        private void PatientDelete(object obj) => CurrentView = new DeletePatientVM();
        private void PatientSearch(object obj) => CurrentView = new ConsultPatientVM();
        private void NavigationCrudPatient(object obj) => CurrentView = new NavigationCrudPatientVM();



        public NavigationVM()
        {
            CancelCommand = new RelayCommand(Cancel);
            //HomeCommand = new RelayCommand(Home);
            //ECGMonitoringsCommand = new RelayCommand(ECGMonitoring);
            //PatientHistorysCommand = new RelayCommand(PatientHistory);
            //SearchPatientCommand = new RelayCommand(SearchPatient);
            //PatientRegistrationsCommand = new RelayCommand(PatientRegistration);
            //PatientUpdatesCommand = new RelayCommand(PatientUpdate);
            //PatientDeletesCommand = new RelayCommand(PatientDelete);
            //PatientSearchCommand = new RelayCommand(PatientSearch);
            //NavigationCrudPatientsCommand = new RelayCommand(NavigationCrudPatient);

            HomeCommand = new RelayCommand(Home);
            ECGMonitoringsCommand = new RelayCommand(ECGMonitoring);
            PatientHistorysCommand = new RelayCommand(PatientHistory);
            NavigationCrudPatientsCommand = new RelayCommand(NavigationCrudPatient);
            PatientRegistrationsCommand = new RelayCommand(PatientRegistration);
            PatientSearchCommand = new RelayCommand(PatientSearch);
            PatientUpdatesCommand = new RelayCommand(PatientUpdate);
            PatientDeletesCommand = new RelayCommand(PatientDelete);



            // Startup Page
            //CurrentView = new HomeVM();
        }

    }
}
