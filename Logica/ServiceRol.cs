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
    public class ServiceRol 
    {
        RolRepositorio rolRepositorio = new RolRepositorio();

        public string Guardar(string rol)
        {
            return rolRepositorio.Guardar(rol);
        }


        public Rol ConsultarNom(string id)
        {
            return rolRepositorio.ConsultarNom(id);
        }

        public List<Rol> ConsultarTodo()
        {
            return rolRepositorio.ConsultarTodo();
        }

        public string Eliminar(string nom)
        {
            return rolRepositorio.Eliminar(nom);
        }

        
    }
}
