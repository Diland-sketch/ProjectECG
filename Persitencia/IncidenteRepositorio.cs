using Entidades;
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
    public class IncidenteRepositorio : ConexionOracle
    {
        SesionECGRepositorio SesionECGRepositorio = new SesionECGRepositorio();
        public string Guardar(Incidentes incidente)
        {
            try
            {
                 
                AbrirConexion();
                using (OracleCommand cmd = new OracleCommand("insertar_incidente", conexion)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                })
                {
                    cmd.Parameters.Add("p_FechaHora", OracleDbType.TimeStamp).Value = incidente.FechaHoraIncidente;
                    cmd.Parameters.Add("p_IdSesion", OracleDbType.Int32).Value = incidente.IdSesionECG;
                    cmd.Parameters.Add("p_Descripcion", OracleDbType.Varchar2).Value = incidente.Descripcion;

                    cmd.ExecuteNonQuery();
                }
                CerrarConexion();
                return "Incidente registrado exitosamente";
            }
            catch (Exception ex)
            {
                return "Error al registrar incidente";
            }
        }
    }
}
