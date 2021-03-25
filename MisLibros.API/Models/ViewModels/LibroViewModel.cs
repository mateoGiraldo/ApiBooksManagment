using MisLibros.API.Models.Entities;

namespace MisLibros.API.Models.ViewModels
{
    public class LibroViewModel : Libro
    {
        public int EditorialId { get; set; }

        public string NombreEditorial { get; set; }
    }
}
