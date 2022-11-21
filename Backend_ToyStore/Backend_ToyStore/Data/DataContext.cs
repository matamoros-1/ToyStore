using Backend_ToyStore.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend_ToyStore.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 
        
        }

        public DbSet<Juguete> juguetes { get; set; }
    }
}
