using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterLinQ.PGClasse
{
    public partial class Classes : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null && Session["ano"] != null) { } else { Response.Redirect("../Login.aspx"); }
        }
    }
}