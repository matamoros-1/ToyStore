using Backend_ToyStore.Models;

namespace Backend_ToyStore.Repository
{
    public interface IJuguetesRepository
    {
        ICollection<Juguete> GetJuguetes();

        Juguete GetJuguete(int id);

        bool ExisteJuguete(int id);

        bool CrearJuguete(Juguete juguete);

        bool ActualiarJuguete(Juguete juguete);

        bool BorrarJuguete(Juguete juguete);

        bool Guardar();
    }
}
