using LinqBackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterLinQ.PGClasse
{
    public partial class List_Profes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (BDEscolaDataContext cx = new BDEscolaDataContext())
            {

                var local = (from p in cx.Professors
                             join pe in cx.Pessoas on p.id equals pe.id                            
                             select new { nome = pe.nome, registro = p.registr, id= p.id }).ToList(); 



                ListaProf.DataSource = local;
                ListaProf.DataBind();

                if (Request.QueryString["alert"] == "OK")
                {


                    this.DataBind();
                    string myScript = @" 

        $(document).ready(function() {
      bootbox.alert('Data Saved Successfully !', function(result) {});
    });";
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", myScript,
                    true);


                }
            }

        }

        protected void ListaProf_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void ListaProf_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void Button1_Command(object sender, CommandEventArgs e)
        {
            int linha = Convert.ToInt32(e.CommandArgument);

            int id = (int)ListaProf.DataKeys[linha].Value;


            switch (e.CommandName)
            {
                case "Delet":
                    using (ProfessorModel model = new ProfessorModel())
                    {
                        model.Delet(id);
                    }
                    Response.Redirect("List_Profes.aspx");
                    break;

                case "Editar":
                    Response.Redirect("Edit_Prof.aspx?id=" + id);
                    break;

            }
        }

        protected void ListaProf_PreRender(object sender, EventArgs e)
        {
            if (ListaProf.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                ListaProf.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                ListaProf.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element. 
                //Remove if you don't have a footer row
                ListaProf.FooterRow.TableSection = TableRowSection.TableFooter;

            }
        }
    }
}