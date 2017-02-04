using LinqBackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterLinQ.PGClasse
{
    public partial class List_Materia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (BDEscolaDataContext cx = new BDEscolaDataContext()) 
            {
                ListaMaterias.DataSource = cx.Disciplinas.ToList();
                ListaMaterias.DataBind();
            
            }

        }

        protected void ListaMaterias_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void ListaMaterias_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void Button1_Command(object sender, CommandEventArgs e)
        {
            int linha = Convert.ToInt32(e.CommandArgument);

            int id = (int)ListaMaterias.DataKeys[linha].Value;


            switch (e.CommandName)
            {
                case "Delet":
                    using (DisciplinaModel model = new DisciplinaModel())
                    {
                       model.DeletaMateria(id);
                    }
                    Response.Redirect("List_Materia.aspx");
                    break;

                case "Editar":
                    Response.Redirect("Edit_Materia.aspx?id=" + id);
                    break;

            }
        }

        protected void ListaMaterias_PreRender(object sender, EventArgs e)
        {
            if (ListaMaterias.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                ListaMaterias.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                ListaMaterias.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element. 
                //Remove if you don't have a footer row
                ListaMaterias.FooterRow.TableSection = TableRowSection.TableFooter;

            }
        }
    }
}