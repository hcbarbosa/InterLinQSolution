










function buscaTurma(id) {

    var cpf;
     $.ajax({
        dataType: "json",
        url: "../GetAluno.aspx?id="+id,
        

        success: function (data) {

            if (data != null) {
                $.each(data, function (index, vr) {
                    if (vr.id === $('#formulario_CPF').val()) {
                        $('#formulario_CPF').attr('title', 'ID Aready Used in Data Base!');
                        $('#formulario_CPF').tooltip('show');
                    } else {
                        $('#formulario_CPF').removeAttr("title");
                    }
                   
                    
                });
            }


        }
    });
   // alert(cpf)
    
};





    $('#formulario_CPF').focusout(function () {
        buscaTurma($('#formulario_CPF').val());
        

    })


    $('#formulario_CPF').click(function () {

        $('#formulario_CPF').removeAttr("title");
    })






