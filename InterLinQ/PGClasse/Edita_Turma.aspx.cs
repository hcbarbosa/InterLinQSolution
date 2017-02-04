using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterLinQ.PGClasse
{
    public partial class Edita_Turma : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ano"] != null)
            {
                if (!IsPostBack)
                {
                    if (Request.Params["id"] != null)
                    {
                        int id = Int32.Parse(Request.Params["id"]);
                        ViewState["id"] = id;
                        idturma.Value = id.ToString();


                        using (BDEscolaDataContext cx = new BDEscolaDataContext())
                        {
                            Turma t = cx.Turmas.Single(turma => turma.id == id);
                            Nome.Value = t.nome;
                            ListItem li = Periodo.Items.FindByText(t.periodo);
                            li.Selected = true;


                        }

                    }
                }
            }
        }

        protected void criar_Click(object sender, EventArgs e)
        {
            AnoLetivo anl = new AnoLetivo();
            if (Request.Params["NPeriodo"] != "0")
            {
                anl = (AnoLetivo)Session["ano"];
                Turma t = new Turma();
                t.id = (int)ViewState["id"];
                r_Turma_Disc_Prof rel;

                t.nome = Nome.Value;
                t.periodo = Periodo.SelectedItem.Text;

                string[] profs = Request.Params["Professores[]"].Split(',');
                string[] mate = Request.Params["Materias[]"].Split(',');

                if (profs[0] != "00" && mate[0] != "00")
                {
                    using (BDEscolaDataContext cx = new BDEscolaDataContext())
                    {

                        cx.ExecuteCommand(@"UPDATE Turma set nome={0},periodo={1}
                                    WHERE id={2}", t.nome, t.periodo, t.id);

                        for (int i = 0; i < profs.Length; i++)
                        {
                            rel = new r_Turma_Disc_Prof();
                            rel.id_turma = t.id;
                            rel.id_disciplina = Int32.Parse(mate[i]);
                            rel.id_prof = Int32.Parse(profs[i]);
                            rel.data = anl.ano;
                            rel.desativado = 0;
                            try
                            {
                                cx.r_Turma_Disc_Profs.InsertOnSubmit(rel);
                                cx.SubmitChanges();
                            }catch(Exception ex)
                             {
                            }

                        }

                        Response.Redirect("Informacoes.aspx?id=" + t.id);

                    }

                }
                else
                {

                    string myScript = @" $(document).ready(function() {        
         
      bootbox.alert('Select the Disciplines and Teachers!', function(result) {});
           
    });";
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", myScript,
                    true);


                }
            }
            else
            {

                string myScript = @" $(document).ready(function() {        
         
      bootbox.alert('Fill in all fields marked * !', function(result) {});
           
    });";
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", myScript,
                true);


            }
        }
    }
}