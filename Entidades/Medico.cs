using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Medico : Usuario
    {
        public List<Paciente> pacientes;
        public Medico(string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, 
            string identificacion, DateTime fechaNacmiento, char sexo, string nombreUsuario, string contrasenha, Rol rol) 
            : base(primerNombre, segundoNombre, primerApellido, segundoApellido, identificacion, fechaNacmiento, sexo, nombreUsuario, contrasenha, rol)
        {
            pacientes = new List<Paciente>();
        }
    }
}
