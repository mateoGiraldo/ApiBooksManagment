using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MisLibros.API.Models;
using MisLibros.API.Models.Entities;
using MisLibros.API.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MisLibros.API.Controllers
{
    //[EnableCors("_myAllowSpecificOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly DataContext _context;

        public LibrosController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public ActionResult<IEnumerable<LibroViewModel>> GetLibros()
        {
            return _context.Libros.Select(l => new LibroViewModel
            {
                Id = l.Id,
                Titulo = l.Titulo,
                Autor = l.Autor,
                Fecha = l.FechaLocal,
                Costo = l.Costo,
                PrecioSugerido = l.PrecioSugerido,
                EditorialId = l.Editorial.Id,
                NombreEditorial = l.Editorial.Nombre,
            }).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<LibroViewModel> GetLibro(int id)
        {
            LibroViewModel libro = _context.Libros.Select(l => new LibroViewModel
            {
                Id = l.Id,
                Titulo = l.Titulo,
                Autor = l.Autor,
                EditorialId = l.Editorial.Id,
                Fecha = l.FechaLocal,
                Costo = l.Costo,
                PrecioSugerido = l.PrecioSugerido,
            })
                .FirstOrDefault(l => l.Id == id);

            if (libro == null)
            {
                return NotFound();
            }

            return Ok(libro);
        }

        [HttpPost]
        public ActionResult<bool> PostLibro(LibroViewModel libro)
        {
            try
            {
                //La fecha se guarda en tiempo universal 
                //para recuperarla en la hora local de donde esté el usuario
                Libro lib = new Libro()
                {
                    Titulo = libro.Titulo,
                    Autor = libro.Autor,
                    Editorial = _context.Editoriales.Find(libro.EditorialId),
                    Fecha = libro.Fecha.ToUniversalTime(),
                    Costo = libro.Costo,
                    PrecioSugerido = libro.PrecioSugerido,

                };

                _context.Libros.Add(lib);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPut("{id}")]
        public ActionResult<bool> PutLibro(int id, LibroViewModel libro)
        {
            if (id != libro.Id)
            {
                return BadRequest();
            }

            Libro objUpd = _context.Libros.Find(id);

            if (objUpd != null)
            {
                objUpd.Titulo = libro.Titulo;
                objUpd.Autor = libro.Autor;
                objUpd.Editorial = _context.Editoriales.Find(libro.EditorialId);
                objUpd.Costo = libro.Costo;
                objUpd.PrecioSugerido = libro.PrecioSugerido;
                objUpd.Fecha = libro.Fecha.ToUniversalTime();
                //La fecha se guarda en tiempo universal 
                //para recuperarla en la hora local de donde esté el usuario
            }
            else
            {
                return Ok(false);
            }

            try
            {
                _context.SaveChanges();
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteLibro(int id)
        {
            try
            {
                Libro libro = _context.Libros.Find(id);
                if (libro == null)
                {
                    return Ok(false);
                }

                _context.Libros.Remove(libro);
                _context.SaveChanges();

                return Ok(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}