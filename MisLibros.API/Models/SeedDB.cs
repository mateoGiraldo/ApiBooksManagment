using MisLibros.API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MisLibros.API.Models
{
    public class SeedDB
    {
        private readonly DataContext _context;

        public SeedDB(DataContext context)
        {
            _context = context;
        }

        public async Task AlimentarAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await VerificarEditorialesAsync();
        }

        private async Task VerificarEditorialesAsync()
        {
            if (!_context.Editoriales.Any())
            {
                await AgregarEditorial("Babel Libros");
                await AgregarEditorial("Angosta Editores");
            }
        }

        private async Task AgregarEditorial(string nombre)
        {
            _context.Editoriales.Add(new Editorial
            {
                Nombre = nombre
            });

            await _context.SaveChangesAsync();
        }
    }
}
