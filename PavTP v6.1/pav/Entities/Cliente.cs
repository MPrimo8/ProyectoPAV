using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace pav.Entities
{
    public class Cliente
    {
        public int IdCliente{ get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Telefono { get; set; }
        public int TelefonoEmerg { get; set; }
        public int Puntos { get; set; }
        public double Peso { get; set; }
        public int Altura { get; set; }




        public Enfermedad Enfermedad{ get; set; }

    }
}
