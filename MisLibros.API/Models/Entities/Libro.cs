using System;
using System.ComponentModel.DataAnnotations;

namespace MisLibros.API.Models.Entities
{
    public class Libro
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Título")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Titulo { get; set; }

        public double Costo { get; set; }

        [Display(Name = "Precio Sugerido")]
        public double PrecioSugerido { get; set; }

        public string Autor { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public DateTime Fecha { get; set; }

        [Display(Name = "Fecha Local")]
        public DateTime FechaLocal => Fecha.ToLocalTime();

        public Editorial Editorial { get; set; }
    }
}