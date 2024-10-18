using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniMarketIntec.Datos;
using MiniMarketIntec.Entidad;

namespace MiniMarketIntec.Negocios
{
    public class NRubro
    {
        public static string RegistrarRubros(int opcion, int codigo, string descripcion)
        {
            //instanciar un objeto de la capa de acceso a datos
            DRubro datos = new DRubro();
            //crear la entidad marca
            Rubro rubro = new Rubro();
            //inicializamos los atributos
            rubro.Codigo_rubro = codigo;
            rubro.Descripcion_rubro = descripcion;
            //registrar o editar la marca
            return datos.RegistrarRubro(opcion, rubro);
        }

        //listar las marcas
        public static DataTable ListarRubros(string valor)
        {
            //instanciar la capa de acceso a datos
            DRubro datos = new DRubro();
            //listar las categorias
            return datos.ListarRubros(valor);
        }

        //determianr si una marca existe
        public static string Existe(string valor)
        {
            //instanciar la capa de acceso a datos
            DRubro datos = new DRubro();
            return datos.Existe(valor);
        }

        //desactivar una marca
        public static string Desactivar(int id)
        {
            //instanciar la capa de acceso a datos
            DRubro datos = new DRubro();
            return datos.Desactivar(id);
        }
    }
}
