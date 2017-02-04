
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterLinQ
{
    public partial class GetCidade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null) { 
            if (Request.QueryString["id"] != null) {
                int id = Int32.Parse( Request.QueryString["id"]);

                using (BDEscolaDataContext cx = new BDEscolaDataContext()) 
                {
                    List<Cidade> lc = new List<Cidade>();
                    lc = cx.Cidades.Where(p => p.id_estado == id).ToList();

                    List<RootObject> list = new List<RootObject>();
                    foreach (Cidade c in lc)
                    {
                        RootObject o = new RootObject();
                        o.id = c.id.ToString();
                        o.nome = c.nome;
                        list.Add(o);
                    }
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    string strJson = js.Serialize(list);
                    Response.Write(strJson);

                
                }
            
            
            }
            }
            else { Response.Redirect("../Login.aspx"); }
        }
    }
}