using Entidades;
using Newtonsoft.Json.Converters;
using Oracle.ManagedDataAccess.Client;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persitencia
{
    public class SesionECGRepositorio : ConexionOracle
    {
        UsuarioRepositorio UsuarioRepositorio = new UsuarioRepositorio();
        public string Guardar(SesionECG entity)
        {
            try

            {

                AbrirConexion();
                using (OracleCommand cmd = new OracleCommand("insertar_sesion", conexion)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                })
                {
                    cmd.Parameters.Add("p_fecha_ini", OracleDbType.Date).Value = entity.InicioSesionECG;
                    cmd.Parameters.Add("p_fecha_fini", OracleDbType.Date).Value = entity.FinSesionECG;
                    cmd.Parameters.Add("p_paciente", OracleDbType.Varchar2).Value = entity.IdPaciente;
                    cmd.Parameters.Add("p_descripcion", OracleDbType.Varchar2).Value = entity.Descripcion;
                    cmd.Parameters.Add("p_medico", OracleDbType.Varchar2).Value = entity.IdMedico;

                    int confirmacion = cmd.ExecuteNonQuery();
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

        public string Actualizar(string idPaciente, string idMedico, DateTime? fechaFin, string descripcion) 
        {
            try
            {
                AbrirConexion();
                using (OracleCommand cmd = new OracleCommand("actualizar_sesion", conexion)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                })
                {
                    cmd.Parameters.Add("p_id_paciente", OracleDbType.Varchar2).Value = idPaciente;
                    cmd.Parameters.Add("p_id_medico", OracleDbType.Varchar2).Value = idMedico;
                    cmd.Parameters.Add("p_fecha_fini", OracleDbType.TimeStamp).Value = fechaFin;
                    cmd.Parameters.Add("p_descripcion", OracleDbType.Varchar2).Value = descripcion;

                    cmd.ExecuteNonQuery();
                }
                CerrarConexion();
                return "Sesion Guardada con exito";
            }
            catch (Exception ex) 
            {
                return "Error al guardar una sesion";
            }
        }

        public int MostrarId(DateTime fecha)
        {
            string ssql = $"SELECT id_sesion FROM usuarios WHERE fechainiciosesion = '{fecha}' ";
            int iduser = 0;

            using (OracleCommand cmd = new OracleCommand(ssql, conexion))
            {
                AbrirConexion();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        iduser = reader.GetInt32(reader.GetOrdinal("fechainiciosesion"));
                    }
                }
            }
            CerrarConexion();
            return iduser;

        }
        public SesionECG ConsultarId(string id)
        {
            throw new NotImplementedException();
        }

        public DataTable ConsultarTodo()
        {
            string ssql = $"SELECT * FROM historial_sesiones ";
            AbrirConexion();
            OracleCommand cmd = new OracleCommand(ssql, conexion);
            OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(cmd);
            DataTable list = new DataTable();
            oracleDataAdapter.Fill(list);
           
            
            CerrarConexion();
            return list;
        }
        
        //public string Eliminar(string id)
        //{
        //    try
        //    { 
        //        OracleCommand ocmd = new OracleCommand(ssql, conexion);
        //        AbrirConexion();


        //        int confirmacion = ocmd.ExecuteNonQuery();
                
        //        if (confirmacion > 0)
        //        {
        //            return "Se elimino satisfactoriamente";
        //        }
        //        else
        //        {
        //            return "Error a la hora de eliminar";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //    finally
        //    {
        //        CerrarConexion();
        //    }
        //}
    }
}
