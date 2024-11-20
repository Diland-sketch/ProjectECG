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
        MedicoRepositorio MedicosRepositorio = new MedicoRepositorio();

        public string Guardar(Medico medico, Usuario usuario)
        {
            return MedicosRepositorio.Guardar(medico, usuario);
        }
        public string Actualizar(Medico medico, Usuario usuario)
        {
            return MedicosRepositorio.Actualizar(medico, usuario);

        }
        public int MostrarIdu(string id)
        {
            return MedicosRepositorio.MostrarIdU(id);
        }

        public string MostrarId(int id)
        {
            return MedicosRepositorio.MostrarId(id);
        }
        public Medico ConsultarId(string id)
        {
            return MedicosRepositorio.ConsultarId(id);
        }
        public List<Medico> ConsultarTodo()
        {
            return MedicosRepositorio.ConsultarTodo();
        }

        public string Eliminar(string id)
        {
            return MedicosRepositorio.Eliminar(id);
        }

        public string EliminarTodo()
        {
            return MedicosRepositorio.EliminarTodo();
        }

      
    }
}
