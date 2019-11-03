using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pav.Entities;
using System.Data;

namespace pav.DataAcessLayer
{
    public class ClienteDao
    {
        public IList<Cliente> GetAll()
        {
            List<Cliente> listadoClientes = new List<Cliente>();

            String strSql = string.Concat(" SELECT idCliente, ",
                                          "        nombre, ",
                                          "        apellido, ",
                                          "        telefono," +
                                          "        telefonoEmerg," +
                                          "        puntos, peso, altura " +
                                          " FROM Clientes",
                                          " WHERE borrado=0 ");

            var resultadoConsulta = DBHelper.GetDBHelper().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoClientes.Add(ObjectMapping(row));
            }

            return listadoClientes;
        }
        

        /*
        public Cliente GetClienteSinParametros(string nombreCliente)
        {
            //Construimos la consulta sql para buscar el usuario en la base de datos.
            String strSql = string.Concat(" SELECT idCliente, ",
                                          "        nombre, ",
                                          "        apellido, ",
                                          "        telefono," +
                                          "        telefonoEmerg," +
                                          "        puntos, peso, altura ",

                                          "   FROM Clientes WHERE borrado=0 ");

            strSql += " AND nombre=" + "'" + nombreCliente + "'";


            //Usando el método GetDBHelper obtenemos la instancia unica de DBHelper (Patrón Singleton) y ejecutamos el método ConsultaSQL()
            var resultado = DBHelper.GetDBHelper().ConsultaSQL(strSql);

            // Validamos que el resultado tenga al menos una fila.
            if (resultado.Rows.Count > 0)
            {
                return ObjectMapping(resultado.Rows[0]);
            }

            return null;
        }
        */



        public IList<Cliente> GetByFiltersSinParametros(String condiciones)
        {

            List<Cliente> lst = new List<Cliente>();
            String strSql = string.Concat(" SELECT idCliente, ",
                                          "        nombre, ",
                                          "        apellido, ",
                                          "        telefono," +
                                          "        telefonoEmerg," +
                                          "        puntos, peso, altura ",
                                          " FROM Clientes ",
                                          " WHERE borrado=0 ");

            strSql += condiciones;


            var resultado = DBHelper.GetDBHelper().ConsultaSQL(strSql);


            foreach (DataRow row in resultado.Rows)
                lst.Add(ObjectMapping(row));

            return lst;
        }

        internal bool Create(Cliente oCliente)
        {
            string str_sql = "INSERT INTO Usuarios (nombre, apellido,  telefono," +
                             " telefonoEmerg, puntos, peso, altura )" +
                            " VALUES ('"
                            + oCliente.Nombre + "' , '"
                            + oCliente.Apellido + "' , "
                            + oCliente.Telefono + " , "
                            + oCliente.TelefonoEmerg + " , "
                            + oCliente.Puntos + " , "
                            + oCliente.Peso + " , "
                            + oCliente.Altura + ")";

                         

            return (DBHelper.GetDBHelper().EjecutarSQL(str_sql) == 1);
        }

        internal bool Delete(Cliente oCliente)
        {
            string str_sql = "UPDATE Clientes " +
                             "SET borrado=1 WHERE idCliente=" + oCliente.IdCliente;
            return (DBHelper.GetDBHelper().EjecutarSQL(str_sql) == 1);
        }


        internal bool Update(Cliente oCliente)
        {
            //SIN PARAMETROS

            string str_sql = "UPDATE Clientes " +
                             "SET nombre=" + "'" + oCliente.Nombre + "'" + "," +
                             " apellido=" + "'" + oCliente.Apellido + "'" + "," +
                             " peso=" + oCliente.Peso + "," +
                             " altura=" + oCliente.Altura + 
                             ", telefono=" + oCliente.Telefono +
                             ", telefonoEmerg=" + oCliente.TelefonoEmerg +
                             " WHERE idCliente=" + oCliente.IdCliente;

            return (DBHelper.GetDBHelper().EjecutarSQL(str_sql) == 1);
        }

        private Cliente ObjectMapping(DataRow row)
        {
            Cliente oCliente = new Cliente
            {
                /*IdCliente = Convert.ToInt32(row["idCliente"].ToString()),
                Nombre = row["nombre"].ToString(),
                Apellido = row["apellido"].ToString(),
                Puntos = Convert.ToInt32(row["puntos"].ToString()),
                Peso = Convert.ToDouble(row["peso"].ToString()),
                Altura = Convert.ToInt32(row["altura"].ToString()),
                Telefono = Convert.ToInt32(row["telefono"].ToString()),
                TelefonoEmerg = Convert.ToInt32(row["telefonoEmerg"].ToString())*/
                
                
                IdCliente = 1,
                Nombre = "Javier",
                Apellido = "Alonso",
                //Puntos = Convert.ToInt32(row["puntos"].ToString()),
                Peso = 75,
                //Altura = Convert.ToInt32(row["altura"].ToString()),
                Telefono = 103,
                TelefonoEmerg = 1855
                

                /*
                Enfermedad = new Enfermedad()
                {
                    Nombre = row["Enfermedad"].ToString(),
                    Descripcion = row["Descripcion"].ToString(),
                }*/
            };

            return oCliente;
        }
    }
}
