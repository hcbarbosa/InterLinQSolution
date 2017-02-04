$(document).ready(function () {
    
    if (!jQuery('#radRm').is(":checked") && !jQuery('#radNome').is(":checked")) {

        $('#searchRM').attr('readonly', 'true');
        $('#searchnome').attr('readonly', 'true');
        $('#searchRM').attr('title', 'Select a kind of search');
        $('#searchnome').attr('title', 'Select a kind of search');


    }


   

})


function Checa() {



    if (jQuery('#radRm').is(":checked")) {

        $("#searchRM").attr('readonly', false);
        $("#searchnome").attr('readonly', true);
    } else
        if (jQuery('#radNome').is(":checked")) {


            $("#searchRM").attr('readonly', true);
            $("#searchnome").attr('readonly', false);

        }
}