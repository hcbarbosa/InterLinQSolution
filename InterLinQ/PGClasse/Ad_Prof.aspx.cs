using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterLinQ.PGClasse
{
    public partial class Ad_Prof : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ListItem l;

            using (BDEscolaDataContext cx = new BDEscolaDataContext())
            {

                foreach (Pai p in cx.Pais.ToList())
                {

                    l = new ListItem();
                    l.Text = p.nome;
                    l.Value = p.id.ToString();
                    pais.Items.Add(l);
                }

                l = new ListItem();
                l.Value = "0";
                l.Text = "Chose";
                estado.Items.Add(l);
                foreach (Estado es in cx.Estados.ToList())
                {

                    l = new ListItem();
                    l.Text = es.nome;
                    l.Value = es.id.ToString();
                    estado.Items.Add(l);
                }



            }





            
        }

        protected void Salva_Click(object sender, EventArgs e)
        {
            Professor p = new Professor();
            p.Pessoa = new Pessoa();

            p.Pessoa.nome = Nome.Value;
            p.Pessoa.rg = RG.Value;
            p.Pessoa.cpf = CPF.Value;
            p.registr = NREGISTRO.Value;
            p.Pessoa.rua = endereco.Value;
            p.Pessoa.bairro = bairro.Value;
            p.Pessoa.complemento = complemento.Value;
            p.Pessoa.localidade= Int32.Parse(Request.Params["ctl00$formularios$cidade"]);
            p.Pessoa.data_nasc = " ";
            p.Pessoa.sexo = " ";
            Telefone t = new Telefone();
            t.tel_pessoal = tel1.Value;
            t.tel_residencia = tel2.Value;

            using (BDEscolaDataContext cx = new BDEscolaDataContext()) 
            {

                cx.Professors.InsertOnSubmit(p);
                cx.SubmitChanges();
                t.id = p.id;

                cx.Telefones.InsertOnSubmit(t);
                cx.SubmitChanges();

                Response.Redirect("List_Profes.aspxa?lert=OK");
            
            }
        }
    }
}