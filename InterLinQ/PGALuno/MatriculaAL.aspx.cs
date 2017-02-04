using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterLinQ.PGALuno
{
    public partial class MatriculaAL : System.Web.UI.Page
    {              
                   AnoLetivo anl = new AnoLetivo();


                   protected void Page_Load(object sender, EventArgs e)
                   {
                       if (Session["ano"] != null)
                       {

                           anl = (AnoLetivo)Session["ano"];
                           if (Request.Params["salva"] != null)
                           {

                               int idAluno = Int32.Parse(Request.Params["idaluno"]);
                               int idTurma = Int32.Parse(Request.Params["Turma"]);

                               Matricula m = new Matricula();
                               m.id_aluno = idAluno;
                               m.id_turma = idTurma;
                               m.data = DateTime.Now.Year;
                               m.desativado = 0;




                               using (BDEscolaDataContext cx = new BDEscolaDataContext())
                               {
                                   anl = (AnoLetivo)Session["ano"];
                                   if (cx.Alunos.SingleOrDefault(a => a.id == idAluno && a.status == 1) != null)
                                   {
                                       // var vr = cx.Matriculas.FirstOrDefault(a => a.id_aluno == m.id_aluno && a.data == DateTime.Now.Year && m.id_turma == idTurma);
                                       if (cx.Matriculas.FirstOrDefault(a => a.id_aluno == m.id_aluno && a.data == m.data && (a.desativado == 0 || a.desativado > anl.ano)) != null)
                                       {
                                           string myScript = @"  $(document).ready(function() {
                                            bootbox.alert('Student Alread Registred !', function(result) {
                                            window.location = 'MatriculaAL.aspx';});});";
                                           Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", myScript,
                                           true);
                                       }
                                       else
                                       {

                                           cx.Matriculas.InsertOnSubmit(m);
                                           cx.SubmitChanges();
                                           string myScript = @"  $(document).ready(function() {
                                            bootbox.alert('Student Registred !', function(result) {
                                            window.location = 'MatriculaAL.aspx';});});";
                                           Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", myScript,
                                           true);
                                       }
                                   }
                                   else
                                   {
                                       var alr = cx.Alunos.SingleOrDefault(a => a.id == idAluno);
                                       var rea = (from s in cx.status where s.id == alr.status select s.descricao).Single();
                                       string myScript = @"  $(document).ready(function() {
                                            bootbox.alert('Student Was " + rea + @" !', function(result) {
                                            window.location = 'MatriculaAL.aspx';});});";
                                       Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", myScript,
                                       true);
                                   }
                               }

                           }
                           if (Request.Params["tipo"] != null)
                           {
                               if (Request.Params["tipo"].Contains("RM"))
                               {

                                   string rm = Request.Params["SelctRm"];


                                   using (BDEscolaDataContext cx = new BDEscolaDataContext())
                                   {
                                       anl = (AnoLetivo)Session["ano"];
                                       var turmas = "";
                                       foreach (var t in (from t in cx.Turmas where t.desativado == 0 || t.desativado > anl.ano select t).ToList())
                                       {

                                           turmas += "<option value='" + t.id + "'>" + t.nome + "</option> \n";
                                       }


                                       var al = cx.Alunos.Single(a => a.rm == rm);


                                       litCorpo.Text = @"<h3 class='panel-title'>Select a Classroom</h3>
                 Name:  <input type='text' required name= 'Nome'  id='Nome' value='" + al.Pessoa.nome + @"' class='form-control telefone-field' placeholder='Name'/> 
                 RM : <input type ='text' required name='RM' value='" + al.rm + @"' id='RM'  placeholder='RM'/>    
               	         <input type = 'hidden' name='idaluno' value='" + al.id + @"'/>  
                   
                
                    <div class='row'>
                        <div class='col-lg-2 form-group '>
                            <label>Nome da turma </label><br/>
                        </div>
                        
                         
                    </div>

                    <div class='row'>
                        <div class=' col-lg-8 '>
                            <div class='row'>
                                <div class='col-lg-9'>
                                   
                                   <select id='Turma' name='Turma' class='form-control input-xxlarge'>
                                        " + turmas + @"
                                                                    
                                   </select>
                                   </div>

                               
                               
                            </div>
                        </div>
                           <div class='col-lg-8  btn-group btn-toolbar'>
                                                        <div class='row'>
                                                            <div class='col-lg-8'>

                                                               <input type='submit'  value='Register' name='salva' Class='btn btn-success'  />
                                                               
                                                                <input type='reset' class='btn btn-danger' value='Clean' />
                                                            </div>
                                                        </div>
                                                    </div>
                    </div>";
                                       search.Text = "";
                                   }
                               }

                               else if (Request.Params["tipo"].Contains("Name"))
                               {
                                   string nome = Request.Params["SelectName"];


                                   using (BDEscolaDataContext cx = new BDEscolaDataContext())
                                   {
                                       anl = (AnoLetivo)Session["ano"];
                                       var turmas = "";
                                       foreach (var t in (from t in cx.Turmas where t.desativado == 0 || t.desativado > anl.ano select t).ToList())
                                       {

                                           turmas += "<option value='" + t.id + "'>" + t.nome + "</option> \n";
                                       }


                                       var al = cx.Alunos.Single(a => a.Pessoa.nome.Contains(nome));


                                       litCorpo.Text = @"<h3 class='panel-title'>Select a Classroom</h3>
                 Name:  <input type='text' required name= 'Nome'  id='Nome' value='" + al.Pessoa.nome + @"' class='form-control telefone-field' placeholder='Name'/> 
                 RM : <input type ='text' required name='RM' value='" + al.rm + @"' id='RM'  placeholder='RM'/>  
                      <input type = 'hidden' name='idaluno' value='" + al.id + @"'/>  
               	
                   
                
                    <div class='row'>
                        <div class='col-lg-2 form-group '>
                            <label>Nome da turma </label><br/>
                        </div>
                        
                         
                    </div>

                    <div class='row'>
                        <div class=' col-lg-8 '>
                            <div class='row'>
                                <div class='col-lg-9'>
                                   
                                   <select id='Turma' name='Turma' class='form-control input-xxlarge'>
                                        " + turmas + @"
                                                                    
                                   </select>
                                   </div>

                               
                               
                            </div>
                        </div>
                           <div class='col-lg-8  btn-group btn-toolbar'>
                                                        <div class='row'>
                                                            <div class='col-lg-8'>

                                                               <input type='submit'  value='Register' name='salva' Class='btn btn-success'  />
                                                               
                                                                <input type='reset' class='btn btn-danger' value='Clean' />
                                                            </div>
                                                        </div>
                                                    </div>
                    </div>";
                                       search.Text = "";
                                   }
                               }
                           }
                           else
                           {

                               search.Text = @" 
                <h2>Registration</h2>
                    <label>
        <input type='radio' name='tipo' value='RM' id='RadRm' onclick='Checa()'> RM
          <input type='radio' name='tipo' value='Name' id='RadNome' onclick='Checa()'> Name<br></label>
  <div class='form-group pull-left'>
    <label class='sr-only' >Search by RM</label>
    <input type='text' class='form-control typeahead ' id='SearchRM' name='SelctRm'   data-provide='typeahead' data-items='10'  />
    
  </div>
  <div class='form-group '>
    <label class='sr-only' >Search by Name</label>
    <input type='text' class='form-control  typeahead ' data-provide='typeahead' name='SelectName' data-items='10' id='SearchNome' onclick='' />
  </div>
  
  
  <button type='submit' class='btn btn-default'>Load</button><br /><br />  <script> buscaNome()</script>";

                           }

                       }
                   }

        protected void criar_Click(object sender, EventArgs e)
        {
            

        }
    }
}