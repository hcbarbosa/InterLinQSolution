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
    public partial class GetMateria_Ed : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if(Request.Params["id"]!= null){

                int id = Int32 .Parse(Request.Params["id"]);
                using (BDEscolaDataContext cx = new BDEscolaDataContext())
                {
                    List<RootObject> list = new List<RootObject>();
                    var dl = cx.Disciplinas.ToList();


                    foreach (var dis in dl)
                    {
                        if ((from r in cx.r_Turma_Disc_Profs where r.id_turma == id && r.id_disciplina == dis.id && r.desativado ==0 select r).SingleOrDefault() == null)
                        {
                            RootObject o = new RootObject();
                            o.id = dis.id.ToString();
                            o.nome = dis.nome;
                            list.Add(o);
                        }
                    }

                    JavaScriptSerializer js = new JavaScriptSerializer();
                    string strJson = js.Serialize(list);

                    Response.Write(strJson);
                }
            }
        }
    }
}