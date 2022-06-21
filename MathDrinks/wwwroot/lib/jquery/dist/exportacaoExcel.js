$("#botao-exportar").click(exportaExcel);

function exportaExcel() {
    $.get("https://localhost:7252/Product/Export", data => {
        console.log("exportado");
    });
}
