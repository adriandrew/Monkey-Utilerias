using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Logica
{
    public class UsuariosClase
    {
        private int idUsuario;
        private int idSucursal;
        private string nombre;
        private string direccion;
        private string sexo;
        private string telefono;

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public string Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public int IdSucursal
        {
            get { return idSucursal; }
            set { idSucursal = value; }
        }

        public int IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }

        public void Guardar()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = BaseDatos.conn;
                cmd.CommandText = "INSERT INTO Usuarios VALUES(@nombre, @direccion, @sexo, @telefono)";
                cmd.Parameters.AddWithValue("@nombre", this.Nombre);
                cmd.Parameters.AddWithValue("@direccion", this.Direccion);
                cmd.Parameters.AddWithValue("@sexo", this.Sexo);
                cmd.Parameters.AddWithValue("@telefono", this.Telefono);
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
                cmd.CommandText = "UPDATE Usuarios SET nombre=@nombre, direccion=@direccion, sexo=@sexo, telefono=@telefono WHERE idUsuario)";
                cmd.Parameters.AddWithValue("@idUsuario", this.IdUsuario);
                cmd.Parameters.AddWithValue("@nombre", this.Nombre);
                cmd.Parameters.AddWithValue("@direccion", this.Direccion);
                cmd.Parameters.AddWithValue("@sexo", this.Sexo);
                cmd.Parameters.AddWithValue("@telefono", this.Telefono);
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
                cmd.CommandText = "DELETE FROM Usuarios WHERE idUsuario=@idUsuario";
                cmd.Parameters.AddWithValue("@idUsuario", this.IdUsuario);
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
                cmd.CommandText = "SELECT * FROM Usuarios WHERE idUsuario=@idUsuario";
                cmd.Parameters.AddWithValue("@idUsuario", this.IdUsuario);
                BaseDatos.conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    this.IdUsuario = Convert.ToInt32(dr["idUsuario"].ToString());
                    this.IdSucursal = Convert.ToInt32(dr["idSucursal"].ToString());
                    this.Nombre = dr["nombre"].ToString();
                    this.Direccion = dr["direccion"].ToString();
                    this.Sexo = dr["sexo"].ToString();
                    this.Telefono = dr["telefono"].ToString();
                }
                BaseDatos.conn.Close();
                return this.IdUsuario + "|" + this.IdSucursal + "|" + this.Nombre + "|" + this.Direccion + "|" + this.Sexo;
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

        public List<UsuariosClase> ObtenerListado()
        {
            List<UsuariosClase> lista = new List<UsuariosClase>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = BaseDatos.conn;
                cmd.CommandText = "SELECT * FROM Usuarios";
                BaseDatos.conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                UsuariosClase p;
                while (dr.Read())
                {
                    p = new UsuariosClase();
                    p.IdUsuario = Convert.ToInt32(dr["idUsuario"].ToString());
                    p.IdSucursal = Convert.ToInt32(dr["idSucursal"].ToString());
                    p.Nombre = dr["nombre"].ToString();
                    p.Direccion = dr["direccion"].ToString();
                    p.Sexo = dr["sexo"].ToString();
                    p.Telefono = dr["telefono"].ToString();
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
