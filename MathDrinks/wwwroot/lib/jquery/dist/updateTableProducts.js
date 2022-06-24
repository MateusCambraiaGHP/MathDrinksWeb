$("#botao-trazer-produtos").click(updateTableProducts);

function updateTableProducts() {
    $.get("https://localhost:7252/Product/GetAllProduct", data => {
        console.log(data);
            $('#tabela-produtos').html('');
            setTimeout(function () {
                $("#spinner").toggle();
                $(data).each(function () {
                    var line = createLine(this.name, this.quantity, this.price, this.description);
                    $("#tabela-produtos").append(line);
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

function createLine(name, quantity, price, description) {
    var line = $("<tr>");
    var columnName = $("<td>").text(name).attr("width", "20%").attr("id", "name-product");
    var columnQuantity = $("<td>").text(quantity).attr("width", "13%");
    var columnPrice = $("<td>").text(price).attr("width", "20%");
    var columnDescription = $("<td>").text(description).attr("width", "40%");
    var columnRemoveAndEdit = $("<td>");

    //fazendo a div que vão ficar os botões de editar e remover
    var divRemoverEditar = $("<div>").addClass("w-76 btn-group").attr("role", "group");

    //colocando o 
    var linkEdit = $("<a>").addClass("btn btn-primary mx-2").attr("href", "/Product/Edit/2");
    var iconEdit = $("<i>").text("Editar");
    linkEdit.append(iconEdit);

    var linkRemove = $("<a>").addClass("btn btn-danger mx-2").attr("href", "/Product/Delete/2");
    var iconRemove = $("<i>").text("Remove");
    linkRemove.append(iconRemove);

    divRemoverEditar.append(linkEdit, linkRemove);
    columnRemoveAndEdit.append(divRemoverEditar);

    line.append(columnName, columnQuantity, columnPrice, columnDescription, columnRemoveAndEdit);

    return line;
}
