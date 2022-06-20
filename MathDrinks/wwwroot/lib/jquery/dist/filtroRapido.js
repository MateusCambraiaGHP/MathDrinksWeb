$("#botao-filtrar-produto").click(pesquisaNome);

function pesquisaNome(event) {
    event.preventDefault();
    $.get("https://localhost:7252/Product/GetProduct", data => {
        $(data).each(function () {
            data.filter((i,v)=>{
                return v == 1;
            })
        });
    });
}
