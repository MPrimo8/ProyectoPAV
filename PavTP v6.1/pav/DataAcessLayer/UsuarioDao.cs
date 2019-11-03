using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pav.Entities;
using System.Data;

namespace pav.DataAcessLayer
{
    public class UsuarioDao
    {
        public IList<Usuario> GetAll()
        {
            List<Usuario> listadoUsuarios = new List<Usuario>();

            String strSql = string.Concat(" SELECT idUsuario, ",
                                          "        usuario, ",
                                          "        contraseña, ",
                                          "        p.idPerfil, ",
                                          "        p.nombre as perfil",
                                          "   FROM Usuarios u",
                                          "  INNER JOIN Perfiles p ON u.idPerfil= p.idPerfil WHERE u.borrado=0 ");

            var resultadoConsulta = DBHelper.GetDBHelper().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoUsuarios.Add(ObjectMapping(row));
            }

            return listadoUsuarios;
        }
        

        public Usuario GetUserSinParametros(string nombreUsuario)
        {
            //Construimos la consulta sql para buscar el usuario en la base de datos.
            String strSql = string.Concat(" SELECT idUsuario, ",
                                          "        usuario, ",
                                          "        contraseña, ",
                                          "        p.idPerfil, ",
                                          "        p.nombre as perfil ",
                                          "   FROM Usuarios u",
                                          "  INNER JOIN Perfiles p ON u.idPerfil= p.idPerfil ",
                                          "  WHERE u.borrado =0 ");

            strSql += " AND usuario=" + "'" + nombreUsuario + "'";


            //Usando el método GetDBHelper obtenemos la instancia unica de DBHelper (Patrón Singleton) y ejecutamos el método ConsultaSQL()
            var resultado = DBHelper.GetDBHelper().ConsultaSQL(strSql);

            // Validamos que el resultado tenga al menos una fila.
            if (resultado.Rows.Count > 0)
            {
                return ObjectMapping(resultado.Rows[0]);
            }

            return null;
        }

        

        public IList<Usuario> GetByFiltersSinParametros(String condiciones)
        {

            List<Usuario> lst = new List<Usuario>();
            String strSql = string.Concat(" SELECT idUsuario, ",
                                              "        usuario, ",
                                              "        contraseña, ",
                                              "        p.idPerfil, ",
                                              "        p.nombre as perfil ",
                                              "   FROM Usuarios u",
                                              "  INNER JOIN Perfiles p ON u.idPerfil= p.idPerfil ",
                                              "  WHERE u.borrado =0 ");

            strSql += condiciones;
            

            var resultado = DBHelper.GetDBHelper().ConsultaSQL(strSql);


            foreach (DataRow row in resultado.Rows)
                lst.Add(ObjectMapping(row));

            return lst;
        }

        internal bool Create(Usuario oUsuario)
        {
           

            string str_sql = "INSERT INTO Usuarios (usuario, contraseña,  idPerfil )" +
                            " VALUES (" +
                            "'" + oUsuario.NombreUsuario + "'" + "," +
                            "'" + oUsuario.Contraseña + "'" + "," +
                            oUsuario.Perfil.IdPerfil + ")";


            return (DBHelper.GetDBHelper().EjecutarSQL(str_sql) == 1);
        }

        internal bool Delete(Usuario oUsuario)
        {
            string str_sql = "UPDATE Usuarios " +
                             "SET borrado=1 WHERE idUsuario=" + oUsuario.IdUsuario;
            return (DBHelper.GetDBHelper().EjecutarSQL(str_sql) == 1);
        }


        internal bool Update(Usuario oUsuario)
        {
            //SIN PARAMETROS

            string str_sql = "UPDATE Usuarios " +
                             "SET usuario=" + "'" + oUsuario.NombreUsuario + "'" + "," +
                             " contraseña=" + "'" + oUsuario.Contraseña + "'" + "," +
                             " idPerfil=" + oUsuario.Perfil.IdPerfil +
                             " WHERE idUsuario=" + oUsuario.IdUsuario;

            return (DBHelper.GetDBHelper().EjecutarSQL(str_sql) == 1);
        }

        private Usuario ObjectMapping(DataRow row)
        {
            Usuario oUsuario = new Usuario
            {
                IdUsuario = Convert.ToInt32(row["idUsuario"].ToString()),
                NombreUsuario = row["usuario"].ToString(),
                Contraseña= row.Table.Columns.Contains("contraseña") ? row["contraseña"].ToString() : null,
                Perfil = new Perfil()
                {
                    IdPerfil = Convert.ToInt32(row["idPerfil"].ToString()),
                    Nombre = row["perfil"].ToString(),
                }
            };

            return oUsuario;
        }
    }
}
