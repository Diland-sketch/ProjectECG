using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paciente : Persona
    { 
        public SesionECG SesionECG { get; set; }

        public Paciente(string documento, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido,
            DateTime fechaNacmiento, char sexo)
            : base(documento, primerNombre, segundoNombre, primerApellido, segundoApellido, fechaNacmiento, sexo)
        {

        }
    }
}
