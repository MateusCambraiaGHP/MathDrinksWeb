using System.ComponentModel.DataAnnotations.Schema;

namespace MathDrinks.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(45)")]
        public string Name { get; set; } 

        [Column(TypeName = "varchar(130)")]
        public string Description { get; set; }
        public int Quantity { get; set; }
        
        [Column(TypeName = "decimal(30,2)")]
        public double Price { get; set; }
        public string Created_by { get; set; } = "Administrador";

        [Column(TypeName = "datetime")]
        public DateTime Created_at { get; set; } = DateTime.Now;
        public string Updated_by { get; set; } = "Administrador";

        [Column(TypeName = "datetime")]
        public DateTime Updated_at { get; set; } = DateTime.Now;

    }
}
