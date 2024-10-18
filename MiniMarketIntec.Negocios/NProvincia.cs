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
    public class NProvincia
    {
        // Método para registrar o editar provincias
        public static string RegistrarProvincias(int opcion, int codigo, int codigoPais, string descripcion)
        {
            // Instanciar un objeto de la capa de acceso a datos
            DProvincia datos = new DProvincia();
            // Crear entidad de provincias
            Provincia provincia = new Provincia
            {
                Codigo_Provincia = codigo,
                CodigoPais = codigoPais,  // Incluimos el código de país
                Descripcion_Provincia = descripcion
            };

            // Registrar o editar la provincia
            return datos.RegistrarProvincia(opcion, provincia);
        }

        // Listar provincias
        public static DataTable ListarProvincias(string valor)
        {
            // Instanciar la capa de acceso a datos
            DProvincia datos = new DProvincia();
            // Listar provincias
            return datos.ListarProvincias(valor);
        }

        // Determinar si la provincia existe
        public static string Existe(string valor)
        {
            // Instanciar la capa de acceso a datos
            DProvincia datos = new DProvincia();
            return datos.Existe(valor);
        }

        // Desactivar una provincia
        public static string Desactivar(int id)
        {
            // Instanciar la capa de acceso a datos
            DProvincia datos = new DProvincia();
            return datos.Desactivar(id);
        }
        public static DataTable Seleccionar(string paisprovincia)
        {
            DProvincia datos = new DProvincia();
            return datos.Seleccionar(paisprovincia);
        }
    }
}
