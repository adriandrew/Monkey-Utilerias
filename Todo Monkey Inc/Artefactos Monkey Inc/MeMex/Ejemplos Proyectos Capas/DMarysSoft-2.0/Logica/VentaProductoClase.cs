using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Logica
{
    public class VentaProductoClase
    {
        private int idVentaProducto;
        private int idVenta;
        private int idProducto;
        private int cantidad;
        private float precioUnitario;
        private float importe;

        public int IdVentaProducto
        {
            get { return idVentaProducto; }
            set { idVentaProducto = value; }
        }

        public int IdVenta
        {
            get { return idVenta; }
            set { idVenta = value; }
        }

        public int IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public float PrecioUnitario
        {
            get { return precioUnitario; }
            set { precioUnitario = value; }
        }

        public float Importe
        {
            get { return importe; }
            set { importe = value; }
        }

        public void Guardar()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = BaseDatos.conn;
                cmd.CommandText = "INSERT INTO VentaProducto VALUES (@idVentaProducto,@idVenta,@idProducto,@cantidad,@precioUnitario,@importe)";
                cmd.Parameters.AddWithValue("@idVentaProducto", this.IdVentaProducto);
                cmd.Parameters.AddWithValue("@idVenta", this.IdVenta);
                cmd.Parameters.AddWithValue("@idProducto", this.IdProducto);
                cmd.Parameters.AddWithValue("@cantidad", this.Cantidad);
                cmd.Parameters.AddWithValue("@precioUnitario", this.PrecioUnitario);
                cmd.Parameters.AddWithValue("@importe", this.Importe);
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
                cmd.CommandText = "UPDATE VentaProducto SET idVenta=@idVenta,idProducto=@idProducto,cantidad=@cantidad,precioUnitario=@precioUnitario,importe=@importe WHERE idVentaProducto=@idVentaProducto";
                cmd.Parameters.AddWithValue("@idVentaProducto", this.IdVentaProducto);
                cmd.Parameters.AddWithValue("@idVenta", this.IdVenta);
                cmd.Parameters.AddWithValue("@idProducto", this.IdProducto);
                cmd.Parameters.AddWithValue("@cantidad", this.Cantidad);
                cmd.Parameters.AddWithValue("@precioUnitario", this.PrecioUnitario);
                cmd.Parameters.AddWithValue("@importe", this.Importe);
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
                cmd.CommandText = "DELETE FROM VentaProducto WHERE idVentaProducto=@idVentaProducto";
                cmd.Parameters.AddWithValue("@idVentaProducto", this.IdVentaProducto);
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
                cmd.CommandText = "SELECT * FROM VentaProducto WHERE idVentaProducto=@idVentaProducto";
                cmd.Parameters.AddWithValue("@idVentaProducto", this.IdVentaProducto);
                BaseDatos.conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    this.IdVentaProducto = Convert.ToInt32(dr["idVentaProducto"].ToString());
                    this.IdVenta = Convert.ToInt32(dr["idVenta"].ToString());
                    this.IdProducto = Convert.ToInt32(dr["idProducto"].ToString());
                    this.Cantidad = Convert.ToInt32(dr["cantidad"].ToString());
                    this.PrecioUnitario = Convert.ToInt32(dr["precioUnitario"].ToString());
                    this.Importe = Convert.ToInt32(dr["importe"].ToString());
                }
                BaseDatos.conn.Close();
                return this.IdVentaProducto + "|" + this.IdVenta + "|" + this.IdProducto + "|" + this.Cantidad + "|" + this.PrecioUnitario + "|" + this.Importe;
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

        public List<VentaProductoClase> ObtenerListado()
        {
            List<VentaProductoClase> lista = new List<VentaProductoClase>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = BaseDatos.conn;
                cmd.CommandText = "SELECT * FROM VentaProducto";
                BaseDatos.conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                VentaProductoClase p;
                while (dr.Read())
                {
                    p = new VentaProductoClase();
                    p.IdVentaProducto = Convert.ToInt32(dr["idVentaProducto"].ToString());
                    p.IdVenta = Convert.ToInt32(dr["idVenta"].ToString());
                    p.IdProducto = Convert.ToInt32(dr["idProducto"].ToString());
                    p.Cantidad = Convert.ToInt32(dr["cantidad"].ToString());
                    p.PrecioUnitario = Convert.ToInt32(dr["precioUnitario"].ToString());
                    p.Importe = Convert.ToInt32(dr["importe"].ToString());
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
