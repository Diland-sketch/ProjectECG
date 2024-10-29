using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Paciente : Persona
    {
        public string IdPaciente { get; set; }
        public List<HistorialMedico> historialMedicos { get; set; }

        public Paciente(string idPaciente, List<HistorialMedico> historialMedicos, string nombre, string apellido, string documento, DateTime fechaNacmiento, char sexo) : base(nombre, apellido, documento, fechaNacmiento, sexo)
        {

            IdPaciente = idPaciente;
            this.historialMedicos = historialMedicos;
        }
    }
}
