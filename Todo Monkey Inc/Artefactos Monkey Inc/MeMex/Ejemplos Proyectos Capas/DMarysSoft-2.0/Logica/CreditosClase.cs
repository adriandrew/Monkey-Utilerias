using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Logica
{
    public class CreditosClase
    {

        private int idCredito;
        private int idCliente;
        private int idUsuario;
        private double montoInicial;
        private double intereses;
        private double montoActual;

        public int IdCredito
        {
            get { return idCredito; }
            set { idCredito = value; }
        }
        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }
        public int IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }
        public double MontoInicial
        {
            get { return montoInicial; }
            set { montoInicial = value; }
        }
        public double Intereses
        {
            get { return intereses; }
            set { intereses = value; }
        }
        public double MontoActual
        {
            get { return montoActual; }
            set { montoActual = value; }
        }


        public void Guardar()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = BaseDatos.conn;
                cmd.CommandText = "INSERT INTO Creditos VALUES (@idCliente, @idUsuario, @montoInicial, @intereses, @montoActual)";
                cmd.Parameters.AddWithValue("@idCliente", this.IdCliente);
                cmd.Parameters.AddWithValue("@idUsuario", this.IdUsuario);
                cmd.Parameters.AddWithValue("@montoInicial", this.MontoInicial);
                cmd.Parameters.AddWithValue("@intereses", this.Intereses);
                cmd.Parameters.AddWithValue("@montoActual", this.MontoActual);
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
                cmd.CommandText = "UPDATE Creditos SET idCliente=@idCliente,idUsuario=@idUsuario,montoInicial=@montoInicial, intereses=@intereses, montoActual=@montoActual WHERE idCredito=@idCredito";
                cmd.Parameters.AddWithValue("@idCredito", this.IdCredito);
                cmd.Parameters.AddWithValue("@idCliente", this.IdCliente);
                cmd.Parameters.AddWithValue("@idUsuario", this.IdUsuario);
                cmd.Parameters.AddWithValue("@montoInicial", this.MontoInicial);
                cmd.Parameters.AddWithValue("@intereses", this.Intereses);
                cmd.Parameters.AddWithValue("@montoActual", this.MontoActual);
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
                cmd.CommandText = "DELETE FROM Creditos WHERE idCredito=@idCredito";
                cmd.Parameters.AddWithValue("@idCredito", this.IdCredito);
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
                cmd.CommandText = "SELECT * FROM Creditos WHERE idCredito=@idCredito";
                cmd.Parameters.AddWithValue("@idCredito", this.IdCredito);
                BaseDatos.conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    this.IdCliente = Convert.ToInt32(dr["idCliente"].ToString());
                    this.IdUsuario = Convert.ToInt32(dr["idUsuario"].ToString());
                    this.MontoInicial = Convert.ToInt32(dr["montoInicial"].ToString());
                    this.Intereses = Convert.ToInt32(dr["intereses"].ToString());
                    this.MontoActual = Convert.ToInt32(dr["montoActual"].ToString());
                }
                BaseDatos.conn.Close();
                return this.IdCliente + "|" + this.IdUsuario + "|" + this.MontoInicial + "|" + this.Intereses + "|" + this.MontoActual;
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

        public List<CreditosClase> ObtenerListado()
        {
            List<CreditosClase> lista = new List<CreditosClase>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = BaseDatos.conn;
                cmd.CommandText = "SELECT * FROM Creditos";
                BaseDatos.conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                CreditosClase c;
                while (dr.Read())
                {
                    c = new CreditosClase();
                    c.IdCredito = Convert.ToInt32(dr["idCredito"].ToString());
                    c.IdCliente = Convert.ToInt32(dr["idCliente"].ToString());
                    c.IdUsuario = Convert.ToInt32(dr["idUsuario"].ToString());
                    c.MontoInicial = Convert.ToDouble(dr["montoInicial"].ToString());
                    c.Intereses = Convert.ToDouble(dr["intereses"].ToString());
                    c.MontoActual = Convert.ToDouble(dr["montoActual"].ToString());
                    lista.Add(c);
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
