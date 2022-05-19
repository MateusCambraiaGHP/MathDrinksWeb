using System.ComponentModel.DataAnnotations.Schema;

namespace MathDrinks.Models
{
    public class Supplier_Product
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public int ProductId { get; set; }
        
        [Column(TypeName = "decimal(20,2)")]
        public int Price { get; set; }

        [Column(TypeName = "varchar(150)")]
        public string Drescription { get; set;  }
        public string Created_by { get; set; } = "Administrador";

        [Column(TypeName = "datetime")]
        public DateTime Created_at { get; set; } = DateTime.Now;
        public string Updated_by { get; set; } = "Administrador";

        [Column(TypeName = "datetime")]
        public DateTime Updated_at { get; set; } = DateTime.Now;
        public Supplier supplier { get; set; }
        public Product product { get; set; }
        
    }
}
