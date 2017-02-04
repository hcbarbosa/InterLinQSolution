/* 
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

var Materiaoption;
var Profoption;

 function buscaMateria() {
  
    //alert(uf_id)
    
        return $.ajax({
            dataType: "json",
            url: "../GetMateria.aspx",
           
            
            success: function (data) {
                Materiaoption = '<option value=\'00\'>Select Name</option>';
                if (data != null) {
                    $.each(data, function (index, materia) {
                        Materiaoption += '<option value="' + materia.id + '">' + materia.nome + '</option> \n';
                    });
                }
                $('#Materia').append(Materiaoption);
                
            }
        });
  
};


function buscaProfessor() {
  
    //alert(uf_id)
    
        return $.ajax({
            dataType: "json",
            url: "../GetProfessor.aspx",
           
            
            success: function (data) {
                Profoption= '<option value=\'00\'>Select Responsable</option>';
                if (data != null) {
                    $.each(data, function (index, professor) {
                        Profoption += '<option value="' + professor.id + '">' + professor.nome + '</option> \n';
                    });
                }
                $('#Professor').append(Profoption);
                
            }
        });
  
};

$(document).ready(function () {
    //alert()
    // coloca o evento pra mudar as cidades, quando vc mudar o estado
   
   
        buscaMateria();
        buscaProfessor()
        

});





function ad_aula(){
    
    //alert(Profoption)
			$('.aula').append(
				"<div class='row '>" +
					"<div class='pull-left'  style='width: 200px; margin-right: 120px;'>" +
						"<select name='Materias[]' class='form-control'>" +
							Materiaoption +
						"</select>" +
					"</div>" +
					"<div class=' pull-left'>" +
						"<select name='Professores[]' class='form-control'>" +
							
                                                  Profoption+
						 "</select>" +
					"</div>" +
                                        
					"<div class='pull-left'>" +
						"<a class='btn btn-danger aula-remove' style=' margin-left: 30px;'>-</a>" +
					"</div>" +
				"</div>");
      
                        
     $(document).on('click', '.aula-remove', function(){
          $(this).parent().parent().remove();
	});
  
}


