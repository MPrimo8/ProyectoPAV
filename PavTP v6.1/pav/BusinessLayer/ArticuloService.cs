using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pav.DataAcessLayer;
using pav.Entities;

namespace pav.BusinessLayer
{
    public class ArticuloService
    {
        private ArticuloDao oArticuloDao;
        public ArticuloService()
        {
            oArticuloDao = new ArticuloDao();
        }

        public IList<Articulo> ObtenerTodos()
        {
            return oArticuloDao.GetAll();
        }

        public Articulo ConsultarArticuloPorId(int id)
        {
            return oArticuloDao.getArticuloById(id);
        }
    }
}
