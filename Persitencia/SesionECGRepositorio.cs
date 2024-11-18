using Entidades;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persitencia
{
    public class SesionECGRepositorio : ConexionOracle, ICrud<SesionECG>
    {

        public string Guardar(SesionECG entity)
        {
            /*try
            {
                string ssql = "INSERT INTO sesiones(ID_SESION, FECHAINICIOSESION, DESCRIPCION, IDPACIENTE, IDMEDICO, RUTA_ARCHIVO) " +
                      "VALUES (:idSesion, :inicioSesion, :descripcion, :idPaciente, :idMedico, :rutaArchivo)";
            }*/
            throw new NotImplementedException();
        }

        public string Actualizar(SesionECG entity)
        {
            throw new NotImplementedException();
        }

        public SesionECG ConsultarId(string id)
        {
            throw new NotImplementedException();
        }

        public List<SesionECG> ConsultarTodo()
        {
            throw new NotImplementedException();
        }
        
        public string Eliminar(string id)
        {
            throw new NotImplementedException();
        }
    }
}
