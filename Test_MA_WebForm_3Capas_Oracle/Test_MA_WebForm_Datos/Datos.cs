using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using System.Data.SqlClient;
using Test_MA_WebForm_Entidades;

namespace Test_MA_WebForm_Datos
{
    public static class Conexion
    {
        public static string ObtenerConexion()
        {
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=testmetrica; Password=abcd1234";
            return conStr;
        }
    }

    public class datos
    {
        public DataTable CargaDatosCliente(string id)
        {
            OracleConnection conexion = new OracleConnection();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            try
            {
                using (OracleConnection connection = new OracleConnection(Conexion.ObtenerConexion()))
                {
                    using (OracleCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "PKG_CLIENTES.PROC_BUSCAR_CLIENTE";
                        command.CommandType = CommandType.StoredProcedure;

                        OracleParameter[] parameters = new OracleParameter[1];

                        command.Parameters.Add(new OracleParameter("p_codcliente", OracleDbType.Varchar2, id, ParameterDirection.Input));
                        command.Parameters.Add(new OracleParameter("o_ClienteEncontrado", OracleDbType.RefCursor, DBNull.Value, ParameterDirection.Output));
                        connection.Open();

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            dt.Load(reader);
                            return dt;
                        }
                    }
                }
            }
            catch (OracleException ex)
            {
                /* SI ALCANZA TIEMPO ME FALTA CREAR METODO QUE GUARDE UN LOG EN ARCHIVO DE TEXTO */
                return null;
            }
            catch (Exception ex)
            {
                /* SI ALCANZA TIEMPO ME FALTA CREAR METODO QUE GUARDE UN LOG EN ARCHIVO DE TEXTO */
                return null;
            }
            finally
            {
                conexion.Close();
            }
        }

