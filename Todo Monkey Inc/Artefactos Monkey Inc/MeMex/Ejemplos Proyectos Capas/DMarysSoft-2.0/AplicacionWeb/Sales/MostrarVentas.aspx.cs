using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DMarysSoft.localhost;
using System.Text;

namespace DMarysSoftWEB
{
    public partial class Formulario_web16 : System.Web.UI.Page
    {
        DMarysSoft.localhost.Servicio srv = new DMarysSoft.localhost.Servicio();
        protected void Page_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        void Cargar()
        {
            btnBuscar.Enabled = false;
            grvMostrarVentas.DataSource = srv.ListadoVentas();
            grvMostrarVentas.DataBind();
        }

        void Habilitar() {
            btnBuscar.Enabled = true;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (CalendarInicio.SelectedDate.ToString() != ("01/01/0001 0:00:00") & CalendarFin.SelectedDate.ToString() != ("01/01/0001 0:00:00"))
            {
                DMarysSoft.localhost.VentasClase s = new DMarysSoft.localhost.VentasClase();
                string fecha1 = CalendarInicio.SelectedDate.ToShortDateString();
                string fecha2 = CalendarFin.SelectedDate.ToShortDateString();
                grvMostrarVentas.DataSource = srv.ObtenerRangoFecha(fecha1, fecha2);
                grvMostrarVentas.DataBind();
            }
            else
            {
                Cargar();
            }
        }

        protected void CalendarInicio_SelectionChanged(object sender, EventArgs e)
        {
            Habilitar();
            txtFecha.Text = CalendarInicio.SelectedDate.ToString();
            //CalendarInicio.
        }

        protected void CalendarFin_SelectionChanged(object sender, EventArgs e)
        {
            Habilitar();
        }


    }
}