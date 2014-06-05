using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DMarysSoft.Offices
{
    public partial class AdministrarSucursales : System.Web.UI.Page
    {
        localhost.Servicio srv = new localhost.Servicio();

        protected void Page_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        void Cargar() { 
           grvSucursales.DataSource=srv.ListadoSucursal(); 
           grvSucursales.DataBind();
        }

        void ReiniciarTxt() {
            txtNombre.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefono.Text = string.Empty;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            localhost.SucursalesClase s = new localhost.SucursalesClase();
            s.Nombre = txtNombre.Text;
            s.Direccion = txtDireccion.Text;
            s.Telefono = txtTelefono.Text;
            
            if (!Convert.ToBoolean(Session["editar"]))
            {
                srv.GuardarSucursales(s);
            }
            else {
                s.IdSucursal = Convert.ToInt32(Session["id"]);
                srv.EditarSucursales(s);
                Session["editar"] = false;
                Session["id"] = 0;
                grvSucursales.SelectedIndex = -1; 
            }
            ReiniciarTxt();
            Cargar();
        }

        protected void grvSucursales_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["id"] = grvSucursales.SelectedRow.Cells[2].Text;
            string[] datos = srv.ObtenerSucursales(Convert.ToInt32(Session["id"])).Split('|');
            txtNombre.Text = datos[0];
            txtDireccion.Text = datos[1];
            txtTelefono.Text = datos[2];
            Session["editar"] = true;
        }

        protected void grvSucursales_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = false;
            Session["id"] = grvSucursales.Rows[e.RowIndex].Cells[2].Text;
            srv.EliminarSucursales(Convert.ToInt32(Session["id"]));
            Cargar();
            ReiniciarTxt();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ReiniciarTxt(); grvSucursales.SelectedIndex = -1;
        }


    }
}