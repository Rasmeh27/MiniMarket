using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMarketIntec.Entidad
{
    public class Provincia
    {
        public int Codigo_Provincia { get; set; }
        public int CodigoPais { get; set; }
        public string Descripcion_Provincia { get; set; }
        public bool Estado { get; set; }
    }
}