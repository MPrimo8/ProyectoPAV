using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pav.DataAcessLayer;
using pav.Entities;

namespace pav.BusinessLayer
{
    public class ClienteService
    {
        private ClienteDao oClienteDao;
        public ClienteService()
        {
            oClienteDao = new ClienteDao();
        }
        public IList<Cliente> ObtenerTodos()
        {
            return oClienteDao.GetAll();
        }

        
        internal bool CrearCliente(Cliente oCliente)
        {
            return oClienteDao.Create(oCliente);
        }

        internal bool ActualizarUsuario(Cliente oClienteSelected)
        {
            return oClienteDao.Update(oClienteSelected);
        }

        internal bool ModificarEstadoCliente(Cliente oClienteSelected)
        {
            return oClienteDao.Delete(oClienteSelected);
            //throw new NotImplementedException();
        }

        /*
        internal object ObtenerCliente(string usuario)
        {
            //SIN PARAMETROS
            return oClienteDao.GetClienteSinParametros(usuario);


        }
        */

        internal IList<Cliente> ConsultarConFiltrosSinParametros(String condiciones)
        {
            return oClienteDao.GetByFiltersSinParametros(condiciones);
        }
    }
}
