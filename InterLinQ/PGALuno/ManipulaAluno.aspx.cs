using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace InterLinQ.PGALuno
{   
    public partial class ManipulaAluno : System.Web.UI.Page
    {
        static string imagem_rec = null;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                if (Request.Params["tipo"] != null)
                {
                    salvaAluno.Text = "Update";
                    if (Request.Params["tipo"].Contains("RM"))
                    {
                        lblstatus.Visible = true;
                        txtStatus.Visible = true;

                        string rem = Request.Params["SelctRm"];

                        using (BDEscolaDataContext cx = new BDEscolaDataContext())
                        {
                            Aluno al = new Aluno();
                            al.Pessoa = new Pessoa();

                            al.id = 0;


                            if (cx.Alunos.SingleOrDefault(a => a.rm == rem) == null)
                            {
                                
                                string myScript = @"  $(document).ready(function() {
                                            bootbox.alert('Student not Found !', function(result) {
                                            window.location = 'Alunos.aspx';});});";
                                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", myScript,
                                true);
                            }
                            else
                            {
                                al = cx.Alunos.Single(a => a.rm == rem);
                                ViewState["id"] = al.id;
                                Nome.Value = al.Pessoa.nome;
                                nascimento.Value = al.Pessoa.data_nasc;
                                txtStatus.Value = (from s in cx.status where s.id == al.status select s.descricao).Single().ToString();
                               
                                switch (al.Pessoa.sexo)
                                {
                                    case "Male":
                                        ListItem li = Sexo.Items.FindByText("Male");
                                        li.Selected = true;
                                        break;
                                    case "Female":
                                        ListItem l = Sexo.Items.FindByText("Female");
                                        l.Selected = true;
                                        break;

                                }
                                CPF.Value = al.Pessoa.cpf;
                                rg.Value = al.Pessoa.rg;
                                Rua.Value = al.Pessoa.rua;
                                Bairro.Text = al.Pessoa.bairro;
                                Complemento.Text = al.Pessoa.complemento;

                                ListItem ls;

                                List<Pai> Paises = new List<Pai>();

                                Paises = cx.Pais.ToList();
                                foreach (Pai p in Paises)
                                {

                                    ls = new ListItem();
                                    ls.Text = p.nome;
                                    ls.Value = p.id.ToString();
                                    pais.Items.Add(ls);
                                }




                                var local = (from c in cx.Cidades
                                             where c.id == al.Pessoa.localidade
                                             select c).Single();

                                List<Estado> est = new List<Estado>();

                                est = cx.Estados.ToList();
                                ls = new ListItem();
                                ls.Value = "0";
                                ls.Text = "Update List";
                                estado.Items.Add(ls);
                                foreach (Estado es in est)
                                {
                                    ls = new ListItem();
                                    ls.Text = es.nome;
                                    ls.Value = es.id.ToString();
                                    estado.Items.Add(ls);

                                }
                                ListItem list = estado.Items.FindByValue(local.id_estado.ToString());
                                list.Selected = true;

                                ls = new ListItem();
                                ls.Text = local.nome;
                                ls.Value = local.id.ToString();
                                cidade.Items.Add(ls);

                                rm.Value = al.rm;
                                ra.Value = al.ra;
                                rne.Value = al.rne;
                                nomepai.Value = al.nome_pai;
                                nomemae.Value = al.nome_mae;
                                if (al.foto != " ")
                                {
                                    Image1.ImageUrl = "../images/" + al.foto + "";
                                    imagem_rec = al.foto;
                                }
                                else
                                {
                                    Image1.ImageUrl = "../bootstrap/img/adm.png";
                                }


                                txt_inf.Value = al.inf;
                                Telefone te = (from t in cx.Telefones
                                               where t.id == al.id
                                               select t).Single();

                                tel1.Value = te.tel_pessoal;
                                tel2.Value = te.tel_residencia;

                                LoadHistorico(al.id);
                            }
                        }
                    }
                    else if (Request.Params["tipo"].Contains("Name"))
                    {
                        lblstatus.Visible = true;
                        txtStatus.Visible = true;
                        string nome = Request.Params["SelectName"];
                        using (BDEscolaDataContext cx = new BDEscolaDataContext())
                        {
                            Aluno al = new Aluno();
                            al.Pessoa = new Pessoa();

                            al.id = 0;

                            if (cx.Alunos.SingleOrDefault(a => a.Pessoa.nome.Contains(nome)) == null)
                            {
                              
                                string myScript = @"  $(document).ready(function() {
                                            bootbox.alert('Student not Found !', function(result) {
                                            window.location = 'Alunos.aspx';});});";
                                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", myScript,
                                true);
                            }
                            else
                            {
                                al = cx.Alunos.Single(a => a.Pessoa.nome.Contains(nome));
                                ViewState["id"] = al.id;
                                Nome.Value = al.Pessoa.nome;
                                nascimento.Value = al.Pessoa.data_nasc;
                                txtStatus.Value = (from s in cx.status where s.id == al.status select s.descricao).Single().ToString();
                               
                                switch (al.Pessoa.sexo)
                                {
                                    case "Male":
                                        ListItem li = Sexo.Items.FindByText("Male");
                                        li.Selected = true;
                                        break;
                                    case "Female":
                                        ListItem l = Sexo.Items.FindByText("Female");
                                        l.Selected = true;
                                        break;

                                }
                                CPF.Value = al.Pessoa.cpf;
                                rg.Value = al.Pessoa.rg;
                                Rua.Value = al.Pessoa.rua;
                                Bairro.Text = al.Pessoa.bairro;
                                Complemento.Text = al.Pessoa.complemento;

                                ListItem ls;

                                List<Pai> Paises = new List<Pai>();

                                Paises = cx.Pais.ToList();
                                foreach (Pai p in Paises)
                                {

                                    ls = new ListItem();
                                    ls.Text = p.nome;
                                    ls.Value = p.id.ToString();
                                    pais.Items.Add(ls);
                                }




                                var local = (from c in cx.Cidades
                                             where c.id == al.Pessoa.localidade
                                             select c).Single();

                                List<Estado> est = new List<Estado>();

                                est = cx.Estados.ToList();
                                ls = new ListItem();
                                ls.Value = "0";
                                ls.Text = "Update List";
                                estado.Items.Add(ls);
                                foreach (Estado es in est)
                                {
                                    ls = new ListItem();
                                    ls.Text = es.nome;
                                    ls.Value = es.id.ToString();
                                    estado.Items.Add(ls);

                                }
                                ListItem list = estado.Items.FindByValue(local.id_estado.ToString());
                                list.Selected = true;

                                ls = new ListItem();
                                ls.Text = local.nome;
                                ls.Value = local.id.ToString();
                                cidade.Items.Add(ls);

                                rm.Value = al.rm;
                                ra.Value = al.ra;
                                rne.Value = al.rne;
                                nomepai.Value = al.nome_pai;
                                nomemae.Value = al.nome_mae;
                                if (al.foto != " ")
                                {
                                    Image1.ImageUrl = "../images/" + al.foto + "";
                                    imagem_rec = al.foto;
                                }
                                else
                                {
                                    Image1.ImageUrl = "../bootstrap/img/adm.png";
                                }


                                txt_inf.Value = al.inf;
                                Telefone te = (from t in cx.Telefones
                                               where t.id == al.id
                                               select t).Single();

                                tel1.Value = te.tel_pessoal;
                                tel2.Value = te.tel_residencia;

                                LoadHistorico(al.id);

                            }
                        }

                    }
                }
                else
                {
                    lblstatus.Visible = false;
                    txtStatus.Visible = false;
                    using (BDEscolaDataContext cx = new BDEscolaDataContext())
                    {
                        ListItem ls;
                        List<Estado> est = new List<Estado>();

                        est = cx.Estados.ToList();
                        ls = new ListItem();
                        ls.Value = "0";
                        ls.Text = "Select one Iten";
                        estado.Items.Add(ls);
                        foreach (Estado es in est)
                        {
                            ls = new ListItem();
                            ls.Text = es.nome;
                            ls.Value = es.id.ToString();
                            estado.Items.Add(ls);

                        }

                        ls = new ListItem();
                        ls.Value = "00";
                        ls.Text = "Brasil";
                        pais.Items.Add(ls);



                        HtmlTableRow r;
                        HtmlTableCell cel;

                        for (int i = 0; i < 12; i++)
                        {

                            r = new HtmlTableRow();

                            cel = new HtmlTableCell("th");

                            cel.Attributes.Add("class", "input-small text-center");
                            cel.Width = "120px";
                            if (i == 0)
                            {
                                cel.InnerHtml = "" + (i + 1) + "st Grade";
                            }
                            else
                                if (i == 1)
                                {
                                    cel.InnerHtml = "" + (i + 1) + "nd Grade";
                                }
                                else
                                    if (i == 2)
                                    {
                                        cel.InnerHtml = "" + (i + 1) + "rd Grade";
                                    }
                                    else
                                    {
                                        cel.InnerHtml = "" + (i + 1) + "th Grade";
                                    }
                            r.Cells.Add(cel);

                            cel = new HtmlTableCell();
                            cel.Attributes.Add("class", "text-center");

                            cel.InnerHtml = "<input type='text' class='input-xlarge tb_historico ' name='" + (i + 1) + "serie[]'/>";
                            r.Cells.Add(cel);

                            cel = new HtmlTableCell();
                            cel.Attributes.Add("class", "text-center");

                            cel.InnerHtml = "<input type='text' class='input-mini ' name='" + (i + 1) + "serie[]'/>";
                            r.Cells.Add(cel);

                            cel = new HtmlTableCell();
                            cel.Attributes.Add("class", "text-center");

                            cel.InnerHtml = "<input type='text' class='input-xlarge tb_historico  city' data-provide='typeahead' data-items='10' name='" + (i + 1) + "serie[]' /> ";
                            r.Cells.Add(cel);


                            cel = new HtmlTableCell();
                            cel.Attributes.Add("class", "text-center");

                            cel.InnerHtml = "<input type='text' style='width: 20px;' class='state' data-provide='typeahead' data-items='10 ' name='" + (i + 1) + "serie[]'/>";
                            r.Cells.Add(cel);



                            cel = new HtmlTableCell();
                            cel.Attributes.Add("class", "text-center");

                            cel.InnerHtml = "<input type='text' class='input-small tb_pais coutry' value='Brasil'/>";
                            r.Cells.Add(cel);





                            tbhitorico.Rows.Add(r);



                        }



                    }

                }

            }

            else
            {

                if (Imagem.HasFile)
                {
                    Image1.ImageUrl = "../images/" + Imagem.FileName + "";
                }
                else
                {
                    Image1.ImageUrl = (imagem_rec != null ? imagem_rec : "../bootstrap/img/adm.png");
                }


            }
            }


        public void LoadHistorico(int id) {


            using (BDEscolaDataContext cx = new BDEscolaDataContext())
            {
                if ((from h in cx.historicos where h.id_aluno == id select h).FirstOrDefault() != null)
                {
                    var his = (from h in cx.historicos where h.id_aluno == id select h).ToList();
                    HtmlTableRow r;
                    HtmlTableCell cel;
                    int indce = 0;

                    for (int i = 0; i < 12; i++)
                    {

                        r = new HtmlTableRow();

                        if (i + 1 == his.ElementAt(indce).id_serie)
                        {


                            cel = new HtmlTableCell("th");

                            cel.Attributes.Add("class", "input-small text-center");
                            cel.Width = "120px";
                            if (i == 0)
                            {
                                cel.InnerHtml = "" + (i + 1) + "st Grade";
                            }
                            else
                                if (i == 1)
                                {
                                    cel.InnerHtml = "" + (i + 1) + "nd Grade";
                                }
                                else
                                    if (i == 2)
                                    {
                                        cel.InnerHtml = "" + (i + 1) + "rd Grade";
                                    }
                                    else
                                    {
                                        cel.InnerHtml = "" + (i + 1) + "th Grade";
                                    }
                            r.Cells.Add(cel);

                            cel = new HtmlTableCell();
                            cel.Attributes.Add("class", "text-center");

                            cel.InnerHtml = "<input type='text' class='input-xlarge tb_historico ' name='" + (i + 1) + "serie[]' value='" + his.ElementAt(indce).nome_escola + "'/> ";
                            r.Cells.Add(cel);

                            cel = new HtmlTableCell();
                            cel.Attributes.Add("class", "text-center");

                            cel.InnerHtml = "<input type='text' class='input-mini ' name='" + (i + 1) + "serie[]' value='" + his.ElementAt(indce).ano + "'/>";
                            r.Cells.Add(cel);

                            cel = new HtmlTableCell();
                            cel.Attributes.Add("class", "text-center");
                            var cidadeestado = (from ci in cx.Cidades join es in cx.Estados on ci.id_estado equals es.id where ci.id == his.ElementAt(indce).id_cidade select new { cidade = ci.nome, sigla = es.sigla }).Single();
                            cel.InnerHtml = "<input type='text' class='input-xlarge tb_historico  city' data-provide='typeahead' data-items='10' name='" + (i + 1) + "serie[]' value='" + cidadeestado.cidade + "' /> ";
                            r.Cells.Add(cel);


                            cel = new HtmlTableCell();
                            cel.Attributes.Add("class", "text-center");

                            cel.InnerHtml = "<input type='text' style='width: 20px;' class='state' data-provide='typeahead' data-items='10 ' name='" + (i + 1) + "serie[]' value='" + cidadeestado.sigla + "'/>";
                            r.Cells.Add(cel);



                            cel = new HtmlTableCell();
                            cel.Attributes.Add("class", "text-center");

                            cel.InnerHtml = "<input type='text' class='input-small tb_pais coutry' value='Brasil'/>";
                            r.Cells.Add(cel);


                            if (indce < his.Count - 1)
                            {
                                indce++;
                            }



                        }
                        else
                        {


                            cel = new HtmlTableCell("th");

                            cel.Attributes.Add("class", "input-small text-center");
                            cel.Width = "120px";

                            if (i == 0)
                            {
                                cel.InnerHtml = "" + (i + 1) + "st Grade";
                            }
                            else
                                if (i == 1)
                                {
                                    cel.InnerHtml = "" + (i + 1) + "nd Grade";
                                }
                                else
                                    if (i == 2)
                                    {
                                        cel.InnerHtml = "" + (i + 1) + "rd Grade";
                                    }
                                    else
                                    {
                                        cel.InnerHtml = "" + (i + 1) + "th Grade";
                                    }

                            r.Cells.Add(cel);

                            cel = new HtmlTableCell();
                            cel.Attributes.Add("class", "text-center");

                            cel.InnerHtml = "<input type='text' class='input-xlarge tb_historico ' name='" + (i + 1) + "serie[]'/>";
                            r.Cells.Add(cel);

                            cel = new HtmlTableCell();
                            cel.Attributes.Add("class", "text-center");

                            cel.InnerHtml = "<input type='text' class='input-mini ' name='" + (i + 1) + "serie[]'/>";
                            r.Cells.Add(cel);

                            cel = new HtmlTableCell();
                            cel.Attributes.Add("class", "text-center");

                            cel.InnerHtml = "<input type='text' class='input-xlarge tb_historico  city' data-provide='typeahead' data-items='10' name='" + (i + 1) + "serie[]' /> ";
                            r.Cells.Add(cel);


                            cel = new HtmlTableCell();
                            cel.Attributes.Add("class", "text-center");

                            cel.InnerHtml = "<input type='text' style='width: 20px;' class='state' data-provide='typeahead' data-items='10 ' name='" + (i + 1) + "serie[]'/>";
                            r.Cells.Add(cel);



                            cel = new HtmlTableCell();
                            cel.Attributes.Add("class", "text-center");

                            cel.InnerHtml = "<input type='text' class='input-small tb_pais coutry' value='Brasil'/>";
                            r.Cells.Add(cel);








                        }
                        tbhitorico.Rows.Add(r);
                    }
                }
                else
                {

                    HtmlTableRow r;
                    HtmlTableCell cel;

                    for (int i = 0; i < 12; i++)
                    {

                        r = new HtmlTableRow();

                        cel = new HtmlTableCell("th");

                        cel.Attributes.Add("class", "input-small text-center");
                        cel.Width = "120px";
                        if (i == 0)
                        {
                            cel.InnerHtml = "" + (i + 1) + "st Grade";
                        }
                        else
                            if(i == 1)
                            {
                                cel.InnerHtml = "" + (i + 1) + "nd Grade";
                            }
                            else
                                if (i == 2)
                                {
                                    cel.InnerHtml = "" + (i + 1) + "rd Grade";
                                }
                                else 
                                {
                                    cel.InnerHtml = "" + (i + 1) + "th Grade";
                                }

                        r.Cells.Add(cel);

                        cel = new HtmlTableCell();
                        cel.Attributes.Add("class", "text-center");

                        cel.InnerHtml = "<input type='text' class='input-xlarge tb_historico ' name='" + (i + 1) + "serie[]'/>";
                        r.Cells.Add(cel);

                        cel = new HtmlTableCell();
                        cel.Attributes.Add("class", "text-center");

                        cel.InnerHtml = "<input type='text' class='input-mini ' name='" + (i + 1) + "serie[]'/>";
                        r.Cells.Add(cel);

                        cel = new HtmlTableCell();
                        cel.Attributes.Add("class", "text-center");

                        cel.InnerHtml = "<input type='text' class='input-xlarge tb_historico  city' data-provide='typeahead' data-items='10' name='" + (i + 1) + "serie[]' /> ";
                        r.Cells.Add(cel);


                        cel = new HtmlTableCell();
                        cel.Attributes.Add("class", "text-center");

                        cel.InnerHtml = "<input type='text' style='width: 20px;' class='state' data-provide='typeahead' data-items='10 ' name='" + (i + 1) + "serie[]'/>";
                        r.Cells.Add(cel);



                        cel = new HtmlTableCell();
                        cel.Attributes.Add("class", "text-center");

                        cel.InnerHtml = "<input type='text' class='input-small tb_pais coutry' value='Brasil'/>";
                        r.Cells.Add(cel);





                        tbhitorico.Rows.Add(r);
                    }
                }
            }
        }
        
            
            
            

        

        protected void salvaAluno_Click(object sender, EventArgs e)
        {
            Aluno al = new Aluno();
              al.Pessoa = new Pessoa();

           

              if (Request.Params["ctl00$formulario$cidade"] != null)
              {
                  int? id = (int?)ViewState["id"];
                  al.Pessoa.id = (id != null ? (int)id : 0);
                  al.Pessoa.nome = Nome.Value;
                  al.status = 1;
                  al.Pessoa.data_nasc = nascimento.Value;
                  al.Pessoa.sexo = Sexo.Value;
                  al.Pessoa.cpf = (CPF.Value != null ? CPF.Value : null);
                  al.Pessoa.rg = rg.Value;
                  al.Pessoa.rua = Rua.Value;
                  al.Pessoa.bairro = Bairro.Text;
                  al.Pessoa.complemento = Complemento.Text;
                  al.Pessoa.localidade = Int32.Parse(Request.Params["ctl00$formulario$cidade"]);
                  al.rm = rm.Value;
                  al.ra = ra.Value;
                  al.rne = (rne.Value != null ? rne.Value : null);
                  al.nome_pai = (nomepai.Value != null ? nomepai.Value : null);
                  al.nome_mae = (nomemae.Value != null ? nomemae.Value : null);
                  if (Imagem.HasFile)
                  {
                      al.foto = Imagem.FileName;
                      imagem_rec = Imagem.FileName;
                  }
                  else
                  {

                      al.foto = (imagem_rec != null ? imagem_rec : "../bootstrap/img/adm.png");
                  }

                  al.inf = (txt_inf.Value != null ? txt_inf.Value : " ");
                  Telefone t = new Telefone();

                  t.tel_pessoal = tel1.Value;
                  t.tel_residencia = (tel2.Value != null ? tel2.Value : null);

                  if (Imagem.HasFile)
                  {
                      try
                      {

                          string filename = Path.GetFileName(Imagem.FileName);
                          Imagem.SaveAs(Server.MapPath("\\images\\" + filename));


                      }
                      catch (Exception ex)
                      {

                      }
                  }
                  using (BDEscolaDataContext cx = new BDEscolaDataContext())
                  {

                      if (al.Pessoa.id == 0)
                      {

                          cx.Alunos.InsertOnSubmit(al);
                          cx.SubmitChanges();
                          t.id = al.id;




                          cx.Telefones.InsertOnSubmit(t);
                          cx.SubmitChanges();

                          for (int i = 1; i <= 12; i++) 
                          {
                              if (Request.Form["" + i + "serie[]"] != null) {

                                  string[] sereies = Request.Form["" + i + "serie[]"].Split(',');
                                  if ((from c in cx.Cidades join es in cx.Estados on c.id_estado equals es.id where c.nome == sereies[2] && es.sigla == sereies[3] select c).SingleOrDefault() != null)
                                  {
                                      var idcidade = (from c in cx.Cidades join es in cx.Estados on c.id_estado equals es.id where c.nome == sereies[2] && es.sigla == sereies[3] select c.id).Single();

                                      historico h = new historico();
                                      h.id_serie = i;
                                      h.id_aluno = al.id;
                                      h.nome_escola = sereies[0];
                                      h.id_cidade = idcidade;
                                      h.ano = Int32.Parse(sereies[1]);

                                      cx.historicos.InsertOnSubmit(h);
                                      cx.SubmitChanges();


                                  }
                              
                              }
                          
                          }

                          LoadHistorico(al.id);
                          Matricular.PostBackUrl = "MatriculaAL.aspx?tipo=RM&SelctRm=" + al.rm;

                          string myScript = @" $(document).ready(function() {        
         $('.matricular').css('visibility','visible');
         $('.btnsalva').css('visibility','hidden');
      //alert('Sucesso!'); 
      bootbox.alert('Data Saved by Success !', function(result) {});
           
    });";
                          Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", myScript,
                          true);

                      }
                      else
                      {

                          cx.ExecuteCommand(@"UPDATE  Pessoa SET nome={0},data_nasc={1},sexo={2},cpf={3},rg={4},rua={5},bairro={6},
                                complemento={7},localidade={8} WHERE id={9}", al.Pessoa.nome, al.Pessoa.data_nasc, al.Pessoa.sexo, al.Pessoa.cpf,
                                                   al.Pessoa.rg, al.Pessoa.rua, al.Pessoa.bairro, al.Pessoa.complemento, al.Pessoa.localidade, al.Pessoa.id);

                          cx.ExecuteCommand(@"UPDATE Aluno set rm={0},ra={1},rne={2},nome_pai={3},nome_mae={4},
                                    foto={5},inf={6} WHERE id={7}", al.rm, al.ra, al.rne, al.nome_pai, al.nome_mae, al.foto, al.inf, al.Pessoa.id);

                          cx.ExecuteCommand(@"UPDATE Telefone set tel_pessoal={0},tel_residencia={1}
                                    WHERE id={2}", t.tel_pessoal, t.tel_residencia, al.Pessoa.id);


                          for (int i = 1; i <= 12; i++)
                          {
                              if (Request.Form["" + i + "serie[]"] != null)
                              {

                                  string[] sereies = Request.Form["" + i + "serie[]"].Split(',');
                                  if ((from c in cx.Cidades join es in cx.Estados on c.id_estado equals es.id where c.nome == sereies[2] && es.sigla == sereies[3] select c).SingleOrDefault() != null)
                                  {
                                      var idcidade = (from c in cx.Cidades join es in cx.Estados on c.id_estado equals es.id where c.nome == sereies[2] && es.sigla == sereies[3] select c.id).Single();

                                      historico h = new historico();
                                      h.id_serie = i;
                                      h.id_aluno = al.Pessoa.id;
                                      h.nome_escola = sereies[0];
                                      h.id_cidade = idcidade;
                                      h.ano = Int32.Parse(sereies[1]);

                                      if ((from hi in cx.historicos where hi.id_serie == h.id_serie && hi.id_aluno == h.id_aluno select hi).SingleOrDefault() != null)
                                      {
                                          cx.ExecuteCommand("UPDATE historico set nome_escola = {0} , ano = {1} , id_cidade = {2} where id_serie = {3} and id_aluno = {4}", h.nome_escola, h.ano, h.id_cidade, h.id_serie, h.id_aluno);

                                      }
                                      else
                                      {

                                          cx.historicos.InsertOnSubmit(h);
                                          cx.SubmitChanges();
                                      }

                                  }
                              }

                          }

                          LoadHistorico(al.Pessoa.id);

                          string myScript = @" $(document).ready(function() {        
         
      //alert('Sucesso!'); 
      bootbox.alert('Data Saved Successfully!', function(result) {});
           
    });";
                          Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", myScript,
                          true);

                      }

                      if (Imagem.HasFile)
                      {
                          Image1.ImageUrl = "../images/" + Imagem.FileName + "";

                      }
                      else
                      {
                          if (imagem_rec != null)
                          {
                              Image1.ImageUrl = "../images/" + imagem_rec + "";
                          }
                          else
                          {
                              Image1.ImageUrl = "../bootstrap/img/adm.png";
                          }
                      }
                  }
              }
              else 
              {

                  string myScript = @" $(document).ready(function() {        
         
      bootbox.alert('Fill in all fields marked * !', function(result) {});
           
    });";
                  Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", myScript,
                  true);
              }
        }
    }
}