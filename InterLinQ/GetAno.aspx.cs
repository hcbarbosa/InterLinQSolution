using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterLinQ
{
    public partial class GetAno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            using (BDEscolaDataContext cx = new BDEscolaDataContext())
            {

                var ano = cx.AnoLetivos.ToList();
                
                List<RootObject2> list = new List<RootObject2>();

                foreach (var pro in ano)
                {
                    string st = " ";
                    RootObject2 o = new RootObject2();
                    o.nome = pro.ano.ToString();
                    o.id = (from s in cx.status where s.id == pro.status select s.descricao).Single();
                    if (pro.status == 1)
                    {
                        st = "disabled ";
                    }
                    o.conteudo = @"<select " + st + " onchange='MudaStatus(this," + pro.ano + @")'>
                                <option value='0'>Choose</option>
                                <option value='1'>Active</option>
                               
                                </select>";
                    list.Add(o);
                }

                JavaScriptSerializer js = new JavaScriptSerializer();
                string strJson = js.Serialize(list);

                Response.Write("{\"aaData\":"+strJson+"}");
            
            
            }

        }
    }
}