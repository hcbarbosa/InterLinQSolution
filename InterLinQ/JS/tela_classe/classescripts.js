





$(document).ready(function () {
    $('#link2').addClass('menu-selected');
    
    $('#formularios_GridView1').dataTable();
    var campo = document.getElementsByName('formularios_GridView1_length');
    $(campo).css('width', '60px');

    

    $('#formularios_ListaMaterias').dataTable();
    var campo = document.getElementsByName('formularios_ListaMaterias_length');
    $(campo).css('width', '60px');


    $('#formularios_ListaProf').dataTable();
    var campo = document.getElementsByName('formularios_ListaProf_length');
    $(campo).css('width', '60px');
});



$(document).ready(function(){
    //alert("fgd");
   
});
function cd_prof(){
    $('#conteudo').load('./consultas/cadastra_prof.jsp');
    
}


   

function cria_materia(){
    $('#conteudo').load('./consultas/cria_materia.jsp');
    $('#showconteudo').removeClass('span9');
      $('#showconteudo').addClass('span8');
}
function ad_materia(){
    
    		
			$('.materia').append(
				"<div  style='width: 700px;'>" +
					"<div class='pull-left' style=' margin-right: 70px;'>" +
						" <input type='text' name='Nome[]'  required  class='form-control input-xlarge' placeholder='Name'>" +
					"</div>" +
					"<div class='pull-left' style='margin-right: 20px;'>" +
						" <input type='text' name='Info[]'  required  class='form-control input-xlarge' placeholder='Additional Anformation'>" +
					"</div>" +
					"<div class='pull-left'>" +
						"<a class='btn btn-danger materia-remove'>-</a>" +
					"</div>" +
				"</div>");
      
                        
     $(document).on('click', '.materia-remove', function(){
          $(this).parent().parent().remove();
	});
  
}

function carrega_form(){
    
     $('#conteudo').load('./consultas/form_ad_aluno.jsp');
     
}



function abre_pagina(pg, item)
{
    //alert(item)
    var post;
    post = {'el': item};

    if ((post == null) || (post == ""))
    {
        post = "";
    }

    // alert(post);

    jQuery.post(pg, post, function(resposta) {
        //alert(resposta);
        //var novo=jQuery('#form').html(resposta);
        //alert(novo);
        document.getElementById('conteudo').innerHTML = resposta;
        // $('#conteudo').appendTo(resposta);
    });

}


function closeform() {

    document.getElementById('conteudo').innerHTML = "";

}

function resetform(item) {

    $(item).each(function() {
        this.reset(); //Cada volta no laço o form atual será resetado
    });


}

function informacoes(id) {
    alert()
    $(document).ready(function() {
        
        var maskHeight = $(document).height();
        var maskWidth = $(window).width();

        $('#mascara').css({'width': maskWidth, 'height': maskHeight});

        $('#mascara').fadeIn(800);
        $('#mascara').fadeTo("slow", 0.4);

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
            $('#info').html("");

        });

        $('#mascara').click(function() {
            $(this).hide();
            $('.janela').hide();
            $('#info').html("");
        });
        
      $('#info').html("<iframe src='informacoes_classes.jsp?id="+id+"' width='100%' height='590px' />");

    });
}
function teste(){
    alert("funciona")
}

function pesquisa_ra(pg, item) {
    //alert(item)
    $(document).ready(function() {
         $('.window .fechar').click(function(e) {
            e.preventDefault();

            $('#mask').hide();
            $('.window').hide();

        });
    });

    var post;
    post = {'el': item};

    if ((post == null) || (post == ""))
    {
        post = "";
    }

    // alert(post);

    jQuery.post(pg, post, function(resposta) {
        //alert(resposta);
        //var novo=jQuery('#form').html(resposta);
        //alert(novo);
        document.getElementById('conteudo').innerHTML = resposta;
        // $('#conteudo').appendTo(resposta);
    });


}
//referente ao ogin 

function logout(){
    window.location = "logout";
    
}

function salva(){
    
    $("#cd_aluno").submit();
}

function close_inf(){
     $('#mascara').hide();
     $('.janela').hide();
    $('#info').html("");
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
                options = '<option value>Select a City</option>';
                if (data != null) {
                    $.each(data, function (index, cidade) {
                        options += '<option value="' + cidade.id + '">' + cidade.nome + '</option>';
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
    $('#formularios_estado').change(function () {
        buscaCidade('formularios_estado',
                    'formularios_cidade');
    });

});
