using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DMarysSoft.localhost;
using System.Text;

namespace DMarysSoft.Orders
{
    public partial class AdministrarPedidos : System.Web.UI.Page
    {
        localhost.Servicio srv=new localhost.Servicio();
        bool idRepetido=false;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Cargar();

            // Se rellena DropDownList ddlProveedor
            if (ddlProveedor.Items.Count == 0)
            {
                RellenarDdlProveedores();
            } // Se rellena DropDownList ddlSucursal
            if(ddlSucursal.Items.Count == 0){
                RellenarDdlSucursales();
            }
        }

        void Cargar() {
            //ProveedoresClase[] lista = srv.ListadoIdyProveedores();

            grvPedidos.DataSource = srv.ListadoProductos();
            grvPedidos.DataBind();

            /*
            int i = Convert.ToInt32(ddlProveedor.SelectedIndex.ToString());
            lblProveedor.Text = lista[i].Idproveedor.ToString();
            grvPrueba.DataSource = lista;
            grvPrueba.DataBind();
            int id=Convert.ToInt32(grvPrueba.SelectedRow.Cells[0].Text);
            grvPrueba.Visible=false;
            
            for (int i=0; i <= lista.Length-1; i++)
            {
                ddlProveedor.Items.Add(lista[i].Nombreempresa.ToString());
            }

            lblSucursal.Text = "Id Sucursal: ";
            lblProveedor.Text = "Id Proveedor: "+ ddlProveedor.SelectedValue.ToString(); 
            */
        }

        void RellenarDdlProveedores() {
            ddlProveedor.DataSource = srv.ListadoIdyProveedores();
            ddlProveedor.DataTextField = "nombreEmpresa";
            ddlProveedor.DataValueField = "idProveedor";
            ddlProveedor.DataBind();
        }

        void RellenarDdlSucursales()
        {
            ddlSucursal.DataSource = srv.ListadoIdySucursales();
            ddlSucursal.DataTextField = "nombre";
            ddlSucursal.DataValueField = "idSucursal";
            ddlSucursal.DataBind();
        }

        void ReiniciarTxt() {
            txtCodigoProducto.Text = string.Empty;
            txtColor.Text = string.Empty;
            txtDescuento.Text = "0";
            txtEstilo.Text = string.Empty;
            txtMarca.Text = string.Empty;
            txtModelo.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtStock.Text = string.Empty;
            txtTalla.Text = string.Empty;
            ddlProveedor.SelectedIndex = 0;
            ddlSexo.SelectedIndex=0;
            ddlSucursal.SelectedIndex = 0;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            /* Esto sirve para validar que no haya entradas diferentes a numeros en el campo ID del Registro Interno.
            txtID.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            int Result = 0;
            if (!int.TryParse(txtID.Text, out Result))
            {
                txtID.Text = "";
            }*/


            localhost.ProductosClase p = new localhost.ProductosClase();
            ProductosClase[] listaProductos = srv.ListadoProductos();

            p.IdProveedor = Convert.ToInt32(ddlProveedor.SelectedValue.ToString());
            p.IdSucursal = Convert.ToInt32(ddlSucursal.SelectedValue.ToString());
            p.Descripcion = txtDescripcion.Text;
            p.Stock = Convert.ToInt32(txtStock.Text);
            p.Precio = Convert.ToDouble(txtPrecio.Text);
            p.Talla = txtTalla.Text;
            p.Modelo = txtModelo.Text;
            p.Color = txtColor.Text;
            p.Marca = txtMarca.Text;
            p.Estilo = txtEstilo.Text;
            p.Sexo = ddlSexo.SelectedValue;
            p.Descuento = Convert.ToDouble(txtDescuento.Text);
            p.FechaIngreso = Convert.ToDateTime(DateTime.Now.ToLongDateString());

           
            if (!Convert.ToBoolean(Session["editar"]))
            {
                for (int i = 0; i < listaProductos.Length; i++ )
                {
                    if (listaProductos[i].CodigoProducto.ToString().Equals(txtCodigoProducto.Text))
                    {
                        //Response.Write("<script>alert('!El codigoProducto esta duplicado!')</script>");
                        string strMessage = "!El codigoProducto esta duplicado!"; StringBuilder sb = new StringBuilder("");
                        sb.Append("<script language='javascript'>"); sb.AppendFormat("confirm(\"{0}\");", strMessage);
                        sb.Append("</script>"); Page.RegisterClientScriptBlock("AlertScript", sb.ToString());
                        idRepetido = true;
                    }
                }
                    
                    if(idRepetido==false){
                        p.CodigoProducto = txtCodigoProducto.Text;
                        srv.GuardarProductos(p);
                    }

                
            }
            else
            {
                p.CodigoProducto = Convert.ToString(Session["id"]);
                srv.EditarProductos(p);
                Session["editar"] = false;
                Session["id"] = 0;
                grvPedidos.SelectedIndex = -1;
            }
            txtCodigoProducto.Enabled = true;
            ReiniciarTxt();
            Cargar();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ReiniciarTxt(); txtCodigoProducto.Enabled = true;
            Cargar(); grvPedidos.SelectedIndex = -1;
        }

        protected void grvPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {

            Session["id"] = grvPedidos.SelectedRow.Cells[2].Text;
            string[] datos = srv.ObtenerProductos(Convert.ToString(Session["id"])).Split('|');
            txtCodigoProducto.Text=datos[0];
            RellenarDdlProveedores();
            //ddlProveedor.SelectedValue=datos[1];
            RellenarDdlSucursales();
            //ddlSucursal.SelectedValue = datos[2];
            txtDescripcion.Text = datos[3];
            txtStock.Text = datos[4];
            txtPrecio.Text = datos[5];
            txtTalla.Text = datos[6];
            txtModelo.Text = datos[7];
            txtColor.Text = datos[8];
            txtMarca.Text = datos[9];
            txtEstilo.Text = datos[10];
            ddlSexo.SelectedValue=datos[11];
            txtDescuento.Text = datos[12];
            Session["editar"] = true;

            txtCodigoProducto.Enabled = false;
        }

        protected void grvPedidos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = false;
            Session["id"] = grvPedidos.Rows[e.RowIndex].Cells[2].Text;
            srv.EliminarProductos(Convert.ToString(Session["id"]));
            Cargar();
        }

    }
}