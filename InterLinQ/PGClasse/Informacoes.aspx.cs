using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterLinQ.PGClasse
{
    public partial class Informacoes : System.Web.UI.Page
    {

        AnoLetivo anl = new AnoLetivo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ano"] != null)
            {
                anl = (AnoLetivo)Session["ano"];
                if (Request.Form["materiasExcluir[]"] != null || (Request.Params["AlunosTransferir[]"] != null))
                {
                    int id = Int32.Parse(Request.Params["id"]);
                    if (Request.Form["materiasExcluir[]"] != null)
                    {
                        string[] materias = Request.Form["materiasExcluir[]"].Split(',');
                        string[] professor = Request.Form["ProfessorExcluir[]"].Split(',');


                        using (BDEscolaDataContext cx = new BDEscolaDataContext())
                        {

                            for (int i = 0; i < materias.Length; i++)
                            {
                                if (cx.r_matr_r_Turma_Disc_Profs.FirstOrDefault(t => t.id_turma == id) != null || cx.Matriculas.FirstOrDefault(m => m.id_turma == id) != null)
                                {


                                    cx.ExecuteCommand("Update r_Turma_Disc_Prof set desativado = {0}  where id_turma = {1} and id_disciplina = {2} and id_prof = {3}", anl.ano, id, materias[i], professor[i]);
                                }
                                else
                                {
                                    cx.ExecuteCommand("DELETE FROM r_Turma_Disc_Prof  where id_turma = {0} and id_disciplina = {1} and id_prof = {2}", id, materias[i], professor[i]);


                                }
                            }
                            // Response.Redirect("Informacoes.aspx?id=" + id);

                        }
                    }



                    if (Request.Params["AlunosTransferir[]"] != null)
                    {

                        string[] idAlunos = Request.Params["AlunosTransferir[]"].Split(',');
                        string[] idTurmas = Request.Params["TurmaReceptora[]"].Split(',');


                        using (BDEscolaDataContext cx = new BDEscolaDataContext())
                        {


                            for (int i = 0; i < idAlunos.Length; i++)
                            {
                                var idmatr = cx.Matriculas.Single(m => m.id_aluno == Int32.Parse(idAlunos[i]) && (m.desativado == 0 || m.desativado > anl.ano) && m.data == anl.ano);
                                cx.ExecuteCommand("Update r_matr_r_Turma_Disc_Prof set id_turma = {0}  where  id_matricula = {1}  ", idTurmas[i], idmatr.id);
                                cx.ExecuteCommand("Update Matricula set id_turma = {0}  where  id= {1} ", idTurmas[i], idmatr.id);


                            }

                        }



                    }
                    Response.Redirect("Informacoes.aspx?id=" + id);
                }




                if (!IsPostBack)
                {

                    using (BDEscolaDataContext cx = new BDEscolaDataContext())
                    {
                        List<r_Turma_Disc_Prof> list = new List<r_Turma_Disc_Prof>();

                        try
                        {
                            int vr_disp = 0;
                            int id = Int32.Parse(Request.Params["id"]);
                            IDTurma.Value = id.ToString();

                            //vou recuperar uma lista da rel entre disciplina professor e turma 
                            //linhas

                            list = cx.r_Turma_Disc_Profs.Where(p => p.id_turma == id && (p.data <= anl.ano || p.data == 0) && (p.desativado == 0 || p.desativado > anl.ano)).ToList();

                            if ((from r in cx.r_matr_r_Turma_Disc_Profs
                                 join t in cx.Turmas on r.id_turma equals t.id
                                 where (r.data == anl.ano || r.data == 0) && t.id == id && (r.desativado > anl.ano || r.desativado == 0)
                                 select r).FirstOrDefault() != null)
                            {
                                //verifica se a turma ja tem lançamento de notas no ano vigente, caso tenha nao sera possivel adicionar materias 
                                vr_disp = 1;
                                Atualiza.Visible = false;

                            }


                            TableRow th;
                            th = new TableRow();
                            th.TableSection = TableRowSection.TableHeader;
                            TableCell c1;
                            c1 = new TableCell();
                            c1.Controls.Add(new LiteralControl("Name"));
                            th.Cells.Add(c1);

                            c1 = new TableCell();
                            c1.Controls.Add(new LiteralControl("Teacher"));
                            th.Cells.Add(c1);
                            if (vr_disp != 1)
                            {
                                c1 = new TableCell();
                                c1.Controls.Add(new LiteralControl("Delete"));
                                th.Cells.Add(c1);
                            }
                            tb_materias.Rows.Add(th);


                            foreach (var rel in list)
                            {
                                TableRow r = new TableRow();
                                TableCell c;

                                c = new TableCell();

                                c.Controls.Add(new LiteralControl(@"<h4 >" + rel.Disciplina.nome + " </h4> <input type='hidden' id='IdDisciplina' class='iddisc' value='" + rel.Disciplina.id + "'/>"));


                                r.Cells.Add(c);

                                c = new TableCell();

                                c.Controls.Add(new LiteralControl(@"<h4 >" + rel.Professor.Pessoa.nome + "</h4>  <input type='hidden' id='IdProfessor' class='idprof' value='" + rel.Professor.id + "'/>"));
                                r.Cells.Add(c);

                                if (vr_disp != 1)
                                {
                                    c = new TableCell();
                                    c.Controls.Add(new LiteralControl(@"<a class=' btn btn-danger' onclick='deleteMateria(this)'  ><img src='../bootstrap/img/deletar_inf.png' class='img_inf'/></a>"));
                                    r.Cells.Add(c);
                                }
                                tb_materias.Rows.Add(r);
                            }

                            //tabela de alunos 

                            th = new TableRow();
                            th.TableSection = TableRowSection.TableHeader;

                            c1 = new TableCell();
                            c1.Controls.Add(new LiteralControl("Name"));
                            th.Cells.Add(c1);

                            c1 = new TableCell();
                            c1.Controls.Add(new LiteralControl("Class"));
                            th.Cells.Add(c1);

                            c1 = new TableCell();
                            c1.Controls.Add(new LiteralControl("Alter"));
                            th.Cells.Add(c1);
                            tb_aluno.Rows.Add(th);

                            //vou recuperar uma lista de alunos contido na turma e o select tera todas as turmas disponiveis  
                            //linhas

                            if (cx.Matriculas.FirstOrDefault(mt => mt.id_turma == id) != null)
                            {
                                var alunosmtr = (from m in cx.Matriculas
                                                 join a in cx.Alunos on m.id_aluno equals a.id
                                                 where m.id_turma == id && a.status == 1 && m.data == anl.ano
                                                 select a).ToList();
                                var turma = cx.Turmas.Single(t => t.id == id);
                                string partNome = turma.nome.Substring(0, 5);
                                var turmarela = (from t in cx.Turmas
                                                 where t.nome.Contains(partNome) && (t.desativado == 0 || t.desativado > anl.ano) && t.id != id
                                                 select t).ToList();
                                string options = "";
                                foreach (var item in turmarela)
                                {
                                    options += "<option value='" + item.id + "'>" + item.nome + "</option>\n";
                                }

                                foreach (var item in alunosmtr)
                                {
                                    TableRow r = new TableRow();
                                    TableCell c;

                                    c = new TableCell();

                                    c.Controls.Add(new LiteralControl(@"<input type='text' readonly='' value='" + item.Pessoa.nome + " '/> <input type='hidden'  class='IdAluno' value='" + item.id + "'/>"));


                                    r.Cells.Add(c);

                                    c = new TableCell();

                                    c.Controls.Add(new LiteralControl(@"<select disabled='' onchange='AlteraTurma(this)'>
                                                    <option value='0' > Chose a new Class</option>
                                                " + options + @"
                                            </select>"));
                                    r.Cells.Add(c);

                                    c = new TableCell();
                                    c.Controls.Add(new LiteralControl(@"<a class='btn btn-info' onclick='atualizaMateria(this)' ><img  src='../bootstrap/img/editas_inf.png' class='img_inf'/></a> "));
                                    r.Cells.Add(c);

                                    tb_aluno.Rows.Add(r);
                                }
                            }
                            string myScript = @" 

                  $(document).ready(function() {
        
        var maskHeight = $(document).height();
        var maskWidth = $(window).width();

        $('#mascara').css({'width': maskWidth, 'height': maskHeight});

        $('#mascara').fadeIn(800);
        $('#mascara').fadeTo('slow', 0.4);

        //Get the window height and width
        var winH = $(window).height();
        var winW = $(window).width();

        $('#dialogo').css('top', winH / 2 - $('#dialogo').height() / 2);
        $('#dialogo').css('left', winW / 2 - $('#dialogo').width() / 2);

        $('#dialogo').fadeIn(900);

        $('.janela .fechar').click(function(e) {
            e.preventDefault();

            $('#mascara').hide();
            $('.janela').hide();
              window.location = 'Lista_Turmas.aspx';
            

        });

        $('#mascara').click(function() {
            $(this).hide();
            $('.janela').hide();
             window.location = 'Lista_Turmas.aspx';
            
        });
        
     
      
    });";
                            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", myScript,
                            true);

                        }
                        catch (Exception ex)
                        {
                            Response.Write(ex);
                        }

                    }

                }


            }
        }
    }
}