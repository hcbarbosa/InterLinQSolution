using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterLinQ.PGClasse
{
    public partial class Matricula_p_Inf : System.Web.UI.Page
    {
        AnoLetivo anl = new AnoLetivo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ano"] != null)
            {
                anl = (AnoLetivo)Session["ano"];

                {

                    int idAluno = Int32.Parse(Request.Params["idAlun"]);
                    int idTurma = Int32.Parse(Request.Params["idTur"]);

                    Matricula m = new Matricula();
                    m.id_aluno = idAluno;
                    m.id_turma = idTurma;
                    m.data = anl.ano;
                    m.desativado = 0;



                    using (BDEscolaDataContext cx = new BDEscolaDataContext())
                    {
                        if (cx.Alunos.SingleOrDefault(a => a.id == idAluno && a.status == 1) != null)
                        {
                            // var vr = cx.Matriculas.FirstOrDefault(a => a.id_aluno == m.id_aluno && a.data == anl.ano && m.id_turma == idTurma);
                            if (cx.Matriculas.FirstOrDefault(a => a.id_aluno == m.id_aluno && a.data == m.data && (a.desativado == 0 || a.desativado > anl.ano)) != null)
                            {
                                string myScript = @"  $(document).ready(function() {
                                            bootbox.alert('Studant Alread Registred !', function(result) {
                                            window.location = 'MatriculaAL.aspx';});});";
                                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", myScript,
                                true);
                            }
                            else
                            {

                                cx.Matriculas.InsertOnSubmit(m);
                                cx.SubmitChanges();
                                Response.Redirect("Informacoes.aspx?id=" + idTurma);
                            }
                        }
                        else
                        {

                            string myScript = @"  $(document).ready(function() {
                                            bootbox.alert('Studant not found!', function(result) {
                                            window.location = 'Informacoes.aspx?id=" + idTurma + "';});});";
                            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", myScript,
                            true);
                        }
                    }
                }
            }
        }
    }
}