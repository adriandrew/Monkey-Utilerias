using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DMarysSoft.Providers
{
    public partial class AdministrarProveedores1 : System.Web.UI.Page
    {
        localhost.Servicio srv = new localhost.Servicio();
        protected void Page_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        void Cargar() {
            grvProveedores.DataSource = srv.ListadoProveedores();
            grvProveedores.DataBind();
        }

        void ReiniciarTxt() {
            txtNombreEmpresa.Text = string.Empty;
            txtDireccionEmpresa.Text = string.Empty;
            txtTelefonoEmpresa.Text = string.Empty;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ReiniciarTxt();grvProveedores.SelectedIndex = -1;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            localhost.ProveedoresClase p = new localhost.ProveedoresClase();
            p.Nombreempresa = txtNombreEmpresa.Text;
            p.Direccionempresa = txtDireccionEmpresa.Text;
            p.Telefonoempresa = txtTelefonoEmpresa.Text;

            if (!Convert.ToBoolean(Session["editar"]))
            {
                srv.GuardarProveedores(p);
            }
            else
            {
                p.Idproveedor = Convert.ToInt32(Session["id"]);
                srv.EditarProveedores(p);
                Session["editar"] = false;
                Session["id"] = 0;
                grvProveedores.SelectedIndex = -1;
            }
            ReiniciarTxt();
            Cargar(); 
        }

        protected void grvProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["id"] = grvProveedores.SelectedRow.Cells[2].Text;
            string[] datos = srv.ObtenerProveedores(Convert.ToInt32(Session["id"])).Split('|');
            txtNombreEmpresa.Text = datos[0];
            txtDireccionEmpresa.Text = datos[1];
            txtTelefonoEmpresa.Text = datos[2];
            Session["editar"] = true;
        }

        protected void grvProveedores_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = false;
            Session["id"] = grvProveedores.Rows[e.RowIndex].Cells[2].Text;
            srv.EliminarProveedores(Convert.ToInt32(Session["id"]));
            Cargar();
            ReiniciarTxt();
        }
    }
}