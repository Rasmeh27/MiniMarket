using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniMarketIntec.Datos
{
    public class Conexion
    {
        private string Base;
        private string Servidor;
        private string Usuario;
        private string Clave;
        private bool Seguridad;
        private static Conexion Con = null;

        // Constructor privado para Singleton
        private Conexion()
        {
            this.Base = "db_minimarketIntec";
            this.Servidor = "localHost";
            this.Usuario = "";
            this.Clave = ""; // Agrega la contraseña de 'sa' si es necesaria
            this.Seguridad = true; // Cambiar a 'false' si se va a usar autenticación SQL
            //MessageBox.Show("Se ha conectado correctamente");
            
        }

        // Método para crear la conexión a la base de datos
        public SqlConnection CrearConexion()
        {
            SqlConnection Cadena = new SqlConnection();
            try
            {
                // Construir la cadena de conexión
                if (this.Seguridad)
                {
                    // Si usa autenticación integrada (Windows)
                    Cadena.ConnectionString = "Server=" + this.Servidor + "; Database=" + this.Base + "; Trusted_Connection=True;";
                }
                else
                {
                    // Si usa autenticación SQL Server (usuario y contraseña)
                    Cadena.ConnectionString = "Server=" + this.Servidor + "; Database=" + this.Base + "; User Id=" + this.Usuario + "; Password=" + this.Clave + ";";
                }
            }
            catch (Exception ex)
            {
                Cadena = null;
                throw new Exception("Error al intentar conectar a la base de datos", ex);
            }
            return Cadena;
        }

        // Método para obtener la instancia de la conexión (Patrón Singleton)
        public static Conexion getInstancia()
        {
            if (Con == null)
            {
                Con = new Conexion();
            }
            return Con;
        }
    }
}
