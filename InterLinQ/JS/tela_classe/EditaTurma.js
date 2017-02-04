var Mat;
var Prof;

function buscaMateria() {

    //alert(uf_id)

    return $.ajax({
        dataType: "json",
        url: "../GetMateria_Ed.aspx?id=" + document.getElementById('formularios_idturma').value,


        success: function (data) {
            Mat = '<option value=\'00\'>Select Name</option>';
            if (data != null) {
                $.each(data, function (index, materia) {
                    Mat += '<option value="' + materia.id + '">' + materia.nome + '</option> \n';
                });
            }
            $('#Materia').append(Mat);

        }
    });

};


function buscaProfessor() {

    //alert(uf_id)

    return $.ajax({
        dataType: "json",
        url: "../GetProfessor.aspx",


        success: function (data) {
            Prof = '<option value=\'00\'>Select Responsable</option>';
            if (data != null) {
                $.each(data, function (index, professor) {
                    Prof += '<option value="' + professor.id + '">' + professor.nome + '</option> \n';
                });
            }
            $('#Professor').append(Prof);

        }
    });

};

$(document).ready(function () {
    //alert()
    // coloca o evento pra mudar as cidades, quando vc mudar o estado


    buscaMateria();
    buscaProfessor()


});





function ad_aula_ed() {

    //alert(Profoption)
    $('.aula').append(
				"<div class='row '>" +
					"<div class='pull-left'  style='width: 200px; margin-right: 120px;'>" +
						"<select name='Materias[]' class='form-control'>" +
                    Mat +
                "</select>" +
					"</div>" +
					"<div class=' pull-left'>" +
						"<select name='Professores[]' class='form-control'>" +

                     Prof +
                  "</select>" +
					"</div>" +

					"<div class='pull-left'>" +
						"<a class='btn btn-danger aula-remove' style=' margin-left: 30px;'>-</a>" +
					"</div>" +
				"</div>");


    $(document).on('click', '.aula-remove', function () {
        $(this).parent().parent().remove();
    });

}
