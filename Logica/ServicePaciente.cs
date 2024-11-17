﻿using Entidades;
using Persistencia;
using Persitencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ServicePaciente
    {

        public PacienteRepositorio repositorio;

        public ServicePaciente()
        {
            repositorio = new PacienteRepositorio();
        }

        public string Guardar(Paciente paciente)
        {
            return repositorio.Guardar(paciente);
        }
        public string Actualizar(Paciente paciente)
        {
            return repositorio.Actualizar(paciente);

        }

        public Paciente ConsultarId(string id)
        {
            return repositorio.ConsultarId(id);
        }

        public List<Paciente> ConsultarTodo()
        {
            return repositorio.ConsultarTodo();
        }

        public string Eliminar(string id)
        {
            return repositorio.Eliminar(id);
        }

    }
}