using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DMarysSoft.localhost;
using System.Data;
using System.Text;

namespace DMarysSoft.Sales
{
    public partial class PuntoVenta : System.Web.UI.Page
    {
        localhost.Servicio srv = new localhost.Servicio();
        double valorIva = .16;


        protected void Page_Load(object sender, EventArgs e)
        {
            txtCodigoProducto.Focus();
        }

        protected void txtCodigoProducto_TextChanged(object sender, EventArgs e)
        {
            
        }

        void ReiniciarTxt(){
            txtCodigoProducto.Text = string.Empty;
            txtCambio.Text="0";
            txtIva.Text = string.Empty;
            txtRecibido.Text = string.Empty;
            txtTotal.Text = string.Empty;
            txtCodigoProducto.Enabled = true;

        }

        void NuevoRow() {
            DataTable dt = new DataTable();

            DataColumn Producto = new DataColumn("Producto", typeof(DropDownList));
            DataColumn Talla = new DataColumn("Talla", typeof(string));
            DataColumn Marca = new DataColumn("Marca", typeof(string));
            DataColumn Cantidad = new DataColumn("Cantidad", typeof(string));
            DataColumn Precio = new DataColumn("Precio", typeof(string));

            dt.Columns.AddRange(new DataColumn[] { Producto, Talla, Marca, Cantidad, Precio });

            dt.Rows.Add(new object[] { new DropDownList(), "", "", "", "" });
            grvPuntoVenta.DataSource = dt;
            grvPuntoVenta.DataBind();
        }

        void LimpiarGridView() {
            grvPuntoVenta.DataSource = null;
            grvPuntoVenta.DataBind();
        }

        private void AddNewRowToGrid()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //extract the TextBox values
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    grvPuntoVenta.DataSource = dtCurrentTable;
                    grvPuntoVenta.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }

            //Set Previous Data on Postbacks
            //SetPreviousData();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            double recibido=Convert.ToDouble(txtRecibido.Text);

            string[] datos = srv.ObtenerProductos(txtCodigoProducto.Text).Split('|');
            if (datos[4].Equals("0") || datos[4].Equals("-1"))
            {
                string strMessage = "!El stock es 0, no puedes vender este producto!"; StringBuilder sb = new StringBuilder("");
                sb.Append("<script language='javascript'>"); sb.AppendFormat("confirm(\"{0}\");", strMessage);
                sb.Append("</script>"); Page.RegisterClientScriptBlock("AlertScript", sb.ToString());
            }
            else
            {

                grvPuntoVenta.DataSource = srv.ObtenerConLista(txtCodigoProducto.Text);
                grvPuntoVenta.DataBind();

                double precio = Convert.ToDouble(datos[5]);
                double iva = precio * valorIva;
                txtIva.Text = iva.ToString();
                double total = iva + precio;
                txtTotal.Text = total.ToString();
                txtCodigoProducto.Enabled = false;

                if (recibido < total)
                {
                    txtCambio.Text = "Recibido menor a Precio";
                }
                else
                {
                    txtCambio.Text = (total - recibido).ToString();
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarGridView();
            ReiniciarTxt();
        }

        protected void btnCobrar_Click(object sender, EventArgs e)
        {
            if (txtCambio.Text.Equals("Recibido menor a Precio"))
            {
                txtRecibido.Focus();
            }
            else {
                string[] datos = srv.ObtenerProductos(txtCodigoProducto.Text).Split('|');

                localhost.ProductosClase p = new localhost.ProductosClase();
                p.CodigoProducto = datos[0];
                p.IdProveedor=Convert.ToInt32(datos[1]);
                p.IdSucursal=Convert.ToInt32(datos[2]);
                p.Descripcion = datos[3];
                p.Precio = Convert.ToDouble(datos[5]);
                p.Talla = datos[6];
                p.Modelo = datos[7];
                p.Color = datos[8];
                p.Marca = datos[9];
                p.Estilo = datos[10];
                p.Sexo = datos[11];
                p.Descuento = Convert.ToDouble(datos[12]);
                p.FechaIngreso = Convert.ToDateTime(datos[13]);
                int valorStock=Convert.ToInt32(datos[4]);
                valorStock=valorStock - 1;
                p.Stock = valorStock;
                srv.EditarProductos(p);
                LimpiarGridView();
                ReiniciarTxt();

            }

        }

       
    }
}