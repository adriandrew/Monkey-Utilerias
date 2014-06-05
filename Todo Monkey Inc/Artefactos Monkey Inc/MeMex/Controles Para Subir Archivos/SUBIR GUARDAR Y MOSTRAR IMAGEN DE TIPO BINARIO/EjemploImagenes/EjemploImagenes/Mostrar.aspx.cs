using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Data.SqlClient;


namespace EjemploImagenes
{
    public partial class Mostrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //el request va a llamar al id de tu tabla y va ser una comparacion para que extraiga la foto de lo que as ingresado :D
            //Mostramos la ImagenFile por pantalla
        string sql = "Select Foto From Tabla Where Idtabla = " + Request.QueryString["Id"];
        SqlConnection SqlConn = new SqlConnection("Data Source=KEN-PC\\SQLEXPRESS;Initial Catalog=Imagenes;Integrated Security=True");
        SqlCommand SqlCom = new SqlCommand(sql, SqlConn);

        SqlConn.Open();
        byte[] byteImage = (byte[])SqlCom.ExecuteScalar();
        //byte[] byteImage = (byte[])SqlCom.Ex();
        //SqlConn.Close();
     
        if (byteImage!= null)
        {
            Response.ContentType = "image/jpeg";
            Response.Expires = 0;
            Response.Buffer = true;
            Response.Clear();
            Response.BinaryWrite(byteImage);
            Response.End();
        }
        SqlConn.Close();
    }

        }
    }
