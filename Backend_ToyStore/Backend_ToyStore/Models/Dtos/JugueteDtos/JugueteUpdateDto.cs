
using System.ComponentModel.DataAnnotations;

namespace Backend_ToyStore.Models.Dtos
{
    public class JugueteUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string? Nombre { get; set; }
        [MaxLength(100)]
        public string? Descripcion { get; set; }
        [Range(0, 100)]
        public int? RestriccionEdad { get; set; }

        [Required, MaxLength(50)]
        public string? Compania { get; set; }

        [Required, Range(1, 1000)]
        public decimal Precio { get; set; }
    }
}
