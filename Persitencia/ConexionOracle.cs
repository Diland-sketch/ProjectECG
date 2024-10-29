using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class ConexionOracle
    {
        protected OracleConnection conexion;
        protected string cadena = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
                                  "(HOST=192.168.1.6)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=XEPDB1)));" +
                                  "User Id=ecg;Password=1234;";
        public ConexionOracle()
        {
            conexion = new OracleConnection(cadena);
        }

        public string AbrirConexion()
        {
            try
            {
                conexion.Open();
                return conexion.State.ToString();
            }
            catch (OracleException Oex)
            {
                return $"Error de oracle {Oex.Message}";
            }
            catch (Exception ex) 
            {
                return $"Error en {ex.Message}";
            }
        }

        public string CerrarConexion()
        {
            conexion.Close();
            return conexion.State.ToString();
        }
    }
}
