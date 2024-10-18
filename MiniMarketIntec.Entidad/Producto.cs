using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMarketIntec.Entidad
{
    public class Producto
    {
        public int CodigoProducto { get; set; }
        public string DescripcionProducto { get; set; }
        public int CodigoMarca { get; set; }
        public int CodigoUnidadMedida { get; set; }
        public int CodigoCategoria { get; set; }
        public decimal StockMinimo { get; set; }
        public decimal StockMaximo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public bool Estado { get; set; }

    }
}