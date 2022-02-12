
var btn = document.getElementById("#btnFechar");
var divCarrinho = document.querySelector(".cartList");

function fecharModal() {
    divCarrinho.style.display = "none";
}

function abrirModal() {
    divCarrinho.style.display = "block";
}


function adicionarNoCarrinho(btn) {

    var item = $(btn).attr('id');

    $.ajax({
        url: '/Pedido/RealizarVenda',
        type: 'POST',
        contentType: 'application/json',
        data: item
    }).done(function (response) {
        debugger;
        console.log("produto incluido");
        let classQuantidade = document.getElementsByClassName("ItemQuantidade");
        console.log(response.Produtos);

        abrirModal();
    });
}
