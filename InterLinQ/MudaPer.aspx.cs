using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterLinQ
{
    public partial class MudaPer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.Params["per"]!=null)
            {

                using (BDEscolaDataContext cx = new BDEscolaDataContext()) 
                {

                    cx.ExecuteCommand("Update Usuario set permissao = {0} where id={1}", Request.Params["per"], Request.Params["id"]);
                
                }
            
            }

        }
    }
}