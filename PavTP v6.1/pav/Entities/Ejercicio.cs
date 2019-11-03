using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pav.Entities
{
    public class Ejercicio
    {
        public int IdEjercicio { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string MusculoAfectado { get; set; }
        public string Dificultad { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
