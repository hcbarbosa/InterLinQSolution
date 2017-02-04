using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterLinQ
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            erro.Visible = false;
            if(IsPostBack){
                using (BDEscolaDataContext cx = new BDEscolaDataContext())
                {
                    Usuario u = new Usuario();
                    u.email = username.Value;
                    u.senha = password.Value;

                    if (cx.Usuarios.SingleOrDefault(us => us.email == u.email && us.senha == u.senha) != null)
                    {
                        Session["User"] = cx.Usuarios.SingleOrDefault(us => us.email == u.email && us.senha == u.senha);
                        Session["ano"] = cx.AnoLetivos.Single(y => y.status == 1);
                        Response.Redirect("PgAluno/Alunos.aspx");

                    }
                    else
                    {
                        erro.Visible = true;

                    }
                }
            
            }
        }
    }
}