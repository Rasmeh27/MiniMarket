using MiniMarketIntec.Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniMarketIntec.Datos
{
    public class DAlmacen
    {
        public string RegistrarAlmacen(int opcion, Almacen almacen)
        {
            //Obtener la cadena de conexion a la base de datos
            SqlConnection sqlConn = new SqlConnection();
            //Variable para almacenar la respuesta que el metodo va a devolver
            string Respuesta = "";

            //vamos a tratar de abrir una conexion y ejecutar un procedimiento almacenado
            try
            {
                //obtener la cadena de conexion
                sqlConn = Conexion.getInstancia().CrearConexion();
                //Debemos configurar el comando
                SqlCommand Comando = new SqlCommand("SP_Registrar_Almacenes", sqlConn);
                //debemos decirle que es un procedimiento almacenado
                Comando.CommandType = System.Data.CommandType.StoredProcedure;
                //indicamos los parametros que requiere el procedimiento almacenado
                Comando.Parameters.Add("@opcion", SqlDbType.Int).Value = opcion;
                Comando.Parameters.Add("@codigo_alm", SqlDbType.Int).Value = almacen.CodigoAlmacen;
                Comando.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = almacen.DescripcionAlmacen;
                //abrir la conexion
                sqlConn.Open();
                //ejecutamos el comando
                Respuesta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo ingresar el registro";
            }
            catch (Exception ex)
            {

                Respuesta = ex.Message; //si hubo un error, lo devolvemos
            }
            finally
            {
                //cerramos la conexion a la base de datos
                if (sqlConn.State == ConnectionState.Open)
                {
                    sqlConn.Close();
                }
            }
            return Respuesta; //devolvemos el texto con la respuesta
        }

        //Listar los almacenes
        public DataTable ListarAlmacenes(string nombreAlmacen)
        {
            //Obtener la cadena de conexion a la base de datos
            SqlConnection sqlConn = new SqlConnection();
            //Variable para almacenar la respuesta que el metodo va a devolver
            DataTable Tabla = new DataTable();
            //Objeto DataReader para extraer la informacion de una tabla en una BD
            SqlDataReader Resultado;


            //vamos a tratar de abrir una conexion y ejecutar un procedimiento almacenado
            try
            {
                //obtener la cadena de conexion
                sqlConn = Conexion.getInstancia().CrearConexion();
                //Debemos configurar el comando
                SqlCommand Comando = new SqlCommand("SP_Listar_Almacenes", sqlConn);
                //debemos decirle que es un procedimiento almacenado
                Comando.CommandType = System.Data.CommandType.StoredProcedure;
                //indicamos los parametros que requiere el procedimiento almacenado
                Comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = nombreAlmacen;
                //abrir la conexion
                sqlConn.Open();
                //ejecutamos el comando
                Resultado = Comando.ExecuteReader();
                //debemos convertirlo a un DataTable - es lo que puede manejar C#
                Tabla.Load(Resultado);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message); //si hubo un error, lo devolvemos
            }
            finally
            {
                //cerramos la conexion a la base de datos
                if (sqlConn.State == ConnectionState.Open)
                {
                    sqlConn.Close();
                }
            }
            return Tabla; //devolvemos la tabla como un DataTable
        }

        //Determinar si una marca existe
        public string Existe(string nombreAlmacen)
        {
            //Obtener la cadena de conexion a la base de datos
            SqlConnection sqlConn = new SqlConnection();
            //Variable para almacenar la respuesta que el metodo va a devolver
            string Respuesta = "";

            //vamos a tratar de abrir una conexion y ejecutar un procedimiento almacenado
            try
            {
                //obtener la cadena de conexion
                sqlConn = Conexion.getInstancia().CrearConexion();
                //Debemos configurar el comando
                SqlCommand Comando = new SqlCommand("SP_Existe_Almacen", sqlConn);
                //debemos decirle que es un procedimiento almacenado
                Comando.CommandType = System.Data.CommandType.StoredProcedure;
                //indicamos los parametros que requiere el procedimiento almacenado
                Comando.Parameters.Add("@valor", SqlDbType.Int).Value = nombreAlmacen;
                //creamos un parametro de salida, porque el SP lo requiere
                SqlParameter existe = new SqlParameter();
                //configurar ese parametro
                existe.ParameterName = "@existe";
                existe.SqlDbType = SqlDbType.Int;
                existe.Direction = ParameterDirection.Output;
                Comando.Parameters.Add(existe);
                //abrir la conexion
                sqlConn.Open();
                //ejecutamos el comando
                Comando.ExecuteNonQuery();
                Respuesta = Convert.ToString(existe);
            }
            catch (Exception ex)
            {

                Respuesta = ex.Message; //si hubo un error, lo devolvemos
            }
            finally
            {
                //cerramos la conexion a la base de datos
                if (sqlConn.State == ConnectionState.Open)
                {
                    sqlConn.Close();
                }
            }
            return Respuesta; //devolvemos el texto con la respuesta
        }

        //Desactivar (eliminar para fines del usuario) una marca
        public string Desactivar(int id)
        {
            //Obtener la cadena de conexion a la base de datos
            SqlConnection sqlConn = new SqlConnection();
            //Variable para almacenar la respuesta que el metodo va a devolver
            string Respuesta = "";

            //vamos a tratar de abrir una conexion y ejecutar un procedimiento almacenado
            try
            {
                //obtener la cadena de conexion
                sqlConn = Conexion.getInstancia().CrearConexion();
                //Debemos configurar el comando
                SqlCommand Comando = new SqlCommand("SP_Desactivar_Almacen", sqlConn);
                //debemos decirle que es un procedimiento almacenado
                Comando.CommandType = System.Data.CommandType.StoredProcedure;
                //indicamos los parametros que requiere el procedimiento almacenado
                Comando.Parameters.Add("@codigo_alm", SqlDbType.Int).Value = id;

                //abrir la conexion
                sqlConn.Open();
                //ejecutamos el comando
                Respuesta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo desactivar el registro";
            }
            catch (Exception ex)
            {

                Respuesta = ex.Message; //si hubo un error, lo devolvemos
            }
            finally
            {
                //cerramos la conexion a la base de datos
                if (sqlConn.State == ConnectionState.Open)
                {
                    sqlConn.Close();
                }
            }
            return Respuesta; //devolvemos el texto con la respuesta
        }
    }
}


