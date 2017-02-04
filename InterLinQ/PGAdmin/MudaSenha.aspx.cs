using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterLinQ.PGAdmin
{
    public partial class MudaSenha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void change_Click(object sender, EventArgs e)
        {
            using (BDEscolaDataContext cx = new BDEscolaDataContext()) 
            {

                if (cx.Usuarios.SingleOrDefault(u => u.email.Contains(Email.Value) ) != null)
                {


                    cx.ExecuteCommand("Update Usuario set senha = {0} where email like {1}",Passwd.Value, Email.Value);
                    string myScript = @"  $(document).ready(function() {
                                            bootbox.alert('Password Has Been Changed', function(result) {
                                           });});";
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", myScript,
                    true);
                }
                else 
                {
                    string myScript = @"  $(document).ready(function() {
                                            bootbox.alert('Email Incorrect', function(result) {
                                           });});";
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", myScript,
                    true);
                
                
                }
            }
        }
    }
}