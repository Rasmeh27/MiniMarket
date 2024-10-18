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
    public class NMarcas
    {
        //registrar o editar una categoria
        public static string RegistrarMarcas(int opcion, int codigo, string descripcion)
        {
            //instanciar un objeto de la capa de acceso a datos
            DMarcas datos = new DMarcas();
            //crear entidad de categoria
            Marcas marca = new Marcas();
            //inicializamos los atributos - los objetos tienen los atributos vacios
            marca.Codigo_Marca = codigo;
            marca.Descripicion_Marca= descripcion;

            //registrar o editar la categoria
            return datos.RegistrarMarca(opcion, marca);
        }

        //listar categoorias
        public static DataTable ListarMarcas(string valor)
        {
            //instanciar la capa de acceso a datos
            DMarcas datos = new DMarcas();
            //listar categorias
            return datos.ListarMarcas(valor);

        }
        //determinar si una categoria existe
        public static string Existe(string valor)
        {
            //instanciar la capa de acceso a datos
            DMarcas datos = new DMarcas();
            return datos.Existe(valor);
        }
        //desacrivar una categoria
        public static string Desactivar(int id)
        {
            //instanciar la capa de acceso a datos
            DMarcas datos = new DMarcas();
            return datos.Desactivar(id);
        }
    }
}
