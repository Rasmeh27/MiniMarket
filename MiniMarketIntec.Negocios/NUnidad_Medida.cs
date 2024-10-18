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
    public class NUnidad_Medida
    {
        //Registrar o Editar una Unidad de Medida
        public static string RegistrarUM(int opcion, int codigo, string descripcion,string abreviatura)
        {
            //instanciar un objeto de la capa de acceso a datos
            DUnidad_Medida datos = new DUnidad_Medida();
            //crear la entidad unidad de medida
            Unidad_Medida um = new Unidad_Medida();
            //inicializamos los atributos
            um.Codigo_UM = codigo;
            um.Descripcion_UM = descripcion;
            um.Abreviatura_UM = abreviatura;
            //registrar o editar la unidad de medida
            return datos.RegistrarUM(opcion, um);
        }

        //listar las unidades de medida
        public static DataTable ListarUM(string valor)
        {
            //instanciar la capa de acceso a datos
            DUnidad_Medida datos = new DUnidad_Medida();
            //listar las unidades de medida
            return datos.ListarUM(valor);
        }

        //determianr si una unidad de medida existe
        public static string Existe(string valor)
        {
            //instanciar la capa de acceso a datos
            DUnidad_Medida datos = new DUnidad_Medida();
            return datos.Existe(valor);
        }

        //desactivar una unidad de medida
        public static string Desactivar(int id)
        {
            //instanciar la capa de acceso a datos
            DUnidad_Medida datos = new DUnidad_Medida();
            return datos.Desactivar(id);
        }
        public static DataTable Seleccionar(string valor)
        {
            // Instanciar la capa de acceso a datos
            DUnidad_Medida datos = new DUnidad_Medida();
            // Listar unidades de medida
            return datos.Seleccionar(valor);
        }
    }
}
