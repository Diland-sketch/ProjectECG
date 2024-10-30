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
        public string Guardar(Medico entity)
        {
            try
            {
                string ssql = "INSERT INTO medicos(id_medico, primer_nombre, segundo_nombre, primer_apellido, " +
                    "segundo_apellido, sexo, fecha_nacimiento, usuarios_id_usuario) " +
                    "VALUES (:id_medico, :primer_nombre, :segundo_nombre, :primer_apellido, :segundo_apellido, :sexo, :fecha_nacimiento, :usuarios_id_usuario)";

                AbrirConexion();
                OracleCommand Ocmd = conexion.CreateCommand();
                Ocmd.CommandText = ssql;

                Ocmd.Parameters.Add(new OracleParameter(":id_medico", entity.Identificacion));
                Ocmd.Parameters.Add(new OracleParameter(":primer_nombre", entity.PrimerNombre));
                Ocmd.Parameters.Add(new OracleParameter(":segundo_nombre", entity.SegundoNombre));
                Ocmd.Parameters.Add(new OracleParameter(":primer_apellido", entity.PrimerApellido));
                Ocmd.Parameters.Add(new OracleParameter(":segundo_apellido", entity.SegundoApellido));
                Ocmd.Parameters.Add(new OracleParameter(":sexo", entity.Sexo));
                Ocmd.Parameters.Add(new OracleParameter(":fecha_nacimiento", entity.FechaNacmiento));
                Ocmd.Parameters.Add(new OracleParameter(":usuarios_id_usuario", entity.Credenciales.IdUsuario));

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
