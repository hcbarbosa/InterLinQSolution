
var cidadenome = [];
var estadosigla = [];



$(document).ready(function () {



    $.ajax({
        url: '../Historico_cidade.aspx',
        type: 'post',
        dataType: 'json',

        success: function (data) {
            $.each(data, function (i, dat) {
                cidadenome.push(dat.nome);
               
            });
            //alert(arr)
            //alert(rm)
            // return arr;
        }
    });

})





$(document).ready(function () {



    $.ajax({
        url: '../Historico_Estado.aspx',
        type: 'post',
        dataType: 'json',

        success: function (data) {
            $.each(data, function (i, dat) {
               estadosigla.push(dat.sigla);
              
            });
            $('.city').typeahead({ source: cidadenome });
            $('.state').typeahead({ source: estadosigla });
        }
    });

    

})


function buscaNome() {

   // var cidades = arr//["red", "blue", "green", "yellow", "brown", "black"];
    //var siglas = rm
   

}