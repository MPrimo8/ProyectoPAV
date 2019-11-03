using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pav.Entities
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        
        

        public string Contraseña { get; set; }

        public Perfil Perfil { get; set; }


        public override string ToString()
        {
            return NombreUsuario;
        }
    }
}
