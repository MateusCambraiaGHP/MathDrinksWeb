$("#ProductId").on('change', getInforProduct);

$(function () {
    getNameSupplier();
});

function getInforProduct() {
    
    let productId = $("#ProductId").val();
    let url = "https://localhost:7252/Product/GetProductId/" + productId;
    $.get(url, data => {
        if (data.price === null && data.description === null) {
            $("#Price").val("");
            $("#Drescription").val("");
        }
        $("#Price").val(data.price);
        $("#Drescription").val(data.description);
    }).fail(function () {
        $("#erro").show();
        setTimeout(function () {
            $("#erro").toggle();
        }, 2500);
    });
};

function getNameSupplier() {
    let supplierId = $("#id-fornecedor").val();
    let url = "https://localhost:7252/Supplier/GetSupplierId/" + supplierId;
    $.get(url, data => {
        $("#name-supplier").text(data.name);
    })
};