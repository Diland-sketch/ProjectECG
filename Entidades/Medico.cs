﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Medico : Persona
    {
        public List<Paciente> pacientes;
        public string Usuario { get; set; }

        public Medico()
        {
        }


        public Medico(string documento, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido,
            DateOnly fechaNacmiento, char sexo, string usuario)
            : base(documento, primerNombre, segundoNombre, primerApellido, segundoApellido, fechaNacmiento, sexo)
        {
            pacientes = new List<Paciente>();
             Usuario = usuario;
        }
    }
}
