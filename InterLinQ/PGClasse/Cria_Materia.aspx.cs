using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterLinQ.PGClasse
{
    public partial class Cria_Materia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Cria_Click(object sender, EventArgs e)
        {
            Disciplina d;
            List<Disciplina> ld = new List<Disciplina>();
            if (Request.Form["Nome[]"] != null)
            {
               string[] nomes = Request.Form["Nome[]"].Split(',');
                if (Request.Form["Info[]"] != null)
                {
                   string[] inf = Request.Form["Info[]"].Split(',');


                   using (BDEscolaDataContext cx = new BDEscolaDataContext())
                   {

                       for (int i = 0; i < nomes.Length; i++)
                       {
                           d = new Disciplina();
                           d.nome = nomes[i];
                           d.informacoes = inf[i];

                           cx.Disciplinas.InsertOnSubmit(d);
                           cx.SubmitChanges();

                       }

                   }
                  



                }
            }

        }
    }
}