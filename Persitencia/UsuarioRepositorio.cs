using Entidades;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class UsuarioRepositorio : ConexionOracle
    {
        RolRepositorio rolRepositorio = new RolRepositorio();
<<<<<<< Updated upstream
        OracleDataAdapter da = new OracleDataAdapter();
        public bool ValidarUsuario(Usuario usuario)
=======
        MedicoRepositorio medicoRepositorio = new MedicoRepositorio();
        string idmedic;
        public int ValidarUsuario(string nombre, string contrasenha)
>>>>>>> Stashed changes
        {
            if(usuario.NombreUsuario == "admin" && usuario.contrasenha == "123")
            {
<<<<<<< Updated upstream
                return true;
=======
                return 1;
            }
            else
            {
                Usuario user = ConsultarUsuario(nombre, contrasenha);
                string nom, contra;
                nom = user.NombreUsuario;
                contra = user.Contrasenha;
                if (nom == null && contra == null)
                {
                    return -1;
                }
                else
                {
                   idmedic = medicoRepositorio.MostrarId(MostrarId(nom));
                    return 2;
                }
>>>>>>> Stashed changes
            }
            return false;
        }
        public string Guardar(Usuario entity)
        {
            try
            {
                
                int IdRol = rolRepositorio.MostrarIdRol("medicos");
                entity.IdRol = IdRol;
                
                string ssql = "INSERT INTO usuarios(Contrasenha, roles_id_rol, id_usuario, nombre_usuario)" +
                                                   $"VALUES ('{entity.Contrasenha}', {entity.IdRol} , seq_usuarios.nextval ," +
                                                   $"'{entity.NombreUsuario}')";

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

        public int MostrarId(string nomuser)
        {

            string ssql = $"SELECT id_usuario FROM usuarios WHERE nombre_usuario = '{nomuser}' ";
            int iduser = 0;

            using (OracleCommand cmd = new OracleCommand(ssql, conexion))
            {
             AbrirConexion();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        iduser= reader.GetInt32(reader.GetOrdinal("id_usuario"));
                    }
                }
            }
            CerrarConexion();
            return iduser;

        }
<<<<<<< Updated upstream
=======

        public Usuario ConsultarUsuario(string nombre, string contrasenha)
        {
            string ssql = $"SELECT nombre_usuario, Contrasenha FROM usuarios WHERE nombre_usuario = '{nombre}' AND Contrasenha = '{contrasenha}'";
            Usuario user = new Usuario();

            using (OracleCommand cmd = new OracleCommand(ssql, conexion))
            {
                AbrirConexion();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user.NombreUsuario = reader.GetString(reader.GetOrdinal("nombre_usuario"));
                        user.Contrasenha = reader.GetString(reader.GetOrdinal("Contrasenha"));
                    }
                }
            }
            CerrarConexion();
            return user;
        }
>>>>>>> Stashed changes
        

        public Usuario ConsultarId(int id)
        {
<<<<<<< Updated upstream

            string ssql = $"SELECT nombre_usuario,contrasenha FROM usuarios WHERE id_usuario = {id} ";
=======
            string ssql = $"SELECT nombre_usuario, Contrasenha  FROM usuarios WHERE id_usuario = {id} ";
>>>>>>> Stashed changes
            Usuario user = new Usuario();

            using (OracleCommand cmd = new OracleCommand(ssql, conexion))
            {
                AbrirConexion();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        
                        user.NombreUsuario = reader.GetString(reader.GetOrdinal("nombre_usuario"));
                        user.Contrasenha = reader.GetString(reader.GetOrdinal("Contrasenha"));

                    }
                }
            }

            return user;
            CerrarConexion();
            
        }

        public string Actualizar(Usuario entity)
        {
            try
            {
                string ssql = $"UPDATE usuarios SET Contrasenha = '{entity.Contrasenha}', nombre_usuario = '{entity.NombreUsuario}' WHERE id_usuario = {entity.IdUsuario} ";
                
                OracleCommand Ocmd = new OracleCommand(ssql, conexion);
                AbrirConexion();

                int confirmacion = Ocmd.ExecuteNonQuery();
                //CerrarConexion();

                if (confirmacion > 0)
                {
                    return "Se actualizo satisfactoriamente";
                }
                else
                {
                    return "Error a la hora de actualizar";
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

        public string Retornaridmedico()
        {
            return idmedic;
        }

        public string Eliminar(int id)
        {
            try
            {
                string ssql = $"DELETE FROM usuarios WHERE id_usuario = {id}";

                
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

        public string EliminarTodo()
        {
            try
            {
                string ssql = $"DELETE FROM usuarios";


                OracleCommand ocmd = new OracleCommand(ssql, conexion);
                AbrirConexion();


                int confirmacion = ocmd.ExecuteNonQuery();

                if (confirmacion > 0)
                {
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
