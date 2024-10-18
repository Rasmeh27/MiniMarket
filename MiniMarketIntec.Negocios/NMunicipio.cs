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
    public class NMunicipio
    {
        public static string RegistrarMunicipio(int opcion, int codigoMunicipio, int codigoProvincia, string descripcion)
        {
            // Instanciar un objeto de la capa de acceso a datos
            DMunicipio datos = new DMunicipio();
            // Crear entidad de distritos
            Municipio municipio = new Municipio
            {
                Codigo_municipio = codigoMunicipio,
                CodigoProvincia = codigoProvincia,  // Incluimos el código de la provincia
                Descripcion_municipio = descripcion
            };

            // Registrar o editar el distrito
            return datos.RegistrarMunicipio(opcion, municipio);
        }

        //listar las marcas
        public static DataTable ListarMunicipios(string valor)
        {
            //instanciar la capa de acceso a datos
            DMunicipio datos = new DMunicipio();
            //listar las categorias
            return datos.ListarMunicipios(valor);
        }

        //determianr si una marca existe
        public static string Existe(string valor)
        {
            //instanciar la capa de acceso a datos
            DMunicipio datos = new DMunicipio();
            return datos.Existe(valor);
        }

        //desactivar una marca
        public static string Desactivar(int id)
        {
            //instanciar la capa de acceso a datos
            DMunicipio datos = new DMunicipio();
            return datos.Desactivar(id);
        }
    }
}
