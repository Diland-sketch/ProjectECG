using Entidades;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class RolRepositorio : ConexionOracle, ICrud<Rol>
    {
        public string Guardar(Rol entity)
        {
            try
            {
                string ssql = "INSERT INTO roles(id_rol, nombre_rol) VALUES (:id_rol, :nombre_rol)";

                AbrirConexion();
                OracleCommand Ocmd = conexion.CreateCommand();
                Ocmd.CommandText = ssql;

                Ocmd.Parameters.Add(new OracleParameter(":id_rol", entity.IdRol));
                Ocmd.Parameters.Add(new OracleParameter(":nombre_rol", entity.NombreRol));

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

        public string Actualizar(Rol entity)
        {
            throw new NotImplementedException();
        }

        public string ConsultarId(string id)
        {
            throw new NotImplementedException();
        }

        public List<Rol> ConsultarTodo(Rol entity)
        {
            throw new NotImplementedException();
        }

        public string Eliminar(Rol entity)
        {
            throw new NotImplementedException();
        }

    }
}
