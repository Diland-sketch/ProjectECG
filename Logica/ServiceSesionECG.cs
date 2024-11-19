using Entidades;
using Persitencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ServiceSesionECG
    {
        SesionECGRepositorio repositorio = new SesionECGRepositorio();
        public string Guardar(SesionECG sesion)
        {
            return repositorio.Guardar(sesion);
        }
    }
}
