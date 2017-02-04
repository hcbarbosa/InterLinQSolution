using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterLinQ.PGAdmin
{
    public partial class ListUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (BDEscolaDataContext cx = new BDEscolaDataContext())
            {

                grdUser.DataSource = (from u in cx.Usuarios select new { Nome = u.Pessoa.nome, Email = u.email, permi = u.permissao, Id = u.id }).ToList();
                grdUser.DataBind();
            }
        }

        protected void grdUser_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void grdUser_PreRender(object sender, EventArgs e)
        {
            if (grdUser.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                grdUser.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                grdUser.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element. 
                //Remove if you don't have a footer row
                grdUser.FooterRow.TableSection = TableRowSection.TableFooter;

            }
        }
    }
}