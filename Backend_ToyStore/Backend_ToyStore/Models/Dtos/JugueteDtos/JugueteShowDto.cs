
namespace Backend_ToyStore.Models.Dtos.JugueteDtos
{
    public class JugueteShowDto
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }

        public int? RestriccionEdad { get; set; }

        public string? Compania { get; set; }

        public decimal Precio { get; set; }
    }
}
