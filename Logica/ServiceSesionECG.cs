﻿using Entidades;
using Persitencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ServiceSesionECG
    {
        SesionECGRepositorio repositorio = new SesionECGRepositorio();
        public int Guardar(SesionECG sesion)
        {
            return repositorio.Guardar(sesion);
        }

        public string Actualizar(SesionECG sesion)
        {
            return repositorio.Actualizar(sesion.IdPaciente, sesion.IdMedico, sesion.FinSesionECG, sesion.Descripcion);
        }
        public DataTable ConsultarTodo()
        {
            return repositorio.ConsultarTodo();
        }
    }
}
