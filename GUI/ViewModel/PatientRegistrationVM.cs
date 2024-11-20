using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI.Model;
using Logica;
using Entidades;
using System.Windows.Input;
using GUI.Utilities;
using GUI.ViewDashBoard;

namespace GUI.ViewModel
{
    class PatientRegistrationVM : Utilities.ViewModelBase
    {
        public ServicePaciente service;
        public ICommand CancelCommand { get; }

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }
        public PatientRegistrationVM()
        {
            service = new ServicePaciente();

            CancelCommand = new RelayCommand(ExecuteCancelCommand);
        }
        private void ExecuteCancelCommand(object parameter)
        {
            // Cambiar la vista a HomeView
            var navigationVM = App.Current.MainWindow?.DataContext as NavigationVM;
            if (navigationVM != null)
            {
                navigationVM.CurrentView = new HomeView();
            }
        }
    }
}
