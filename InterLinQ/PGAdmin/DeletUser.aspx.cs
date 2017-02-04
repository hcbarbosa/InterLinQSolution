using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterLinQ.PGAdmin
{
    public partial class DeletUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack)
            {

                Usuario u = new Usuario();

                u = (Usuario)Session["User"];

                if (u.senha == Passwd.Value)
                {

                    using (BDEscolaDataContext cx = new BDEscolaDataContext())
                    {

                        cx.ExecuteCommand("Delete from Usuario where email like {0}", Email1.Value);
                        cx.ExecuteCommand("Delete from Pessoa where cpf like {0}", Email1.Value);

                        string myScript = @"  $(document).ready(function() {
                                            bootbox.alert('User was Deleted !', function(result) {
                                           });});";
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", myScript,
                        true);
                    }

                }
                else
                {
                    string myScript = @"  $(document).ready(function() {
                                            bootbox.alert('Incorrect Password !', function(result) {
                                           });});";
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", myScript,
                    true);

                }
            }
        }
    }
}