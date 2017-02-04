using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterLinQ.PGClasse
{
    public partial class Cria_Sala : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Confirma.Visible = false;
                Cancela.Visible = false;
                Mensagem.Visible = false;
                criar.Visible = false;
                limpar.Visible = false;

            }
            else
            {

                if (Nome.SelectedItem.Text != null && Request.Params["Complemento"] == null && Request.Params["NPeriodo"] == null)
                {

                    using (BDEscolaDataContext cx = new BDEscolaDataContext())
                    {
                        if (cx.Turmas.FirstOrDefault(t => t.nome.Contains(Nome.SelectedItem.Text) && t.desativado == 0 || t.desativado > DateTime.Now.Year) != null)
                        {
                            //var turmas =  cx.Turmas.FirstOrDefault(t => t.nome.Contains(Nome.Value) && t.desativado == 0 || t.desativado > DateTime.Now.Year);
                            var turmas = (from t in cx.Turmas
                                          where t.nome.Contains(Nome.SelectedItem.Text) && t.desativado == 0 || t.desativado > DateTime.Now.Year
                                          select t).ToList();

                            var tur = turmas.First();

                            var rturmas = (from rl in cx.r_Turma_Disc_Profs
                                           where rl.id_turma == tur.id
                                           select rl).ToList();
                            List<Professor> pl = new List<Professor>();
                            List<Disciplina> dl = new List<Disciplina>();
                            foreach (var item in rturmas)
                            {
                                Professor p = new Professor();
                                p.Pessoa = new Pessoa();
                                Disciplina d = new Disciplina();
                                //  p=cx.Professors.Single(prof => prof.id == item.id_prof);
                                p = (from rl in cx.r_Turma_Disc_Profs
                                     join pr in cx.Professors on rl.id_prof equals pr.id
                                     where rl.id_turma == item.id_turma && rl.id_disciplina == item.id_disciplina
                                     select pr).Single();
                                d = (from rl in cx.r_Turma_Disc_Profs
                                     join di in cx.Disciplinas on rl.id_disciplina equals di.id
                                     where rl.id_prof == item.id_prof && rl.id_turma == item.id_turma && rl.id_disciplina == item.id_disciplina
                                     select di).Single();
                                //d = cx.Disciplinas.Single(c => c.id == item.id_disciplina);
                                pl.Add(p);
                                dl.Add(d);

                            }


                            string[] ListaMaterias = new string[dl.Count];
                            string[] ListaProfe = new string[pl.Count];
                            string print = " ";
                            int i = 0;
                            foreach (var item in dl)
                            {
                                ListaMaterias[i] = @"
                                                <div class='row'>
                                                 <div class='pull-left' style='margin-right: 60px;'>
                                                   <input type='text' readonly value='" + item.nome + @"' class='form-control' /> 
                                                </div>";
                                i++;

                            }

                            int b = 0;
                            foreach (var item in pl)
                            {

                                ListaProfe[b] = @"<div class='pull-rigth'>
                                                   <input type='text' readonly value='" + item.Pessoa.nome + @"' class='form-control' /> 
                                                  </div>
                                            </div>";
                                b++;

                            }
                            for (int x = 0; x < ListaMaterias.Length; x++)
                            {

                                print += ListaMaterias[x] + ListaProfe[x];
                            }
                            string[] opt = { "A", "B", "C", "D", "E", "F", "G" };
                            string option = "";
                            string res1 = " ";

                            foreach (var item in turmas)
                            {

                                for (int a = 0; a < opt.Length; a++)
                                {
                                    string nome = item.nome;
                                    int pos = nome.IndexOf(opt[a]);
                                    if (pos != -1)
                                    {
                                        res1 += " " + opt[a];                                    // option += "<option>" + opt[a] + "</option>";
                                    }




                                }



                            }


                            for (int x = 0; x < opt.Length; x++)
                            {
                                string nome = res1;
                                int pos = nome.IndexOf(opt[x]);
                                if (pos == -1)
                                {
                                    option += "<option>" + opt[x] + "</option>";                                 // option += "<option>" + opt[a] + "</option>";
                                }


                            }

                            LiStMat.Text = @"  Complement:<span style='color:red'>*</span><select class='form-control' name='Complemento' id='Comple' style='width:80px' >
                                        <option value = '0'>Choose</option>
                                        " + option + @"
                                        
                                    </select>

                                     Period:<span style='color:red'>*</span> <select class='form-control' name='NPeriodo'  style=' width: 150px; '  >
                                        <option value='0'>Select a Period</option>
                                        <option>Matutino</option>
                                        <option>Vespertino</option>
                                        <option>Noturno</option>
                                    </select>
                     <h5>Disciplines that Will be Add  </h5>	
                    <div class='row' style=' width: 500px;'>
                        <div class='pull-left form-group ' style='style='width: 500px;'>
                            <h4>Subjects</h4><br/>
                        </div>
                        <div class='pull-right form-group ' style='width:220px'>
                            <h4>Teacher</h4><br/>
                        </div>
                         
                    </div>

                    <div class='row'>
                        <div class='  aula ' style=' width: 500px;'>
                       " + print + @"
                        </div>
                    </div>       
                  </div>";
                            ViewState["idTurma"] = tur.id;
                            Confirma.Visible = true;
                            Cancela.Visible = true;
                            Mensagem.Visible = true;
                        }
                        else {


                            ListaNewTurma.Text = @" Complement:<span style='color:red;'>*</span> <select class='form-control' style=' width: 80px; name='Complemento' id='Comple'  >
                                        <option vaue = '0'>Choose</option>
                                        <option>A</option>
                                        <option>B</option>
                                        <option>C</option>
                                        <option>D</option>
                                        <option>F</option>
                                        <option>G</option>
                                        <option>H</option>
                                        
                                    </select>
 Period: <span style='color:red'>*</span> <select class='form-control' name='NPeriodo' id='Periodo' style=' width:150px; ' >
                                        <option value = '0'>Select a Period</option>
                                        <option>Matutino</option>
                                        <option>Vespertino</option>
                                        <option>Noturno</option>
                                    </select>

<div class='row' style=' width: 540px;'>
                        <div class=' pull-left form-group  'style='width:200px'>
                            <h4>Subjects</h4><br/>
                        </div>
                        <div class=' form-group '>
                            <h4 style='margin-left: 320px;' > Teacher</h4><br/>
                        </div>
                         
                    </div>

                    <div class='row'>
                        <div class=' col-lg-8 aula ' style='width: 600px;'>
                            <div class='row'>
                                <div class='pull-left'  style='width: 200px; margin-right: 120px;'>
                                   <select id='Materia' name='Materias[]' class='form-control'>
                                                                    
                                   </select>
                                   </div>
                                  <div class=' pull-left'>
                                  <select name='Professores[]' id='Professor' class='form-control'>
                                  </select>		
                                  </div>	
                               
                               
                                <div class='pull-left'>
                                    <a class='btn btn-success aula-add' style=' margin-left: 30px;' onclick=' ad_aula()'>+</a>
                                </div>
                            </div>
                        </div>
                           <div class='col-lg-8  btn-group btn-toolbar'>
                                                        <div class='row'>
                                                            <div class='col-lg-8'>
                                                                <asp:Button ID='Save' runat='server' Text='Sava' CssClass='btn btn-success' OnClick='criar_Click' />
                                                               
                                                              
                                                            </div>
                                                        </div>
                                                    </div>
                    </div>";

                            criar.Visible = true;
                            limpar.Visible = true;
                        
                        }

                        }
                    }
                }
            
        }

        protected void criar_Click(object sender, EventArgs e)
        {


            if (Request.Params["Complemento"] != "0" && Request.Params["NPeriodo"] != "0")
            {
                Turma t = new Turma();
                r_Turma_Disc_Prof rel;

                t.nome = Nome.SelectedItem.Text;
                t.nome += " " + Request.Params["Complemento"];// Comple.SelectedItem.Text;
                //t.periodo = Periodo.Value;
                t.desativado = 0;
                t.periodo = Request.Params["NPeriodo"];

           
                string[] profs = Request.Params["Professores[]"].Split(',');
                string[] mate = Request.Params["Materias[]"].Split(',');

                if (profs[0] != "00" && mate[0] != "00")
                {

                    using (BDEscolaDataContext cx = new BDEscolaDataContext())
                    {
                        if ((from tur in cx.Turmas where tur.nome.Contains(t.nome) && tur.desativado ==0 select tur).FirstOrDefault() == null)
                        {

                            cx.Turmas.InsertOnSubmit(t);
                            cx.SubmitChanges();

                            for (int i = 0; i < profs.Length; i++)
                            {
                                rel = new r_Turma_Disc_Prof();
                                rel.id_turma = t.id;
                                rel.id_disciplina = Int32.Parse(mate[i]);
                                rel.id_prof = Int32.Parse(profs[i]);
                                rel.data = 0;
                                rel.desativado = 0;

                                try
                                {
                                    cx.r_Turma_Disc_Profs.InsertOnSubmit(rel);
                                    cx.SubmitChanges();
                                }
                                catch (Exception ex)
                                { }
                                string myScript = @"  $(document).ready(function() {
                                            bootbox.alert('The Classroom Was Created!', function(result) {
                                            window.location = 'Cria_Sala.aspx';});});";
                                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", myScript,
                                true);

                            }
                        }
                        else {


                            string myScript = @"  $(document).ready(function() {
                                            bootbox.alert('The Classroom Already Created!', function(result) {
                                          }) });";
                            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", myScript,
                            true);
                        }
                    }
                }
                else 
                {

                    string myScript = @" $(document).ready(function() {        
         
      bootbox.alert('Select the Disciplines and Teachers!', function(result) {});
           
    });";
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", myScript,
                    true);
            
                
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

        protected void Confirma_Click(object sender, EventArgs e)
        {

            if (Request.Params["Complemento"] != "0" && Request.Params["NPeriodo"] != "0")
            {
                int idturma = (int)ViewState["idTurma"];
                using (BDEscolaDataContext cx = new BDEscolaDataContext())
                {
                    var rt = (from r in cx.r_Turma_Disc_Profs
                              where r.id_turma == idturma
                              select r).ToList();

                    Turma tu = new Turma();


                    tu.nome = Nome.SelectedItem.Text;
                    tu.nome += " " + Request.Params["Complemento"];
                    tu.periodo = Request.Params["NPeriodo"];
                    tu.desativado = 0;
                    cx.Turmas.InsertOnSubmit(tu);

                    cx.SubmitChanges();
                    foreach (var item in rt)
                    {
                        r_Turma_Disc_Prof rtu = new r_Turma_Disc_Prof();

                        rtu.data = item.data;
                        rtu.desativado = item.desativado;
                        rtu.id_disciplina = item.id_disciplina;
                        rtu.id_prof = item.id_prof;
                        rtu.id_turma = tu.id;

                        try
                        {
                            cx.r_Turma_Disc_Profs.InsertOnSubmit(rtu);
                            cx.SubmitChanges();
                        }
                        catch (Exception ex)
                        { 
                        
                        
                        }


                    }
                    string myScript = @"  $(document).ready(function() {
                                            bootbox.alert('The Classroom Was Created!', function(result) {
                                            window.location = 'Cria_Sala.aspx';});});";
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", myScript,
                    true);

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

        protected void Cancela_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cria_Sala.aspx");
        }
    }
}