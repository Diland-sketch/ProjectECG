﻿using Entidades;
using Oracle.ManagedDataAccess.Client;
using System.Data.OracleClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Data;

namespace Persistencia
{
    public class RolRepositorio : ConexionOracle
    {
        public string Guardar(Rol entity)
        {
            try
            {
                string ssql = $"INSERT INTO roles(id_rol, nombre_rol) VALUES ( SEQ_ROLES.NEXTVAL, '{entity.NombreRol}')";

                
                OracleCommand Ocmd = new OracleCommand(ssql,conexion);
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


        public string Eliminar(int id)
        {
            try
            {
                string ssql = "DELETE FROM roles WHERE id_rol = :id";

                AbrirConexion();
                OracleCommand ocmd = conexion.CreateCommand();
                ocmd.CommandText = ssql;

                ocmd.Parameters.Add(new OracleParameter(":id", id));

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

         public int MostrarIdRol(string NomRol)
         {
           
            string ssql = $"SELECT id_rol FROM roles WHERE nombre_rol = '{NomRol}' ";
            int IdRol = 0;

            using (OracleCommand cmd = new OracleCommand(ssql, conexion))
            {
              AbrirConexion();
              using (var reader = cmd.ExecuteReader())
              {
                 while (reader.Read())
                 {
                        IdRol = reader.GetInt32(reader.GetOrdinal("id_rol"));
                 }
              }
            }
            CerrarConexion();
            return IdRol ;  
         }        

        public List<Rol> ConsultarTodo()
        {
            string ssql = $"SELECT * FROM roles ";
            List<Rol> list = new List<Rol>();   

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

        public Rol Mapper(OracleDataReader reader)
        {
            return new Rol
            {
                IdRol = reader.GetInt32(reader.GetOrdinal("id_rol")),
                NombreRol = reader.GetString(reader.GetOrdinal("nombre_rol")),
                
            };
            
        }
    }
}
