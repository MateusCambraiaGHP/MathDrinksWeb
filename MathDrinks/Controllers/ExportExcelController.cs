using MathDrinks.Interfaces;
using MathDrinks.Models;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace MathDrinks.Controllers
{
    public class ExportExcelController : Controller
    {
        public readonly IApplicationMySqlDbContext _db;

        public ExportExcelController(IApplicationMySqlDbContext db)
        {
            _db = db;
        }

        public async Task ExportToExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var file = new FileInfo(@"C:/ProjetosMateusPadraoMvc/MathDrinksWeb/MathDrinks/ListaDeProdutos.xlsx");
            IEnumerable<Product> producsObj = _db.Product.ToList();
            await SaveExcelFile(producsObj, file);
        }

        private static async Task SaveExcelFile(IEnumerable<Product> producsObj, FileInfo file)
        {
            DeleteIfExist(file);
            using var package = new ExcelPackage(file);

            var ws = package.Workbook.Worksheets.Add("MainReport");

            var range = ws.Cells["A1"].LoadFromCollection(producsObj, true);
            range.AutoFitColumns();

            await package.SaveAsync();
        }

        private static void DeleteIfExist(FileInfo file)
        {
            if (file.Exists) {
                file.Delete();
            }
        }
        
    }
}