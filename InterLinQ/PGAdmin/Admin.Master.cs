using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterLinQ.PGAdmin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null && Session["ano"] !=null)
            {

                Usuario u = new Usuario();
                u = (Usuario) Session["User"];

                if (u.permissao.Contains("Admin")) { } else { Response.Redirect("../Logout.aspx"); }
            
            } else { Response.Redirect("../Login.aspx"); }
        }
    }
}