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

                    cmd.ExecuteNonQuery();
                }
                CerrarConexion();
                return "Sesion inicializada exitosamente";
            }
            catch (Exception ex)
            {
                return "Error al inicializar sesion";
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

        public SesionECG ConsultarId(string id)
        {
            throw new NotImplementedException();
        }

        public List<SesionECG> ConsultarTodo()
        {
            throw new NotImplementedException();
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
