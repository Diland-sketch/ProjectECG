using Entidades;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ServiceMedico 
    {
        MedicosRepositorio MedicosRepositorio = new MedicosRepositorio();

        public string Guardar(Medico medico, Usuario usuario)
        {
            return MedicosRepositorio.Guardar(medico, usuario);
        }
        public string Actualizar(Medico medico,Usuario usuario)
        {
            return MedicosRepositorio.Actualizar(medico, usuario);

        }

        public string ConsultarId(string id)
        {
            throw new NotImplementedException();
        }

        public List<Medico> ConsultarTodo()
        {
            return MedicosRepositorio.ConsultarTodo();
        }

        public string Eliminar(string id)
        {
            return MedicosRepositorio.Eliminar(id);
        }

        

      
    }
}
