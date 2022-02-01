using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using CreditoNeg.Entidad;

namespace CreditoNeg.Negocio
{
    public abstract class CuentaAhorroNeg
    {
        //public static string ConexionString = "Data Source=DESKTOP-CTDH2IN\\SQLEXPRESS; Initial Catalog:creditos; User ID=sa;Password=Server01";
        public static string ConexionString = "Persist Security Info=False;User ID=sa;Password=Server01;Initial Catalog=creditos;Server=DESKTOP-CTDH2IN\\SQLEXPRESS";

        public static SqlConnection conexion = new SqlConnection(ConexionString);


        //Funcion crear cliente
        public static bool crearCuentaAhorro(CuentaAhorro oCuentaAhorro, int id)
        {
            try
            {
                conexion.Open();
                using (var cmd = new SqlCommand("", conexion))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO " + oCuentaAhorro.TableName + "(cuenta, saldo_actual, id_cliente)" + " VALUES(@cuenta, @saldo_actual, @id_cliente)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@cuenta", oCuentaAhorro.cuenta);
                    cmd.Parameters.AddWithValue("@saldo_actual", oCuentaAhorro.saldo_actual);
                    cmd.Parameters.AddWithValue("@id_cliente", id);
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

        //Actualizar cuent de ahorro
        public static bool updateCuentaAhorro(CuentaAhorro oCuentaAhorro)
        {
            try
            {
                conexion.Open();
                using (var cmd = new SqlCommand("", conexion))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE " + oCuentaAhorro.TableName + " SET saldo_actual=@saldo_actual WHERE  id_cuenta=@id_cuenta";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@saldo_actual", oCuentaAhorro.saldo_actual);
                    cmd.Parameters.AddWithValue("@id_cuenta", oCuentaAhorro.id_cuenta);
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
        public static List<CuentaAhorro> getCuentaAhorro()
        {
            try
            {

                List<CuentaAhorro> listCuentaAhorro = new List<CuentaAhorro>();
                conexion.Open();
                using (var cmd = new SqlCommand("", conexion))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM CuentaAhorro";
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt != null)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            CuentaAhorro oCuentaAhorro = new CuentaAhorro();
                            oCuentaAhorro.id_cuenta = Convert.ToInt32(dr["id_cuenta"]);
                            oCuentaAhorro.cuenta = Convert.ToInt32(dr["cuenta"]);
                            oCuentaAhorro.saldo_actual = Convert.ToDecimal(dr["saldo_actual"]);
                            oCuentaAhorro.id_cliente = Convert.ToInt32(dr["id_cliente"]);
                            listCuentaAhorro.Add(oCuentaAhorro);
                        }
                    }

                    conexion.Close();
                    return listCuentaAhorro;
                }
            }
            catch
            {
                throw;
            }
        }

        //Traer cuenta de ahorro de cliente
        public static List<CuentaAhorro> getCuentaAhorroByIdCliente(int id)
        {
            try
            {
                List<CuentaAhorro> listCuentaAhorro = new List<CuentaAhorro>();
                conexion.Open();
                using (var cmd = new SqlCommand("", conexion))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM CuentaAhorro WHERE id_cliente = @Vid_cliente";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Vid_cliente", id);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt != null)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            CuentaAhorro oCuentaAhorro = new CuentaAhorro();
                            oCuentaAhorro.id_cuenta = Convert.ToInt32(dr["id_cuenta"]);
                            oCuentaAhorro.cuenta = Convert.ToInt32(dr["cuenta"]);
                            oCuentaAhorro.saldo_actual = Convert.ToDecimal(dr["saldo_actual"]);
                            oCuentaAhorro.id_cliente = Convert.ToInt32(dr["id_cliente"]);
                            listCuentaAhorro.Add(oCuentaAhorro);
                        }
                    }
                    conexion.Close();
                    return listCuentaAhorro;
                }
            }
            catch
            {
                throw;
            }
        }

        //Traer cuenta por id
        public static CuentaAhorro getCuentaAhorroByIdCuenta(int id)
        {
            try
            {
                CuentaAhorro oCuentaAhorro = new CuentaAhorro();
                conexion.Open();
                using (var cmd = new SqlCommand("", conexion))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM CuentaAhorro WHERE id_cuenta = @Vid_cuenta";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Vid_cuenta", id);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt != null)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            oCuentaAhorro.id_cuenta = Convert.ToInt32(dr["id_cuenta"]);
                            oCuentaAhorro.cuenta = Convert.ToInt32(dr["cuenta"]);
                            oCuentaAhorro.saldo_actual = Convert.ToDecimal(dr["saldo_actual"]);
                            oCuentaAhorro.id_cliente = Convert.ToInt32(dr["id_cliente"]);
                        }
                    }
                    conexion.Close();
                    return oCuentaAhorro;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
