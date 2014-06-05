using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            // Propiedades del control.
            ucMultiFileUpload1.Titulo = "Subir imágenes";
            ucMultiFileUpload1.Comment = "Hasta 5 archivos .png, .gif ó .jpg (máx. 4 MB en total).";
            ucMultiFileUpload1.MaxFilesLimit = 5;
            ucMultiFileUpload1.DestinationFolder = "~/MyPictures"; // única propiedad obligatoria.
            ucMultiFileUpload1.FileExtensionsEnabled = ".png|.jpg|.gif";
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        ucMultiFileUpload1.UploadFiles(true);
    }

    private void MostrarImagenes()
    {
        System.IO.DirectoryInfo _dirInfo = new System.IO.DirectoryInfo(HttpContext.Current.Server.MapPath(ucMultiFileUpload1.DestinationFolder));

        if (_dirInfo.Exists)
        {
            System.IO.FileInfo[] _filesInfo = _dirInfo.GetFiles();
            foreach (System.IO.FileInfo _f in _filesInfo)
            {
                Image _img = new Image();
                _img.ImageUrl = string.Format("{0}/{1}", ucMultiFileUpload1.DestinationFolder, _f);
                _img.Height = new Unit(50);
                pnlImagenes.Controls.Add(_img);
            }
        }
        else
        {
            pnlImagenes.Controls.Add(new Label { Text = "Aún no se han subido archivos." });
        }
    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        MostrarImagenes();
    }
}
