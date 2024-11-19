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
                OracleCommand Ocmd = new OracleCommand($"insertar_sesion({entity.InicioSesionECG},{entity.FinSesionECG},{entity.IdPaciente}" +
                                                       $",{entity.Descripcion},{entity.IdMedico})", conexion);
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
