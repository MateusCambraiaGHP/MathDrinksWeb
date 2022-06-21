using MathDrinks.Models;

namespace MathDrinks.Interfaces
{
    public interface IProducExcelService
    {
        Task ExportToExcel(IEnumerable<Product> entityList, string path, string name);
    }
}
