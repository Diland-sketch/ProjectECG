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
                OracleCommand Ocmd = new OracleCommand($"insertar_sesion", conexion);
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

        public SesionECG ConsultarId(string id)
        {
            throw new NotImplementedException();
        }

        public DataTable ConsultarTodo()
        {
            string ssql = $"SELECT * FROM historia_sesiones ";
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
