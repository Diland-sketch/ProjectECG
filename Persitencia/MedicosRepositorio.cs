using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class MedicosRepositorio : ConexionOracle , ICrud<Medico>
    {
        public string Guardar(Medico entity)
        {
            //string sentenciaSql = "INSERT INTO medicos"
            throw new NotImplementedException();
        }

        public List<Medico> ConsultarTodo(Medico entity)
        {
            throw new NotImplementedException();
        }
        public string ConsultarId(string id)
        {
            throw new NotImplementedException();
        }

        public string Actualizar(Medico entity)
        {
            throw new NotImplementedException();
        }

        public string Eliminar(Medico entity)
        {
            throw new NotImplementedException();
        }
    }
}
