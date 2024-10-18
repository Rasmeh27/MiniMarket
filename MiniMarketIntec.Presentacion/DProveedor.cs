using Microsoft.Win32;
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
    public class DProveedor
    {
        //registrar un proveedor
        public string RegistrarProveedor(int opcion, Proveedor proveedor)
        {
            string Respuesta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();

                SqlCommand Comando = new SqlCommand("SP_Registrar_Proveedor", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@opcion", SqlDbType.Int).Value = opcion;
                Comando.Parameters.Add("@codigo_proveedor", SqlDbType.Int).Value = proveedor.CodigoProveedor;
                Comando.Parameters.Add("@codigo_tipo_doc_pc", SqlDbType.Int).Value = proveedor.CoditoTipoDocumentoProveedorCliente;
                Comando.Parameters.Add("@numero_doc_proveedor", SqlDbType.VarChar).Value = proveedor.NumeroDocumentoProveedor;
                Comando.Parameters.Add("@razon_social", SqlDbType.VarChar).Value = proveedor.RazonSocialProveedor;
                Comando.Parameters.Add("@nombres", SqlDbType.VarChar).Value = proveedor.NombresProveedor;
                Comando.Parameters.Add("@apellidos", SqlDbType.VarChar).Value = proveedor.ApellidosProveedor;
                Comando.Parameters.Add("@codigo_sexo", SqlDbType.Int).Value = proveedor.CodigoSexoProveedor;
                Comando.Parameters.Add("@codigo_ru", SqlDbType.Int).Value = proveedor.CodigoRubro;
                Comando.Parameters.Add("@email_proveedor", SqlDbType.VarChar).Value = proveedor.EmailProveedor;
                Comando.Parameters.Add("@telefono_proveedor", SqlDbType.VarChar).Value = proveedor.TelefonoProveedor;
                Comando.Parameters.Add("@movil_proveedor", SqlDbType.VarChar).Value = proveedor.MovilProveedor;
                Comando.Parameters.Add("@direccion", SqlDbType.Text).Value = proveedor.DireccionProveedor;
                Comando.Parameters.Add("@codigo_distrito", SqlDbType.Int).Value = proveedor.CodigoMunicipio;
                Comando.Parameters.Add("@comentarios", SqlDbType.Text).Value = proveedor.Comentarios;
                SqlCon.Open();
                Respuesta = Comando.ExecuteNonQuery() >= 1 ? "OK" : "No se pudo ingresar el registro";

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


        //listar los proveedores
        public DataTable ListarProveedores(string valor)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("SP_Listar_Proveedores", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = valor;
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


        //Desactivar un proveedor
        public string Desactivar(int Id)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("SP_Desactivar_Proveedor", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@codigo_proveedor", SqlDbType.Int).Value = Id;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo desactivar el registro";
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

        //Determinar si un proveedor existe
        public string Existe(string Valor)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("SP_Existe_Proveedor", SqlCon);
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

        //traer los tipos de documentos de Proveedor y Cliente para cargar en el combobox
        public DataTable ListarTipoDocPC()  
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("SP_Listado_Tipo_Doc_PC", SqlCon);
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

        //traer los sexos para cargar en el combobox
        public DataTable ListarSexos()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("SP_Listado_Sexo", SqlCon);
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

        //traer los rubros para cargar en el combobox
        public DataTable ListarRubros()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("SP_Listado_Rubros", SqlCon);
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


        //traer los distritos, provincias y paisds para cargar en el txt
        public DataTable ListarPaisesProvinciasDistritos(string valor)  
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("SP_Paises_Provincias_Distritos", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = valor;
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
