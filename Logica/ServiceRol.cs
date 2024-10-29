using Persistencia;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ServiceRol
    {
        RolRepositorio rolRepositorio = new RolRepositorio();

        public string Eliminar(string idRol)
        {
            return rolRepositorio.Eliminar(idRol);
        }

        public string Guardar(Rol rol)
        {
            return rolRepositorio.Guardar(rol);
        }
    }
}
