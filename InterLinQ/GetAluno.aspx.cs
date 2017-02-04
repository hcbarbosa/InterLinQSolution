using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterLinQ
{
    public partial class GetAluno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null) {
            if (Request.Params["nome"] != null)
            {
                string id = Request.Params["nome"];

                using (BDEscolaDataContext cx = new BDEscolaDataContext())
                {
                    Aluno al = new Aluno();
                    al.Pessoa = new Pessoa();
                    try
                    {
                        al = (from a in cx.Alunos where a.Pessoa.nome == id select a).SingleOrDefault();

                        Response.Write("[{\"rm\":\"" + al.rm + "\",\"idaluno\":\"" + al.id + "\"}]");
                    }
                    catch (Exception ex)
                    {
                        Response.Write("[{\"id\":\""+0+"\"}]");
                    }
                }
            }
            else
                if (Request.Params["RM"] != null)
                {
                    string id = Request.Params["RM"];

                    using (BDEscolaDataContext cx = new BDEscolaDataContext())
                    {
                        Aluno al = new Aluno();
                        al.Pessoa = new Pessoa();
                        try
                        {
                            al = (from a in cx.Alunos where a.rm == id select a).SingleOrDefault();

                            Response.Write("[{\"nome\":\"" + al.Pessoa.nome + "\",\"idaluno\":\"" + al.id + "\"}]");
                        }
                        catch (Exception ex)
                        {

                            Response.Write("[{\"id\":\""+0+"\"}]");
                        }
                    }
                }
            }
            else { Response.Redirect("../Login.aspx"); }

        }

    }
}