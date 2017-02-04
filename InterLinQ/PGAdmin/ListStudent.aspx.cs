using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterLinQ.PGAdmin
{
    public partial class ListStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            using (BDEscolaDataContext cx = new BDEscolaDataContext())
            {


                TableRow th;
                TableCell c1;
                th = new TableRow();
                th.TableSection = TableRowSection.TableHeader;

                c1 = new TableCell();
                c1.Controls.Add(new LiteralControl("Name"));
                th.Cells.Add(c1);

                c1 = new TableCell();
                c1.Controls.Add(new LiteralControl("RM"));
                th.Cells.Add(c1);

                c1 = new TableCell();
                c1.Controls.Add(new LiteralControl("Status"));
                th.Cells.Add(c1);

                c1 = new TableCell();
                c1.Controls.Add(new LiteralControl("Alter"));
                th.Cells.Add(c1);
                listEstudante.Rows.Add(th);

                var est = cx.Alunos.ToList();

                foreach (var item in est)
                {
                    TableRow r = new TableRow();
                    TableCell c;
                   
                        c = new TableCell();

                        c.Controls.Add(new LiteralControl(@"" + item.Pessoa.nome + "  <input type='hidden'  class='idaluno' value='" + item.id + "'"));


                        r.Cells.Add(c);

                        c = new TableCell();

                        c.Controls.Add(new LiteralControl( item.rm ));


                        r.Cells.Add(c);
                   
                        c = new TableCell();
                        var stnome = cx.status.Single(s => s.id == item.status);
                        c.Controls.Add(new LiteralControl(stnome.descricao));


                        r.Cells.Add(c);

                    c = new TableCell();

                    c.Controls.Add(new LiteralControl(@" <input type='button' class='btn btn-success ' onclick='mudaStatus(this)' value='Change' />
                                                                <input type='button' class='btn btn-primary' onclick='anotacoes(this)' value='Notations' />"));


                        r.Cells.Add(c);
                    

                    listEstudante.Rows.Add(r);
                }
            }


        }
    }
}