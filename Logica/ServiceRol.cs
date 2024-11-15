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

        public string Guardar(string rol)
        {
            return rolRepositorio.Guardar(rol);
        }
        

        public string ConsultarId(string id)
        {
            throw new NotImplementedException();
        }

        public List<Rol> ConsultarTodo()
        {
            throw new NotImplementedException();
        }

        public string Eliminar(string nom)
        {
            return rolRepositorio.Eliminar(nom);
        }

        
    }
}
