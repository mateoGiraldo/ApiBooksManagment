using Microsoft.EntityFrameworkCore;
using MisLibros.API.Models.Entities;

namespace MisLibros.API.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Editorial> Editoriales { get; set; }
        public DbSet<Libro> Libros { get; set; }
    }
}
