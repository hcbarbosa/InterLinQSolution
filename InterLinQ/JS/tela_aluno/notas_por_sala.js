
var options = "<option value='0'>Chose</option>";

window.buscaTurma = function () {
   
   
        return $.ajax({
            dataType: "json",
            url: "../GetTurma.aspx",


            success: function (data) {
              
                if (data != null) {
                    $.each(data, function (index, turma) {
                        options += '<option value="' + turma.id + '">' + turma.nome + '</option>\n';
                    });
                }

               
            }
        });
        alert(options)
};

$(document).ready(function () {
  
   
    buscaTurma();
    
    

});


function NotasPorSala() {
    

    $('#pesquisa').empty().append("<div id='Atualiza' class='modal hide fade' tabindex='-1' role='dialog' aria-labelledby='AtualizaLabel' aria-hidden='true'>" +
    "<div class='modal-header'>" +
      "<button type='button' class='close' data-dismiss='modal' aria-hidden='true'>X</button>" +
     " <h3 id='AtualizaLabel'>Select a Classroom</h3>" +
    "</div><form action='Notas_Por_Sala.aspx' metod='Post'>  <div class='' style='margin-left:10px'>" +
         
   " <div class=''>" +
   "Class's Name: <select name='idTurma' >"+
    options+
  " </select> </br> </div>" +
    "</div>  <div class='modal-footer'>" +
     " <button class='btn' data-dismiss='modal' aria-hidden='true'>Close</button>    <input type='submit' class='btn btn-primary' value='Search'/>" +
    " </form></div></div></div>");

    $('#Atualiza').modal('show');



}