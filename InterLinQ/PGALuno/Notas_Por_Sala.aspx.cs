using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterLinQ.PGALuno
{
    public partial class Notas_Por_Sala : System.Web.UI.Page
    {
        AnoLetivo anl = new AnoLetivo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ano"] != null)
            {
                if (Request.Params["idTurma"] != null)
                {
                    anl = (AnoLetivo)Session["ano"];
                    int id = Int32.Parse(Request.Params["idTurma"]);
                    List<Table> tab = new List<Table>();
                    tab.Add(Table);
                    tab.Add(Table1);
                    tab.Add(Table2);
                    tab.Add(Table3);


                    using (BDEscolaDataContext cx = new BDEscolaDataContext())
                    {
                        int bimestre = 1;
                        foreach (var tabela in tab)
                        {
                            var listMat = (from t in cx.Turmas
                                           join r in cx.r_Turma_Disc_Profs on t.id equals r.id_turma
                                           join d in cx.Disciplinas on r.id_disciplina equals d.id
                                           where t.id == id && (r.desativado > anl.ano || r.desativado == 0) && (r.data <= anl.ano)
                                           select new { idmat = d.id, nomeMat = d.nome }).ToList();

                            TableRow th = new TableRow();
                            th.TableSection = TableRowSection.TableHeader;
                            TableCell c1;
                            c1 = new TableCell();
                            c1.Controls.Add(new LiteralControl("Studant's Name"));
                            th.Cells.Add(c1);
                            foreach (var item in listMat)
                            {

                                TableCell ch = new TableCell();


                                ch.Controls.Add(new LiteralControl(item.nomeMat.ToString()));
                                th.Cells.Add(ch);
                            }


                            c1 = new TableCell();
                            c1.Controls.Add(new LiteralControl("Abcenses"));
                            th.Cells.Add(c1);

                            tabela.Rows.Add(th);

                            //linhs
                            var qtdlinhas = (from m in cx.Matriculas
                                             where m.id_turma == id
                                             select m).ToList();

                            foreach (var lin in qtdlinhas)
                            {
                                var mat = (from m in cx.Matriculas
                                           join a in cx.Alunos on m.id_aluno equals a.id
                                           where m.id_aluno == lin.id_aluno && m.id == lin.id && a.status == 1 && m.data == anl.ano
                                           select new { nome = a.Pessoa.nome, idMatricula = m.id }).FirstOrDefault();

                                int totalf = 0;

                                if (mat != null)
                                {

                                    TableRow r = new TableRow();
                                    TableCell c;
                                    c = new TableCell();
                                    c.Controls.Add(new LiteralControl(mat.nome.ToString()));
                                    r.Cells.Add(c);

                                    foreach (var col in listMat)
                                    {
                                        if (cx.r_matr_r_Turma_Disc_Profs.SingleOrDefault(rl => rl.id_turma == id && rl.id_matricula == mat.idMatricula && rl.id_disci == col.idmat && rl.id_bimestre == bimestre && (rl.desativado == 0 || rl.desativado > anl.ano)) != null)
                                        {
                                            var nota = cx.r_matr_r_Turma_Disc_Profs.Single(rl => rl.id_turma == id && rl.id_matricula == mat.idMatricula && rl.id_disci == col.idmat && rl.id_bimestre == bimestre && (rl.desativado == 0 || rl.desativado > anl.ano));
                                            totalf += nota.faltas;


                                            c = new TableCell();
                                            c.Controls.Add(new LiteralControl(nota.nota.ToString()));
                                            r.Cells.Add(c);
                                        }
                                        else
                                        {
                                            c = new TableCell();
                                            c.Controls.Add(new LiteralControl(" "));
                                            r.Cells.Add(c);
                                        }
                                    }

                                    c = new TableCell();
                                    c.Controls.Add(new LiteralControl(totalf.ToString()));
                                    r.Cells.Add(c);


                                    tabela.Rows.Add(r);
                                }
                            }

                            bimestre++;
                        }


                    }
                }
            }


        }
    }
}