using Entidades;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class MedicosRepositorio : ConexionOracle , ICrud<Medico>
    {
        UserRepository userRepository;
        RolRepositorio rolRepositorio;

        public MedicosRepositorio()
        {
            userRepository = new UserRepository();
            rolRepositorio = new RolRepositorio();
        }
        public string Guardar(Medico entity)
        {
            try
            {
                int idRolMedico = rolRepositorio.ObtenerIdRol("'medico'");

                if (idRolMedico == -1) 
                {
                    return "Error: Rol medico no encontrado";
                }

                string userSql = "INSERT INTO usuarios(id_usuario, nombre_usuario, contrasenha, roles_id_rol) " +
                            "VALUES(:id_usuario, :nombre_usuario, :contrasenha, :roles_id_rol)";

                AbrirConexion();
                OracleCommand OcmdUsuario = conexion.CreateCommand();
                OcmdUsuario.CommandText = userSql;

                OcmdUsuario.Parameters.Add(new OracleParameter(":id_usuario", 1));
                OcmdUsuario.Parameters.Add(new OracleParameter(":nombre_usuario", entity.Credenciales.NombreUsuario));
                OcmdUsuario.Parameters.Add(new OracleParameter(":contrasenha", entity.Credenciales.contrasenha));
                OcmdUsuario.Parameters.Add(new OracleParameter(":roles_id_rol", idRolMedico));


                string ssql = "INSERT INTO medicos(idmedico, primer_nombre, segundo_nombre, primer_apeliido, " +
                    "segundo_apellido, sexo, fecha_nacimiento, id_usuario) " +
                    "VALUES (:idmedico, :primer_nombre, :segundo_nombre, :primer_apeliido, :segundo_apellido, :sexo, :fecha_nacimiento, :id_usuario)";

                OracleCommand Ocmd = conexion.CreateCommand();
                Ocmd.CommandText = ssql;

                Ocmd.Parameters.Add(new OracleParameter(":idmedico", entity.Identificacion));
                Ocmd.Parameters.Add(new OracleParameter(":primer_nombre", entity.PrimerNombre));
                Ocmd.Parameters.Add(new OracleParameter(":segundo_nombre", entity.SegundoNombre));
                Ocmd.Parameters.Add(new OracleParameter(":primer_apeliido", entity.PrimerApellido));
                Ocmd.Parameters.Add(new OracleParameter(":segundo_apellido", entity.SegundoApellido));
                Ocmd.Parameters.Add(new OracleParameter(":sexo", entity.Sexo));
                Ocmd.Parameters.Add(new OracleParameter(":fecha_nacimiento", entity.FechaNacmiento));
                Ocmd.Parameters.Add(new OracleParameter(":id_usuario", entity.Credenciales.IdUsuario));

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

        public string Eliminar(string id)
        {
            throw new NotImplementedException();
        }
    }
}
