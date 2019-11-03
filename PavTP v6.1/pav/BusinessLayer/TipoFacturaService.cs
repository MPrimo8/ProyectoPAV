using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pav.Entities;
using pav.DataAcessLayer;

namespace pav.BusinessLayer
{
    public class TipoFacturaService
    {
        private TipoFacturaDao oTipoFacturaDao;
        public TipoFacturaService()
        {
            oTipoFacturaDao = new TipoFacturaDao();
        }
        public IList<TipoFactura> ObtenerTodos()
        {
            return oTipoFacturaDao.GetAll();
        }
    }
}
