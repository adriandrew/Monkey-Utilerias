using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Serialization;
using Logica.ModeloADO;

namespace Logica
{
    public class ProveedoresClase
    {
        private int idProveedor;
        private string nombreEmpresa;
        private string direccionEmpresa;
        private string telefonoEmpresa;

        public int Idproveedor
        {
            get { return idProveedor; }
            set { idProveedor = value; }
        }
        public string Nombreempresa
        {
            get { return nombreEmpresa; }
            set { nombreEmpresa = value; }
        }
        public string Direccionempresa
        {
            get { return direccionEmpresa; }
            set { direccionEmpresa = value; }
        }
        public string Telefonoempresa
        {
            get { return telefonoEmpresa; }
            set { telefonoEmpresa = value; }
        }

        public void Guardar()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = BaseDatos.conn;
                cmd.CommandText = "INSERT INTO Proveedores VALUES (@nombreEmpresa,@direccionEmpresa,@telefonoEmpresa)";
                cmd.Parameters.AddWithValue("@nombreEmpresa", this.Nombreempresa);
                cmd.Parameters.AddWithValue("@direccionEmpresa", this.Direccionempresa);
                cmd.Parameters.AddWithValue("@telefonoEmpresa", this.Telefonoempresa);
                BaseDatos.conn.Open();
                cmd.ExecuteNonQuery();
                BaseDatos.conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally {
                BaseDatos.conn.Close();
            }

        }

        public void Editar()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = BaseDatos.conn;
                cmd.CommandText = "UPDATE Proveedores SET nombreEmpresa=@nombreEmpresa,direccionEmpresa=@direccionEmpresa,telefonoEmpresa=@telefonoEmpresa WHERE idProveedor=@idProveedor";
                cmd.Parameters.AddWithValue("@idProveedor", this.Idproveedor);
                cmd.Parameters.AddWithValue("@nombreEmpresa", this.Nombreempresa);
                cmd.Parameters.AddWithValue("@direccionEmpresa", this.Direccionempresa);
                cmd.Parameters.AddWithValue("@telefonoEmpresa", this.Telefonoempresa);
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
                cmd.CommandText = "DELETE FROM Proveedores WHERE idProveedor=@idProveedor";
                cmd.Parameters.AddWithValue("@idProveedor", this.Idproveedor);
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
                cmd.CommandText = "SELECT * FROM Proveedores WHERE idProveedor=@idProveedor";
                cmd.Parameters.AddWithValue("@idProveedor", this.Idproveedor);
                BaseDatos.conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    this.Nombreempresa = dr["nombreEmpresa"].ToString();
                    this.Direccionempresa = dr["direccionEmpresa"].ToString();
                    this.Telefonoempresa = dr["telefonoEmpresa"].ToString();
                }
                BaseDatos.conn.Close();
                return this.Nombreempresa + "|" + this.Direccionempresa + "|" + this.Telefonoempresa;
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

        public List<ProveedoresClase> ObtenerListado()
        {
            List<ProveedoresClase> lista = new List<ProveedoresClase>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = BaseDatos.conn;
                cmd.CommandText = "SELECT * FROM Proveedores";
                BaseDatos.conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                ProveedoresClase p;
                while (dr.Read())
                {
                    p = new ProveedoresClase();
                    p.Idproveedor = Convert.ToInt32(dr["idProveedor"].ToString());
                    p.Nombreempresa = dr["nombreEmpresa"].ToString();
                    p.Direccionempresa = dr["direccionEmpresa"].ToString();
                    p.Telefonoempresa = dr["telefonoEmpresa"].ToString();
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
