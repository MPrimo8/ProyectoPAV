using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pav.Entities
{
    public class Articulo
    {
        public int IdArticulo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }
        public int Precio { get; set; }
        public int Puntaje { get; set; }
        public Marca Marca { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaHasta { get; set; }

    }
}
