using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Reflection;
using CreditoNeg.Entidad;

namespace CreditoNeg.Negocio
{
    public abstract class ClienteNeg
    {

        //public static string ConexionString = "Data Source=DESKTOP-CTDH2IN\\SQLEXPRESS; Initial Catalog:creditos; User ID=sa;Password=Server01";
        public static string ConexionString = "Persist Security Info=False;User ID=sa;Password=Server01;Initial Catalog=creditos;Server=DESKTOP-CTDH2IN\\SQLEXPRESS";

        public static SqlConnection conexion = new SqlConnection(ConexionString);


        //Funcion crear cliente
        public static bool crearCliente(Cliente oCliente)
        {
            try
            {
                conexion.Open();
                using (var cmd = new SqlCommand("", conexion))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO " + oCliente.TableName + "(nombre, no_identificacion)" + " VALUES(@nombre, @no_identificacion)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@nombre", oCliente.nombre);
                    cmd.Parameters.AddWithValue("@no_identificacion", oCliente.no_identificacion);
                    cmd.ExecuteNonQuery();
                }
                conexion.Close();
                return true;
            }
            catch
            {
                throw;
            }
        }


        //Traer todos los cliente
        public static List<Cliente> getClientes()
        {
            try
            {
                
                List<Cliente> listCliente = new List<Cliente>();
                conexion.Open();
                using (var cmd = new SqlCommand("", conexion))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM Clientes";
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt != null)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            Cliente oCliente = new Cliente();
                            oCliente.id_cliente = Convert.ToInt32(dr["id_cliente"]);
                            oCliente.nombre = Convert.ToString(dr["nombre"]);
                            oCliente.no_identificacion = Convert.ToInt32(dr["no_identificacion"]);
                            listCliente.Add(oCliente);
                        }
                    }

                    conexion.Close();
                    return listCliente;
                }
            }
            catch
            {
                throw;
            }
        }

        //Traer todos los cliente
        public static Cliente getClienteById(int id)
        {
            try
            {

                Cliente oCliente = new Cliente();
                conexion.Open();
                using (var cmd = new SqlCommand("", conexion))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM Clientes WHERE id_cliente = @Vid_cliente";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Vid_cliente", id);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt != null)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            oCliente.id_cliente = Convert.ToInt32(dr["id_cliente"]);
                            oCliente.nombre = Convert.ToString(dr["nombre"]);
                            oCliente.no_identificacion = Convert.ToInt32(dr["no_identificacion"]);
                        }
                    }
                    conexion.Close();
                    return oCliente;
                }
            }
            catch
            {
                throw;
            }
        }

        //protected abstract IDbConnection CrearConexion(string cadena);
        //protected abstract IDbCommand ComandoSql(string comand0Sql, IDbConnection connection);
        //protected abstract IDataAdapter CrearDataAdapterSql(string comandoSql, IDbConnection connection);

        /*
        protected IDbConnection SqlConexion;
        protected abstract IDbConnection CrearConexion(string cadena);
        protected abstract IDbCommand ComandoSql(string comand0Sql, IDbConnection connection);
        protected abstract IDataAdapter CrearDataAdapterSql(string comandoSql, IDbConnection connection);

        public bool ExecuteSqlQuery(String strQuery)
        {
            try
            {
                SqlConexion.Open();
                var com = ComandoSql(strQuery, SqlConexion);
                com.ExecuteNonQuery();
                SqlConexion.Close();
                return true;
            }
            catch
            {
                throw;
            }
        }
        public Object InsertObject(string TableName, Object Instancia)
        {
            try
            {
                string values = "";
                //Formatemao los datos del objeto
                Type _type = Instancia.GetType();
                PropertyInfo[] lst = _type.GetProperties();
                foreach (PropertyInfo oProperty in lst)
                {
                    string AtributeName = oProperty.Name;
                    var AtributeValue = oProperty.GetValue(Instancia);
                    if (AtributeValue.GetType() == typeof(string) || AtributeValue.GetType() == typeof(DateTime))
                    {
                        values = values + "'" + AtributeValue.ToString() + "',";
                    }
                    else
                    {
                        if ((Int32)AtributeValue != -1)
                        {
                            values = values + AtributeValue.ToString() + ",";
                        }
                    }
                }
                values = values.TrimEnd(',');

                string strQuery = "INSERT INTO " + TableName + " VALUES(" + values + ")";

                return ExecuteSqlQuery(strQuery);
            }
            catch
            {
                throw;
            }
        }

        public DataTable TraerDatosSQL(string queryString)
        {
            DataSet ObjData = new DataSet();
            CrearDataAdapterSql(queryString, SqlConexion).Fill(ObjData);
            return ObjData.Tables[0].Copy();
        }

        public Object takeList(string TableName, Object Instancia, string Condicion)
        {
            try
            {
                string CondicionString = "";
                if (Condicion != null)
                {
                    CondicionString = "WHERE " + Condicion
                        ;
                }
                string queryString = "SELECT * FROM " + TableName + CondicionString;
                DataTable Table = TraerDatosSQL(queryString);
                List<Object> ListD = ConvertDataTable(Table, Instancia);
                return ListD;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static List<Object> ConvertDataTable(DataTable dt, Object Instancia)
        {
            List<Object> data = new List<object>();
            foreach (DataRow row in dt.Rows)
            {
                var item = GetItem(row, Instancia);
                data.Add(item);
            }
            return data;
        }

        private static Object GetItem(DataRow dr, Object Inst)
        {
            Type temp = Inst.GetType();
            var obj = Activator.CreateInstance(Inst.GetType());
            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                    {
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return obj;
        }*/
    }
}
