using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterLinQ.PGALuno
{
    public partial class Print : System.Web.UI.Page
    {
        AnoLetivo anl = new AnoLetivo();
        protected void Page_Load(object sender, EventArgs e)
        {
            anl = (AnoLetivo)Session["ano"];
            if (!IsPostBack)
            {

                if (Request.Params["tipo"] != null)
                {

                    if (Request.Params["tipo"].Contains("RM"))
                    {

                         string rem = Request.Params["SelctRm"];

                         using (BDEscolaDataContext cx = new BDEscolaDataContext())
                         {
                             Aluno al = new Aluno();
                             al.Pessoa = new Pessoa();

                             al.id = 0;


                             if (cx.Alunos.SingleOrDefault(a => a.rm == rem) == null)
                             {
                                 // Response.Redirect("Alunos.aspx");
                                 string myScript = @"  $(document).ready(function() {
                                            bootbox.alert('Student not Found !', function(result) {
                                            window.location = 'Alunos.aspx';});});";
                                 Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", myScript,
                                 true);
                             }
                             else
                             {
                                 al = cx.Alunos.Single(a => a.rm == rem);
                                 lblNome.Text = al.Pessoa.nome;
                                 lblrg.Text = al.Pessoa.rg;
                                 lblRM.Text = al.rm;

                                 if((from m in cx.Matriculas where m.id_aluno == al.id && m.data == anl.ano && (m.desativado == 0 || m.desativado > anl.ano) select m).SingleOrDefault()!= null){
                                 var matr = (from m in cx.Matriculas where m.id_aluno == al.id && m.data == anl.ano && (m.desativado == 0 || m.desativado > anl.ano) select m).Single();
                                 var turma = cx.Turmas.Single(t => t.id == matr.id_turma);
                                 lblserie.Text = turma.nome;
                                 lblperiodo.Text = turma.periodo;

                                 var disc = (from rt in cx.r_Turma_Disc_Profs where rt.id_turma == matr.id_turma select rt).ToList();
                                 var bi = cx.Bimestres.ToList();
                                 grades.Text = "";

                              string table = "";
                                 foreach (var item in disc)
                                 {
                                     int totalfalta = 0;
                                     decimal somanotas = 0;
                                     string st = "";
                                     table += @" <tr>

                                                        <td>"+item.Disciplina.nome+@"</td>";

                                                foreach(var b in bi){

                                                    if ((from r in cx.r_matr_r_Turma_Disc_Profs where r.id_bimestre == b.id && r.id_matricula == matr.id && r.id_disci == item.id_disciplina && r.id_turma == matr.id_turma select r).SingleOrDefault() != null)
                                                    {
                                                        var notasfaltas = (from r in cx.r_matr_r_Turma_Disc_Profs where r.id_bimestre == b.id && r.id_matricula == matr.id && r.id_disci == item.id_disciplina && r.id_turma == matr.id_turma select r).Single();
                                                        table += @"   
                                                        <td>" + notasfaltas.nota + " <input type='hidden' id='" + b.nome.Replace(" ", "_")+ "' value='"+notasfaltas.nota+@"'/>  </td>
                                                        <td>" +notasfaltas.faltas+"</td>";
                                                        somanotas += notasfaltas.nota;
                                                        totalfalta += notasfaltas.faltas;
                                                    }
                                                }
                                                string color = "";
                                                if ((somanotas / 4) >= 6 && totalfalta <= 20)
                                                {
                                                    table += @"   <td>N</td>";
                                                   st = "Approved";

                                                }
                                                else
                                                if((somanotas / 4) >= 6 && totalfalta > 20) {
                                                    table += @"<td></td>";
                                                    st = "Reproved";
                                                    color = "style='color:red'";
                                                }else
                                                    if ((somanotas / 4) < 6 && totalfalta <= 20)
                                                    {

                                                        table += @"<td>" + (6 - (somanotas / 4)) + "</td>";
                                                        st = "Reproved";
                                                    
                                                    } else
                                                        if ((somanotas / 4) < 6 && totalfalta > 20)
                                                        {
                                                            table += @"<td>" + (6 - (somanotas / 4)) + "</td>";
                                                            st = "Reproved";
                                                            color = "style='color:red'";
                                                        }

                                                table += @"<td "+color+" >"+totalfalta+@"</td>
                                                            <td>"+st+@"</div></td>
                                                            </tr>";
                                    
                                 }
                                 grades.Text = table;

                                }
                            }
                         }
                    }
                    else if (Request.Params["tipo"].Contains("Name"))
                    {


                        string nome = Request.Params["SelectName"];

                        using (BDEscolaDataContext cx = new BDEscolaDataContext())
                        {
                            Aluno al = new Aluno();
                            al.Pessoa = new Pessoa();

                            al.id = 0;


                            if (cx.Alunos.SingleOrDefault(a => a.Pessoa.nome == nome) == null)
                            {
                                // Response.Redirect("Alunos.aspx");
                                string myScript = @"  $(document).ready(function() {
                                            bootbox.alert('Student not Found !', function(result) {
                                            window.location = 'Alunos.aspx';});});";
                                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", myScript,
                                true);
                            }
                            else
                            {
                                al = cx.Alunos.Single(a => a.Pessoa.nome == nome);
                                lblNome.Text = al.Pessoa.nome;
                                lblrg.Text = al.Pessoa.rg;
                                lblRM.Text = al.rm;

                                if ((from m in cx.Matriculas where m.id_aluno == al.id && m.data == anl.ano && (m.desativado == 0 || m.desativado > anl.ano) select m).SingleOrDefault() != null)
                                {
                                    var matr = (from m in cx.Matriculas where m.id_aluno == al.id && m.data == anl.ano && (m.desativado == 0 || m.desativado > anl.ano) select m).Single();
                                    var turma = cx.Turmas.Single(t => t.id == matr.id_turma);
                                    lblserie.Text = turma.nome;
                                    lblperiodo.Text = turma.periodo;

                                    var disc = (from rt in cx.r_Turma_Disc_Profs where rt.id_turma == matr.id_turma select rt).ToList();
                                    var bi = cx.Bimestres.ToList();
                                    grades.Text = "";

                                    string table = "";
                                    foreach (var item in disc)
                                    {
                                        int totalfalta = 0;
                                        decimal somanotas = 0;
                                        string st = "";
                                        table += @" <tr>

                                                        <td>" + item.Disciplina.nome + @"</td>";

                                        foreach (var b in bi)
                                        {


                                            if ((from r in cx.r_matr_r_Turma_Disc_Profs where r.id_bimestre == b.id && r.id_matricula == matr.id && r.id_disci == item.id_disciplina && r.id_turma == matr.id_turma select r).SingleOrDefault() != null)
                                            {
                                                var notasfaltas = (from r in cx.r_matr_r_Turma_Disc_Profs where r.id_bimestre == b.id && r.id_matricula == matr.id && r.id_disci == item.id_disciplina && r.id_turma == matr.id_turma select r).Single();
                                                table += @"   
                                                        <td>" + notasfaltas.nota + " <input type='hidden' id='" + b.nome.Replace(" ", "_") + "' value='" + notasfaltas.nota + @"'/>  </td>
                                                        <td>" + notasfaltas.faltas + "</td>";
                                                somanotas += notasfaltas.nota;
                                                totalfalta += notasfaltas.faltas;
                                            }
                                        }

                                        string color = "";
                                        if ((somanotas / 4) >= 6 && totalfalta <= 20)
                                        {
                                            table += @"   <td>N</td>";
                                            st = "Approved";

                                        }
                                        else
                                            if ((somanotas / 4) >= 6 && totalfalta > 20)
                                            {
                                                table += @"<td></td>";
                                                st = "Reproved";
                                                color = "style='color:red'";
                                            }
                                            else
                                                if ((somanotas / 4) < 6 && totalfalta <= 20)
                                                {

                                                    table += @"<td>" + (6 - (somanotas / 4)) + "</td>";
                                                    st = "Reproved";

                                                }
                                                else
                                                    if ((somanotas / 4) < 6 && totalfalta > 20)
                                                    {
                                                        table += @"<td>" + (6 - (somanotas / 4)) + "</td>";
                                                        st = "Reproved";
                                                        color = "style='color:red'";
                                                    }

                                        table += @"<td " + color + " >" + totalfalta + @"</td>
                                                            <td>" + st + @"</div></td>
                                                            </tr>";

                                    }
                                    grades.Text = table;

                                }
                            }
                        }
                    }
                }
            }

        }
    }
}