using Backend_ToyStore.Data;
using Backend_ToyStore.Models;

namespace Backend_ToyStore.Repository
{
    public class JuguetesRepository : IJuguetesRepository
    {
        private readonly DataContext _dataBase;

        public JuguetesRepository(DataContext dataBase)
        {
            _dataBase = dataBase;
        }

        public bool ActualiarJuguete(Juguete juguete)
        {
            _dataBase.juguetes.Update(juguete);
            return Guardar();
        }

        public bool BorrarJuguete(Juguete juguete)
        {
            _dataBase.juguetes.Remove(juguete);
            return Guardar();
        }

        public bool CrearJuguete(Juguete juguete)
        {
            _dataBase.juguetes.Add(juguete);
            return Guardar();
        }

        public bool ExisteJuguete(int id)
        {
            return _dataBase.juguetes.Any(j => j.Id == id);
        }

        public Juguete GetJuguete(int id)
        {
            return _dataBase.juguetes.FirstOrDefault(juegue => juegue.Id == id);
        }

        public ICollection<Juguete> GetJuguetes()
        {
            return _dataBase.juguetes.OrderBy(juegue => juegue.Nombre).ToList();
        }

        public bool Guardar()
        {
            return _dataBase.SaveChanges() >= 0 ? true : false;
        }
    }
}
