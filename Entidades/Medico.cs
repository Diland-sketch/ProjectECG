using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Medico : Persona
    {
        
        public int Usuario { get; set; }

        public Medico()
        {
        }


        public Medico(string documento, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido,
            DateOnly fechaNacmiento, char sexo, int usuario)
            : base(documento, primerNombre, segundoNombre, primerApellido, segundoApellido, fechaNacmiento, sexo)
        {
            
             Usuario = usuario;
        }
    }
}
