using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Logica.ModeloADO;

namespace Logica
{
    public class ProductosClase
    {   
        private string codigoProducto;
        public int idProveedor;
        public int idSucursal;
        public string descripcion;
        public int stock;
        public double precio;
        public string talla;
        public string modelo;
        public string color;
        public string marca;
        public string estilo;
        public string sexo;
        public double descuento;
        public DateTime fechaIngreso;

        public string CodigoProducto
        {
            get { return codigoProducto; }
            set { codigoProducto = value; }
        }
        public int IdProveedor
        {
            get { return idProveedor; }
            set { idProveedor = value; }
        }
        public int IdSucursal
        {
            get { return idSucursal; }
            set { idSucursal = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }
        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        public string Talla
        {
            get { return talla; }
            set { talla = value; }
        }
        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }
        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }
        public string Estilo
        {
            get { return estilo; }
            set { estilo = value; }
        }
        public string Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }
        public double Descuento
        {
            get { return descuento; }
            set { descuento = value; }
        }
        public DateTime FechaIngreso
        {
            get { return fechaIngreso; }
            set { fechaIngreso = value; }
        }

        public void Guardar()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = BaseDatos.conn;
                cmd.CommandText = "INSERT INTO Productos VALUES (@codigoProducto,@idProveedor,@idSucursal,@descripcion,@stock,@precio,@talla,@modelo,@color,@marca,@estilo,@sexo,@descuento,@fechaIngreso)";
                cmd.Parameters.AddWithValue("@codigoProducto", this.CodigoProducto);
                cmd.Parameters.AddWithValue("@idProveedor", this.IdProveedor);
                cmd.Parameters.AddWithValue("@idSucursal", this.IdSucursal);
                cmd.Parameters.AddWithValue("@descripcion", this.Descripcion);
                cmd.Parameters.AddWithValue("@stock", this.Stock);
                cmd.Parameters.AddWithValue("@precio", this.Precio);
                cmd.Parameters.AddWithValue("@talla", this.Talla);
                cmd.Parameters.AddWithValue("@modelo", this.Modelo);
                cmd.Parameters.AddWithValue("@color", this.Color);
                cmd.Parameters.AddWithValue("@marca", this.Marca);
                cmd.Parameters.AddWithValue("@estilo", this.Estilo);
                cmd.Parameters.AddWithValue("@sexo", this.Sexo);
                cmd.Parameters.AddWithValue("@descuento", this.Descuento);
                cmd.Parameters.AddWithValue("@fechaIngreso", this.FechaIngreso);
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
                cmd.CommandText = "UPDATE Productos SET idProveedor=@idProveedor,idSucursal=@idSucursal,descripcion=@descripcion,stock=@stock,precio=@precio,talla=@talla,modelo=@modelo,color=@color,marca=@marca,estilo=@estilo,sexo=@sexo,descuento=@descuento,fechaIngreso=@fechaIngreso WHERE codigoProducto=@codigoProducto";
                cmd.Parameters.AddWithValue("@codigoProducto", this.CodigoProducto);
                cmd.Parameters.AddWithValue("@idProveedor", this.IdProveedor);
                cmd.Parameters.AddWithValue("@idSucursal", this.IdSucursal);
                cmd.Parameters.AddWithValue("@descripcion", this.Descripcion);
                cmd.Parameters.AddWithValue("@stock", this.Stock);
                cmd.Parameters.AddWithValue("@precio", this.Precio);
                cmd.Parameters.AddWithValue("@talla", this.Talla);
                cmd.Parameters.AddWithValue("@modelo", this.Modelo);
                cmd.Parameters.AddWithValue("@color", this.Color);
                cmd.Parameters.AddWithValue("@marca", this.Marca);
                cmd.Parameters.AddWithValue("@estilo", this.Estilo);
                cmd.Parameters.AddWithValue("@sexo", this.Sexo);
                cmd.Parameters.AddWithValue("@descuento", this.Descuento);
                cmd.Parameters.AddWithValue("@fechaIngreso", this.FechaIngreso);
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
                cmd.CommandText = "DELETE FROM Productos WHERE codigoProducto=@codigoProducto";
                cmd.Parameters.AddWithValue("@codigoProducto", this.CodigoProducto);
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
                cmd.CommandText = "SELECT * FROM Productos WHERE codigoProducto=@codigoProducto";
                cmd.Parameters.AddWithValue("@codigoProducto", this.CodigoProducto);
                BaseDatos.conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    this.CodigoProducto = dr["codigoProducto"].ToString();
                    this.IdProveedor = Convert.ToInt32(dr["idProveedor"].ToString());
                    this.IdSucursal = Convert.ToInt32(dr["idSucursal"].ToString());
                    this.Descripcion = dr["descripcion"].ToString();
                    this.Stock = Convert.ToInt32(dr["stock"].ToString());
                    this.Precio = Convert.ToDouble(dr["precio"].ToString());
                    this.Talla = dr["talla"].ToString();
                    this.Modelo = dr["modelo"].ToString();
                    this.Color = dr["color"].ToString();
                    this.Marca = dr["marca"].ToString();
                    this.Estilo = dr["estilo"].ToString();
                    this.Sexo = dr["sexo"].ToString();
                    this.Descuento = Convert.ToDouble(dr["descuento"].ToString());
                    this.FechaIngreso = Convert.ToDateTime(dr["fechaIngreso"].ToString());
                }

                return this.CodigoProducto + "|" + this.IdProveedor + "|" + this.IdSucursal + "|" + this.Descripcion + "|" + this.Stock + "|" + this.Precio + "|" + this.Talla + "|" + this.Modelo + "|" + this.Color + "|" + this.Marca + "|" + this.Estilo + "|" + this.Sexo + "|" + this.Descuento + "|" + this.FechaIngreso + "|";
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

        public List<ProductosClase> ObtenerConLista()
        {
            List<ProductosClase> lista = new List<ProductosClase>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = BaseDatos.conn;
                cmd.CommandText = "SELECT * FROM Productos WHERE codigoProducto=@codigoProducto";
                cmd.Parameters.AddWithValue("@codigoProducto", this.CodigoProducto);
                BaseDatos.conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                ProductosClase p;
                while (dr.Read())
                {
                    p = new ProductosClase();
                    p.CodigoProducto = dr["codigoProducto"].ToString();
                    p.IdProveedor = Convert.ToInt32(dr["idProveedor"].ToString());
                    p.IdSucursal = Convert.ToInt32(dr["idSucursal"].ToString());
                    p.Descripcion = dr["descripcion"].ToString();
                    p.Stock = Convert.ToInt32(dr["stock"].ToString());
                    p.Precio = Convert.ToDouble(dr["precio"].ToString());
                    p.Talla = dr["talla"].ToString();
                    p.Modelo = dr["modelo"].ToString();
                    p.Color = dr["color"].ToString();
                    p.Marca = dr["marca"].ToString();
                    p.Estilo = dr["estilo"].ToString();
                    p.Sexo = dr["sexo"].ToString();
                    p.Descuento = Convert.ToDouble(dr["descuento"].ToString());
                    p.FechaIngreso = Convert.ToDateTime(dr["fechaIngreso"].ToString());
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
          
        public List<ProductosClase> ObtenerListado()
        {
            List<ProductosClase> lista = new List<ProductosClase>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = BaseDatos.conn;
                cmd.CommandText = "SELECT * FROM Productos";
                BaseDatos.conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                ProductosClase p;
                while (dr.Read())
                {
                    p = new ProductosClase();
                    p.CodigoProducto = dr["codigoProducto"].ToString();
                    p.IdProveedor = Convert.ToInt32(dr["idProveedor"].ToString());
                    p.IdSucursal = Convert.ToInt32(dr["idSucursal"].ToString());
                    p.Descripcion = dr["descripcion"].ToString();
                    p.Stock = Convert.ToInt32(dr["stock"].ToString());
                    p.Precio = Convert.ToDouble(dr["precio"].ToString());
                    p.Talla = dr["talla"].ToString();
                    p.Modelo = dr["modelo"].ToString();
                    p.Color = dr["color"].ToString();
                    p.Marca = dr["marca"].ToString();
                    p.Estilo = dr["estilo"].ToString();
                    p.Sexo = dr["sexo"].ToString();
                    p.Descuento = Convert.ToDouble(dr["descuento"].ToString());
                    p.FechaIngreso = Convert.ToDateTime(dr["fechaIngreso"].ToString());
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

        public List<ProveedoresClase> ObtenerIdyProveedores()
        {
            List<ProveedoresClase> lista = new List<ProveedoresClase>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = BaseDatos.conn;
                cmd.CommandText = "SELECT idProveedor, nombreEmpresa FROM Proveedores";
                BaseDatos.conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                ProveedoresClase p;
                while (dr.Read())
                {
                    p = new ProveedoresClase();
                    p.Idproveedor = Convert.ToInt32(dr["idProveedor"].ToString());
                    p.Nombreempresa = dr["nombreEmpresa"].ToString();
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

        public List<SucursalesClase> ObtenerIdySucursales()
        {
            List<SucursalesClase> lista = new List<SucursalesClase>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = BaseDatos.conn;
                cmd.CommandText = "SELECT idSucursal, nombre FROM Sucursales";
                BaseDatos.conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                SucursalesClase s;
                while (dr.Read())
                {
                    s = new SucursalesClase();
                    s.IdSucursal = Convert.ToInt32(dr["idSucursal"].ToString());
                    s.Nombre = dr["nombre"].ToString();
                    lista.Add(s);
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
