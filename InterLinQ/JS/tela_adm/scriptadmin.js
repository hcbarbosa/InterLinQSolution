$(document).ready(function() {
    //alert("fgd");
    $('#link3').addClass('menu-selected');

    $('#Conteudo_listEstudante').dataTable();
    var campo = document.getElementsByName('Conteudo_listEstudante_length');
    $(campo).css('width', '60px');

    $('#Conteudo_grdUser').dataTable();
    var campo = document.getElementsByName('Conteudo_grdUser_length');
    $(campo).css('width', '60px');


    
});
function logout(){
    window.location = "logout";
    
}

function Deleta() { $('#myModal').modal('show') }


function mudaStatus(ob)
{
    var idaluno = $(ob).parent().parent().find('.idaluno').val();


    $('#pesquisa').empty().append("<div id='Atualiza' class='modal hide fade' tabindex='-1' role='dialog' aria-labelledby='AtualizaLabel' aria-hidden='true'>" +
    "<div class='modal-header'>" +
      "<button type='button' class='close' data-dismiss='modal' aria-hidden='true'>X</button>" +
       "" +
     " <h3 id='AtualizaLabel'>Select the new status </h3>" +
    "</div><div class='modal-body'><form id='MudaEsta' metod='Post'>  <div class='' style='margin-left:10px'>" +
        
  " <div class='form-group '>"+
   " <label class='sr-only pull-left' >Permission :<span style='color:red'>*</span></label>"+
    "<select class='form-control' id='selec_status'>"+
     "   <option>choose</option>"+
  "<option value='1'>Active</option>" +
  "<option value='2'>Transferred</option>" +
  "<option value='3'>Locked</option>" +

   " </select>"+
  "</div>"+
 "</div>" +
    "</div>  <div class='modal-footer'>" +
     " <button class='btn' data-dismiss='modal' aria-hidden='true'>Close</button>    <input type='button' class='btn btn-primary' onclick='salvaStatus(document.getElementById(\"selec_status\").value," + idaluno + ")' value='Change'/>" +
    " </form></div></div>");

    $('#Atualiza').modal('show');

}


function salvaStatus(stat,id)

{
    $('#Atualiza').modal('hide');
    $.ajax({
        url: '../MudaStatus.aspx?stat='+stat+'&id='+id,
        type: 'post',
        dataType: 'json',

        success: function (data) {
            $.each(data, function (i, dat) {
                if (dat.res == 1) {
                    bootbox.alert('Status changed!!', function (result) {
                        window.location = 'ListStudent.aspx';
                    });
                } else {
                    bootbox.alert('Status no changed!!', function (result) {
                        window.location = 'ListStudent.aspx';
                    });

                }
            });
            //alert(arr)
            //alert(rm)
            // return arr;
        }
    });

}

function anotacoes(ob)
{
    var idaluno = $(ob).parent().parent().find('.idaluno').val();

    
    $.ajax({
        url: '../Notations.aspx?getAN=' + idaluno,
        type: 'post',
        dataType: 'json',

        success: function (data) {
            $.each(data, function (i, dat) {
                if (dat.res != 1) {
                    $('#pesquisa').empty().append("<div id='Atualiza' class='modal hide fade' tabindex='-1' role='dialog' aria-labelledby='AtualizaLabel' aria-hidden='true'>" +
   "<div class='modal-header'>" +
     "<button type='button' class='close' data-dismiss='modal' aria-hidden='true'>X</button>" +
      "" +
    " <h3 id='AtualizaLabel'>Notations About Studant  </h3>" +
   "</div><div class='modal-body'><form id='MudaEsta' metod='Post'>  <div class='' style='margin-left:10px'>" +
        
 " <div class='form-group '>"+
  " <label class='sr-only pull-left' >Notations :</label>" +
    "<textarea rows='8' cols='500'   id='txt' style=' width: 500px;'>" + dat.res + "</textarea>" +
                        
                           
 "</div>"+
 "</div>" +
   "</div>  <div class='modal-footer'>" +
    " <button class='btn' data-dismiss='modal' aria-hidden='true'>Close</button>    <input type='button' class='btn btn-primary' onclick='PostAnotacao(document.getElementById(\"txt\").value," + idaluno + ")' value='Update'/>" +
   " </form></div></div>");

                    $('#Atualiza').modal('show');
                   
                } else {
                    $('#pesquisa').empty().append("<div id='Atualiza' class='modal hide fade' tabindex='-1' role='dialog' aria-labelledby='AtualizaLabel' aria-hidden='true'>" +
  "<div class='modal-header'>" +
    "<button type='button' class='close' data-dismiss='modal' aria-hidden='true'>X</button>" +
     "" +
   " <h3 id='AtualizaLabel'>Notations About Student </h3>" +
  "</div><div class='modal-body'><form id='MudaEsta' metod='Post'>  <div class='' style='margin-left:10px'>" +
        
" <div class='form-group '>"+
 " <label class='sr-only pull-left' >Notations: </label>" +
   "<textarea rows='8' cols='500'  id='txt' style=' width: 500px;'> </textarea>" +
                        
                           
"</div>"+
"</div>" +
  "</div>  <div class='modal-footer'>" +
   " <button class='btn' data-dismiss='modal' aria-hidden='true'>Close</button>    <input type='button' class='btn btn-primary' onclick='PostAnotacao(document.getElementById(\"txt\").value," + idaluno + ")' value='Save'/>" +
  " </form></div></div>");
                    $('#Atualiza').modal('show');
                }
                    });

                }
            });
            //alert(arr)
            //alert(rm)
            // return arr;
        

}


function PostAnotacao(not, id)
{
    $('#Atualiza').modal('hide');
    $.ajax({
        url: '../Notations.aspx?PostAN=' + id + '&Anot=' + not,
        type: 'post',
        dataType: 'json',

        success: function (data) {
            $.each(data, function (i, dat) {
                if (dat.res == 1) {
                    bootbox.alert('Notation saved!', function (result) {
                        window.location = 'ListStudent.aspx';
                    });
                } else {
                    bootbox.alert('Notation no saved!', function (result) {
                        window.location = 'ListStudent.aspx';
                    });

                }
            });
            //alert(arr)
            //alert(rm)
            // return arr;
        }
    });
}
