using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterLinQ
{
    public partial class AddAno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["ano"] != null)
            {
                using (BDEscolaDataContext cx = new BDEscolaDataContext())
                {

                    AnoLetivo a = new AnoLetivo();
                    a.ano = Int32.Parse( Request.Params["ano"]);
                    a.status = 1;

                    if (cx.AnoLetivos.SingleOrDefault(y => y.ano == Int32.Parse(Request.Params["ano"])) == null)
                    {
                        cx.ExecuteCommand("Update  AnoLetivo set status = 4");

                        cx.AnoLetivos.InsertOnSubmit(a);
                        cx.SubmitChanges();

                        Session["ano"] = a;
                    }

                    Response.Write("[{\"ok\":\"ok\"}]");

                }
            
            }
        }
    }
}