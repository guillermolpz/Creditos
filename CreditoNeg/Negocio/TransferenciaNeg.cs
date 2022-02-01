using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using CreditoNeg.Entidad;

namespace CreditoNeg.Negocio
{
    public abstract class TransferenciaNeg
    {
        //public static string ConexionString = "Data Source=DESKTOP-CTDH2IN\\SQLEXPRESS; Initial Catalog:creditos; User ID=sa;Password=Server01";
        public static string ConexionString = "Persist Security Info=False;User ID=sa;Password=Server01;Initial Catalog=creditos;Server=DESKTOP-CTDH2IN\\SQLEXPRESS";

        public static SqlConnection conexion = new SqlConnection(ConexionString);


        //Funcion crear cliente
        public static bool crearTransferencia(Transaccion oTransaccion)
        {
            try
            {
                conexion.Open();
                using (var cmd = new SqlCommand("", conexion))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO " + oTransaccion.TableName + "(monto, tipo, id_cuenta, id_cliente)" + " VALUES(@monto, @tipo, @id_cuenta, @id_cliente)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@monto", oTransaccion.monto);
                    cmd.Parameters.AddWithValue("@tipo", oTransaccion.tipo);
                    cmd.Parameters.AddWithValue("@id_cuenta", oTransaccion.id_cuenta);
                    cmd.Parameters.AddWithValue("@id_cliente", oTransaccion.id_cliente);
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
        public static List<Transaccion> getTransacciones()
        {
            try
            {

                List<Transaccion> listTransaccion = new List<Transaccion>();
                conexion.Open();
                using (var cmd = new SqlCommand("", conexion))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM Transaccion";
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt != null)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            Transaccion oTransaccion = new Transaccion();
                            oTransaccion.monto = Convert.ToDecimal(dr["monto"]);
                            oTransaccion.tipo = Convert.ToString(dr["tipo"]);
                            oTransaccion.id_cliente = Convert.ToInt32(dr["id_cliente"]);
                            listTransaccion.Add(oTransaccion);
                        }
                    }

                    conexion.Close();
                    return listTransaccion;
                }
            }
            catch
            {
                throw;
            }
        }

        //Traer todos los cliente
        public static List<Transaccion> getTransaccionesByIdClienteIdCuenta(int id_cliente, int id_cuenta)
        {
            try
            {

                List<Transaccion> oTransacciones = new List<Transaccion>();
                conexion.Open();
                using (var cmd = new SqlCommand("", conexion))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM Transaccion WHERE id_cliente = @Vid_cliente AND id_cuenta = @Vid_cuenta";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Vid_cliente", id_cliente);
                    cmd.Parameters.AddWithValue("@Vid_cuenta", id_cuenta);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt != null)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            Transaccion oTransaccion = new Transaccion();
                            oTransaccion.monto = Convert.ToInt32(dr["monto"]);
                            oTransaccion.tipo = Convert.ToString(dr["tipo"]);
                            oTransaccion.id_cuenta = Convert.ToInt32(dr["id_cuenta"]);
                            oTransaccion.id_cliente = Convert.ToInt32(dr["id_cliente"]);
                            oTransacciones.Add(oTransaccion);
                        }
                    }
                    conexion.Close();
                    return oTransacciones;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
