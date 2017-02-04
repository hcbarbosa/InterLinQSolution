
var table;

$(document).ready(function ()
{

    table = $('#formulario_Table').dataTable();
    var pesquisa = document.getElementsByName('formulario_Table_length');
    $(pesquisa).css('width', '60px');


    table = $('#formulario_Table1').dataTable();
    var pesquisa = document.getElementsByName('formulario_Table1_length');
    $(pesquisa).css('width', '60px');

    table = $('#formulario_Table2').dataTable();
    var pesquisa = document.getElementsByName('formulario_Table2_length');
    $(pesquisa).css('width', '60px');

    table = $('#formulario_Table3').dataTable();
    var pesquisa = document.getElementsByName('formulario_Table3_length');
    $(pesquisa).css('width', '60px');


    table = $('#formulario_ListStudant').dataTable();
    var pesquisa = document.getElementsByName('formulario_ListStudant_length');
    $(pesquisa).css('width', '60px');
   
              
               
})    
         
   function form_Submit(){
       $('#Form_master_aluno').submit();
         $('#space').css('height','0px');
       
   }
function geratable(){
    $('#listanotas').dataTable();
        var pesquisa =  document.getElementsByName('listanotas_length');
             $(pesquisa).css('width','60px');
         
}


    


function SalvaNotas(){
    
    //$('#Form_master_aluno').submit();
    var dadosform = table.$('input').serialize();
    var post = '../Aluno/notas_fatas.aspx';
    $.ajax({
        type: "POST", url: post, data: dadosform, success: function (msg) {

            bootbox.alert("Dados Salvos com Sucesso!")

        }
    });


    
}

