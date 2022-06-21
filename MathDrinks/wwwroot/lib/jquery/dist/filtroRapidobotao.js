$("#botao-filtrar-produto").click(pesquisaNome);

function pesquisaNome(event) {
    event.preventDefault();

    pesquisaNome();
}



function pesquisaNome() {
    event.preventDefault();
    $('#tabela-produtos>tr').each(function () {
        let nomeTabela = $('#name-product').val();

        let nomeInput = $("#input-filtro-produto").val();
        console.log(nomeInput);
        console.log(nomeTabela);
        console.log(nomeTabela.length == nomeInput.length);
        if (nomeTabela === nomeInput) {
            $(this).show();
        } else {
            $(this).hide();
        }

    });
}