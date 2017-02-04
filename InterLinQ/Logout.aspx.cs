using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterLinQ
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null) {

                Session.RemoveAll();
                Response.Redirect("Login.aspx");
            
            
            } else { Response.Redirect("Login.aspx"); }
        }
    }
}