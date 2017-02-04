using LinqBackEnd.Entity;
using LinqBackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterLinQ
{
    public partial class GetProfessor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (ProfessorModel pm = new ProfessorModel())
            {
                List<ProfessorEnt> pl = new List<ProfessorEnt>();
                pl = pm.GetListProf();
                List<RootObject> list = new List<RootObject>();

                foreach (var pro in pl) 
                {
                    RootObject o = new RootObject();
                    o.id =pro.Id.ToString();
                    o.nome = pro.Nome;
                    list.Add(o);
                }

                JavaScriptSerializer js = new JavaScriptSerializer();
                string strJson = js.Serialize(list);

                Response.Write(strJson);


              
            }
        }
    }
}