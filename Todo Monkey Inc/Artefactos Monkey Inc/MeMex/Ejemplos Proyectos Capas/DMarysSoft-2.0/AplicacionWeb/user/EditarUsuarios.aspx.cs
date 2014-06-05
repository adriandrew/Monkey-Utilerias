using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DMarysSoftWEB
{
    public partial class Formulario_web19 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvEditarUsuarios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try{
            //int indice = gvEditarUsuarios.SelectedIndex;
            //gvEditarUsuarios.SetEditRow(indice);


            //lblSeleccionado.Text = gvEditarUsuarios.SelectedRow.Cells[5].Text.ToString();
            //((BoundField)gvEditarUsuarios.Columns[5]).ReadOnly = false; 
            }catch(Exception ex){
            lblSeleccionado.Text = "No se debe editar el campo UserId, intentelo de nuevo!";
            }
        }

        protected void gvEditarUsuarios_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            try
            {
                //lblSeleccionado.Text = gvEditarUsuarios.SelectedRow.Cells[5].Text.ToString();
                //((BoundField)gvEditarUsuarios.Columns[5]).ReadOnly = false;

            }catch(Exception ex){
            lblSeleccionado.Text = "No se debe editar el campo UserId, intentelo de nuevo!";
            }
        }

        protected void gvEditarUsuarios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                //lblSeleccionado.Text = gvEditarUsuarios.SelectedRow.Cells[5].Text.ToString();
                //((BoundField)gvEditarUsuarios.Columns[5]).ReadOnly = false;

            }
            catch (Exception ex)
            {
                lblSeleccionado.Text = "No se debe editar el campo UserId, intentelo de nuevo!";
            }
        }

        
    }
}