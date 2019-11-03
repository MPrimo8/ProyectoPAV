using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pav.Entities;
using System.Data;

namespace pav.DataAcessLayer
{
    public class PerfilDao
    {
        
        public IList<Perfil> GetAll()
        {
            List<Perfil> listadoBugs = new List<Perfil>();

            var strSql = "SELECT * From Perfiles WHERE idPerfil <> 1 AND borrado=0";

            var resultadoConsulta = DBHelper.GetDBHelper().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoBugs.Add(ObjectMapping(row));
            }

            return listadoBugs;
        }

        private Perfil ObjectMapping(DataRow row)
        {
            Perfil oPerfil = new Perfil
            {
                IdPerfil = Convert.ToInt32(row["idPerfil"].ToString()),
                Nombre = row["nombre"].ToString()
            };

            return oPerfil;
        }
        public Perfil GetPerfSinParametros(string nombrePerfil)
        {
            //Construimos la consulta sql para buscar el usuario en la base de datos.
            String strSql = string.Concat(" SELECT idPerfil, ",
                                          "        nombre ",
                                          "   FROM Perfiles p",
                                          "  WHERE p.borrado =0 ");

            strSql += " AND nombre=" + "'" + nombrePerfil + "'";


            //Usando el método GetDBHelper obtenemos la instancia unica de DBHelper (Patrón Singleton) y ejecutamos el método ConsultaSQL()
            var resultado = DBHelper.GetDBHelper().ConsultaSQL(strSql);

            // Validamos que el resultado tenga al menos una fila.
            if (resultado.Rows.Count > 0)
            {
                return ObjectMapping(resultado.Rows[0]);
            }

            return null;
        }
        internal bool Create(Perfil oPerfil)
        {


            string str_sql = "INSERT INTO Perfiles (nombre )" +
                            " VALUES (" +
                            "'" + oPerfil.Nombre + "'" + ")";


            return (DBHelper.GetDBHelper().EjecutarSQL(str_sql) == 1);
        }
        internal bool Update(Perfil oPerfil)
        {
            //SIN PARAMETROS

            string str_sql = "UPDATE Perfiles " +
                             "SET nombre=" + "'" + oPerfil.Nombre + "'" +
                             " WHERE idPerfil=" + oPerfil.IdPerfil;

            return (DBHelper.GetDBHelper().EjecutarSQL(str_sql) == 1);
        }
        internal bool Delete(Perfil oPerfil)
        {
            string str_sql = "UPDATE Perfiles " +
                             "SET borrado=1 WHERE idPerfil=" + oPerfil.IdPerfil;
            return (DBHelper.GetDBHelper().EjecutarSQL(str_sql) == 1);
        }
    }
}
