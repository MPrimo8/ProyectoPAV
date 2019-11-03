using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pav.Entities;
using System.Data;

namespace pav.DataAcessLayer
{
    public class EjercicioDao
    {
        public IList<Ejercicio> GetAll()
        {
            List<Ejercicio> listadoBugs = new List<Ejercicio>();

            var strSql = "SELECT * From Ejercicios WHERE borrado=0";

            var resultadoConsulta = DBHelper.GetDBHelper().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoBugs.Add(ObjectMapping(row));
            }

            return listadoBugs;
        }
        private Ejercicio ObjectMapping(DataRow row)
        {
            Ejercicio oEjercicio = new Ejercicio
            {
                IdEjercicio = Convert.ToInt32(row["idEjercicio"].ToString()),
                Nombre = row["nombre"].ToString(),
                Descripcion = row["descripcion"].ToString(),
                MusculoAfectado = row["musculoAfectado"].ToString(),
                Dificultad = row["dificultad"].ToString()
            };

            return oEjercicio;
        }
        public Ejercicio GetEjerSinParametros(string nombreEjercicio)
        {
            //Construimos la consulta sql para buscar el usuario en la base de datos.
            String strSql = string.Concat(" SELECT idEjercicio, ",
                                          "        nombre, ",
                                          "        descripcion, ",
                                          "        musculoAfectado, ",
                                          "        dificultad ",
                                          "   FROM Ejercicios e",
                                          "  WHERE e.borrado =0 ");

            strSql += " AND nombre=" + "'" + nombreEjercicio + "'";


            //Usando el método GetDBHelper obtenemos la instancia unica de DBHelper (Patrón Singleton) y ejecutamos el método ConsultaSQL()
            var resultado = DBHelper.GetDBHelper().ConsultaSQL(strSql);

            // Validamos que el resultado tenga al menos una fila.
            if (resultado.Rows.Count > 0)
            {
                return ObjectMapping(resultado.Rows[0]);
            }

            return null;
        }
        internal bool Create(Ejercicio oEjercicio)
        {


            string str_sql = "INSERT INTO Ejercicios (nombre, descripcion, musculoAfectado, dificultad )" +
                            " VALUES (" +
                            "'" + oEjercicio.Nombre + "'" + "," +
                            "'" + oEjercicio.Descripcion + "'" + "," +
                            "'" + oEjercicio.MusculoAfectado + "'" + "," +
                            "'" + oEjercicio.Dificultad + "'" + ")";


            return (DBHelper.GetDBHelper().EjecutarSQL(str_sql) == 1);
        }
        internal bool Update(Ejercicio oEjercicio)
        {
            //SIN PARAMETROS

            string str_sql = "UPDATE Ejercicios " +
                             "SET nombre=" + "'" + oEjercicio.Nombre + "'" + "," +
                             " descripcion=" + "'" + oEjercicio.Descripcion + "'" + "," +
                             " musculoAfectado=" + "'" + oEjercicio.MusculoAfectado + "'" + "," +
                             " dificultad=" + "'" + oEjercicio.Dificultad + "'" +
                             " WHERE idEjercicio=" + oEjercicio.IdEjercicio;

            return (DBHelper.GetDBHelper().EjecutarSQL(str_sql) == 1);
        }
        internal bool Delete(Ejercicio oEjercicio)
        {
            string str_sql = "UPDATE Ejercicios " +
                             "SET borrado=1 WHERE idEjercicio=" + oEjercicio.IdEjercicio;
            return (DBHelper.GetDBHelper().EjecutarSQL(str_sql) == 1);
        }
        public IList<Ejercicio> GetByFiltersSinParametros(String condiciones)
        {

            List<Ejercicio> lst = new List<Ejercicio>();
            String strSql = string.Concat(" SELECT idEjercicio, ",
                                              "        nombre, ",
                                              "        descripcion, ",
                                              "        musculoAfectado, ",
                                              "        dificultad ",
                                              "   FROM Ejercicios e",
                                              "  WHERE e.borrado =0 ");

            strSql += condiciones;


            var resultado = DBHelper.GetDBHelper().ConsultaSQL(strSql);


            foreach (DataRow row in resultado.Rows)
                lst.Add(ObjectMapping(row));

            return lst;
        }
    }
}
