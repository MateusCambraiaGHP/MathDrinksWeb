$("#botao-exportar").click(exportExcel);

function exportExcel() {
    $.get("https://localhost:7252/Product/Export", data => {
        console.log("exportado");
    });
}
