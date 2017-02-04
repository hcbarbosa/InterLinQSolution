using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterLinQ
{
    public partial class ADAluno_em_Inf : System.Web.UI.Page
    {
        AnoLetivo anl = new AnoLetivo();
        protected void Page_Load(object sender, EventArgs e)
        {
            anl = (AnoLetivo)Session["ano"];
            if (Session["User"] != null) { 
            using (BDEscolaDataContext cx = new BDEscolaDataContext())
            {


                List<Aluno> al = new List<Aluno>();
                al = (from a in cx.Alunos where a.status == 1 select a).ToList();

                List<sugestNome> sl = new List<sugestNome>();

                foreach (var c in al)
                {
                    if((from m in cx.Matriculas where m.id_aluno == c.id && m.data == anl.ano && (m.desativado == 0 || m.desativado > anl.ano)select m).SingleOrDefault() == null){
                    sugestNome su = new sugestNome();
                    su.nome = c.Pessoa.nome;
                    su.id = c.rm;
                    sl.Add(su);
                    }

                }

                JavaScriptSerializer js = new JavaScriptSerializer();
                string strJson = js.Serialize(sl);
                Response.Write(strJson);



            }
            }
            else { Response.Redirect("../Login.aspx"); }
        }
    }
}