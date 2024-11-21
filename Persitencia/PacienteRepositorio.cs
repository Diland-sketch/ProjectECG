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
    public class PacienteRepositorio : ConexionOracle
    {
        public string Guardar(Paciente entity)
        {
            try
            {
                string ssql = "INSERT INTO pacientes(idpaciente,primer_nombre,segundo_nombre, primer_apellido,segundo_apellido,sexo,fecha_nacimiento)" +
                                                   $"VALUES('{entity.Identificacion}', '{entity.PrimerNombre}', '{entity.SegundoNombre}', '{entity.PrimerApellido}'," +
                                                   $" '{entity.SegundoApellido}', '{entity.Sexo}', (TO_DATE ('{entity.FechaNacimiento}', 'DD/MM/YYYY')))";

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
        public string Actualizar(Paciente entity)
        {
            try
            {
                string ssql = $"UPDATE pacientes SET primer_nombre = '{entity.PrimerNombre}'," +
                                                   $"segundo_nombre = '{entity.SegundoNombre}'," +
                                                   $"primer_apellido = '{entity.PrimerApellido}'," +
                                                   $"segundo_apellido = '{entity.SegundoApellido}'," +
                                                   $"sexo = '{entity.Sexo}'," +
                                                   $"fecha_nacimiento = (TO_DATE ('{entity.FechaNacimiento}', 'DD/MM/YYYY'))" +
                                                   $"WHERE idpaciente = '{entity.Identificacion}'";


                OracleCommand Ocmd = new OracleCommand(ssql, conexion);
                AbrirConexion();

                int confirmacion = Ocmd.ExecuteNonQuery();

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

        public Paciente ConsultarId(string id)
        {
            string ssql = $"SELECT * FROM pacientes WHERE idpaciente = '{id}' ";
            Paciente paciente = new Paciente();

            using (OracleCommand cmd = new OracleCommand(ssql, conexion))
            {
                AbrirConexion();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        paciente.Identificacion = reader.GetString(reader.GetOrdinal("idpaciente"));
                        paciente.PrimerNombre = reader.GetString(reader.GetOrdinal("primer_nombre"));
                        paciente.SegundoNombre = reader.GetString(reader.GetOrdinal("segundo_nombre"));
                        paciente.PrimerApellido = reader.GetString(reader.GetOrdinal("primer_apellido"));
                        paciente.SegundoApellido = reader.GetString(reader.GetOrdinal("segundo_apellido"));
                        string sexo = reader.GetString(reader.GetOrdinal("sexo"));
                        paciente.Sexo = char.Parse(sexo);
                        string fecha = reader.GetString(reader.GetOrdinal("fecha_nacimiento"));
                        paciente.FechaNacimiento = DateOnly.Parse(fecha);
                    }
                }
            }

            CerrarConexion();
            return paciente;
        }

        public Paciente TraerPaciente(string id)
        {
            string ssql = $"SELECT * FROM pacientes WHERE idpaciente = '{id}' ";
            Paciente paciente = new Paciente();

            using (OracleCommand cmd = new OracleCommand(ssql, conexion))
            {
                AbrirConexion();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        paciente.PrimerNombre = reader.GetString(reader.GetOrdinal("primer_nombre"));
                        paciente.PrimerApellido = reader.GetString(reader.GetOrdinal("primer_apellido"));
                    }
                }

                CerrarConexion();
                return paciente;
            }
        }

        public List<Paciente> ConsultarTodo()
        {
            string ssql = "SELECT * FROM pacientes ";
            List<Paciente> list = new List<Paciente>();

            using (OracleCommand cmd = new OracleCommand(ssql, conexion))
            {
                AbrirConexion();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(Mapper(reader));

                    }
                }
            }
            CerrarConexion();
            return list;
        }
        public Paciente Mapper(OracleDataReader reader)
        {
            
            Paciente paciente = new Paciente();

            paciente.Identificacion = reader.GetString(reader.GetOrdinal("idpaciente"));
            paciente.PrimerNombre = reader.GetString(reader.GetOrdinal("primer_nombre"));
            paciente.SegundoNombre = reader.GetString(reader.GetOrdinal("segundo_nombre"));
            paciente.PrimerApellido = reader.GetString(reader.GetOrdinal("primer_apellido"));
            paciente.SegundoApellido = reader.GetString(reader.GetOrdinal("segundo_apellido"));
            string sexo = reader.GetString(reader.GetOrdinal("sexo"));
            paciente.Sexo = char.Parse(sexo);
                
            string fecha = reader.GetString(reader.GetOrdinal("fecha_nacimiento"));
            paciente.FechaNacimiento = DateOnly.Parse(fecha);

            return paciente;

        }

        public string Eliminar(string id)
        {
            try
            {
                string ssql = $"DELETE FROM pacientes WHERE idpaciente = '{id}'";


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

        
    }
}
