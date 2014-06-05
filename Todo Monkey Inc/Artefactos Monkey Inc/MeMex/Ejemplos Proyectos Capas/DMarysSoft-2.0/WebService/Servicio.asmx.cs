using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Logica;
using System.Data.Entity;

namespace WebService
{
    /// <summary>
    /// Descripción breve de Servicio
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Servicio : System.Web.Services.WebService
    {

        #region Metodos para Sucursales
        [WebMethod (Description="Metodo para guardar sucursales") ]
        public void GuardarSucursales(SucursalesClase s)
        {
            s.Guardar();
        }

        [WebMethod(Description = "Metodo para editar sucursales")]
        public void EditarSucursales(SucursalesClase s)
        {
            s.Editar();
        }

        [WebMethod(Description = "Metodo para eliminar sucursales")]
        public void EliminarSucursales(int id)
        {
            SucursalesClase s=new SucursalesClase();
            s.IdSucursal = id;
            s.Eliminar();
        }

        [WebMethod(Description = "Metodo para obtener una lista de elementos de sucursales mediante id")]
        public string ObtenerSucursales(int id)
        {
            SucursalesClase s = new SucursalesClase();
            s.IdSucursal = id;
            return s.Obtener();
        }

        [WebMethod(Description = "Metodo para obtener una lista de elementos de sucursales")]
        public List<SucursalesClase> ListadoSucursal()
        {
            SucursalesClase s=new SucursalesClase();
            return s.ObtenerListado();
        }
        #endregion 

        #region Metodos para Proveedores
        [WebMethod(Description = "Metodo para guardar proveedores")]
        public void GuardarProveedores(ProveedoresClase p)
        {
            p.Guardar();
        }

        [WebMethod(Description = "Metodo para editar proveedores")]
        public void EditarProveedores(ProveedoresClase p)
        {
            p.Editar();
        }

        [WebMethod(Description = "Metodo para eliminar proveedores")]
        public void EliminarProveedores(int id)
        {
            ProveedoresClase p = new ProveedoresClase();
            p.Idproveedor = id;
            p.Eliminar();
        }

        [WebMethod(Description = "Metodo para obtener una lista de elementos de proveedores mediante id")]
        public string ObtenerProveedores(int id)
        {
            ProveedoresClase p = new ProveedoresClase();
            p.Idproveedor = id;
            return p.Obtener();
        }

        [WebMethod(Description = "Metodo para obtener una lista de elementos de proveedores")]
        public List<ProveedoresClase> ListadoProveedores()
        {
            ProveedoresClase p = new ProveedoresClase();
            return p.ObtenerListado();
        }
        #endregion 

        #region Metodos para Productos
        [WebMethod(Description = "Metodo para guardar productos")]
        public void GuardarProductos(ProductosClase p)
        {
            p.Guardar();    
        }

        [WebMethod(Description = "Metodo para editar productos")]
        public void EditarProductos(ProductosClase p)
        {
            p.Editar();
        }

        [WebMethod(Description = "Metodo para eliminar productos")]
        public void EliminarProductos(string id)
        {
            ProductosClase p = new ProductosClase();
            p.CodigoProducto = id;
            p.Eliminar();
        }

        [WebMethod(Description = "Metodo para obtener una lista de elementos de productos mediante id")]
        public string ObtenerProductos(string id)
        {
            ProductosClase p = new ProductosClase();
            p.CodigoProducto = id;
            return p.Obtener();
        }

        [WebMethod(Description = "Metodo para obtener una lista de elementos de productos")]
        public List<ProductosClase> ListadoProductos()
        {
            ProductosClase p = new ProductosClase();
            return p.ObtenerListado();
        }

        [WebMethod(Description = "Metodo para obtener una lista de elementos de proveedores")]
        public List<ProveedoresClase> ListadoIdyProveedores()
        {
            ProductosClase p = new ProductosClase();
            return p.ObtenerIdyProveedores();
        }

        [WebMethod(Description = "Metodo para obtener una lista de elementos de sucursales")]
        public List<SucursalesClase> ListadoIdySucursales()
        {
            ProductosClase p = new ProductosClase();
            return p.ObtenerIdySucursales();
        }

        [WebMethod(Description = "Metodo para obtener una lista de elementos de sucursales")]
        public List<ProductosClase> ObtenerConLista(string id)
        {
            ProductosClase p = new ProductosClase();
            p.CodigoProducto = id;
            return p.ObtenerConLista();
        }
        #endregion 
        
        #region Metodos para Ventas
        [WebMethod(Description = "Metodo para guardar ventas")]
        public void GuardarVentas(VentasClase s)
        {
            s.Guardar();
        }

        [WebMethod(Description = "Metodo para editar ventas")]
        public void EditarVentas(VentasClase s)
        {
            s.Editar();
        }

        [WebMethod(Description = "Metodo para eliminar ventas")]
        public void EliminarVentas(int id)
        {
            VentasClase s = new VentasClase();
            s.IdVenta = id;
            s.Eliminar();
        }

        [WebMethod(Description = "Metodo para obtener una lista de elementos de ventas mediante id")]
        public string ObtenerVentas(int id)
        {
            VentasClase s = new VentasClase();
            s.IdVenta = id;
            return s.Obtener();
        }

        [WebMethod(Description = "Metodo para obtener una lista de elementos de sucursales")]
        public List<VentasClase> ListadoVentas()
        {
            VentasClase s = new VentasClase();
            return s.ObtenerListado();
        }

        [WebMethod(Description = "Metodo para obtener una lista de fechas")]
        public List<VentasClase> ObtenerRangoFecha(string fecha1, string fecha2)
        {
            VentasClase s = new VentasClase();
            return s.ObtenerRangoFecha(fecha1, fecha2);
        }
        #endregion 

        #region Metodos para Clientes
        [WebMethod(Description = "Metodo para guardar clientes")]
        public void GuardarClientes(ClientesClase c)
        {
            c.Guardar();
        }

        [WebMethod(Description = "Metodo para editar clientes")]
        public void EditarClientes(ClientesClase c)
        {
            c.Editar();
        }

        [WebMethod(Description = "Metodo para eliminar clientes")]
        public void EliminarClientes(int id)
        {
            ClientesClase c = new ClientesClase();
            c.IdCliente = id;
            c.Eliminar();
        }

        [WebMethod(Description = "Metodo para obtener una lista de clientes mediante un id")]
        public string ObtenerClientes(int id)
        {
            ClientesClase c = new ClientesClase();
            c.IdCliente = id;
            return c.Obtener();
        }

        [WebMethod(Description = "Metodo para obtener una lista de clientes")]
        public List<ClientesClase> ListadoClientes()
        {
            ClientesClase c = new ClientesClase();
            return c.ObtenerListado();
        }
        #endregion


    }
}