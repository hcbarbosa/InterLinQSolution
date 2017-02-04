

var table2;

$(document).ready(function () {
    $('.dropdown-toggle').dropdown();
  //var  table = $('#info_tb_materias').dataTable({
  //      "sScrollY": "500px",
  //      "bPaginate": false,
  //      "bScrollCollapse": true,
  //      "bFilter": false
  //  });


   
    var table2 = $('#info_tb_aluno').dataTable({
        "sScrollY": "500px",
        "bPaginate": false,
        "bScrollCollapse": true
      
  });
    
  
})


function carrega() {

   
    table2.fnDraw();
}



$('#myTab a').click(function (e) {
    e.preventDefault()
    $(this).tab('show')
})



function deleteAluno(event) {
    
    bootbox.confirm("Are You Sure ?", function(result) {
        if (result) {
            $(event).parent().parent().remove();
            $('#alteracoes').append("<input type='hidden' value='" + id + "'name='alunosExcluir[]'/>");
        }
    });
   
      
    

}
function deleteMateria(event) {
    $('#conf').empty().append("<div id='jmodal'><div id='deleteMateria' class='modal hide fade' tabindex='-1' role='dialog' aria-labelledby='deleteMateriaLabel' aria-hidden='true'>" +
  "<div class='modal-header'>" +
    "<button type='button' class='close' data-dismiss='modal' aria-hidden='true'>X</button>" +
   " <h3 id='deleteMateriaLabel'>Are you sure?</h3>" +
  "</div>  <div class='modal-body'>" +
        
  "</div>  <div class='modal-footer'>" +
   " <button class='btn' data-dismiss='modal' aria-hidden='true'>Close</button>   <button class='btn eventdeletmat' data-dismiss='modal' aria-hidden='true'>OK</button> " +
  " </div></div></div>");



    $('#deleteMateria').modal('show');
    //$('#MudaNotas').modal();
    $('.eventdeletmat').click(function () {
       // var iddisc =document.getElementById('IdDisciplina').value;
        //var idProf = document.getElementById('IdProfessor').value;
        var iddisc =$(event).parent().parent().find('.iddisc').val();
        var idProf =$(event).parent().parent().find('.idprof').val();
        $(event).parent().parent().remove(); 
        $('#alteracoes').append("<input type='hidden' value='" + iddisc + "'name='materiasExcluir[]'/> <input type='hidden' value='" + idProf + "'name='ProfessorExcluir[]'/>");
        $('#deleteMateria').modal('hide')
        document.getElementById('btnSalva').style.visibility = "visible";
    
        $('#jmodal').empty();
    })
   
   
          };
   

function AlteraTurma(iten) {
    if ($(iten).val() != 0) {
        var idturma = $(iten).val();
        
        var idaluno = $(iten).parent().parent().find('.IdAluno').val();
        document.getElementById('btnSalva').style.visibility = "visible";
        $('#alteracoes').append("<input type='hidden' value='" + idaluno + "'name='AlunosTransferir[]'/> <input type='hidden' value='" + idturma + "'name='TurmaReceptora[]'/>");
    }
}

function submit(){
    $('form').submit();
    
}

function atualizaMateria(inp){
  var input = $(inp).parent().parent().find('select');
   //alert(input)
   $(input).attr('disabled', false);
}

function atualizaAluno(inp){
  var input = $(inp).parent().parent().find('select');
   //alert(input)
   $(input).attr('disabled', false);
}

function updateMaterias() {

    var id = document.getElementById('info_IDTurma').value;

    window.location = 'Edita_Turma.aspx?id='+id;
        
    
}

function ConfRemocaoTurma() {
    $('#conf').empty().append("<div id='jmodal'><div id='confirmaMateria' class='modal hide fade' tabindex='-1' role='dialog' aria-labelledby='deleteMateriaLabel' aria-hidden='true'>" +
   "<div class='modal-header'>" +
     "<button type='button' class='close' data-dismiss='modal' aria-hidden='true'>X</button>" +
    " <h3 id='deleteMateriaLabel'>Are you sure?</h3>" +
   "</div>  <div class='modal-body'>" +

   "</div>  <div class='modal-footer'>" +
    " <button class='btn btn-info' data-dismiss='modal' aria-hidden='true'>Close</button>   <button class='btn btn-danger' onclick='RemoveTurma()' data-dismiss='modal' aria-hidden='true'>OK</button> " +
   " </div></div></div>");
    $('#confirmaMateria').modal('show');

}

function RemoveTurma() {
   
    var id = document.getElementById('info_IDTurma').value;

    window.location = 'RemoveTurma.aspx?id=' + id;
}

var arr = [];
var rm = [];

$(document).ready(function () {



    $.ajax({
        url: '../ADAluno-em-Inf.aspx',
        type: 'post',
        dataType: 'json',

        success: function (data) {
            $.each(data, function (i, dat) {
                arr.push(dat.nome);
                rm.push(dat.id);
            });
            //alert(arr)
            //alert(rm)
            // return arr;
        }
    });

})

