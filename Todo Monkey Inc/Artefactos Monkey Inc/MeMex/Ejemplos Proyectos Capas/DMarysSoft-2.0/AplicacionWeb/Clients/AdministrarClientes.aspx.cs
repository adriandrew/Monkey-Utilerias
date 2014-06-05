using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DMarysSoft.localhost;

namespace DMarysSoft.Clients
{
    public partial class AdministrarClientes : System.Web.UI.Page
    {
        localhost.Servicio srv = new localhost.Servicio();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        void Cargar()
        {
            grvCliente.DataSource = srv.ListadoClientes();
            grvCliente.DataBind();
        }

        void ReiniciarTxt()
        {
            txtNombre.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            localhost.ClientesClase c = new localhost.ClientesClase();
            c.Nombre = txtNombre.Text;
            c.Direccion = txtDireccion.Text;
            c.Telefono = txtTelefono.Text;
            c.Email = txtEmail.Text;

            if (!Convert.ToBoolean(Session["editar"]))
            {
                srv.GuardarClientes(c);
            }
            else
            {
                c.IdCliente = Convert.ToInt32(Session["id"]);
                srv.EditarClientes(c);
                Session["editar"] = false;
                Session["id"] = 0;
                grvCliente.SelectedIndex = -1;
            }
            ReiniciarTxt();
            Cargar();
        }

        protected void grvCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["id"] = grvCliente.SelectedRow.Cells[2].Text;
            string[] datos = srv.ObtenerClientes(Convert.ToInt32(Session["id"])).Split('|');
            txtNombre.Text = datos[0];
            txtDireccion.Text = datos[1];
            txtTelefono.Text = datos[2];
            txtEmail.Text = datos[3];
            Session["editar"] = true;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ReiniciarTxt();
        }

        protected void grvCliente_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = false;
            Session["id"] = grvCliente.Rows[e.RowIndex].Cells[2].Text;
            srv.EliminarClientes(Convert.ToInt32(Session["id"]));
            Cargar();
        }
   

    }
}