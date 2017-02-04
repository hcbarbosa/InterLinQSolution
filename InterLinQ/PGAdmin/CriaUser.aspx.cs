using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterLinQ.PGAdmin
{
    public partial class CriaUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void create_Click(object sender, EventArgs e)
        {
            using(BDEscolaDataContext cx = new BDEscolaDataContext())
            {

                if ((from u in cx.Usuarios where u.email.Contains(Email.Value) select u).SingleOrDefault() == null)
                {
                    Pessoa p = new Pessoa();
                    p.nome = UserName.Value;
                    p.data_nasc = "";
                    p.cpf = Email.Value;
                    p.complemento = Email.Value;
                    p.bairro = Email.Value;
                    p.localidade = 1;
                    p.rua = Email.Value;
                    p.sexo = Email.Value;
                    p.rg = Email.Value;

                    cx.Pessoas.InsertOnSubmit(p);
                    cx.SubmitChanges();

                    Usuario u = new Usuario();
                    u.id = p.id;
                    u.email = Email.Value;
                    u.senha = Passwd.Value;
                    u.permissao = permissao.Value;

                    cx.Usuarios.InsertOnSubmit(u);
                    cx.SubmitChanges();

                    string myScript = @"  $(document).ready(function() {
                                            bootbox.alert('User was Created!', function(result) {
                                            window.location = 'ListUser.aspx';});});";
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", myScript,
                    true);
                }
                else {
                    string myScript = @"  $(document).ready(function() {
                                           bootbox.alert('User Email Aready Exist!', function(result) {
                                            ;});});";
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", myScript,
                  true);
                }

            
            }
        }
    }
}