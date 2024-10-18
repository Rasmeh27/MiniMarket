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
    public class NPais
    {


        public static string RegistrarPais(int opcion, int codigo, string descripcion)
        {
            //instanciar un objeto de la capa de acceso a datos
            DPais datos = new DPais();
            //crear entidad de marcas
            Pais pais = new Pais();
            //inicializamos los atributos 
            pais.Codigo_Pais = codigo;
            pais.descripcion_pais = descripcion;

            //registrar o editar la marca
            return datos.RegistrarPais(opcion, pais);
        }
        //listar categoorias
        public static DataTable ListarPaises(string valor)
        {
            //instanciar la capa de acceso a datos
            DPais datos = new DPais();
            //listar categorias
            return datos.ListarPaises(valor);

        }
        //determinar si almacen existe
        public static string Existe(string valor)
        {
            //instanciar la capa de acceso a datos
            DPais datos = new DPais();
            return datos.Existe(valor);
        }
        //desactivar un almacen
        public static string Desactivar(int id)
        {
            DPais datos = new DPais();
            return datos.Desactivar(id);
        }

        public static DataTable Seleccionar(string nombrepais)
        {
            DPais datos = new DPais();
            return datos.Seleccionar(nombrepais);
        }


    }
}