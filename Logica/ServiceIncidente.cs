using Entidades;
using Persitencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ServiceIncidente
    {
        IncidenteRepositorio repositorio;

        public ServiceIncidente()
        {
            repositorio = new IncidenteRepositorio();
        }

        public string Guardar(Incidentes incidente)
        {
            return repositorio.Guardar(incidente);
        }

        public string MostrarNumeroIncidente(int id)
        {
            return repositorio.MostrarId(id);
        }
    }
}
