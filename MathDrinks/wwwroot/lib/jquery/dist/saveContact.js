$("#botao-enviar-contato").click(postData);


function postData(event) {
    event.preventDefault();
    let dados = getDados();

    $.post("https://localhost:7252/Contact/Create", dados, function () {
        setTimeout(function () {
            $("#successful-contact").toggle();
        }, 1500);
    }).fail(function () {
        console.log("falhou");
        $("#successful-contact").toggle();
    }).always(function () {
        $("#successful-contact").toggle();
    });
}

function getDados() {
    let name = $("#Name").val();
    let email = $("#email").val();
    let phone = $("#Phone").val();
    let mensage = $("#Mensage").val();
    let lineContact = $("#Line_Of_Contact").val();
    let hourContact = $("#Hour_Contact").val();
    let needDescount = $("#Need_Descount").val();

    var dados = {
        Name: name,
        Email: email,
        Phone: phone,
        Mensage: mensage,
        Line_Of_Contact: lineContact,
        Hour_Contact: hourContact,
        Need_Descount: needDescount
    };

    return dados;
}