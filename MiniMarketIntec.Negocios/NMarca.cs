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
    public class NMarca
    {
        //Registrar o Editar una Marca
        public static string RegistrarMarca(int opcion, int codigo, string descripcion)
        {
            //instanciar un objeto de la capa de acceso a datos
            DMarca datos = new DMarca();
            //crear la entidad marca
            Marca marca = new Marca();
            //inicializamos los atributos
            marca.Codigo_Marca = codigo;
            marca.Descripcion_Marca = descripcion;
            //registrar o editar la marca
            return datos.RegistrarMarca(opcion, marca);
        }

        //listar las marcas
        public static DataTable ListarMarcas(string valor)
        {
            //instanciar la capa de acceso a datos
            DMarca datos = new DMarca();
            //listar las categorias
            return datos.ListarMarcas(valor);
        }

        //determianr si una marca existe
        public static string Existe(string valor)
        {
            //instanciar la capa de acceso a datos
            DMarca datos = new DMarca();
            return datos.Existe(valor);
        }

        //desactivar una marca
        public static string Desactivar(int id)
        {
            //instanciar la capa de acceso a datos
            DMarca datos = new DMarca();
            return datos.Desactivar(id);
        }

        public static DataTable Seleccionar(string valor)
        {
            //instanciar la capa de acceso a datos
            DMarca datos = new DMarca();
            //listar las categorias
            return datos.Seleccionar(valor);
        }
    }
}
