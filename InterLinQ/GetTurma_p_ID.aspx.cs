using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterLinQ
{
    public partial class GetTurma_p_ID : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (BDEscolaDataContext cx = new BDEscolaDataContext())
            {
                if (Request.Params["id"] != null)
                {
                    int id = Int32.Parse(Request.Params["id"]);
                    var lista = (from t in cx.Turmas
                                 where  t.id == id
                                 select t).Single();

                    List<RootObject> lt = new List<RootObject>();

                   
                        RootObject o = new RootObject();
                        o.id = lista.id.ToString();
                        o.nome = lista.nome;
                        lt.Add(o);

                   

                    JavaScriptSerializer js = new JavaScriptSerializer();
                    string strJson = js.Serialize(lt);
                    Response.Write(strJson);
                }
            }
        }
    }
}