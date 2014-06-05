using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Logica.ModeloADO;
using System.Data.Objects;
using System.Web;

namespace Logica
{
    public class SucursalesClase
    {   
        private int idSucursal;
        private string nombre;
        private string direccion;
        private string telefono;

        public int IdSucursal
        {
            get { return idSucursal; }
            set { idSucursal = value; }
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

        public void Guardar()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = BaseDatos.conn;
                cmd.CommandText = "INSERT INTO Sucursales VALUES (@nombre,@direccion,@telefono)";
                cmd.Parameters.AddWithValue("@nombre", this.Nombre);
                cmd.Parameters.AddWithValue("@direccion", this.Direccion);
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
                cmd.CommandText = "UPDATE Sucursales SET nombre=@nombre,direccion=@direccion,telefono=@telefono WHERE idSucursal=@idSucursal";
                cmd.Parameters.AddWithValue("@idSucursal", this.IdSucursal);
                cmd.Parameters.AddWithValue("@nombre", this.Nombre);
                cmd.Parameters.AddWithValue("@direccion", this.Direccion);
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
                cmd.CommandText = "DELETE FROM Sucursales WHERE idSucursal=@idSucursal";
                cmd.Parameters.AddWithValue("@idSucursal", this.IdSucursal);
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
                cmd.CommandText = "SELECT * FROM Sucursales WHERE idSucursal=@idSucursal";
                cmd.Parameters.AddWithValue("@idSucursal", this.IdSucursal);
                BaseDatos.conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    this.Nombre = dr["nombre"].ToString();
                    this.Direccion = dr["direccion"].ToString();
                    this.Telefono = dr["telefono"].ToString();
                }
                BaseDatos.conn.Close();
                return this.Nombre + "|" + this.Direccion + "|" + this.Telefono;
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

        public List<SucursalesClase> ObtenerListado()
        {
            List<SucursalesClase> lista = new List<SucursalesClase>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = BaseDatos.conn;
                cmd.CommandText = "SELECT * FROM Sucursales";
                BaseDatos.conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                SucursalesClase s;
                while (dr.Read())
                {
                    s = new SucursalesClase();
                    s.IdSucursal = Convert.ToInt32(dr["idSucursal"].ToString());
                    s.Nombre = dr["nombre"].ToString();
                    s.Direccion = dr["direccion"].ToString();
                    s.Telefono = dr["telefono"].ToString();
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
     

        /* ADO.NET que ya no quise implementar porque es todo un show!
         
        private int idSucursal;
        private string nombre;
        private string direccion;
        private string telefono;

        public int IdSucursal
        {
            get { return idSucursal; }
            set { idSucursal = value; }
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


        
        public void GuardarSucursalesADO()
        {
            try
            {
                DMarysDBEntities e = new DMarysDBEntities();
                Sucursale s = new Sucursale();
                s.nombre = this.Nombre;
                s.direccion = this.Direccion;
                s.telefono = this.Telefono;
                e.AddToSucursales(s);
                e.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EditarSucursalesADO(Sucursale suc)
        {
            try{
            DMarysDBEntities e = new DMarysDBEntities();
            Sucursale s = e.Sucursales.First(f=> f.idSucursal==suc.idSucursal);
            s.nombre = suc.nombre;
            s.direccion = suc.direccion;
            s.telefono = suc.telefono;
            e.SaveChanges();
            }catch(Exception ex){
                throw ex;
            }
        }

        public void EliminarSucursalesADO(int id) 
        {
            try{
            DMarysDBEntities e = new DMarysDBEntities();
            Sucursale s = e.Sucursales.ToList().Where(f=> f.idSucursal == id).First();
            e.DeleteObject(s);
            e.SaveChanges();
            }catch(Exception ex){
                throw ex;
            }
        }

        public string ObtenerSucursalADO(int id){
            try{
            DMarysDBEntities e = new DMarysDBEntities();
            Sucursale s = e.Sucursales.ToList().Where(f => f.idSucursal == id).First();
            this.Nombre=s.nombre;
            this.Direccion=s.direccion;
            this.Telefono=s.telefono;
            return this.Nombre + "|" + this.Direccion + "|" + this.Telefono;  
            }catch(Exception ex){
                throw ex;
            }
        }

        public static List<Sucursale> ListadoSucursalADO() {
            try
            {
                DMarysDBEntities e = new DMarysDBEntities();
                List<Sucursale> lista = e.Sucursales.ToList();
                return lista;
            }catch(Exception ex){
                throw ex;
            }
        }

        */ 
         
    }
}
