using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterLinQ.JS.tela_adm
{
    public partial class EditaAnoLetivo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["ano"] != null)
            {
                using (BDEscolaDataContext cx = new BDEscolaDataContext())
                {

                    AnoLetivo a = new AnoLetivo();
                    a.ano = Int32.Parse(Request.Params["ano"]);
                    a.status = Int32.Parse(Request.Params["status"]);

                  
                        cx.ExecuteCommand("Update  AnoLetivo set status = 4");

                        cx.ExecuteCommand("Update Anoletivo set status = 1 where ano = {0}",Int32.Parse(Request.Params["ano"]));

                        Session["ano"] = a;

                        Response.Write("[{\"ok\":\"ok\"}]");
                   

                }

            }
        }
    }
}