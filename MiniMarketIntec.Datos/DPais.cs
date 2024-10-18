using MiniMarketIntec.Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMarketIntec.Datos
{
    public class DPais
    {
        public string RegistrarPais(int opcion, Pais pais)
        {
            string Respuesta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();

                SqlCommand Comando = new SqlCommand("SP_Registrar_Pais", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@opcion", SqlDbType.Int).Value = opcion;
                Comando.Parameters.Add("@codigo_pais", SqlDbType.Int).Value = pais.Codigo_Pais;
                Comando.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = pais.descripcion_pais;
                SqlCon.Open();
                Respuesta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo ingresar el registro";

            }
            catch (Exception ex)
            {
                Respuesta = ex.Message;
                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return Respuesta;
        }

        //listar las marcas
        public DataTable ListarPaises(string nombrePais)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("SP_Listar_Paises", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = nombrePais;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }

        //Desactivar una marca
        public string Desactivar(int codigoPais)
        {
            string respuesta = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();  // Crear la conexión
                sqlCon.Open();

                // Configurar el comando para ejecutar el procedimiento almacenado
                SqlCommand comando = new SqlCommand("SP_Desactivar_Pais", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;

                // Agregar el parámetro requerido por el procedimiento
                comando.Parameters.Add("@codigo_pais", SqlDbType.Int).Value = codigoPais;

                // Ejecutar el procedimiento almacenado
                respuesta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo desactivar el país.";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message; // Capturar cualquier error
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close(); // Asegurarse de cerrar la conexión
            }

            return respuesta; // Devolver la respuesta
        }


        //Determinar si una marca existe
        public string Existe(string Valor)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("SP_Existe_Pais", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = Valor;
                SqlParameter ParExiste = new SqlParameter();
                ParExiste.ParameterName = "@existe";
                ParExiste.SqlDbType = SqlDbType.Int;
                ParExiste.Direction = ParameterDirection.Output;
                Comando.Parameters.Add(ParExiste);
                SqlCon.Open();
                Comando.ExecuteNonQuery();
                Rpta = Convert.ToString(ParExiste.Value);
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }

        public DataTable Seleccionar(string nombrePais)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("SP_Paises_Seleccionar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }


    }


}