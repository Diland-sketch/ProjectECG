using Entidades;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class UserRepository : ConexionOracle, ICrud<Usuario>
    {

        public string Guardar(Usuario entity)
        {
            try
            {
                string ssql = "INSERT INTO usuarios(id_usuario, nombre_usuario, contrasenha, roles_id_rol, " +
                    "VALUES (:id_usuario, :nombre_usuario, :contrasenha, :roles_id_rol)";

                AbrirConexion();
                OracleCommand Ocmd = conexion.CreateCommand();
                Ocmd.CommandText = ssql;

                Ocmd.Parameters.Add(new OracleParameter(":id_usuario", entity.IdUsuario));
                Ocmd.Parameters.Add(new OracleParameter(":nombre_usuario", entity.NombreUsuario));
                Ocmd.Parameters.Add(new OracleParameter(":contrasenha", entity.contrasenha));
                Ocmd.Parameters.Add(new OracleParameter(":roles_id_rol", entity.Rol.IdRol));

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
        public string Actualizar(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public string ConsultarId(string id)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> ConsultarTodo(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public string Eliminar(string id)
        {
            throw new NotImplementedException();
        }

        public bool ValidarUsuarioAdmin(Usuario usuario)
        {
            if(usuario.NombreUsuario == "admin" && usuario.contrasenha == "123")
            {
                return true;
            }
            return false;
        }
    }
}
