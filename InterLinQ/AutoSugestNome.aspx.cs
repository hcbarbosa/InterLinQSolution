using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterLinQ
{
    public partial class AutoSugestNome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (BDEscolaDataContext cx = new BDEscolaDataContext())
            
            {


                List<Aluno> al = new List<Aluno>();
                al = (from a in cx.Alunos where a.status == 1 select a).ToList();

                List<sugestNome> sl = new List<sugestNome>();

                foreach (var c in al) {
                    sugestNome su = new sugestNome();
                    su.nome = c.Pessoa.nome;
                    su.id =c.rm;
                    sl.Add(su);
                
                }

                JavaScriptSerializer js = new JavaScriptSerializer();
                string strJson = js.Serialize(sl);
                Response.Write(strJson);


            
            }
        }
    }
}