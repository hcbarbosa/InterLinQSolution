using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterLinQ.PGClasse
{
    public partial class RemoveTurma : System.Web.UI.Page
    {
        AnoLetivo anl = new AnoLetivo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ano"] != null)
            {
                anl = (AnoLetivo)Session["ano"];
                int id = Int32.Parse(Request.Params["id"]);

                using (BDEscolaDataContext cx = new BDEscolaDataContext())
                {
                    if (cx.r_matr_r_Turma_Disc_Profs.FirstOrDefault(t => t.id_turma == id) != null)
                    {

                        cx.ExecuteCommand("UPDATE Turma set desativado = {0} where id ={1}", anl.ano, id);
                        if (cx.Matriculas.FirstOrDefault(m => m.id_turma == id) != null)
                        {
                            if (cx.r_matr_r_Turma_Disc_Profs.FirstOrDefault(rl => rl.id_turma == id) != null)
                            {

                                cx.ExecuteCommand("UPDATE Matricula set desativado = {0} where id_turma = {1} ", anl.ano, id);

                                //  cx.ExecuteCommand("UPDATE r_matr_r_Turma_Disc_Prof  set desativado = {0} where id_turma = {1} and data = {2} ", anl.ano, id, anl.ano);


                            }
                            else
                            {

                                cx.ExecuteCommand("UPDATE Matricula set desativado = {0} where id_turma = {1} ", anl.ano, id);
                            }

                        }
                    }
                    else
                    {
                        cx.ExecuteCommand("DELETE FROM  Matricula  where id_turma ={0}", id);
                        cx.ExecuteCommand("DELETE FROM   r_Turma_Disc_Prof  where id_turma ={0}", id);
                        cx.ExecuteCommand("DELETE FROM  Turma  where id ={0}", id);

                    }

                    Response.Redirect("Lista_Turmas.aspx");

                }
            }
        }
    }
}