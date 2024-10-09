using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Paciente : Usuario
    {
        public string IdPaciente { get; set; }
        public List<HistorialMedico> historialMedicos { get; set; }
        public Paciente(string nombre, string apellido, string documento, DateTime fechaNacmiento, char sexo, string nombreUsuario, string contrasenha, Rol rol) 
            : base(nombre, apellido, documento, fechaNacmiento, sexo, nombreUsuario, contrasenha, rol)
        {
            historialMedicos = new List<HistorialMedico>();
        }
    }
}
