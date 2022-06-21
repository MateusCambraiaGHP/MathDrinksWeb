$("#botao-trazer-produtos").click(atualizaTabelaProdutos);

function atualizaTabelaProdutos() {
    $.get("https://localhost:7252/Product/GetProduct", data => {
        console.log(data);
            $('#tabela-produtos').html('');
            setTimeout(function () {
                $("#spinner").toggle();
                $(data).each(function () {
                    var linha = novaLinha(this.name, this.quantity, this.price, this.description);
                    $("#tabela-produtos").append(linha);
                });
            }, 1500); 
    }).fail(function () {
        $("#erro").show();
        setTimeout(function () {
            $("#erro").toggle();
        }, 2500);
    }).always(function () {
        $("#spinner").toggle();
    });
};

function novaLinha(name, quantity, price, description) {
    var linha = $("<tr>");
    var colunaName = $("<td>").text(name).attr("width", "20%").attr("id", "name-product");
    var colunaQuantidade = $("<td>").text(quantity).attr("width", "13%");
    var colunaPreco = $("<td>").text(price).attr("width", "20%");
    var colunaDescricao = $("<td>").text(description).attr("width", "40%");
    var colunaRemoverEditar = $("<td>");

    //fazendo a div que vão ficar os botões de editar e remover
    var divRemoverEditar = $("<div>").addClass("w-76 btn-group").attr("role", "group");

    //colocando o 
    var linkEditar = $("<a>").addClass("btn btn-primary mx-2").attr("href", "/Product/Edit/2");
    var iconeEditar = $("<i>").text("Editar");
    linkEditar.append(iconeEditar);

    var linkRemover = $("<a>").addClass("btn btn-danger mx-2").attr("href", "/Product/Delete/2");
    var iconeRemover = $("<i>").text("Remove");
    linkRemover.append(iconeRemover);

    divRemoverEditar.append(linkEditar, linkRemover);
    colunaRemoverEditar.append(divRemoverEditar);

    linha.append(colunaName, colunaQuantidade, colunaPreco, colunaDescricao, colunaRemoverEditar);
    return linha;
}
