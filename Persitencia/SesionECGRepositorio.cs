using Entidades;
using Oracle.ManagedDataAccess.Client;
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
        UsuarioRepositorio UsuarioRepositorio = new UsuarioRepositorio();
        public string Guardar(SesionECG entity)
        {
            try
            {
                entity.IdMedico = UsuarioRepositorio.Retornaridmedico();
                
                OracleCommand Ocmd = new OracleCommand($"insertar_sesion({entity.InicioSesionECG},{entity.FinSesionECG},{}" +
                                                       $",{},{})", conexion);
                AbrirConexion();

                int confirmacion = Ocmd.ExecuteNonQuery();
                //CerrarConexion();

                if (confirmacion > 0)
                {
                    return "Se guardo satisfactoriamente";
                }
                else
                {
                    return "Error a la hora de guardar";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                CerrarConexion();
            }
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
