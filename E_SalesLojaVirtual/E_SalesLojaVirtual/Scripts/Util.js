$(document).ready(function () {
    $("a.click").click(function (e) {
        e.preventDefault();
        var botao = $(this).unbind().find('button');
        botao.trigger('click');
    });

    $(".btnCarrinnho").click(function () {
        window.location.href = "/Carrinho/Index/";
    });
});