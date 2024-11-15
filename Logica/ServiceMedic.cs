using Entidades;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ServiceMedic 
    {
        MedicoRepositorio MedicosRepositorio = new MedicoRepositorio();

        public string Guardar(Medico medico, Usuario usuario)
        {
            return MedicosRepositorio.Guardar(medico, usuario);
        }
        public string Actualizar(Medico medico)
        {
            return MedicosRepositorio.Actualizar(medico);

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
