using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pav.Entities;
using System.Data;

namespace pav.DataAcessLayer
{
    class MarcaDao
    {
        public IList<Marca> GetAll()
        {
            List<Marca> listadoMarca = new List<Marca>();

            var strSql = "SELECT * from Marcas where borrado=0";

            var resultadoConsulta = DBHelper.GetDBHelper().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoMarca.Add(ObjectMapping(row));
            }

            return listadoMarca;
        }

        public Marca GetMarcasSinParametros(string marca)
        {
            
            var strSql = "SELECT * from Marcas where borrado=0";

            strSql += " AND nombre=" + "'" + marca + "'";


            //Usando el método GetDBHelper obtenemos la instancia unica de DBHelper (Patrón Singleton) y ejecutamos el método ConsultaSQL()
            var resultado = DBHelper.GetDBHelper().ConsultaSQL(strSql);

            // Validamos que el resultado tenga al menos una fila.
            if (resultado.Rows.Count > 0)
            {
                return ObjectMapping(resultado.Rows[0]);
            }

            return null;
        }

        public IList<Marca> GetByFiltersSinParametros(String condiciones)
        {

            List<Marca> lst = new List<Marca>();
            var strSql = "SELECT * from Marcas WHERE borrado=0";

            strSql += condiciones;


            var resultado = DBHelper.GetDBHelper().ConsultaSQL(strSql);


            foreach (DataRow row in resultado.Rows)
                lst.Add(ObjectMapping(row));

            return lst;
        }

        internal bool Create(Marca oMarca)
        {


            string str_sql = "INSERT INTO Marcas (nombre )" +
                            " VALUES ('"  + oMarca.Nombre+ "')";


            return (DBHelper.GetDBHelper().EjecutarSQL(str_sql) == 1);
        }

        internal bool Delete(Marca oMarca)
        {
            string str_sql = "UPDATE Marcas " +
                             "SET borrado=1 WHERE idMarca=" + oMarca.IdMarca;
            return (DBHelper.GetDBHelper().EjecutarSQL(str_sql) == 1);
        }


        
        private Marca ObjectMapping(DataRow row)
        {
            Marca oMarca = new Marca
            {
                IdMarca = Convert.ToInt32(row["idMarca"].ToString()),
                Nombre = row["nombre"].ToString()
            };

            return oMarca;
        }



    }
}
