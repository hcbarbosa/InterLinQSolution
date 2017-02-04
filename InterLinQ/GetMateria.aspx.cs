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
    public partial class GetMateria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (DisciplinaModel mm = new DisciplinaModel()) 
            {

                List<DisciplinaEnt> dl = new List<DisciplinaEnt>();
                List<RootObject> list = new List<RootObject>();
                dl = mm.LoadDisciplina();
               

                foreach (var dis in dl) {

                    RootObject o = new RootObject();
                    o.id = dis.Id.ToString();
                    o.nome = dis.Nome;
                    list.Add(o);
                
                }

                JavaScriptSerializer js = new JavaScriptSerializer();
                string strJson = js.Serialize(list);

                Response.Write(strJson);
            
            }

        }
    }
}