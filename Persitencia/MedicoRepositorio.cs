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
    public class MedicoRepositorio : ConexionOracle 
    {
        UsuarioRepositorio userRepository = new UsuarioRepositorio();
        public string Guardar(Medico entity, Usuario user)
        {
            try
            {
                userRepository.Guardar(user);
                entity.Usuario = userRepository.MostrarId(user.NombreUsuario);
                string ssql = "";
                if (entity.SegundoNombre == "")
                {
                    ssql = "INSERT INTO medicos(idmedico,primer_nombre,segundo_nombre, primer_apellido,segundo_apellido,sexo,fecha_nacimiento,usuario_id)" +
                                                   $"VALUES('{entity.Identificacion}', '{entity.PrimerNombre}', DEFAULT, '{entity.PrimerApellido}'," +
                                                   $" '{entity.SegundoApellido}', '{entity.Sexo}', (TO_DATE ('{entity.FechaNacimiento}', 'DD/MM/YYYY')), {entity.Usuario})";
                }
                else 
                { 
                    ssql =  "INSERT INTO medicos(idmedico,primer_nombre,segundo_nombre, primer_apellido,segundo_apellido,sexo,fecha_nacimiento,usuario_id)" +
                                                   $"VALUES('{entity.Identificacion}', '{entity.PrimerNombre}', '{entity.SegundoNombre}', '{entity.PrimerApellido}'," +
                                                   $" '{entity.SegundoApellido}', '{entity.Sexo}', (TO_DATE ('{entity.FechaNacimiento}', 'DD/MM/YYYY')), {entity.Usuario})";
                }
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

        public string Actualizar(Medico entity, Usuario user)
        {
            try
            {
                user.IdUsuario = MostrarIdU(entity.Identificacion);
                /*string u =*/
                userRepository.Actualizar(user);


                string ssql = $"UPDATE medicos SET primer_nombre = '{entity.PrimerNombre}'," +
                                                  $"segundo_nombre = '{entity.SegundoNombre}'," +
                                                  $"primer_apellido = '{entity.PrimerApellido}'," +
                                                  $"segundo_apellido = '{entity.SegundoApellido}'," +
                                                  $"sexo = '{entity.Sexo}'," +
                                                  $"fecha_nacimiento = (TO_DATE ('{entity.FechaNacimiento}', 'DD/MM/YYYY'))" +
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

        public List<Medico> ConsultarTodo()
        {

            string ssql = "SELECT * FROM medicos";
                //$"SELECT m.idmedico,m.primer_nombre,m.segundo_nombre,m.primer_apellido,m.segundo_apellido,m.sexo,m.fecha_nacimiento , u.nombre_usuario" +
            //                       $"FROM medicos m" +
            //                       $"JOIN usuarios u" +
            //                       $"ON m.usuario_id =u.id_usuario";

            List<Medico> list = new List<Medico>();

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
        public Medico Mapper(OracleDataReader reader)
        {
            string sexo = reader.GetString(reader.GetOrdinal("sexo"));
            string fecha = reader.GetString(reader.GetOrdinal("fecha_nacimiento"));
            return new Medico
            {
                Identificacion = reader.GetString(reader.GetOrdinal("idmedico")),
                PrimerNombre = reader.GetString(reader.GetOrdinal("primer_nombre")),
                SegundoNombre = reader.GetString(reader.GetOrdinal("segundo_nombre")),
                PrimerApellido = reader.GetString(reader.GetOrdinal("primer_apellido")),
                SegundoApellido = reader.GetString(reader.GetOrdinal("segundo_apellido")),
                Sexo = char.Parse(sexo),
                FechaNacimiento = DateOnly.Parse(fecha),
            };

        }
        public int MostrarIdU(string id)
        {
            string ssql = $"SELECT usuario_id FROM medicos WHERE idmedico = '{id}' ";
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

        public string Eliminar(string id)
        {
            try
            {
                int idu = MostrarIdU(id);
                string ssql = $"DELETE FROM medicos WHERE idmedico = '{id}'";
                
                
                OracleCommand ocmd = new OracleCommand(ssql, conexion);
                AbrirConexion();


                int confirmacion = ocmd.ExecuteNonQuery();
                userRepository.Eliminar(idu);
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
            string ssql = $"SELECT * FROM medicos WHERE idmedico = '{id}' ";
            Medico medico = new Medico();

            using (OracleCommand cmd = new OracleCommand(ssql, conexion))
            {
                AbrirConexion();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        medico.Identificacion = reader.GetString(reader.GetOrdinal("idmedico"));
                        medico.PrimerNombre = reader.GetString(reader.GetOrdinal("primer_nombre"));
                        medico.SegundoNombre = reader.GetString(reader.GetOrdinal("segundo_nombre"));
                        medico.PrimerApellido = reader.GetString(reader.GetOrdinal("primer_apellido"));
                        medico.SegundoApellido = reader.GetString(reader.GetOrdinal("segundo_apellido"));
                        string sexo = reader.GetString(reader.GetOrdinal("sexo"));
                        medico.Sexo = char.Parse(sexo);
                        string fecha = reader.GetString(reader.GetOrdinal("fecha_nacimiento"));
                        medico.FechaNacimiento = DateOnly.Parse(fecha);
                        
                    }
                }
            }

            CerrarConexion();
            return medico;
        }
        
        public string EliminarTodo()
        {
            try
            {
                string ssql = $"DELETE FROM medicos";


                OracleCommand ocmd = new OracleCommand(ssql, conexion);
                AbrirConexion();


                int confirmacion = ocmd.ExecuteNonQuery();

                if (confirmacion > 0)
                {
                    UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();
                    usuarioRepositorio.EliminarTodo();
                    return "Se eliminaron todos los datos satisfactoriamente";
                    
                }
                else
                {
                    return "Error a la hora de eliminar todo";
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
