using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterLinQ
{
    public partial class Historico_cidade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (BDEscolaDataContext cx = new BDEscolaDataContext()) 
            {
                var cidade = (from c in cx.Cidades select new {nome = c.nome }).ToList();

                

                JavaScriptSerializer js = new JavaScriptSerializer();
                string strJson = js.Serialize(cidade);
                Response.Write(strJson);

                 
            }

        }
    }
}