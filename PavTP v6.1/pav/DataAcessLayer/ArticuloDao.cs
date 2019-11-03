using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using pav.Entities;

namespace pav.DataAcessLayer
{
    class ArticuloDao
    {
        public Articulo getArticuloById(int idArticulo)
        {
            string strSql = "SELECT a.idArticulo, a.nombre, m.nombre, a.descripcion, " +
                "a.stock, a.precio, a.puntaje, a.fechaAlta, a.fechaHasta " +
                "FROM Articulos A JOIN Marcas M on A.idMarca=M.idMarca " +
                "WHERE a.borrado=0 AND a.idArticulo=" + idArticulo;

            return MappingArticulo(DBHelper.GetDBHelper().ConsultaSQL(strSql).Rows[0]);
        }

        public IList<Articulo> GetAll()
        {
            List<Articulo> listadoProductos = new List<Articulo>();

            var strSql  = "SELECT a.idArticulo, a.nombre, m.nombre, a.descripcion, " +
                "a.stock, a.precio, a.puntaje, a.fechaAlta, a.fechaHasta " +
                "FROM Articulos A JOIN Marcas M on A.idMarca=M.idMarca " +
                "WHERE a.borrado=0";

            var resultadoConsulta = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoProductos.Add(MappingArticulo(row));
            }

            return listadoProductos;
        }



        private Articulo MappingArticulo(DataRow row)
        {
            Articulo oArticulo = new Articulo();

            oArticulo.IdArticulo = Convert.ToInt32(row["idArticulo"].ToString());
            oArticulo.Nombre = row["nombre"].ToString();
            oArticulo.Descripcion = row["descripcion"].ToString();
            oArticulo.Puntaje = Convert.ToInt32(row["puntaje"].ToString());
            oArticulo.Precio = Convert.ToInt32(row["precio"].ToString());
            //oArticulo.FechaAlta = Convert.ToDateTime(row["fechaAlta"].ToString());
            //oArticulo.FechaHasta = Convert.ToDateTime(row["fechaHasta"].ToString());
            oArticulo.Stock = Convert.ToInt32(row["stock"].ToString());

            oArticulo.Marca = new Marca();
            //oArticulo.Marca.IdMarca = Convert.ToInt32(row["idMarca"].ToString());
            oArticulo.Marca.Nombre = row["Nombre"].ToString();

            return oArticulo;
        }
    }
}
