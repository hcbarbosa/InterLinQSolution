using LinqBackEnd.Entity;
using LinqBackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterLinQ.PGClasse
{
    public partial class Edit_Prof : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int dado;
            if (Request.QueryString["id"] != null)
            {
                dado = Int32.Parse(Request.QueryString["id"]);

                using (ProfessorModel am = new ProfessorModel())
                {

                    ProfessorEnt al = new ProfessorEnt();

                    al = am.LoadProf(dado);

                    idAluno.Value = al.Id.ToString();
                    Nome.Value = al.Nome;

                    CPF.Value = al.CPF;
                    RG.Value = al.RG;
                    endereco.Value = al.Rua;
                    bairro.Value = al.Bairro;
                    complemento.Value = al.Complemento;
                    NREGISTRO.Value = al.Registro;

                    ListItem ls;

                    using (PaisMOdel pm = new PaisMOdel())
                    {

                        foreach (PaisEnt p in pm.GetPais())
                        {

                            ls = new ListItem();
                            ls.Text = p.Nome;
                            ls.Value = p.idPais.ToString();
                            pais.Items.Add(ls);
                        }



                    }


                    using (EstadoModel em = new EstadoModel())
                    {
                        EstadoEnt est = new EstadoEnt();
                        ls = new ListItem();
                        ls.Value = "0";
                        ls.Text = "Update List";
                        estado.Items.Add(ls);
                        using (EstadoModel em2 = new EstadoModel())
                        {
                            est = em2.GetEstado(al.Localidade);

                        }

                        foreach (EstadoEnt es in em.GetEstado())
                        {

                            ls = new ListItem();
                            ls.Text = es.Nome;
                            ls.Value = es.idEstado.ToString();
                            if (es.idEstado == est.idEstado)
                            {
                                ls.Selected = true;
                            }
                            estado.Items.Add(ls);
                        }



                    }
                    using (  CidadeModel cm = new CidadeModel())
                    {


                        CidadeEnt c = new CidadeEnt();
                        ls = new ListItem();


                        c = cm.REcCidade(al.Localidade);


                        ls = new ListItem();
                        ls.Text = c.Nome;
                        ls.Value = c.idCidade.ToString();
                        ls.Selected = true;

                        cidade.Items.Add(ls);
                    }



                    tel1.Value = al.Tel1;
                    tel2.Value = al.Tel2;

                }

            }

        }

        protected void Salva_Click(object sender, EventArgs e)
        {
            ProfessorEnt a = new ProfessorEnt();
            a.Id = Int32.Parse(Request.Params["ctl00$formularios$idAluno"]);
            a.Nome = Request.Params["ctl00$formularios$Nome"];
            a.DataNasci = Request.Params["ctl00$formulario$nascimento"];
            a.Sexo = Request.Params["ctl00$formulario$Sexo"];
            a.CPF = Request.Params["ctl00$formularios$CPF"];
            a.RG = Request.Params["ctl00$formularios$RG"];
            a.Rua = Request.Params["ctl00$formularios$endereco"];
            a.Bairro = Request.Params["ctl00$formularios$bairro"];
            a.Complemento = Request.Params["ctl00$formularios$complemento"];
            a.Localidade = Int32.Parse(Request.Params["ctl00$formularios$cidade"]);
            a.Registro = Request.Params["ctl00$formularios$NREGISTRO"];
            a.Tel1 = Request.Params["ctl00$formularios$tel1"];
            a.Tel2 = Request.Params["ctl00$formularios$tel2"];




            using (ProfessorModel p = new ProfessorModel())
            {


                p.UpdateProf(a);

            }

            Response.Redirect("List_Profes.aspx?alert=OK");


        }
    }

}
