using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pav.DataAcessLayer;
using pav.Entities;

namespace pav.BusinessLayer
{
    class MarcaService
    {
        private MarcaDao oMarcaDao;
        public MarcaService()
        {
            oMarcaDao = new MarcaDao();
        }
        public IList<Marca> ObtenerTodos()
        {
            return oMarcaDao.GetAll();
        }

        public Marca ValidarMarca(string marca)
        {
            //SIN PARAMETROS
            var mrc = oMarcaDao.GetMarcasSinParametros(marca);

           
            if (mrc != null) 
            {
                return mrc;
            }

            return null;
        }

       

        internal bool CrearMarca(Marca oMarca)
        {
            return oMarcaDao.Create(oMarca);
        }

        internal bool ActualizarMarca(Marca oMarcaSelected)
        {
            return oMarcaDao.Delete(oMarcaSelected);
        }

        internal bool ModificarEstadoMarca(Marca oMarcaSelected)
        {
            return oMarcaDao.Delete(oMarcaSelected);
        }

        internal object ObtenerMarca(string marca)
        {
            //SIN PARAMETROS
            return oMarcaDao.GetMarcasSinParametros(marca);


        }

        internal IList<Marca> ConsultarConFiltrosSinParametros(String condiciones)
        {
            return oMarcaDao.GetByFiltersSinParametros(condiciones);
        }
    }
}
