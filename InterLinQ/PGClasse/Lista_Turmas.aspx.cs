using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterLinQ.PGClasse
{
    public partial class Lista_Turmas : System.Web.UI.Page
    {
        AnoLetivo anl = new AnoLetivo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ano"] != null)
            {
                anl = (AnoLetivo)Session["ano"];
                using (BDEscolaDataContext cx = new BDEscolaDataContext())
                {
                    GridView1.DataSource = (from t in cx.Turmas where t.desativado == 0 || t.desativado > anl.ano select t).ToList();
                    GridView1.DataBind();

                }

            }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int linha = Convert.ToInt32(e.CommandArgument);

            int id = (int)GridView1.DataKeys[linha].Value;

            Response.Redirect("Informacoes.aspx?id=" + id);

        }

        protected void GridView1_PreRender(object sender, EventArgs e)
        {
            if (GridView1.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                GridView1.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element. 
                //Remove if you don't have a footer row
                GridView1.FooterRow.TableSection = TableRowSection.TableFooter;

            }
        }
    }
}