using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterLinQ.PGALuno
{
    public partial class ListAluno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using(BDEscolaDataContext cx = new BDEscolaDataContext()){
                ListStudant.DataSource = (from a in cx.Alunos where a.status == 1 select  new {nome = a.Pessoa.nome, id = a.id , rm = a.rm, rg = a.Pessoa.rg }).ToList();
                ListStudant.DataBind();
            }
        }

        protected void ListStudant_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void ListStudant_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void ListStudant_PreRender(object sender, EventArgs e)
        {
            if (ListStudant.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                ListStudant.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                ListStudant.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element. 
                //Remove if you don't have a footer row
                ListStudant.FooterRow.TableSection = TableRowSection.TableFooter;

            }
        }
    }
}