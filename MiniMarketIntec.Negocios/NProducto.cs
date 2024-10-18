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
    public class NProducto
    {
        // Método para registrar un producto
        public static string RegistrarProducto(
            int opcion,
            int codigoProducto,
            string descripcionProducto,
            int codigoMarca,
            int codigoUM,
            int codigoCategoria,
            decimal stockMinimo,
            decimal stockMaximo)
        {
            DProducto datos = new DProducto();
            Producto producto = new Producto
            {
                CodigoProducto = codigoProducto,
                DescripcionProducto = descripcionProducto,
                CodigoMarca = codigoMarca,
                CodigoUnidadMedida = codigoUM,
                CodigoCategoria = codigoCategoria,
                StockMinimo = stockMinimo,
                StockMaximo = stockMaximo
            };
            return datos.RegistrarProducto(opcion, producto);
        }

        // Método para listar productos
        public static DataTable ListarProductos(string valor)
        {
            DProducto datos = new DProducto();
            return datos.ListarProductos(valor);
        }

        // Método para listar el stock del almacén (el que necesitas)
        public static DataTable ListarStockAlmacen(int valor)
        {
            DProducto datos = new DProducto();
            return datos.ListarStockAlmacen(valor);
        }

        // Método para verificar si un producto existe
        public static string Existe(string valor)
        {
            DProducto datos = new DProducto();
            return datos.Existe(valor);
        }

        // Método para desactivar un producto
        public static string Desactivar(int id)
        {
            DProducto datos = new DProducto();
            return datos.Desactivar(id);
        }

        public static string RegistrarProducto(int opcionGuardar, int v1, string v2)
        {
            throw new NotImplementedException();
        }
    }
}
