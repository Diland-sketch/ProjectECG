using Entidades;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ServiceMedico
    {
        MedicosRepositorio medicosRepositorio;

        public ServiceMedico()
        {
            medicosRepositorio = new MedicosRepositorio();
        }

        public string Guardar(Medico medico)
        {
            return medicosRepositorio.Guardar(medico);
        }
    }
}
