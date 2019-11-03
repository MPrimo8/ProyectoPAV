using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pav.Entities;
using System.Data;

namespace pav.DataAcessLayer
{
    public class TipoFacturaDao
    {
        public IList<TipoFactura> GetAll()
        {
            List<TipoFactura> listadoTiposFactura = new List<TipoFactura>();

            var strSql = "SELECT id_tipoFactura, descripcion from TipoFactura where borrado=0";

            var resultadoConsulta = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoTiposFactura.Add(MappingTipoFactura(row));
            }

            return listadoTiposFactura;
        }

        private TipoFactura MappingTipoFactura(DataRow row)
        {
            TipoFactura oTipoFactura = new TipoFactura
            {
                IdTipoFactura = Convert.ToChar(row["id_tipoFactura"].ToString()),
                Descripcion = row["descripcion"].ToString()
            };

            return oTipoFactura;
        }
    }
}
