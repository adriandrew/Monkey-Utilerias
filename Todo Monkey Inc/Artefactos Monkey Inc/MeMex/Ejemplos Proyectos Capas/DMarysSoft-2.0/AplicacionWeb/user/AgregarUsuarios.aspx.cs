﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace DMarysSoftWEB.user
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateUserWizard_CreatedUser(object sender, EventArgs e)
        {
            Roles.AddUserToRole(CreateUserWizard.UserName, "Usuario");
        }

       
    }
}