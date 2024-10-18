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
    public class NUnidadesDeMedidas
    {
        //Registrar o Editar una Unidad de Medida
        public static string RegistrarUM(int opcion, int codigo, string descripcion, string abreviatura)
        {
            //instanciar un objeto de la capa de acceso a datos
            DUnidadesDeMedidas datos = new DUnidadesDeMedidas();
            //crear la entidad cunidad de medida
            UnidadesDeMedidas um = new UnidadesDeMedidas();
            //inicializamos los atributos
            um.Codigo_um = codigo;
            um.Descripcion_um = descripcion;
            um.Abreviatura_um = abreviatura;
            //registrar o editar la unidad de medida
            return datos.RegistrarUM(opcion, um);
        }

        //listar las unidades de medida
        public static DataTable ListarUM(string valor)
        {
            //instanciar la capa de acceso a datos
            DUnidadesDeMedidas datos = new DUnidadesDeMedidas();
            //listar las unidades de medida
            return datos.ListarUM(valor);
        }

        //determianr si una unidad de medida existe
        public static string Existe(string valor)
        {
            //instanciar la capa de acceso a datos
            DUnidadesDeMedidas datos = new DUnidadesDeMedidas();
            return datos.Existe(valor);
        }

        //desactivar una unidad de medida
        public static string Desactivar(int id)
        {
            //instanciar la capa de acceso a datos
            DUnidadesDeMedidas datos = new DUnidadesDeMedidas();
            return datos.Desactivar(id);
        }
    }
}
