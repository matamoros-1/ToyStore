using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_ToyStore.Models
{
    public class Juguete
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Nombre { get; set; }

        [MaxLength(100)]
        public string? Descripcion { get; set; }

        [MaxLength(3)]
        public int? RestriccionEdad { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Compania { get; set; }

        [Required]
        [Column(TypeName = "decimal(6,2)")]
        public decimal Precio { get; set; }
    }
}
