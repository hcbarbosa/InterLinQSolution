using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterLinQ
{
    public partial class MudaStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["stat"] != null)
            {

                using (BDEscolaDataContext cx = new BDEscolaDataContext())
                {
                    try
                    {
                        cx.ExecuteCommand("Update Aluno set status = {0} where id={1}", Request.Params["stat"], Request.Params["id"]);
                        Response.Write("[{\"res\":\"1\"}]");
                    }
                    catch 
                    {
                        Response.Write("[{\"res\":\"0\"}]");
                    
                    }
                }
            }
        }
    }
}