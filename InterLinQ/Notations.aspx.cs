using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterLinQ
{
    public partial class Notations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["getAN"] != null)
            {

                using (BDEscolaDataContext cx = new BDEscolaDataContext())
                {
                    try
                    {
                        
                            var not = cx.Anotacoes.Single(an => an.id == Int32.Parse(Request.Params["getAN"]));
                            Response.Write("[{\"res\":\"" + not.Anotacao + "\"}]");
                       
                    }
                    catch
                    {
                        Response.Write("[{\"res\":\"1\"}]");

                    }
                }
            }
            else
                if (Request.Params["PostAN"] != null)
                {

                    using (BDEscolaDataContext cx = new BDEscolaDataContext())
                    {
                        try
                        {
                         if ((from an in cx.Anotacoes where an.id == Int32.Parse(Request.Params["PostAN"]) select an).SingleOrDefault() == null)
                        {
                            Anotacoe a = new Anotacoe();
                            a.id = Int32.Parse(Request.Params["PostAN"]);
                            a.Anotacao = Request.Params["Anot"];
                            cx.Anotacoes.InsertOnSubmit(a);
                            cx.SubmitChanges();
                            Response.Write("[{\"res\":\"1\"}]");
                         }
                        else 
                        {
                            cx.ExecuteCommand("Update Anotacoes set Anotacao = {0} where id = {1}", Request.Params["Anot"], Int32.Parse(Request.Params["PostAN"]));
                            Response.Write("[{\"res\":\"1\"}]");
                        }
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