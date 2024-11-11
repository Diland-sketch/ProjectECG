using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Medico : Persona
    {
        public List<Paciente> pacientes;
        public Usuario Credenciales { get; set; }

        public Medico()
        {
        }

        public Medico(string documento, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido,
            DateTime fechaNacmiento, char sexo, Usuario credenciales)
            : base(documento, primerNombre, segundoNombre, primerApellido, segundoApellido, fechaNacmiento, sexo)
        {
            pacientes = new List<Paciente>();
            Credenciales = credenciales;
        }
    }
}
