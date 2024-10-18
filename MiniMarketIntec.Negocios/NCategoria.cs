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
    public class NCategoria
    {
        //Registrar o Editar una Categoria
        public static string RegistrarCategoria(int opcion, int codigo, string descripcion)
        {
            //instanciar un objeto de la capa de acceso a datos
            DCategoria datos = new DCategoria();
            //crear la entidad categoria
            Categoria categoria = new Categoria();
            //inicializamos los atributos
            categoria.Codigo_Cat = codigo;
            categoria.Descripcion_Cat = descripcion;
            //registrar o editar la categoria
             return datos.RegistrarCategoria(opcion, categoria);
        }

        //listar las categorias
        public static DataTable ListarCategorias(string valor)
        {
            //instanciar la capa de acceso a datos
            DCategoria datos = new DCategoria();
            //listar las categorias
            return datos.ListarCategorias(valor);
        }

        //determianr si una categoria existe
        public static string Existe(string valor) 
        {
            //instanciar la capa de acceso a datos
            DCategoria datos = new DCategoria();
            return datos.Existe(valor);
        }

        //desactivar una categoria
        public static string Desactivar(int id)
        {
            //instanciar la capa de acceso a datos
            DCategoria datos = new DCategoria();
            return datos.Desactivar(id);
        }
        public static object Seleccionar()
        {
            //instanciar la capa de acceso a datos
            DCategoria datos = new DCategoria();
            //listar las categorias
            return datos.Seleccionar();
        }
    }
}
