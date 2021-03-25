using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MisLibros.API.Models.Entities
{
    public class Editorial
    {
        [Key]
        public int Id { get; set; }

        public string Nombre { get; set; }

        public ICollection<Libro> Libros { get; set; }
    }
}
