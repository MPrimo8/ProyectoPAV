using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pav.DataAcessLayer;
using pav.Entities;

namespace pav.BusinessLayer
{
    public class EjercicioService
    {
        private EjercicioDao oEjercicioDao;

        public EjercicioService()
        {
            oEjercicioDao = new EjercicioDao();
        }
        public IList<Ejercicio> ObtenerTodos()
        {
            return oEjercicioDao.GetAll();
        }
        internal object ObtenerEjercicio(string ejercicio)
        {
            //SIN PARAMETROS
            return oEjercicioDao.GetEjerSinParametros(ejercicio);
        }
        internal bool CrearEjercicio(Ejercicio oEjercicio)
        {
            return oEjercicioDao.Create(oEjercicio);
        }
        internal bool ActualizarEjercicio(Ejercicio oEjercicioSelected)
        {
            return oEjercicioDao.Update(oEjercicioSelected);
        }
        internal bool ModificarEstadoEjercicio(Ejercicio oEjercicioSelected)
        {
            return oEjercicioDao.Delete(oEjercicioSelected);
            //throw new NotImplementedException();
        }
        internal IList<Ejercicio> ConsultarConFiltrosSinParametros(String condiciones)
        {
            return oEjercicioDao.GetByFiltersSinParametros(condiciones);
        }
    }
}
