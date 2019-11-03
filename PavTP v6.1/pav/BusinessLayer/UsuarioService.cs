using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pav.Entities;
using pav.DataAcessLayer;


namespace pav.BusinessLayer
{
    public class UsuarioService
    {
        private UsuarioDao oUsuarioDao;
        public UsuarioService()
        {
            oUsuarioDao = new UsuarioDao();
        }
        public IList<Usuario> ObtenerTodos()
        {
            return oUsuarioDao.GetAll();
        }

        public Usuario ValidarUsuario(string usuario, string password)
        {
            //SIN PARAMETROS
            var usr = oUsuarioDao.GetUserSinParametros(usuario);

            //CON PARAMETROS
            //var usr = oUsuarioDao.GetUserConParametros(usuario);


            if ((usr != null) && (usr.Contraseña != null && usr.Contraseña.Equals(password)))
            {
                return usr;
            }

            return null;
        }

        internal bool CrearUsuario(Usuario oUsuario)
        {
            return oUsuarioDao.Create(oUsuario);
        }

        internal bool ActualizarUsuario(Usuario oUsuarioSelected)
        {
            return oUsuarioDao.Update(oUsuarioSelected);
        }

        internal bool ModificarEstadoUsuario(Usuario oUsuarioSelected)
        {
            return oUsuarioDao.Delete(oUsuarioSelected);
            //throw new NotImplementedException();
        }

        internal object ObtenerUsuario(string usuario)
        {
            //SIN PARAMETROS
            return oUsuarioDao.GetUserSinParametros(usuario);


        }

        internal IList<Usuario> ConsultarConFiltrosSinParametros(String condiciones)
        {
            return oUsuarioDao.GetByFiltersSinParametros(condiciones);
        }

        /*internal IList<Usuario> ConsultarConFiltrosConParametros(Dictionary<string, object> filtros)
        {
            return oUsuarioDao.GetByFiltersConParametros(filtros);
        }*/
    }
        
}
