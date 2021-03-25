using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MisLibros.API.Models;
using MisLibros.API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MisLibros.API.Controllers
{
    //[EnableCors("_myAllowSpecificOrigins")]
    [ApiController]
    [Route("api/[controller]")]
    public class LibroController : Controller
    {
        private readonly DataContext _context;

        public LibroController(DataContext context)
        {
            _context = context;
        }

        //[EnableCors]
        [HttpGet("[action]")]
        public IActionResult ObtenerLista()
        {
            try
            {
                List<Libro> list = new List<Libro>();
                list = _context.Libros.ToList();


                if (list.Count > 0)
                {
                    return Ok(list);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}