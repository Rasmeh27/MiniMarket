using MiniMarketIntec.Datos;
using MiniMarketIntec.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMarketIntec.Negocio
{
    public class NProveedor
    {
        //Listar proveedores
        public static DataTable ListarProveedores(string valor)
        {
            DProveedor datos = new DProveedor();
            return datos.ListarProveedores(valor);
        }




        //Registrar o Editar un proveedor
        public static string RegistrarProveedor(int opcion, int codigoProveedor, int codigoTipoDocumento, string numeroDocumentoProveedor, string razonSocial, string nombres, string apellidos,
            int codigoSexo, int codigoRubro, string emailProveedor, string telefonoProveedor, string movilProveedor, string direccion, int codigoMunicipio, string comentarios)
        {
            DProveedor datos = new DProveedor();
            Proveedor proveedor = new Proveedor();

            proveedor.CodigoProveedor = codigoProveedor;
            proveedor.CoditoTipoDocumentoProveedorCliente = codigoTipoDocumento;
            proveedor.NumeroDocumentoProveedor = numeroDocumentoProveedor;
            proveedor.RazonSocialProveedor = razonSocial;
            proveedor.NombresProveedor = nombres;
            proveedor.ApellidosProveedor = apellidos;
            proveedor.CodigoSexoProveedor = codigoSexo;
            proveedor.CodigoRubro = codigoRubro;
            proveedor.EmailProveedor = emailProveedor;
            proveedor.TelefonoProveedor = telefonoProveedor;
            proveedor.MovilProveedor = movilProveedor;
            proveedor.DireccionProveedor = direccion;
            proveedor.CodigoMunicipio = codigoMunicipio;
            proveedor.Comentarios = comentarios;

            return datos.RegistrarProveedor(opcion, proveedor);
        }

        //Desactivar (eliminar) un proveedor
        public static string Desactivar(int Id)
        {
            DProveedor Datos = new DProveedor();
            return Datos.Desactivar(Id);
        }

        //Determinar si un proveedor existe
        public static string Existe(string valor)
        {
            DProveedor datos = new DProveedor();
            return datos.Existe(valor);
        }


        //listar tipos de documentos del proveedor y cliente en el combobox
        public static DataTable ListarTipoDocPC()
        {
            DProveedor Datos = new DProveedor();
            return Datos.ListarTipoDocPC();
        }

        //listar sexos en el combobox
        public static DataTable ListarSexos()
        {
            DProveedor Datos = new DProveedor();
            return Datos.ListarSexos();
        }

        //listar rubros en el combobox
        public static DataTable ListarRubros()
        {
            DProveedor Datos = new DProveedor();
            return Datos.ListarRubros();
        }

        //cargar paises,provincias,distritos textbox
        public static DataTable ListarPaisesProvinciasDistritos(string valor)
        {
            DProveedor Datos = new DProveedor();
            return Datos.ListarPaisesProvinciasDistritos(valor);
        }


    }
}

