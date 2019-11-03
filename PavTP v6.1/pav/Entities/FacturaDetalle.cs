using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pav.Entities
{
    public class FacturaDetalle
    {
        public int IdFacturaDetalle { get; set; }
        public int IdFactura { get; set; }
        public int NroItem { get; set; }
        public Articulo Articulo { get; set; }
        public Double PrecioUnitario { get; set; }
        public int Cantidad { get; set; }

        public int IdArticulo
        {
            get
            {
                return Articulo.IdArticulo;
            }
        }
        public string ArticuloDescripcion
        {
            get
            {
                return Articulo.Nombre;
            }
        }

        public Double Importe
        {
            get
            {
                return Cantidad * PrecioUnitario;
            }
        }
    }
}
