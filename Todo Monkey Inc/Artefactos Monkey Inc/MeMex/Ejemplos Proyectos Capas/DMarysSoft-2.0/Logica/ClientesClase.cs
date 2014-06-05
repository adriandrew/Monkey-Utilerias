using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Logica;

namespace Logica
{
    public class ClientesClase
    {

        private int idCliente;
        private string nombre;
        private string direccion;
        private string telefono;
        private string email;


        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }


        public void Guardar()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = BaseDatos.conn;
                cmd.CommandText = "INSERT INTO Clientes VALUES (@nombre, @direccion, @telefono, @email)";
                cmd.Parameters.AddWithValue("@nombre", this.Nombre);
                cmd.Parameters.AddWithValue("@direccion", this.Direccion);
                cmd.Parameters.AddWithValue("@telefono", this.Telefono);
                cmd.Parameters.AddWithValue("@email", this.Email);
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
            //Proveedores prod = new Proveedores();
            //prod.Nombreempresa;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = BaseDatos.conn;
                cmd.CommandText = "UPDATE Clientes SET nombre=@nombre,direccion=@direccion,telefono=@telefono WHERE idCliente=@idCliente";
                cmd.Parameters.AddWithValue("@idCliente", this.IdCliente);
                cmd.Parameters.AddWithValue("@nombre", this.Nombre);
                cmd.Parameters.AddWithValue("@direccion", this.Direccion);
                cmd.Parameters.AddWithValue("@telefono", this.Telefono);
                cmd.Parameters.AddWithValue("@email", this.Email);
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
                cmd.CommandText = "DELETE FROM Clientes WHERE idCliente=@idCliente";
                cmd.Parameters.AddWithValue("@idCliente", this.IdCliente);
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
                cmd.CommandText = "SELECT * FROM Clientes WHERE idCliente=@idCliente";
                cmd.Parameters.AddWithValue("@idCliente", this.IdCliente);
                BaseDatos.conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    this.Nombre = dr["nombre"].ToString();
                    this.Direccion = dr["direccion"].ToString();
                    this.Telefono = dr["telefono"].ToString();
                    this.Email = dr["email"].ToString();
                }
                BaseDatos.conn.Close();
                return this.Nombre + "|" + this.Direccion + "|" + this.Telefono + "|" + this.Email;
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

        public List<ClientesClase> ObtenerListado()
        {
            List<ClientesClase> lista = new List<ClientesClase>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = BaseDatos.conn;
                cmd.CommandText = "SELECT * FROM Clientes";
                BaseDatos.conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                ClientesClase c;
                while (dr.Read())
                {
                    c = new ClientesClase();
                    c.IdCliente = Convert.ToInt32(dr["idCliente"].ToString());
                    c.Nombre = dr["nombre"].ToString();
                    c.Direccion = dr["direccion"].ToString();
                    c.Telefono = dr["telefono"].ToString();
                    c.Email = dr["email"].ToString();
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
