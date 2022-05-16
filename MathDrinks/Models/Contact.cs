using System.ComponentModel.DataAnnotations.Schema;

namespace MathDrinks.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(40)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(40)")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(25)")]
        public string Phone { get; set; }

        [Column(TypeName = "varchar(150)")]
        public string Mensage { get; set; }

        [Column(TypeName = "varchar(25)")]
        public string Line_Of_Contact { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Hour_Contact { get; set; }
        public int Need_Descount { get; set; }
        public string Created_by { get; set; } = nameof(Name);

        [Column(TypeName = "datetime")]
        public DateTime Created_at { get; set; } = DateTime.Now;
    }
}
