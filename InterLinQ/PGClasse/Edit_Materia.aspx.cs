using LinqBackEnd.Entity;
using LinqBackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterLinQ.PGClasse
{
    public partial class Edit_Materia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                using (DisciplinaModel dm = new DisciplinaModel())
                {
                    if (Request.QueryString["id"] != null)
                    {
                        DisciplinaEnt d = new DisciplinaEnt();
                        d = dm.GetDisciplina(Int32.Parse(Request.QueryString["id"]));
                        Nome.Value = d.Nome;
                        Info.Value = d.Inf;
                        idmateria.Value = d.Id.ToString();

                    }
                }

            }

        }

        protected void Cria_Click(object sender, EventArgs e)
        {

            using (DisciplinaModel dm = new DisciplinaModel())
            {
                DisciplinaEnt d = new DisciplinaEnt();

                d.Nome = Nome.Value;
                d.Inf = Info.Value;
                d.Id = Int32.Parse(idmateria.Value);
                dm.UpdateDisciplina(d);

            }

            Response.Redirect("List_Materia.aspx");



        }
    }
}