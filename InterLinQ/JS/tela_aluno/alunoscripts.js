



$(document).ready(function () {
  

    $('#myTab a').click(function (e) {
        e.preventDefault()
        $(this).tab('show')
    })


    //alert("fgd");
    $('#link1').addClass('menu-selected');
    
});



var arr = [];
var rm = [];



$(document).ready(function () {
   
    

    $.ajax({
        url: '../AutoSugestNome.aspx',
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

function buscaNome() {
   
    var dados = arr//["red", "blue", "green", "yellow", "brown", "black"];
    var rms = rm
    $('#searchnome').typeahead({ source: dados });
    $('#searchRM').typeahead({ source: rms });
    $('#SearchNome').typeahead({ source: dados });
    $('#SearchRM').typeahead({ source: rms });

    if (!jQuery('#radRm').is(":checked") && !jQuery('#radNome').is(":checked")) {

        $('#searchRM').attr('readonly', 'true');
        $('#searchnome').attr('readonly', 'true');
        $('#searchRM').attr('title', 'Select a kind of search');
        $('#searchnome').attr('title', 'Select a kind of search');
       

    } if (!jQuery('#RadRm').is(":checked") && !jQuery('#RadNome').is(":checked"))
    { $('#SearchRM').attr('readonly', 'true');
    $('#SearchNome').attr('readonly', 'true');
    $('#SearchRM').attr('title', 'Select a kind of search');
    $('#SearchNome').attr('title', 'Select a kind of search');
}
}


function Checa() {



    if (jQuery('#radRm').is(":checked")) {

        $("#searchRM").attr('readonly', false);
        
        $("#searchnome").attr('readonly', true);
        //document.getElementById('searchnome').value = " ";
    } else
        if (jQuery('#radNome').is(":checked")) {


            $("#searchRM").attr('readonly', true);
           // document.getElementById('searchRM').value = " ";
            $("#searchnome").attr('readonly', false);

        }else

    if (jQuery('#RadRm').is(":checked")) {

        $("#SearchRM").attr('readonly', false);

        $("#SearchNome").attr('readonly', true);
        //document.getElementById('searchnome').value = " ";
    } else
        if (jQuery('#RadNome').is(":checked")) {


            $("#SearchRM").attr('readonly', true);
            // document.getElementById('searchRM').value = " ";
            $("#SearchNome").attr('readonly', false);

        }
}
function PesquisaAluno() {


    $('#pesquisa').empty().append("<div id='Atualiza' class='modal hide fade' tabindex='-1' role='dialog' aria-labelledby='AtualizaLabel' aria-hidden='true'>" +
     "<div class='modal-header'>" +
       "<button type='button' class='close' data-dismiss='modal' aria-hidden='true'>X</button>" +
      " <h3 id='AtualizaLabel'>Inform RM or Name</h3>" +
     "</div><form action='ManipulaAluno.aspx' metod='Post'>  <div class='' style='margin-left:10px'>" +
          " <input type='radio' name='tipo' value='RM' id='radRm' onclick='Checa()'> RM"+
         " <input type='radio' name='tipo' value='Name' id='radNome' onclick='Checa()'> Name<br></label>"+
    " <div class='form-group pull-left'>"+
    "<label class='sr-only' >Search by RM</label>"+
   " <input type='text' class='form-control typeahead ' id='searchRM' name='SelctRm'   data-provide='typeahead' data-items='10'  />"+
    
  "</div>  <div class='form-group '>    <label class='sr-only' >Search by Name</label>    <input type='text' class='form-control  typeahead ' data-provide='typeahead' name='SelectName' data-items='10' id='searchnome' onclick='' />"+
 " </div>" +
     "</div>  <div class='modal-footer'>" +
      " <button class='btn' data-dismiss='modal' aria-hidden='true'>Close</button>    <input type='submit' class='btn btn-primary' value='Search'/>" +
     " </form></div></div>");

    $('#Atualiza').modal('show');

    buscaNome()
    //$('#MudaNotas').modal();

}


function mudaNota() {



    $('#pesquisa').empty().append("<div id='Atualiza' class='modal hide fade' tabindex='-1' role='dialog' aria-labelledby='AtualizaLabel' aria-hidden='true'>" +
    " <form action='Notas_Faltas.aspx' metod='Post'> <div class='modal-header'>" +
      "<button type='button' class='close' data-dismiss='modal' aria-hidden='true'>X</button>" +
     " <h3 id='AtualizaLabel'>Inform RM or Name</h3>" +
    "</div> <div class='' style='margin-left:10px'>" +
         " <input type='radio' name='tipo' value='RM' id='radRm' onclick='Checa()'> RM" +
        " <input type='radio' name='tipo' value='Name'  id='radNome' onclick='Checa()'> Name<br></label>" +
   " <div class='form-group pull-left'>" +
   "<label class='sr-only' >Search by RM</label>" +
  " <input type='text' class='form-control typeahead ' id='searchRM' name='SelctRm'   data-provide='typeahead' data-items='10'  />" +

 "</div>  <div class='form-group '>    <label class='sr-only' >Search by Name</label>    <input type='text' class='form-control  typeahead ' data-provide='typeahead' name='SelectName' data-items='10' id='searchnome' onclick='' />" +
" </div>" +
    "</div>  <div class='modal-footer'>" +
     " <button class='btn' data-dismiss='modal' aria-hidden='true'>Close</button>    <input type='submit' class='btn btn-primary' value='Search'/>" +
    " </div></form></div>");

    $('#Atualiza').modal('show');

    buscaNome()
    // $('#MudaNotas').modal();
    // var rm = document.getElementById('p_aluno').value;
    // $('.pesquisa').click(function (){

    //     window.location = "notas_fatas.aspx?rm=" + rm;
    //})

}


function PrintNota()
{

    $('#pesquisa').empty().append("<div id='Atualiza' class='modal hide fade' tabindex='-1' role='dialog' aria-labelledby='AtualizaLabel' aria-hidden='true'>" +
    " <form action='Print.aspx' metod='Post'> <div class='modal-header'>" +
      "<button type='button' class='close' data-dismiss='modal' aria-hidden='true'>X</button>" +
     " <h3 id='AtualizaLabel'>Inform RM or Name</h3>" +
    "</div> <div class='' style='margin-left:10px'>" +
         " <input type='radio' name='tipo' value='RM' id='radRm' onclick='Checa()'> RM" +
        " <input type='radio' name='tipo' value='Name'  id='radNome' onclick='Checa()'> Name<br></label>" +
   " <div class='form-group pull-left'>" +
   "<label class='sr-only' >Search by RM</label>" +
  " <input type='text' class='form-control typeahead ' id='searchRM' name='SelctRm'   data-provide='typeahead' data-items='10'  />" +

 "</div>  <div class='form-group '>    <label class='sr-only' >Search by Name</label>    <input type='text' class='form-control  typeahead ' data-provide='typeahead' name='SelectName' data-items='10' id='searchnome' onclick='' />" +
" </div>" +
    "</div>  <div class='modal-footer'>" +
     " <button class='btn' data-dismiss='modal' aria-hidden='true'>Close</button>    <input type='submit' class='btn btn-primary' value='Search'/>" +
    " </div></form></div>");

    $('#Atualiza').modal('show');

    buscaNome()

}


window.buscaCidade = function (id_select_do_estado, campo) {
    var uf_id, elemento, img_html, options;
    elemento = $("#" + id_select_do_estado);
    //img_html = "<img class='uf_id-preloader' src='<%= image_path('elements/loaders/10s.gif')%>'>";
    uf_id = $(elemento).val();
    //alert(uf_id)
    if (uf_id) {
        return $.ajax({
            dataType: "json",
            url: "../GetCidade.aspx?id= " + uf_id,
           
            
            success: function (data) {
                options = '<option value=\'0\'>Select a City</option>';
                if (data != null) {
                    $.each(data, function (index, cidade) {
                        options += '<option value="' + cidade.id+ '">' + cidade.nome + '</option>';
                    });
                }

                return $('#' + campo).empty().append(options);
            },
            error: function (xhr) {
                var errors;
                errors = $.parseJSON(xhr.responseText).errors;
                $(".uf_id.error").remove();
                return elemento.parent().append("<label class='uf_id error'>" + errors + "</label>");
            }
        });
    } else {
        return elemento.parent().append("<label class='uf_id error'>Informe um uf_id válido</label>");
    }
};

$(document).ready(function () {
    // coloca o evento pra mudar as cidades, quando vc mudar o estado
    $('#formulario_estado').change(function () {
        buscaCidade('formulario_estado',
                    'formulario_cidade');
    });

});

    
           
           







//referente ao ogin 

function logout() {
    window.location = "logout";

}

function VRsubmit() {
    if ($('#formulario_estado').val() != 0) {
        if ($('#formulario_cidade').val != 0) {
            $("#Form_master_aluno").submit();
        } else
        {
            bootbox.alert("Select a City !");
            return false;
        }
    } else
    {
        bootbox.alert("Select a State and a City !");
        return false; 
    }
}
