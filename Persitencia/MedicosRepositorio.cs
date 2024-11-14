using Entidades;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class MedicosRepositorio : ConexionOracle 
    {
        
        public string Guardar(Medico entity, Usuario user)
        {
            try
            {

                UserRepository userRepository = new UserRepository();
                userRepository.Guardar(user);
                entity.Usuario = userRepository.MostrarId(user.NombreUsuario);
                string ssql = "INSERT INTO medicos(idmedico,primer_nombre,segundo_nombre, primer_apeliido,segundo_apellido,sexo,fecha_nacimiento,id_usuario)" +
                                                   $"VALUES('{entity.Identificacion}', '{entity.PrimerNombre}', '{entity.SegundoNombre}', '{entity.PrimerApellido}'," +
                                                   $" '{entity.SegundoApellido}', '{entity.Sexo}', TO_DATE ('{entity.FechaNacmiento}', 'dd/mm/yyyy'), {entity.Usuario})";

                OracleCommand Ocmd = new OracleCommand(ssql, conexion);
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

        public List<Medico> ConsultarTodo()
        {
            throw new NotImplementedException();
        }
        public int MostrarIdU(string id)
        {
            string ssql = $"SELECT id_usuario FROM medicos WHERE idmedico = '{id}' ";
            int Iduser = 0;

            using (OracleCommand cmd = new OracleCommand(ssql, conexion))
            {
                AbrirConexion();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        
                        Iduser = reader.GetInt32(reader.GetOrdinal("usuario_id"));

                    }
                }
            }

            CerrarConexion();
            return Iduser;
        }

        public string Actualizar(Medico entity,Usuario user)
        {
            try
            {

                UserRepository userRepository = new UserRepository();
                user.IdUsuario = MostrarIdU(entity.Identificacion);
                /*string u =*/ userRepository.Actualizar(user);
                

                string ssql = $"UPDATE medicos SET primer_nombre = '{entity.PrimerNombre}'," +
                                                  $"segundo_nombre = '{entity.SegundoNombre}'," +
                                                  $"primer_apeliido = '{entity.PrimerApellido}'," +
                                                  $"segundo_apellido = '{entity.SegundoApellido}'," +
                                                  $"sexo = '{entity.Sexo}'," +
                                                  $"fecha_nacimiento = (TO_DATE ('{entity.FechaNacmiento}', 'DD/MM/YYYY'))" +
                                                  $"WHERE idmedico = '{entity.Identificacion}'";
                                                  

                OracleCommand Ocmd = new OracleCommand(ssql, conexion);
                AbrirConexion();

                int confirmacion = Ocmd.ExecuteNonQuery();
                //CerrarConexion();

                if (confirmacion > 0)
                {
                    return "Se actualizaron los datos satisfactoriamente";
                }
                else
                {
                    return "Error a la hora de actualizar los datos";
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

        public string Eliminar(string id)
        {
            try
            {
                string ssql = $"DELETE FROM medicos WHERE idmedico = '{id}'";

                
                OracleCommand ocmd = new OracleCommand(ssql, conexion);
                AbrirConexion();


                int confirmacion = ocmd.ExecuteNonQuery();

                if (confirmacion > 0)
                {
                    return "Se elimino satisfactoriamente";
                }
                else
                {
                    return "Error a la hora de eliminar";
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

        public Medico ConsultarId(string id) 
        {
            string ssql = $"SELECT * FROM medico WHERE idmedico = '{id}' ";
            Medico medico = new Medico();

            using (OracleCommand cmd = new OracleCommand(ssql, conexion))
            {
                AbrirConexion();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        medico.Identificacion = reader.GetString(reader.GetOrdinal("idmedico"));
                        medico.PrimerNombre = reader.GetString(reader.GetOrdinal("idmedico"));
                        medico.SegundoNombre = reader.GetString(reader.GetOrdinal("idmedico"));
                        medico.PrimerApellido = reader.GetString(reader.GetOrdinal("idmedico"));
                        medico.SegundoApellido = reader.GetString(reader.GetOrdinal("idmedico"));
                        medico.Sexo = reader.GetChar(reader.GetOrdinal("idmedico"));
                        string fecha = reader.GetOrdinal("idmedico").ToString("dd-mm-yyyy");
                        medico.FechaNacmiento = DateOnly.Parse(fecha);
                        

                    }
                }
            }

            CerrarConexion();
            return medico;
        }
        
    }
}
