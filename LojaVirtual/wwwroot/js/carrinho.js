﻿
var btn = document.getElementById("#btnFechar");
var divCarrinho = document.querySelector(".cartList");

function fecharModal() {
    divCarrinho.style.display = "none";
}

function abrirModal() {
    divCarrinho.style.display = "block";
}


function adicionarNoCarrinho(btn) {

    var itemIncrementado = $(btn).attr('id');

    $.ajax({
        url: '/Pedido/AumentarQuantidade',
        type: 'POST',
        contentType: 'application/json',
        data: itemIncrementado
    }).done(function (response) {
        debugger;
        let IdDoProduto = response.item1;
        let NovaQuantidade = response.item2;

        document.getElementById(IdDoProduto).innerText = NovaQuantidade;

        abrirModal();
    });
}