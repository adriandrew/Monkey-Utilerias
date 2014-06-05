using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace DMarysSoftWEB
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            string sesion = User.Identity.IsAuthenticated.ToString();
            if (sesion.Equals("False"))
            {
                LinkButtonRegresar.Visible=false;
                ImageProhibido.Visible = false;
            }

        }

    }
}