var turma = '';
var id = '';
$(document).ready(function (){



    $.ajax({
        url: '../GetTurma_p_ID.aspx?id='+document.getElementById('info_IDTurma').value,
        type: 'post',
        dataType: 'json',

        success: function (data) {
            $.each(data, function (i, dat) {
                turma += '<input type=\'text\' readonly value=\'' + dat.nome + '\' class=\'form-control \'/> <input type=\'hidden\' name=\'idTur\' value= \''+dat.id+'\'/>'
                //alert(turma)
            });
            //alert(arr)
            //alert(rm)
            // return arr;
        }
    });
   
})


function AdAluno()
{
 
    
    var dados = arr//["red", "blue", "green", "yellow", "brown", "black"];
    var rms = rm

   
    
    

    $('#conf').empty().append("<div class='modal fade' id='ADDAluno' tabindex='-1' role='dialog' aria-labelledby='ADDAlunoLabel' aria-hidden='true'>" +
    "<div class='modal-dialog'>"+
   " <div class='modal-content'>"+
   "   <div class='modal-header'>"+
    "    <button type='button' class='close' data-dismiss='modal' aria-hidden='true'>&times;</button>"+
     "   <h4 class='modal-title' id='ADDAlunoLabel'>Select a Studant</h4>" +
      "</div>"+
      "<div class='modal-body'> <form id='matr_inf'  action='Matricula_p_Inf.aspx' method='POST'>" +
         
   " Name:  <input type='text'  class='form-control typeahead '  required name= 'Nome'  id='SearchNome'  data-provide='typeahead' data-items='10' style='width:210px'/><i></i> <a href='#' onclick='Alter1(this)' class=' icon-search' ></a> " +
    "RM : <input type ='text'  class='form-control typeahead '  required name='RM' id='SearchRM' data-provide='typeahead' data-items='10' style='width:100px' /><i></i> <a  href='#' onclick='Alter2(this)' class=' icon-search' ></a>" +
    
                   
                
      "     <div class=''>" +
       "        <div class='col-lg-4form-group '>" +
        "           <h5>Classroom's Name</h5><br/>" +
         "      </div>" +
                        
                         
          " </div>" +

           "<div class=''>" +
            "   <div class=' col-lg-8 '>" +
             "      <div class='row'>" +
              "         <div class='col-lg-9'>" 
                                   
                          + turma + 
                                                                    
                       
                          "<input type='hidden' id='idAl' name='idAlun' value='0'/></div>" +

                               
                               
                   "</div>" +
               "</div>" +
                "  <div class='col-lg-8  btn-group btn-toolbar'>" +
                                             "  <div class='row'>" +
                                                 "  <div class='col-lg-8'>" +

                                                  "    <input type='button' onclick=' matricula()'  value='Register' name='salva' Class='btn btn-success'  />" +
                                                               
                                                  
                                                   "</div>" +
                                               "</div>" +
                                           "</div>" +
           "</div>" +
      "</form></div>"+
      "<div class='modal-footer'>"+
       " <button type='button' class='btn btn-default' data-dismiss='modal'>Close</button>"+
        
      "</div>"+
    "</div><!-- /.modal-content -->"+
  "</div><!-- /.modal-dialog -->"+
"</div><!-- /.modal -->");
    $('#ADDAluno').modal('show');
    $('#SearchNome').typeahead({ source: dados });
    $('#SearchRM').typeahead({ source: rms });

}


function Alter1()
{

    var cpf;
    $.ajax({
        dataType: "json",
        url: "../GetAluno.aspx?nome=" + document.getElementById('SearchNome').value,


        success: function (data) {

            if (data != null) {
                $.each(data, function (index, vr) {
                    if (vr.id != '0') {
                        document.getElementById('SearchRM').value = vr.rm;
                        document.getElementById('idAl').value = vr.idaluno;

                    } else
                    {
                       
                        document.getElementById('SearchRM').value = 'Not found!'
                    }
                });
            }


        }
    });
}

function Alter2() {

    var cpf;
    $.ajax({
        dataType: "json",
        url: "../GetAluno.aspx?RM=" + document.getElementById('SearchRM').value,


        success: function (data) {

            if (data != null) {
                $.each(data, function (index, vr) {
                    if (vr.id != '0') {
                        document.getElementById('SearchNome').value = vr.nome;
                       document.getElementById('idAl').value = vr.idaluno;
                    } else
                    {
                        document.getElementById('SearchNome').value = 'Not found!';

                    }
                });
            }


        }
    });
}

function matricula() {


    if (document.getElementById('idAl').value != 0) {
        $('#matr_inf').submit();
    } else {

        bootbox.alert('Search for Student!');

    }

}



