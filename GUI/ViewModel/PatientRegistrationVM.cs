using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI.Model;
using Logica;
using Entidades;

namespace GUI.ViewModel
{
    class PatientRegistrationVM : Utilities.ViewModelBase
    {
        public ServicePaciente service;

        public PatientRegistrationVM()
        {
            service = new ServicePaciente();
        }
    }
}
