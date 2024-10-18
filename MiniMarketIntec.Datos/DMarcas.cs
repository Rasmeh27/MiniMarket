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
    public class DMarcas
    {
       
            //Registrar o editar una categoria
            public string RegistrarMarca(int opcion, Marcas marca)
            {
                //Obtener la cadena de conexion a la base de datos
                SqlConnection sqlConn = new SqlConnection();
                //Variable para almacenar la respuesta del emtodo a devolver
                string Respuesta = "";

                //vamos a tratar de abrir una conexion y ejecutra un procedimiento almacenado
                try
                {
                    //obtener la cadena de conexion
                    sqlConn = Conexion.getInstancia().CrearConexion();
                    //Debemos configurar el comando que vamos a mandar
                    SqlCommand Comando = new SqlCommand("SP_Registrar_Marca", sqlConn);
                    //debemos decirle que es un procedmiento almancenado
                    Comando.CommandType = CommandType.StoredProcedure;
                    //indicamos los parametros que requieren el procedimiento almacenado
                    Comando.Parameters.Add("@opcion", SqlDbType.Int).Value = opcion;
                    Comando.Parameters.Add("@codigo_alm", SqlDbType.Int).Value = marca.Codigo_Marca;
                    Comando.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = marca.Descripicion_Marca;
                    //abrir la conexion
                    sqlConn.Open();
                    //ejecutamos el comando
                    Respuesta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo ingresar el registro"; //en ado .net
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

            //Listar las categorias
            public DataTable ListarMarcas(string NombreMarca)
            {
                //Obtener la cadena de conexion a la base de datos
                SqlConnection sqlConn = new SqlConnection();
                //Data TABLE
                DataTable Tabla = new DataTable();
                //Objeto DataReader paar extraer la informacion de una tabla en BD
                SqlDataReader Resultado;

                //vamos a tratar de abrir una conexion y ejecutra un procedimiento almacenado
                try
                {
                    //obtener la cadena de conexion
                    sqlConn = Conexion.getInstancia().CrearConexion();
                    //Debemos configurar el comando que vamos a mandar
                    SqlCommand Comando = new SqlCommand("SP_Listar_Marcas", sqlConn);
                    //debemos decirle que es un procedmiento almancenado
                    Comando.CommandType = CommandType.StoredProcedure;
                    //indicamos los parametros que requieren el procedimiento almacenado
                    Comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = NombreMarca;

                    //abrir la conexion
                    sqlConn.Open();
                    //ejecutamos el comando
                    Resultado = Comando.ExecuteReader();
                    //debemmos convertirlo a un DataTable, es lo que puede manejar C#
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

            //determinar si una categoria existe
            public string Existe(string NombreMarca) //es stiring  porque recibe un valor string
            {
                //Obtener la cadena de conexion a la base de datos
                SqlConnection sqlConn = new SqlConnection();
                //Variable para almacenar la respuesta del emtodo a devolver
                string Respuesta = "";

                //vamos a tratar de abrir una conexion y ejecutra un procedimiento almacenado
                try
                {
                    //obtener la cadena de conexion
                    sqlConn = Conexion.getInstancia().CrearConexion();
                    //Debemos configurar el comando que vamos a mandar
                    SqlCommand Comando = new SqlCommand("SP_Existe_Marca", sqlConn);
                    //debemos decirle que es un procedmiento almancenado
                    Comando.CommandType = CommandType.StoredProcedure;
                    //indicamos los parametros que requieren el procedimiento almacenado
                    Comando.Parameters.Add("@valor", SqlDbType.Int).Value = NombreMarca;
                    //creamos un parametro de salida, porque SP lo reuiqeere
                    SqlParameter existe = new SqlParameter();
                    // configurar ese parametro
                    existe.ParameterName = "@existe";
                    existe.SqlDbType = SqlDbType.Int;
                    existe.Direction = ParameterDirection.Output;
                    Comando.Parameters.Add(existe);

                    //abrir la conexion
                    sqlConn.Open();
                    //ejecutamos el comando
                    Comando.ExecuteNonQuery();
                    Respuesta = Convert.ToString(existe.Value);
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

            //desactivar (eliminar para fines del usuario) una categoria
            public string Desactivar(int id)
            {
                //Obtener la cadena de conexion a la base de datos
                SqlConnection sqlConn = new SqlConnection();
                //Variable para almacenar la respuesta del emtodo a devolver
                string Respuesta = "";

                //vamos a tratar de abrir una conexion y ejecutra un procedimiento almacenado
                try
                {
                    //obtener la cadena de conexion
                    sqlConn = Conexion.getInstancia().CrearConexion();
                    //Debemos configurar el comando que vamos a mandar
                    SqlCommand Comando = new SqlCommand("SP_Desactivar_Marca", sqlConn);
                    //debemos decirle que es un procedmiento almancenado
                    Comando.CommandType = CommandType.StoredProcedure;
                    //indicamos los parametros que requieren el procedimiento almacenado
                    Comando.Parameters.Add("@codigo_marca", SqlDbType.Int).Value = id;

                    //abrir la conexion
                    sqlConn.Open();
                    //ejecutamos el comando
                    Respuesta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo desactivar el registro"; //en ado .net
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