        public DataTable CargarListaDeClientes()
        {
            OracleConnection conexion = new OracleConnection();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            try
            {
                using (OracleConnection connection = new OracleConnection(Conexion.ObtenerConexion()))
                {
                    using (OracleCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "PKG_CLIENTES.PROC_LISTAR_CLIENTE";
                        command.CommandType = CommandType.StoredProcedure;

                        OracleParameter[] parameters = new OracleParameter[1];

                        command.Parameters.Add(new OracleParameter("", OracleDbType.RefCursor, DBNull.Value, ParameterDirection.Output));
                        connection.Open();

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            dt.Load(reader);
                            return dt;
                        }
                    }
                }
            }
            catch (OracleException ex)
            {
                /* SI ALCANZA TIEMPO ME FALTA CREAR METODO QUE GUARDE UN LOG EN ARCHIVO DE TEXTO */
                return null;
            }
            catch (Exception ex)
            {
                /* SI ALCANZA TIEMPO ME FALTA CREAR METODO QUE GUARDE UN LOG EN ARCHIVO DE TEXTO */
                return null;
            }
            finally
            {
                conexion.Close();
            }
        }
        public bool EliminarCliente(string id)
        {
            using (OracleConnection connection = new OracleConnection(Conexion.ObtenerConexion()))
            {

                using (OracleCommand command = connection.CreateCommand())
                {
                    command.CommandText = "PKG_CLIENTES.PROC_ELIMINAR_CLIENTE";
                    command.CommandType = CommandType.StoredProcedure;

                    OracleParameter[] parameters = new OracleParameter[2];

                    command.Parameters.Add(new OracleParameter("p_codcliente", OracleDbType.Varchar2, id, ParameterDirection.Input));
                    command.Parameters.Add(new OracleParameter("o_resultado", OracleDbType.Int32, ParameterDirection.Output));

                    connection.Open();

                    command.ExecuteScalar();

                    if (!string.IsNullOrEmpty(command.Parameters["o_resultado"].Value.ToString()))
                        return true;
                    else
                        return false;
                }
            }
        }

        public bool ActualizarCliente(Entidades entidades)
        {
            using (OracleConnection connection = new OracleConnection(Conexion.ObtenerConexion()))
            {

                using (OracleCommand command = connection.CreateCommand())
                {
                    command.CommandText = "PKG_CLIENTES.PROC_ACTUALIZAR_CLIENTE";
                    command.CommandType = CommandType.StoredProcedure;

                    OracleParameter[] parameters = new OracleParameter[6];

                    command.Parameters.Add(new OracleParameter("p_codcliente", OracleDbType.Varchar2, entidades.CodCliente, ParameterDirection.Input));
                    command.Parameters.Add(new OracleParameter("p_ruc", OracleDbType.Varchar2, entidades.Ruc, ParameterDirection.Input));
                    command.Parameters.Add(new OracleParameter("p_razonsocial", OracleDbType.Varchar2, entidades.RazonSocial, ParameterDirection.Input));
                    command.Parameters.Add(new OracleParameter("p_telefono", OracleDbType.Varchar2, entidades.Telefono, ParameterDirection.Input));
                    command.Parameters.Add(new OracleParameter("p_contacto", OracleDbType.Varchar2, entidades.Contacto, ParameterDirection.Input));
                    command.Parameters.Add(new OracleParameter("o_resultado", OracleDbType.Int32, ParameterDirection.Output));

                    connection.Open();

                    command.ExecuteScalar();

                    if (!string.IsNullOrEmpty(command.Parameters["o_resultado"].Value.ToString()))
                        return true;
                    else
                        return false;
                }
            }
        }

        public bool RegistrarCliente(Entidades entidades)
        {
            using (OracleConnection connection = new OracleConnection(Conexion.ObtenerConexion()))
            {

                using (OracleCommand command = connection.CreateCommand())
                {
                    command.CommandText = "PKG_CLIENTES.PROC_REGISTRAR_CLIENTE";
                    command.CommandType = CommandType.StoredProcedure;

                    OracleParameter[] parameters = new OracleParameter[5];

                    command.Parameters.Add(new OracleParameter("p_ruc", OracleDbType.Varchar2, entidades.Ruc, ParameterDirection.Input));
                    command.Parameters.Add(new OracleParameter("p_razonsocial", OracleDbType.Varchar2, entidades.RazonSocial, ParameterDirection.Input));
                    command.Parameters.Add(new OracleParameter("p_telefono", OracleDbType.Varchar2, entidades.Telefono, ParameterDirection.Input));
                    command.Parameters.Add(new OracleParameter("p_contacto", OracleDbType.Varchar2, entidades.Contacto, ParameterDirection.Input));
                    command.Parameters.Add(new OracleParameter("o_resultado", OracleDbType.Int32, ParameterDirection.Output));
                    connection.Open();

                    command.ExecuteScalar();

                    if (!string.IsNullOrEmpty(command.Parameters["o_resultado"].Value.ToString()))
                        return true;
                    else
                        return false;
                }
            }
        }

        public DataTable CargaDatosSedes(string id)
        {
            OracleConnection conexion = new OracleConnection();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            try
            {
                using (OracleConnection connection = new OracleConnection(Conexion.ObtenerConexion()))
                {
                    using (OracleCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "PKG_SEDES.PROC_BUSCAR_SEDES";
                        command.CommandType = CommandType.StoredProcedure;

                        OracleParameter[] parameters = new OracleParameter[1];

                        command.Parameters.Add(new OracleParameter("p_codcliente", OracleDbType.Varchar2, id, ParameterDirection.Input));
                        command.Parameters.Add(new OracleParameter("o_ListaSedes", OracleDbType.RefCursor, DBNull.Value, ParameterDirection.Output));
                        connection.Open();

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            dt.Load(reader);
                            return dt;
                        }
                    }
                }
            }
            catch (OracleException ex)
            {
                /* SI ALCANZA TIEMPO ME FALTA CREAR METODO QUE GUARDE UN LOG EN ARCHIVO DE TEXTO */
                return null;
            }
            catch (Exception ex)
            {
                /* SI ALCANZA TIEMPO ME FALTA CREAR METODO QUE GUARDE UN LOG EN ARCHIVO DE TEXTO */
                return null;
            }
            finally
            {
                conexion.Close();
            }
        }

        public bool EliminarSede(string id)
        {
            using (OracleConnection connection = new OracleConnection(Conexion.ObtenerConexion()))
            {

                using (OracleCommand command = connection.CreateCommand())
                {
                    command.CommandText = "PKG_SEDES.PROC_ELIMINAR_SEDE";
                    command.CommandType = CommandType.StoredProcedure;

                    OracleParameter[] parameters = new OracleParameter[2];

                    command.Parameters.Add(new OracleParameter("p_codsede", OracleDbType.Varchar2, id, ParameterDirection.Input));
                    command.Parameters.Add(new OracleParameter("o_resultado", OracleDbType.Int32, ParameterDirection.Output));

                    connection.Open();

                    command.ExecuteScalar();

                    if (!string.IsNullOrEmpty(command.Parameters["o_resultado"].Value.ToString()))
                        return true;
                    else
                        return false;
                }
            }
        }
        
        public bool ActualizarSede(Entidades entidades)
        {
            using (OracleConnection connection = new OracleConnection(Conexion.ObtenerConexion()))
            {

                using (OracleCommand command = connection.CreateCommand())
                {
                    command.CommandText = "PKG_SEDES.PROC_ACTUALIZAR_SEDE";
                    command.CommandType = CommandType.StoredProcedure;

                    OracleParameter[] parameters = new OracleParameter[6];

                    command.Parameters.Add(new OracleParameter("p_codsede", OracleDbType.Varchar2, entidades.CodSede, ParameterDirection.Input));
                    command.Parameters.Add(new OracleParameter("p_pais", OracleDbType.Varchar2, entidades.Pais, ParameterDirection.Input));
                    command.Parameters.Add(new OracleParameter("p_departamento", OracleDbType.Varchar2, entidades.Departamento, ParameterDirection.Input));
                    command.Parameters.Add(new OracleParameter("p_direccion", OracleDbType.Varchar2, entidades.Direccion, ParameterDirection.Input));
                    command.Parameters.Add(new OracleParameter("p_telefono", OracleDbType.Varchar2, entidades.TelefonoSede, ParameterDirection.Input));
                    command.Parameters.Add(new OracleParameter("p_contacto", OracleDbType.Varchar2, entidades.ContactoSede, ParameterDirection.Input));
                    command.Parameters.Add(new OracleParameter("o_resultado", OracleDbType.Int32, ParameterDirection.Output));

                    connection.Open();

                    command.ExecuteScalar();

                    if (!string.IsNullOrEmpty(command.Parameters["o_resultado"].Value.ToString()))
                        return true;
                    else
                        return false;
                }
            }
        }

        public bool RegistrarSede(Entidades entidades)
        {
            using (OracleConnection connection = new OracleConnection(Conexion.ObtenerConexion()))
            {

                using (OracleCommand command = connection.CreateCommand())
                {
                    command.CommandText = "PKG_SEDES.PROC_REGISTRAR_SEDE";
                    command.CommandType = CommandType.StoredProcedure;

                    OracleParameter[] parameters = new OracleParameter[5];

                    command.Parameters.Add(new OracleParameter("p_codcliente", OracleDbType.Varchar2, entidades.CodCliente, ParameterDirection.Input));
                    command.Parameters.Add(new OracleParameter("p_pais", OracleDbType.Varchar2, entidades.Pais, ParameterDirection.Input));
                    command.Parameters.Add(new OracleParameter("p_departamento", OracleDbType.Varchar2, entidades.Departamento, ParameterDirection.Input));
                    command.Parameters.Add(new OracleParameter("p_direccion", OracleDbType.Varchar2, entidades.Direccion, ParameterDirection.Input));
                    command.Parameters.Add(new OracleParameter("p_telefono", OracleDbType.Varchar2, entidades.TelefonoSede, ParameterDirection.Input));
                    command.Parameters.Add(new OracleParameter("p_contacto", OracleDbType.Varchar2, entidades.ContactoSede, ParameterDirection.Input));
                    command.Parameters.Add(new OracleParameter("o_resultado", OracleDbType.Int32, ParameterDirection.Output));
                    connection.Open();

                    command.ExecuteScalar();

                    if (!string.IsNullOrEmpty(command.Parameters["o_resultado"].Value.ToString()))
                        return true;
                    else
                        return false;
                }
            }
        }
    }
}