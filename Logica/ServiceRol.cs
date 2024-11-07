using Persistencia;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Logica
{
    public class ServiceRol : ICrud<Rol>
    {
        RolRepositorio rolRepositorio = new RolRepositorio();

        public string Guardar(Rol rol)
        {
            return rolRepositorio.Guardar(rol);
        }
        public string Actualizar(Rol entity)
        {
            throw new NotImplementedException();
        }

        public string ConsultarId(string id)
        {
            throw new NotImplementedException();
        }

        public List<Rol> ConsultarTodo()
        {
            throw new NotImplementedException();
        }

        public string Eliminar(string idRol)
        {
            return rolRepositorio.Eliminar(idRol);
        }

        
    }
}
