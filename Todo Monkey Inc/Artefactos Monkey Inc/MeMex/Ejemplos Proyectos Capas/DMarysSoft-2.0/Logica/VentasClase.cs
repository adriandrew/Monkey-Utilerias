using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Logica
{
    public class VentasClase
    {
        private int idVenta;
        private int idUsuario;
        private int idSucursal;
        private string cliente;
        private string fecha;
        private double subtotal;
        private double efectivo;
        private double cambio;
        private double iva;
        private double total;

        public int IdSucursal
        {
            get { return idSucursal; }
            set { idSucursal = value; }
        }

        public double Cambio
        {
            get { return cambio; }
            set { cambio = value; }
        }

        public double Efectivo
        {
            get { return efectivo; }
            set { efectivo = value; }
        }

        public double Subtotal
        {
            get { return subtotal; }
            set { subtotal = value; }
        }

        public double Iva
        {
            get { return iva; }
            set { iva = value; }
        }

        public double Total
        {
            get { return total; }
            set { total = value; }
        }

        public string Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public string Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        public int IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }

        public int IdVenta
        {
            get { return idVenta; }
            set { idVenta = value; }
        }


        public void Guardar()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = BaseDatos.conn;
                cmd.CommandText = "INSERT INTO Ventas VALUES (@idVenta,@idUsuario,@idSucursal,@cliente,@fecha,@subtotal,@iva,@total,@efectivo,@cambio)";
                cmd.Parameters.AddWithValue("@idVenta", this.IdVenta);
                cmd.Parameters.AddWithValue("@idUsuario", this.IdUsuario);    
                cmd.Parameters.AddWithValue("@idSucursal", this.IdSucursal);
                cmd.Parameters.AddWithValue("@cliente", this.Cliente);
                cmd.Parameters.AddWithValue("@fecha", this.Fecha);
                cmd.Parameters.AddWithValue("@subtotal", this.Subtotal);
                cmd.Parameters.AddWithValue("@iva", this.Iva);
                cmd.Parameters.AddWithValue("@total", this.Total);
                cmd.Parameters.AddWithValue("@efectivo", this.Efectivo);
                cmd.Parameters.AddWithValue("@cambio", this.Cambio);
                BaseDatos.conn.Open();
                cmd.ExecuteNonQuery();
                BaseDatos.conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BaseDatos.conn.Close();
            }

        }

        public void Editar()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = BaseDatos.conn;
                cmd.CommandText = "UPDATE Ventas SET idVenta=@idVenta,idUsuario=@idUsuario,idSucursal=@idSucursal,cliente=@cliente,fecha=@fecha,subtotal=@subtotal,iva=@iva,total=@total,efectivo=@efectivo,cambio=@cambio WHERE idVenta=@idVenta";
                cmd.Parameters.AddWithValue("@idVenta", this.IdVenta);
                cmd.Parameters.AddWithValue("@idUsuario", this.IdUsuario);
                cmd.Parameters.AddWithValue("@idSucursal", this.IdSucursal);
                cmd.Parameters.AddWithValue("@cliente", this.Cliente);
                cmd.Parameters.AddWithValue("@fecha", this.Fecha);
                cmd.Parameters.AddWithValue("@subtotal", this.Subtotal);
                cmd.Parameters.AddWithValue("@iva", this.Iva);
                cmd.Parameters.AddWithValue("@total", this.Total);
                cmd.Parameters.AddWithValue("@efectivo", this.Efectivo);
                cmd.Parameters.AddWithValue("@cambio", this.Cambio);
                BaseDatos.conn.Open();
                cmd.ExecuteNonQuery();
                BaseDatos.conn.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BaseDatos.conn.Close();
            }

        }

        public void Eliminar()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = BaseDatos.conn;
                cmd.CommandText = "DELETE FROM Ventas WHERE idVenta=@idVenta";
                cmd.Parameters.AddWithValue("@idVenta", this.IdVenta);
                BaseDatos.conn.Open();
                cmd.ExecuteNonQuery();
                BaseDatos.conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BaseDatos.conn.Close();
            }

        }

        public string Obtener()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = BaseDatos.conn;
                cmd.CommandText = "SELECT * FROM Ventas WHERE idVenta=@idVenta";
                cmd.Parameters.AddWithValue("@idVenta", this.IdVenta);
                BaseDatos.conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    this.IdVenta = Convert.ToInt32(dr["idVenta"].ToString());
                    this.IdUsuario = Convert.ToInt32(dr["idUsuario"].ToString());
                    this.IdSucursal = Convert.ToInt32(dr["idSucursal"].ToString());
                    this.Cliente = dr["cliente"].ToString();
                    this.Fecha = dr["fecha"].ToString();
                    this.Subtotal = Convert.ToInt32(dr["subtotal"].ToString());
                    this.Iva = Convert.ToInt32(dr["iva"].ToString());
                    this.Total = Convert.ToInt32(dr["total"].ToString());
                    this.Efectivo = Convert.ToInt32(dr["efectivo"].ToString());
                    this.Cambio = Convert.ToInt32(dr["cambio"].ToString());
                }
                BaseDatos.conn.Close();
                return this.IdUsuario + "|" + this.IdSucursal + "|" + this.Cliente + "|" + this.Fecha + "|" + this.Subtotal + "|" + this.Iva + "|" + this.Total + "|" + this.Efectivo + "|" + this.Cambio;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BaseDatos.conn.Close();
            }
        }

        public List<VentasClase> ObtenerListado()
        {
            List<VentasClase> lista = new List<VentasClase>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = BaseDatos.conn;
                cmd.CommandText = "SELECT * FROM Ventas";
                BaseDatos.conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                VentasClase p;
                while (dr.Read())
                {
                    p = new VentasClase();
                    p.IdVenta = Convert.ToInt32(dr["idVenta"].ToString());
                    p.IdUsuario = Convert.ToInt32(dr["idUsuario"].ToString());
                    p.IdSucursal = Convert.ToInt32(dr["idSucursal"].ToString());
                    p.Cliente = dr["cliente"].ToString();
                    p.Fecha = dr["fecha"].ToString();
                    p.Subtotal = Convert.ToDouble(dr["subtotal"].ToString());
                    p.Iva = Convert.ToDouble(dr["iva"].ToString());
                    p.Total = Convert.ToDouble(dr["total"].ToString());
                    p.Efectivo = Convert.ToDouble(dr["efectivo"].ToString());
                    p.Cambio = Convert.ToDouble(dr["cambio"].ToString());
                    lista.Add(p);
                }
                BaseDatos.conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BaseDatos.conn.Close();
            }
            return lista;
        }

        public List<VentasClase> ObtenerRangoFecha(string fecha1, string fecha2)
        {
            List<VentasClase> lista = new List<VentasClase>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = BaseDatos.conn;
                cmd.CommandText = "SELECT * FROM Ventas WHERE fecha BETWEEN @fecha1 and @fecha2";
                cmd.Parameters.AddWithValue("@fecha1", fecha1);
                cmd.Parameters.AddWithValue("@fecha2", fecha2);
                BaseDatos.conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                VentasClase p;
                while (dr.Read())
                {
                    p = new VentasClase();
                    p.IdVenta = Convert.ToInt32(dr["idVenta"].ToString());
                    p.IdUsuario = Convert.ToInt32(dr["idUsuario"].ToString());
                    p.IdSucursal = Convert.ToInt32(dr["idSucursal"].ToString());
                    p.Cliente = dr["cliente"].ToString();
                    p.Fecha = dr["fecha"].ToString();
                    p.Subtotal = Convert.ToInt32(dr["subtotal"].ToString());
                    p.Iva = Convert.ToInt32(dr["iva"].ToString());
                    p.Total = Convert.ToInt32(dr["total"].ToString());
                    p.Efectivo = Convert.ToInt32(dr["efectivo"].ToString());
                    p.Cambio = Convert.ToInt32(dr["cambio"].ToString());
                    lista.Add(p);
                }
                BaseDatos.conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BaseDatos.conn.Close();
            }
            return lista;
        }
    }
}
