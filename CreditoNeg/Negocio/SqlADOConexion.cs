using System;
using System.Collections.Generic;
using System.Text;

namespace CreditoNeg.Negocio
{
    static public class SqlADOConexion
    {
        static string UserSQLConexion = "";
        public static SqlServer SQLM;

        static public bool IniciarConexion(string user="sa", string password="Server01")
        {
            try
            {
                UserSQLConexion = "Data Source=DESKTOP-CTDH2IN\\SQLEXPRESS; Initial Catalog:creditos; User ID=" + user + ";Password=" + password;
                //var providerName = "System.Data.SqlClient";
                //SQLM = new SqlServer(UserSQLConexion);
                return true;
            }
            catch
            {
                throw;
            }
        }
        /*
        static public bool IniciarConexion(string user, string password)
        {
            try
            {
                UserSQLConexion = "Data Source=DESKTOP-CTDH2IN\\SQLEXPRESS; Initial Catalogo:creditos; User ID=" + user + ";Password=" + password;
                SQLM = new SqlServer(UserSQLConexion);
                return true;
            }
            catch
            {
                throw;
            }
        }*/
    }
}
