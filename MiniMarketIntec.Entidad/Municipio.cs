using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMarketIntec.Entidad
{
    public class Municipio
    {
        public int Codigo_municipio { get; set; }
        public int CodigoProvincia { get; set; }
        public string Descripcion_municipio { get; set; }
        public bool Estado { get; set; }
    }
}
