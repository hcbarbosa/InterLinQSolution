using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterLinQ
{
    public partial class GetTurma : System.Web.UI.Page
    {
        AnoLetivo anl = new AnoLetivo();
        protected void Page_Load(object sender, EventArgs e)
        {
            anl = (AnoLetivo)Session["ano"];
            using (BDEscolaDataContext cx = new BDEscolaDataContext())
            {

                var lista = (from t in cx.Turmas
                             where t.desativado == 0 || t.desativado > anl.ano
                             select t).ToList();

                List<RootObject> lt = new List<RootObject>();

                foreach (var item in lista) 
                {
                    RootObject o = new RootObject();
                    o.id = item.id.ToString();
                    o.nome = item.nome;
                    lt.Add(o);
                
                }

                JavaScriptSerializer js = new JavaScriptSerializer();
                string strJson = js.Serialize(lt);
                Response.Write(strJson);
            
            
            }

        }
    }
}