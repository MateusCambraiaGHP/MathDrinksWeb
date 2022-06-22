using OfficeOpenXml;

namespace MathDrinks.Services
{
    public abstract class ExcelService<T>
    {
        public virtual async Task ExportToExcel(IEnumerable<T> entityList, string path, string name)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var file = new FileInfo($"{path}/{name}.xlsx");
            await DeleteAndSaveExcelFile(entityList, file);
        }

        private async Task SaveExcelFile(IEnumerable<T> entityList, FileInfo file)
        {
            using var package = new ExcelPackage(file);
            var ws = package.Workbook.Worksheets.Add("MainReport");
            var range = ws.Cells["A1"].LoadFromCollection(entityList, true);
            range.AutoFitColumns();

            await package.SaveAsync();
        }

        private async Task DeleteAndSaveExcelFile(IEnumerable<T> entityList, FileInfo file)
        {
            if (file.Exists)
                file.Delete();

            await SaveExcelFile(entityList, file);
        }
    }
}