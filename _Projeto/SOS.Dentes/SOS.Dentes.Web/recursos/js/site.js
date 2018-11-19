$(document).ready(function(){
    $(".tabs-tratamento table").hide();
    $(".tabs-tratamento table:first").show();
    $("h3").on('click', function(obj){
       var valor = $(obj.currentTarget).attr('target-tab');
       if (valor){
            $(".tabs-tratamento table").hide();
            $('#'+valor).fadeIn();
       }
    });
    $("#btnCadastro").on('click',function(obj){
        $("#cadastro").modal({
            escapeClose: false,
            clickClose: false,
            showClose: true
          });
    });
    $('.Telefone').mask('(00) 0000-0000');
});


/*
/// Use o bloco abaixo para executar algum conjunto de ações quando a página for carregada
$(document).ready(function(){

    
});
*/
