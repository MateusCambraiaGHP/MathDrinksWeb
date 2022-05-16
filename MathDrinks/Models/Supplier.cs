using System.ComponentModel.DataAnnotations.Schema;

namespace MathDrinks.Models
{
    public class Supplier
    {
        public int Id { get; set; } 
        public int ProductID { get; set; }

        [Column(TypeName = "varchar(35)")]
        public string Name { get; set; }
        
        [Column(TypeName = "varchar(35)")]
        public string FantasyName { get; set; }
       
        [Column(TypeName = "varchar(45)")]
        public string CNPJ { get; set; }
        
        [Column(TypeName = "varchar(35)")]
        public string Cep { get; set; }
        public string Created_by { get; set; } = "Administrador";

        [Column(TypeName = "datetime")]
        public DateTime Created_at { get; set; } = DateTime.Now;
        public string Updated_by { get; set; } = "Administrador";

        [Column(TypeName = "datetime")]
        public DateTime Updated_at { get; set; } = DateTime.Now;
    }
}
