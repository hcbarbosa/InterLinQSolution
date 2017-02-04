
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterLinQ.PGALuno
{
    public partial class Notas_Faltas : System.Web.UI.Page
    {
         AnoLetivo anl = new AnoLetivo();
           
        static string selected = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ano"] != null)
            {
                anl = (AnoLetivo)Session["ano"];
                if (!IsPostBack)
                {
                    salva.Visible = false;
                    Clean.Visible = false;
                    if (Request.Params["tipo"] != null)
                    {
                        if (Request.Params["tipo"].Contains("RM"))
                        {

                            string rm = Request.Params["SelctRm"];


                            using (BDEscolaDataContext cx = new BDEscolaDataContext())
                            {

                                if (cx.Alunos.SingleOrDefault(a => a.rm == rm) == null)
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
                                    var al = cx.Alunos.Single(a => a.rm == rm);
                                    if ((from t in cx.Turmas
                                         join m in cx.Matriculas on t.id equals m.id_turma
                                         where m.id_aluno == al.id && m.data == anl.ano && t.desativado < anl.ano && (m.desativado == 0 || m.desativado > anl.ano)
                                         select m).SingleOrDefault() == null)
                                    {

                                        string myScript = @"  $(document).ready(function() {
                                            bootbox.alert('Student are not Registred !', function(result) {
                                            window.location = 'Alunos.aspx';});});";
                                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", myScript,
                                        true);

                                    }
                                    else
                                    {

                                        var turma = (from t in cx.Turmas
                                                     join m in cx.Matriculas on t.id equals m.id_turma
                                                     where m.id_aluno == al.id && m.data == anl.ano && t.desativado < anl.ano && (m.desativado == 0 || m.desativado > anl.ano)
                                                     select new { idturma = t.id, nomeTurma = t.nome, idMatr = m.id }).SingleOrDefault();
                                        var bimes = cx.Bimestres.ToList();
                                        ViewState["id"] = al.id;
                                        ViewState["Matr"] = turma.idMatr;
                                        ViewState["turma"] = turma.idturma;
                                        if (al.status != 1) { muda_bimestre.Visible = false; lblbimestre.Visible = false; }

                                        serie.Text = turma.nomeTurma;
                                        NomeAl.Text = al.Pessoa.nome;
                                        ListItem l;
                                        l = new ListItem();
                                        l.Text = "Choose";
                                        l.Value = "Choose";
                                        muda_bimestre.Items.Add(l);

                                        foreach (var i in bimes)
                                        {
                                            l = new ListItem();
                                            l.Text = i.nome;
                                            l.Value = i.id.ToString();
                                            muda_bimestre.Items.Add(l);


                                        }

                                        ListaTudo(al.id, turma.idMatr, turma.idturma);
                                    }
                                }
                            }
                        }
                        else if (Request.Params["tipo"].Contains("Name"))
                        {
                            string nome = Request.Params["SelectName"];


                            using (BDEscolaDataContext cx = new BDEscolaDataContext())
                            {


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

                                    var al = cx.Alunos.Single(a => a.Pessoa.nome.Contains(nome));


                                    if ((from t in cx.Turmas
                                         join m in cx.Matriculas on t.id equals m.id_turma
                                         where m.id_aluno == al.id && m.data == anl.ano && (t.desativado == 0 || t.desativado > anl.ano) && (m.desativado == 0 || m.desativado > anl.ano)
                                         select new { idturma = t.id, nomeTurma = t.nome }).SingleOrDefault() == null)
                                    {

                                        string myScript = @"  $(document).ready(function() {
                                            bootbox.alert('No Data To Show !', function(result) {
                                            window.location = 'Alunos.aspx';});});";
                                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", myScript,
                                        true);

                                    }
                                    else
                                    {
                                        var turma = (from t in cx.Turmas
                                                     join m in cx.Matriculas on t.id equals m.id_turma
                                                     where m.id_aluno == al.id && m.data == anl.ano && (t.desativado == 0 || t.desativado > anl.ano) && (m.desativado == 0 || m.desativado > anl.ano)
                                                     select new { idturma = t.id, nomeTurma = t.nome, idMatr = m.id }).SingleOrDefault();

                                        var bimes = cx.Bimestres.ToList();
                                        ViewState["id"] = al.id;
                                        ViewState["Matr"] = turma.idMatr;
                                        ViewState["turma"] = turma.idturma;
                                        if (al.status != 1) { muda_bimestre.Visible = false; lblbimestre.Visible = false; }

                                        serie.Text = turma.nomeTurma;
                                        NomeAl.Text = al.Pessoa.nome;
                                        ListItem l;
                                        l = new ListItem();
                                        l.Text = "Choose";
                                        l.Value = "Choose";
                                        muda_bimestre.Items.Add(l);

                                        foreach (var i in bimes)
                                        {
                                            l = new ListItem();
                                            l.Text = i.nome;
                                            l.Value = i.id.ToString();
                                            muda_bimestre.Items.Add(l);


                                        }

                                        ListaTudo(al.id, turma.idMatr, turma.idturma);
                                    }
                                }
                            }
                        }
                    }


                }
                else
                {
                    salva.Visible = true;
                    Clean.Visible = true;
                    string bi = muda_bimestre.SelectedItem.Text;
                    int id = (int)ViewState["id"];
                    int matr = (int)ViewState["Matr"];
                    int tur = (int)ViewState["turma"];


                    switch (bi)
                    {
                        case "Choose":

                            salva.Visible = false;
                            Clean.Visible = false;


                            ListaTudo(id, matr, tur);
                            break;
                        case "1st Bimester":
                            selected = bi;
                            LoadBimestre(id, bi, matr, tur);

                            break;

                        case "2nd Bimester":
                            selected = bi;
                            LoadBimestre(id, bi, matr, tur);
                            break;

                        case "3rd Bimester":
                            selected = bi;
                            LoadBimestre(id, bi, matr, tur);
                            break;
                        case "4th Bimester":
                            selected = bi;
                            LoadBimestre(id, bi, matr, tur);
                            break;


                    }

                }
            }
        }

        public void ListaTudo( int id , int matr , int turma)
        {
            salva.Visible = false;
            Clean.Visible = false;

            Tables.Visible = false;
            Table.Visible = true;
            if (selected != null)
            {
                ListItem li = muda_bimestre.Items.FindByText(selected);
                li.Selected = false;
                ListItem l2 = muda_bimestre.Items.FindByText("Choose");
                l2.Selected = true;
            }
            using (BDEscolaDataContext cx = new BDEscolaDataContext()){


               

                var disc = (from rl in cx.r_matr_r_Turma_Disc_Profs 
                            join r in cx.r_Turma_Disc_Profs  on rl.id_disci equals r.id_disciplina
                            join d in cx.Disciplinas on r.id_disciplina equals d.id
                            join t in cx.Turmas on r.id_turma equals t.id
                            join b in cx.Bimestres on rl.id_bimestre equals b.id
                            where rl.id_matricula == matr && (r.desativado == 0 || r.desativado > anl.ano) && t.id == turma && (rl.desativado == 0 || rl.desativado > anl.ano) && b.id ==1
                            select new { nome = d.nome, idDisc = d.id }).ToList(); 

                //var bim = (from r in cx.r_matr_r_Turma_Disc_Profs 
                //           join b in cx.Bimestres on r.id_bimestre equals b.id
                //           join m in cx.Matriculas on r.id_matricula equals m.id
                //           where m.id_aluno == id
                           
                //           select new {nome = b.nome , id = b.id}).ToList();
               
                List<Bimestre> listb = new List<Bimestre>();
                for (int i = 0; i < 4; i++) 
                {
                    Bimestre bim1 = new Bimestre();
                    bim1.id = 0;
                   var lbi = (from b in cx.Bimestres
                               join  r in cx.r_matr_r_Turma_Disc_Profs on b.id equals r.id_bimestre
                               join m in cx.Matriculas on r.id_matricula equals m.id
                              where m.id_aluno == id && b.id == i + 1 && m.data == anl.ano && (m.desativado == 0 || m.desativado > anl.ano)
                              select b).ToList();
                   if (lbi.Count > 0)
                   {
                       bim1 = lbi.First();

                       //if (bim1.id != 0)
                       //{
                           
                           listb.Add(bim1);

                       //}
                   }
                
                }
                 
                //foreach (var item in rl)
                //{
                //    notas[item.id_disci] = item.nota.ToString();
                //    faltas[item.id_disci] = item.faltas.ToString();
                //}

                
               TableRow th = new TableRow();
               th.TableSection = TableRowSection.TableHeader;
               TableCell c1;
            c1 = new TableCell();
            c1.Controls.Add(new LiteralControl("Subjects"));
            th.Cells.Add(c1);
            foreach(var item in listb)
            {

                TableCell ch = new TableCell();


                ch.Controls.Add(new LiteralControl(item.nome.ToString()));
                th.Cells.Add(ch);
            }
            c1 = new TableCell();
            c1.Controls.Add(new LiteralControl("Total Absences"));
            th.Cells.Add(c1);
            Table.Rows.Add(th);

            //linhas
            foreach(var d in disc)
            {
                int totalf = 0;
               


                TableRow r = new TableRow();
                TableCell c;
                c = new TableCell();
                c.Controls.Add(new LiteralControl(d.nome.ToString()));
                r.Cells.Add(c);
                //colunas
               foreach(var item in listb)
                {
                    var nf = cx.ExecuteQuery<r_matr_r_Turma_Disc_Prof>(@"Select * from r_matr_r_Turma_Disc_Prof r join Matricula m on(r.id_matricula = m.id)  where r.id_disci = " + d.idDisc + "   and r.id_bimestre = " + item.id + " and m.id_aluno = " + id + " and r.data = " + anl.ano + " and (r.desativado = 0 or r.desativado > " + anl.ano + ") and (m.desativado = 0 or m.desativado > " + anl.ano + ")");
                    // var notasFaltas = cx.r_matr_r_Turma_Disc_Profs.Single(rl => rl.id_disci == d.idDisc && rl.id_bimestre == item.id);
                    var notasFaltas = nf.First(); 
                   totalf += notasFaltas.faltas;
                    c = new TableCell();

                    c.Controls.Add(new LiteralControl("<input type='text' readonly='' class='in_tab ' onkeypress='Nota(this)'  name='notas_" + item.nome.Replace(" ", "_").ToLower() + "_" + d.nome + "[]' value='" + notasFaltas.nota + "'/> "));


                    r.Cells.Add(c);
                }
                c = new TableCell();
                c.Controls.Add(new LiteralControl("<input type='text' readonly='' class='in_tab ' onkeypress='MascaraFalta(this)' value='" + totalf + "'/> "));
                r.Cells.Add(c);

                Table.Rows.Add(r);
            }
            }
       // }catch(Exception ex )
        
        //{
        //    Response.Write(ex);
        
        //}
        }
        private void LoadBimestre(int id, string bimestre , int matr , int turma)
        {
            Tables.Visible = true;
            Table.Visible = false;
                           
           // string[] mat = { "Portgues", "Portgues", "Matematica", "Historia", "Geografia", "Literatura", "Portgues", "Matematica", "Historia", "Geografia", "Literatura", "Matematica", "Historia" };
            using (BDEscolaDataContext cx = new BDEscolaDataContext())
            {

                var recb = cx.Bimestres.Single(b => b.nome.Contains(bimestre));
                //verifica se ja tem lançamento de notas 
                var exm = (from rls in cx.r_matr_r_Turma_Disc_Profs
                           join m in cx.Matriculas on rls.id_matricula equals m.id

                           where m.id_aluno == id && rls.id_bimestre == recb.id && m.data == anl.ano && (m.desativado == 0 || m.desativado > anl.ano)
                           select m).ToList();
                //se for maior que 0 indica que ja existe lançamento de notas e sera uma edcao 
                if (exm.Count > 0)
                {
                    //string vnome = "" + bimestre.Replace(" ", "_") + "";
                    ViewState[""+recb.id+""] = 1;
                    ViewState["fluxo"] = recb.id;
                    salva.Text = "Update";
                    var disc = (from rl in cx.r_matr_r_Turma_Disc_Profs 
                                join r in cx.r_Turma_Disc_Profs  on rl.id_disci equals r.id_disciplina
                                join d in cx.Disciplinas on r.id_disciplina equals d.id
                                join t in cx.Turmas on r.id_turma equals t.id
                                join b in cx.Bimestres on rl.id_bimestre equals b.id
                                where rl.id_matricula == matr && t.id == turma && (r.desativado == 0 || r.desativado > anl.ano) && (rl.desativado == 0 || rl.desativado > anl.ano) && b.id == recb.id
                                select new { nome = d.nome, idDisc = d.id }).ToList();
                               

                    //var bim = (from r in cx.r_matr_r_Turma_Disc_Profs 
                    //           join b in cx.Bimestres on r.id_bimestre equals b.id
                    //           join m in cx.Matriculas on r.id_matricula equals m.id
                    //           where m.id_aluno == id

                    //           select new {nome = b.nome , id = b.id}).ToList();

                    List<Bimestre> listb = new List<Bimestre>();
                    
                        Bimestre bim1 = new Bimestre();
                        bim1.id = 0;
                        var lbi = (from b in cx.Bimestres
                                   join r in cx.r_matr_r_Turma_Disc_Profs on b.id equals r.id_bimestre
                                   join m in cx.Matriculas on r.id_matricula equals m.id
                                   where m.id_aluno == id && b.id == recb.id && m.data == anl.ano && (m.desativado == 0 || m.desativado > anl.ano)
                                   select b).ToList();
                        if (lbi.Count > 0)
                        {
                            bim1 = lbi.First();

                            //if (bim1.id != 0)
                            
                            listb.Add(bim1);

                            //}
                    }

                    //foreach (var item in rl)
                    //{
                    //    notas[item.id_disci] = item.nota.ToString();
                    //    faltas[item.id_disci] = item.faltas.ToString();
                    //}


                    TableRow th = new TableRow();
                    th.TableSection = TableRowSection.TableHeader;
                    TableCell c1;
                    c1 = new TableCell();
                    c1.Controls.Add(new LiteralControl("Subjects"));
                    th.Cells.Add(c1);
                    foreach (var item in listb)
                    {

                        TableCell ch = new TableCell();


                        ch.Controls.Add(new LiteralControl(item.nome.ToString()));
                        th.Cells.Add(ch);
                    }
                    c1 = new TableCell();
                    c1.Controls.Add(new LiteralControl("Absences of " + bimestre + ""));
                    th.Cells.Add(c1);
                    Tables.Rows.Add(th);

                    //linhas
                    foreach (var d in disc)
                    {
                        //int totalf = 0;

                        var notasFaltas = cx.r_matr_r_Turma_Disc_Profs.Single(rl => rl.id_matricula == matr && rl.id_disci == d.idDisc && (rl.desativado == 0 || rl.desativado > anl.ano) && rl.id_bimestre == bim1.id); 
                        // var notasFaltas = cx.r_matr_r_Turma_Disc_Profs.Single(rl => rl.id_disci == d.idDisc && rl.id_bimestre == item.id);
                       // var notasFaltas = nf.First();

                        TableRow r = new TableRow();
                        TableCell c;
                        c = new TableCell();
                        c.Controls.Add(new LiteralControl(d.nome.ToString()));
                        r.Cells.Add(c);
                        //colunas
                        
                           // var nf = cx.ExecuteQuery<r_matr_r_Turma_Disc_Prof>(@"Select * from r_matr_r_Turma_Disc_Prof where id_disci = " + d.idDisc + "   and id_bimestre = "+item.id+"  ");
                           //// var notasFaltas = cx.r_matr_r_Turma_Disc_Profs.Single(rl => rl.id_disci == d.idDisc && rl.id_bimestre == item.id);
                           // var notasFaltas = nf.First();
                           // totalf += notasFaltas.faltas;
                            c = new TableCell();

                            c.Controls.Add(new LiteralControl(@"<input type='text'  class='in_tab nota'  onkeypress='Nota(this)'  name='notas_" + bimestre.Replace(" ", "_").ToLower() + @"[]' value='" + notasFaltas.nota.ToString().Replace(",",".") + @"'/> 
                                                    <input type='hidden' name='idnotas" + bimestre.Replace(" ", "_").ToLower() + "[]' value='" + d.idDisc + "'/>"));


                            r.Cells.Add(c);
                        
                        c = new TableCell();
                        c.Controls.Add(new LiteralControl("<input type='text'  class='in_tab 'onkeypress=' MascaraFalta(this)' name='faltas_" + bimestre.Replace(" ", "_").ToLower() + "[]' value='" + notasFaltas.faltas + "'/> "));
                        r.Cells.Add(c);

                        Tables.Rows.Add(r);
                    }
                }
                else
                {
                    salva.Text = "Save";
                    ViewState["" + recb.id + ""] = 0;

                    var disc = (from m in cx.Matriculas
                                join t in cx.Turmas on m.id_turma equals t.id
                                join r in cx.r_Turma_Disc_Profs on t.id equals r.id_turma
                                join d in cx.Disciplinas on r.id_disciplina equals d.id

                                where m.id == matr && (r.data == 0 || r.data >= anl.ano) && t.id == turma && (r.desativado == 0 || r.desativado > anl.ano) && (m.desativado == 0 || m.desativado > anl.ano)
                                select new { nome = d.nome, idDisc = d.id }).ToList();



                    TableRow th = new TableRow();
                    th.TableSection = TableRowSection.TableHeader;
                    TableCell c1;
                    c1 = new TableCell();
                    c1.Controls.Add(new LiteralControl("Subjects"));
                    th.Cells.Add(c1);


                    c1 = new TableCell();


                    c1.Controls.Add(new LiteralControl(bimestre.ToString()));
                    th.Cells.Add(c1);

                    c1 = new TableCell();
                    c1.Controls.Add(new LiteralControl("Absences of  " + bimestre + ""));
                    th.Cells.Add(c1);
                    Tables.Rows.Add(th);

                    //linhas
                    foreach (var d in disc)
                    {



                        TableRow r = new TableRow();
                        TableCell c;
                        c = new TableCell();
                        c.Controls.Add(new LiteralControl(d.nome.ToString()));
                        r.Cells.Add(c);
                        //colunas

                        c = new TableCell();

                        c.Controls.Add(new LiteralControl(@"<input type='text'  class='in_tab nota'  onkeypress='Nota(this)'  name='notas_" + bimestre.Replace(" ", "_").ToLower() + @"[]' value=''/> 
                                                    <input type='hidden' name='idnotas" + bimestre.Replace(" ", "_").ToLower() + "[]' value='" + d.idDisc + "'/>"));


                        r.Cells.Add(c);

                        c = new TableCell();
                        c.Controls.Add(new LiteralControl("<input type='text'  class='in_tab 'onkeypress=' MascaraFalta(this)' name='faltas_" + bimestre.Replace(" ", "_").ToLower() + "[]' value=''/> "));
                        r.Cells.Add(c);

                        Tables.Rows.Add(r);
                        Tables.DataBind();
                    }
                }
            }
            
        }

        protected void salva_Click(object sender, EventArgs e)
        {
            AnoLetivo anl = new AnoLetivo();
            anl = (AnoLetivo)Session["ano"];
            int id = (int)ViewState["id"];
            salva.Text = "Save";
            if (Request.Form["notas_1st_bimester[]"] != null) 
            
            {
                int exbi = (int)ViewState["1"];
              
                string[] tnotas = Request.Form["notas_1st_bimester[]"].Split(',');
                
                string[] idNotas = Request.Form["idnotas1st_bimester[]"].Split(',');
                string[] faltas = Request.Form["faltas_1st_bimester[]"].Split(',');
                string bim = muda_bimestre.SelectedItem.Value;

                using (BDEscolaDataContext cx = new BDEscolaDataContext()) 
                
                {
                    var mat = cx.Matriculas.Single(m => m.id_aluno == id && m.data == anl.ano && (m.desativado == 0 || m.desativado > anl.ano));
                    var turma = (from t in cx.Turmas
                                 join m in cx.Matriculas on t.id equals m.id_turma
                                 where m.id_aluno == id && m.data == anl.ano && (m.desativado == 0 || m.desativado > anl.ano)
                                 select new { idturma = t.id, idMatr = m.id}).Single();
                   
                        if (exbi != 1)
                        {
                             for (int i = 0; i < tnotas.Length; i++) 
                             {
                                
                                 var prof = (from rt in cx.r_Turma_Disc_Profs
                                            join t in cx.Turmas on rt.id_turma equals t.id
                                            join m in cx.Matriculas on t.id equals m.id_turma
                                             where m.id == mat.id && t.id == turma.idturma && rt.id_disciplina == Int32.Parse(idNotas[i]) && (rt.desativado == 0 || rt.desativado > anl.ano) && (m.desativado == 0 || m.desativado > anl.ano)
                                            select rt).Single();
                            r_matr_r_Turma_Disc_Prof rel = new r_matr_r_Turma_Disc_Prof();
                            rel.id_matricula = mat.id;
                            rel.id_prof = prof.id_prof;
                            rel.id_turma = turma.idturma;
                            rel.id_disci = Int32.Parse(idNotas[i]);
                            rel.nota = Decimal.Parse(tnotas[i].Replace(".",","));
                            rel.faltas = Int32.Parse(faltas[i]);
                            rel.id_bimestre = Int32.Parse(bim);
                            rel.data = anl.ano;
                            rel.desativado = 0;
                            cx.r_matr_r_Turma_Disc_Profs.InsertOnSubmit(rel);
                            cx.SubmitChanges();
                             }
                        }
                        else {
                            for (int i = 0; i < tnotas.Length; i++)
                            {
                                var prof = cx.r_Turma_Disc_Profs.Single(p => p.id_disciplina == Int32.Parse(idNotas[i]) && p.id_turma == turma.idturma && (p.desativado == 0 || p.desativado > anl.ano));
                            r_matr_r_Turma_Disc_Prof rel = new r_matr_r_Turma_Disc_Prof();
                            rel.id_matricula = mat.id;
                            rel.id_prof = prof.id_prof;
                            rel.id_turma = turma.idturma;
                            rel.id_disci = Int32.Parse(idNotas[i]);
                            rel.nota = Decimal.Parse(tnotas[i].Replace(".", ","));
                            rel.faltas = Int32.Parse(faltas[i]);
                            rel.id_bimestre = Int32.Parse(bim);

                            cx.ExecuteCommand(@"UPDATE r_matr_r_Turma_Disc_Prof SET  nota = {0} , faltas =  {1} 
                                                    Where id_matricula = {2} and id_prof= {3}  
                                                    and id_turma= {4} and id_disci= {5}  and id_bimestre= {6}",
                                                     rel.nota, rel.faltas, rel.id_matricula, rel.id_prof, rel.id_turma, rel.id_disci, rel.id_bimestre);
                        
                        }

                    }
                    
                    ListaTudo(id , turma.idMatr, turma.idturma);
                 
                }
               
            
        
    }else
    if (Request.Form["notas_2nd_bimester[]"] != null) 
            
            {
                int exbi = (int)ViewState["2"];
              
                string[] tnotas = Request.Form["notas_2nd_bimester[]"].Split(',');
                string[] idNotas = Request.Form["idnotas2nd_bimester[]"].Split(',');
                string[] faltas = Request.Form["faltas_2nd_bimester[]"].Split(',');
                string bim = muda_bimestre.SelectedItem.Value;

                using (BDEscolaDataContext cx = new BDEscolaDataContext()) 
                
                {
                    var mat = cx.Matriculas.Single(m => m.id_aluno == id && m.data == anl.ano && (m.desativado == 0 || m.desativado > anl.ano));
                    var turma = (from t in cx.Turmas
                                 join m in cx.Matriculas on t.id equals m.id_turma
                                 where m.id_aluno == id && m.data == anl.ano && (m.desativado == 0 || m.desativado > anl.ano)
                                 select new { idturma = t.id, idMatr = m.id}).Single();
                   
                        if (exbi != 1)
                        {
                             for (int i = 0; i < tnotas.Length; i++) 
                             {
                                
                                 var prof = (from rt in cx.r_Turma_Disc_Profs
                                            join t in cx.Turmas on rt.id_turma equals t.id
                                            join m in cx.Matriculas on t.id equals m.id_turma
                                             where m.id == mat.id && t.id == turma.idturma && rt.id_disciplina == Int32.Parse(idNotas[i]) && (rt.desativado == 0 || rt.desativado > anl.ano) && (m.desativado == 0 || m.desativado > anl.ano)
                                            select rt).Single();
                            r_matr_r_Turma_Disc_Prof rel = new r_matr_r_Turma_Disc_Prof();
                            rel.id_matricula = mat.id;
                            rel.id_prof = prof.id_prof;
                            rel.id_turma = turma.idturma;
                            rel.id_disci = Int32.Parse(idNotas[i]);
                            rel.nota = Decimal.Parse(tnotas[i].Replace(".", ","));
                            rel.faltas = Int32.Parse(faltas[i]);
                            rel.id_bimestre = Int32.Parse(bim);
                            rel.data = anl.ano;
                            rel.desativado = 0;
                            cx.r_matr_r_Turma_Disc_Profs.InsertOnSubmit(rel);
                            cx.SubmitChanges();
                             }
                        }
                        else {
                            for (int i = 0; i < tnotas.Length; i++)
                            {
                                var prof = cx.r_Turma_Disc_Profs.Single(p => p.id_disciplina == Int32.Parse(idNotas[i]) && p.id_turma == turma.idturma && (p.desativado == 0 || p.desativado > anl.ano));
                            r_matr_r_Turma_Disc_Prof rel = new r_matr_r_Turma_Disc_Prof();
                            rel.id_matricula = mat.id;
                            rel.id_prof = prof.id_prof;
                            rel.id_turma = turma.idturma;
                            rel.id_disci = Int32.Parse(idNotas[i]);
                            rel.nota = Decimal.Parse(tnotas[i].Replace(".", ","));
                            rel.faltas = Int32.Parse(faltas[i]);
                            rel.id_bimestre = Int32.Parse(bim);

                            cx.ExecuteCommand(@"UPDATE r_matr_r_Turma_Disc_Prof SET  nota = {0} , faltas =  {1} 
                                                    Where id_matricula = {2} and id_prof= {3}  
                                                    and id_turma= {4} and id_disci= {5}  and id_bimestre= {6}",
                                                     rel.nota, rel.faltas, rel.id_matricula, rel.id_prof, rel.id_turma, rel.id_disci, rel.id_bimestre);
                        
                        }

                    }
                    
                    ListaTudo(id , turma.idMatr, turma.idturma);
                 
                }
               
            }
        
    
    else
    if (Request.Form["notas_3rd_bimester[]"] != null) 
            
            {
                int exbi = (int)ViewState["3"];
              
                string[] tnotas = Request.Form["notas_3rd_bimester[]"].Split(',');
                string[] idNotas = Request.Form["idnotas3rd_bimester[]"].Split(',');
                string[] faltas = Request.Form["faltas_3rd_bimester[]"].Split(',');
                string bim = muda_bimestre.SelectedItem.Value;

                using (BDEscolaDataContext cx = new BDEscolaDataContext()) 
                
                {
                    var mat = cx.Matriculas.Single(m => m.id_aluno == id && m.data == anl.ano && (m.desativado == 0 || m.desativado > anl.ano));
                    var turma = (from t in cx.Turmas
                                 join m in cx.Matriculas on t.id equals m.id_turma
                                 where m.id_aluno == id && m.data == anl.ano && (m.desativado == 0 || m.desativado > anl.ano)
                                 select new { idturma = t.id, idMatr = m.id}).Single();
                   
                        if (exbi != 1)
                        {
                             for (int i = 0; i < tnotas.Length; i++) 
                             {
                                
                                 var prof = (from rt in cx.r_Turma_Disc_Profs
                                            join t in cx.Turmas on rt.id_turma equals t.id
                                            join m in cx.Matriculas on t.id equals m.id_turma
                                             where m.id == mat.id && t.id == turma.idturma && rt.id_disciplina == Int32.Parse(idNotas[i]) && (rt.desativado == 0 || rt.desativado > anl.ano) && (m.desativado == 0 || m.desativado > anl.ano)
                                            select rt).Single();
                            r_matr_r_Turma_Disc_Prof rel = new r_matr_r_Turma_Disc_Prof();
                            rel.id_matricula = mat.id;
                            rel.id_prof = prof.id_prof;
                            rel.id_turma = turma.idturma;
                            rel.id_disci = Int32.Parse(idNotas[i]);
                            rel.nota = Decimal.Parse(tnotas[i].Replace(".", ","));
                            rel.faltas = Int32.Parse(faltas[i]);
                            rel.id_bimestre = Int32.Parse(bim);
                            rel.data = anl.ano;
                            rel.desativado = 0;
                            cx.r_matr_r_Turma_Disc_Profs.InsertOnSubmit(rel);
                            cx.SubmitChanges();
                             }
                        }
                        else {
                            for (int i = 0; i < tnotas.Length; i++)
                            {
                                var prof = cx.r_Turma_Disc_Profs.Single(p => p.id_disciplina == Int32.Parse(idNotas[i]) && p.id_turma == turma.idturma && (p.desativado == 0 || p.desativado > anl.ano));
                            r_matr_r_Turma_Disc_Prof rel = new r_matr_r_Turma_Disc_Prof();
                            rel.id_matricula = mat.id;
                            rel.id_prof = prof.id_prof;
                            rel.id_turma = turma.idturma;
                            rel.id_disci = Int32.Parse(idNotas[i]);
                            rel.nota = Decimal.Parse(tnotas[i].Replace(".", ","));
                            rel.faltas = Int32.Parse(faltas[i]);
                            rel.id_bimestre = Int32.Parse(bim);

                            cx.ExecuteCommand(@"UPDATE r_matr_r_Turma_Disc_Prof SET  nota = {0} , faltas =  {1} 
                                                    Where id_matricula = {2} and id_prof= {3}  
                                                    and id_turma= {4} and id_disci= {5}  and id_bimestre= {6}",
                                                     rel.nota, rel.faltas, rel.id_matricula, rel.id_prof, rel.id_turma, rel.id_disci, rel.id_bimestre);
                        
                        }

                    }
                    
                    ListaTudo(id , turma.idMatr, turma.idturma);
                 
                }
               
            }
    else
        if (Request.Form["notas_4th_bimester[]"] != null)
        {
            int exbi = (int)ViewState["4"];

            string[] tnotas = Request.Form["notas_4th_bimester[]"].Split(',');
            string[] idNotas = Request.Form["idnotas4th_bimester[]"].Split(',');
            string[] faltas = Request.Form["faltas_4th_bimester[]"].Split(',');
            string bim = muda_bimestre.SelectedItem.Value;

            using (BDEscolaDataContext cx = new BDEscolaDataContext())
            {
                var mat = cx.Matriculas.Single(m => m.id_aluno == id && m.data == anl.ano && (m.desativado == 0 || m.desativado > anl.ano));
                var turma = (from t in cx.Turmas
                             join m in cx.Matriculas on t.id equals m.id_turma
                             where m.id_aluno == id && m.data == anl.ano && (m.desativado == 0 || m.desativado > anl.ano)
                             select new { idturma = t.id, idMatr = m.id }).Single();

                if (exbi != 1)
                {
                    for (int i = 0; i < tnotas.Length; i++)
                    {

                        var prof = (from rt in cx.r_Turma_Disc_Profs
                                    join t in cx.Turmas on rt.id_turma equals t.id
                                    join m in cx.Matriculas on t.id equals m.id_turma
                                    where m.id == mat.id && t.id == turma.idturma && rt.id_disciplina == Int32.Parse(idNotas[i]) && (rt.desativado == 0 || rt.desativado > anl.ano) && (m.desativado == 0 || m.desativado > anl.ano)
                                    select rt).Single();
                        r_matr_r_Turma_Disc_Prof rel = new r_matr_r_Turma_Disc_Prof();
                        rel.id_matricula = mat.id;
                        rel.id_prof = prof.id_prof;
                        rel.id_turma = turma.idturma;
                        rel.id_disci = Int32.Parse(idNotas[i]);
                        rel.nota = Decimal.Parse(tnotas[i].Replace(".", ","));
                        rel.faltas = Int32.Parse(faltas[i]);
                        rel.id_bimestre = Int32.Parse(bim);
                        rel.data = anl.ano;
                        rel.desativado = 0;
                        cx.r_matr_r_Turma_Disc_Profs.InsertOnSubmit(rel);
                        cx.SubmitChanges();
                    }
                }
                else
                {
                    for (int i = 0; i < tnotas.Length; i++)
                    {
                        var prof = cx.r_Turma_Disc_Profs.Single(p => p.id_disciplina == Int32.Parse(idNotas[i]) && p.id_turma == turma.idturma && (p.desativado == 0 || p.desativado > anl.ano));
                        r_matr_r_Turma_Disc_Prof rel = new r_matr_r_Turma_Disc_Prof();
                        rel.id_matricula = mat.id;
                        rel.id_prof = prof.id_prof;
                        rel.id_turma = turma.idturma;
                        rel.id_disci = Int32.Parse(idNotas[i]);
                        rel.nota = Decimal.Parse(tnotas[i].Replace(".", ","));
                        rel.faltas = Int32.Parse(faltas[i]);
                        rel.id_bimestre = Int32.Parse(bim);

                        cx.ExecuteCommand(@"UPDATE r_matr_r_Turma_Disc_Prof SET  nota = {0} , faltas =  {1} 
                                                    Where id_matricula = {2} and id_prof= {3}  
                                                    and id_turma= {4} and id_disci= {5}  and id_bimestre= {6}",
                                                 rel.nota, rel.faltas, rel.id_matricula, rel.id_prof, rel.id_turma, rel.id_disci, rel.id_bimestre);

                    }

                }

                ListaTudo(id, turma.idMatr, turma.idturma);

            }

        }
        }
    }
}