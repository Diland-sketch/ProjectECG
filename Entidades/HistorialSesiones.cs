using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class HistorialSesiones
    {
        public string IdHistorial { get; set; }
        public Paciente Paciente { get; set; }
        public Medico Medico { get; set; }
        public string Descripcion { get; set; }
        public HistorialSesiones(string idHistorial, Paciente paciente, Medico medico, string descripcion)
        {
            IdHistorial = idHistorial;
            Paciente = paciente;
            Medico = medico;
            Descripcion = descripcion;
        }

        public override string ToString() 
        {
            return $"";
        }
    }
}
