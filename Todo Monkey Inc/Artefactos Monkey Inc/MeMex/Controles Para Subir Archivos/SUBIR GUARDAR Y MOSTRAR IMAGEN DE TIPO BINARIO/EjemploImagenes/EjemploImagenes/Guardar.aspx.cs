using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace EjemploImagenes
{
    public partial class Guardar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           //ahora a compilar cruzen los dedos jajajjaa
            //bueno ahora ay que verificar pues no cres ?????  :D
            //disculpa la cara de borracho jajaja no es de sueño ya era tarde pues :D
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
                    // Comprobamos que existe fichero y que no esta vacio
        if ((ImagenFile.PostedFile != null) && (ImagenFile.PostedFile.ContentLength > 0))
        {
            //obtener archivos subidos
            HttpPostedFile ImgFile = ImagenFile.PostedFile;
            // crear el array
            // Almacenamos la imagen en una variable para insertarla en la bd.//buscar la longitud y convertir en longitud byte
            Byte[] byteImage = new Byte[ImagenFile.PostedFile.ContentLength];
            //cargado en una matriz de bytes
            ImgFile.InputStream.Read(byteImage, 0, ImagenFile.PostedFile.ContentLength);

            string sql = "insert into Tabla(descripcion, Foto)";
            sql += " Values(@descripcion, @Foto)";

            //estos son los parametros donde vas a almacenar la info de tal foto :D

            SqlConnection SqlConn = new SqlConnection("Data Source=KEN-PC\\SQLEXPRESS;Initial Catalog=Imagenes;Integrated Security=True");
            SqlCommand SqlCom = new SqlCommand(sql, SqlConn);

            SqlCom.Parameters.Add("@descripcion", System.Data.SqlDbType.VarChar, 250);
            SqlCom.Parameters["@descripcion"].Value = txtdescripcion.Text;
            SqlCom.Parameters.Add("@Foto", System.Data.SqlDbType.Image);
            SqlCom.Parameters["@Foto"].Value = byteImage; //byteImage;

            SqlConn.Open();
            SqlCom.ExecuteNonQuery();
            //    //SqlConn.Close();

            SqlCommand SqlCom1 = new SqlCommand("Select MAX(Idtabla) From Tabla", SqlConn);

            string lastID = SqlCom1.ExecuteScalar().ToString();

            SqlConn.Close();

// se direcciona a la pagina mostrar para ver la imagen insertada
            Response.Redirect("Mostrar.aspx?ID=" + lastID);
        }
    }

       
   
public  object Image1 { get; set; }
}


        }
    
