using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Logica
{
    public class DetalleCreditoClase
    {

        private int idDetalleCredito;
        private int idCredito;
        private double abono;
        private DateTime fecha;

        public int IdDetalleCredito
        {
            get { return idDetalleCredito; }
            set { idDetalleCredito = value; }
        }
        public int IdCredito
        {
            get { return idCredito; }
            set { idCredito = value; }
        }
        public double Abono
        {
            get { return abono; }
            set { abono = value; }
        }
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }


        public void Guardar()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = BaseDatos.conn;
                cmd.CommandText = "INSERT INTO DetalleCredito VALUES (@idCredito, @abono, @fecha)";
                cmd.Parameters.AddWithValue("@idCredito", this.IdCredito);
                cmd.Parameters.AddWithValue("@abono", this.Abono);
                cmd.Parameters.AddWithValue("@fecha", this.Fecha);
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
                cmd.CommandText = "UPDATE DetalleCredito SET idCredito=@idCredito,abono=@abono,fecha=@fecha WHERE idDetalleCredito=@idDetalleCredito";
                cmd.Parameters.AddWithValue("@idDetalleCredito", this.IdDetalleCredito);
                cmd.Parameters.AddWithValue("@idCredito", this.IdCredito);
                cmd.Parameters.AddWithValue("@abono", this.Abono);
                cmd.Parameters.AddWithValue("@fecha", this.Fecha);
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
                cmd.CommandText = "DELETE FROM DetalleCredito WHERE idDetalleCredito=@idDetalleCredito";
                cmd.Parameters.AddWithValue("@idDetalleCredito", this.IdDetalleCredito);
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
                cmd.CommandText = "SELECT * FROM DetalleCredito WHERE idDetalleCredito=@idDetalleCredito";
                cmd.Parameters.AddWithValue("@idDetalleCredito", this.IdDetalleCredito);
                BaseDatos.conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    this.IdDetalleCredito = Convert.ToInt32(dr["idDetalleCredito"].ToString());
                    this.IdCredito = Convert.ToInt32(dr["idCredito"].ToString());
                    this.Abono = Convert.ToDouble(dr["abono"].ToString());
                    this.Fecha = Convert.ToDateTime(dr["fecha"].ToString());
                }
                BaseDatos.conn.Close();
                return this.IdDetalleCredito + "|" + this.IdCredito + "|" + this.Abono + "|" + this.Fecha;
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

        public List<DetalleCreditoClase> ObtenerListado()
        {
            List<DetalleCreditoClase> lista = new List<DetalleCreditoClase>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = BaseDatos.conn;
                cmd.CommandText = "SELECT * FROM DetalleCredito";
                BaseDatos.conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DetalleCreditoClase dc;
                while (dr.Read())
                {
                    dc = new DetalleCreditoClase();
                    dc.IdDetalleCredito = Convert.ToInt32(dr["idDetalleCredito"].ToString());
                    dc.IdCredito = Convert.ToInt32(dr["idCredito"].ToString());
                    dc.Abono = Convert.ToDouble(dr["abono"].ToString());
                    dc.Fecha = Convert.ToDateTime(dr["fecha"].ToString());
                    lista.Add(dc);
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
