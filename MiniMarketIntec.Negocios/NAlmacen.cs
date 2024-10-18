using Microsoft.Win32;
using MiniMarketIntec.Datos;
using MiniMarketIntec.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMarketIntec.Negocios
{
    public class NAlmacen
    {
        //Registrar o Editar una Almacen
        public static string RegistrarAlmacen(int opcion, int codigo, string descripcion)
        {
            //instanciar un objeto de la capa de acceso a datos
            DAlmacen datos = new DAlmacen();
            //crear la entidad almacen
            Almacen almacen = new Almacen();
            //inicializamos los atributos
            almacen.CodigoAlmacen = codigo;
            almacen.DescripcionAlmacen = descripcion;
            //registrar o editar la marca
            return datos.RegistrarAlmacen(opcion, almacen);
        }

        //listar los almacenes
        public static DataTable ListarAlmacenes(string valor)
        {
            //instanciar la capa de acceso a datos
            DAlmacen datos = new DAlmacen();
            //listar los almacenes
            return datos.ListarAlmacenes(valor);
        }

        //determianr si una marca existe
        public static string Existe(string valor)
        {
            //instanciar la capa de acceso a datos
            DAlmacen datos = new DAlmacen();
            return datos.Existe(valor);
        }

        //desactivar una marca
        public static string Desactivar(int id)
        {
            //instanciar la capa de acceso a datos
            DAlmacen datos = new DAlmacen();
            return datos.Desactivar(id);
        }
    }
}
