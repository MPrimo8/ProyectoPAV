using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pav.DataAcessLayer;
using pav.Entities;

namespace pav.BusinessLayer
{
    public class PerfilService
    {
        private PerfilDao oPerfilDao;
        public PerfilService()
        {
            oPerfilDao = new PerfilDao();
        }
        public IList<Perfil> ObtenerTodos()
        {
            return oPerfilDao.GetAll();
        }
        internal object ObtenerPerfil(string perfil)
        {
            //SIN PARAMETROS
            return oPerfilDao.GetPerfSinParametros(perfil);
        }
        internal bool CrearPerfil(Perfil oPerfil)
        {
            return oPerfilDao.Create(oPerfil);
        }
        internal bool ActualizarPerfil(Perfil oPerfilSelected)
        {
            return oPerfilDao.Update(oPerfilSelected);
        }
        internal bool ModificarEstadoPerfil(Perfil oPerfilSelected)
        {
            return oPerfilDao.Delete(oPerfilSelected);
            //throw new NotImplementedException();
        }
    }
}
