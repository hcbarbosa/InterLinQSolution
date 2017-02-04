/* Global var for counter */
var giCount = 1;

$(document).ready(function () {
    $('#periodo').dataTable({

        "bProcessing": true,
        "sAjaxSource": "../GetAno.aspx",
        "aoColumns": [
            { "mData": "nome" },
            { "mData": "id" },
            { "mData": "conteudo" }
        ]
    });
});


function fnClickAddRow() {
    var data = new Date();
    var ano = data.getFullYear();
   
       AddAno(ano)
        
}


function AddAno(ano)
{

    return $.ajax({
        dataType: "json",
        url: "../AddAno.aspx?ano="+ano,


        success: function (data) {
            
            if (data != null) {
                $.each(data, function (index, cidade) {
                    window.location = 'ano.aspx'
                });
            }

          
        }
    });



}


function MudaStatus(item,ano)
{

    if (item.value !== '0') {
        return $.ajax({
            dataType: "json",
            url: "../EditaAnoLetivo.aspx?ano=" + ano + "&status=" + item.value,


            success: function (data) {

                if (data != null) {
                    $.each(data, function (index, cidade) {
                        window.location = 'ano.aspx'
                    });
                }


            }
        });
    }
}