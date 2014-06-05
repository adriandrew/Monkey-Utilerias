using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for BasePage
/// </summary>
public class BasePage : System.Web.UI.Page 
{
    private string _metakeywords;
    private string _metadescription;

    public string MetaKeywords
    {
        get
        {
            return _metakeywords;
        }
        set
        {
            _metakeywords = value;
        }
    }
    public string MetaDescription
    {
        get
        {
            return _metadescription;
        }
        set
        {
            _metadescription = value;
        }
    }
     protected override void OnLoad(EventArgs e)
        {
            if (!String.IsNullOrEmpty(MetaKeywords))
            {
                HtmlMeta tag = new HtmlMeta();
                tag.Name = "keywords";
                tag.Content = MetaKeywords;
                Header.Controls.Add(tag);
            }

            if (!String.IsNullOrEmpty(MetaDescription))
            {
                HtmlMeta tag = new HtmlMeta();
                tag.Name = "description";
                tag.Content = MetaDescription;
                Header.Controls.Add(tag);
            }
            base.OnLoad(e);
        }     

    void Page_Error(object sender, EventArgs e)
    {
       Server.Transfer("Error.aspx");       
    }
}
