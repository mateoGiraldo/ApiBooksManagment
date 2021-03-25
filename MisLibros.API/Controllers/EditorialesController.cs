using Microsoft.AspNetCore.Mvc;
using MisLibros.API.Models;
using MisLibros.API.Models.HelperEntities;
using System.Collections.Generic;
using System.Linq;

namespace MisLibros.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialesController : ControllerBase
    {
        private readonly DataContext _context;

        public EditorialesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("[action]")]
        public ActionResult<List<DropDownItem>> EditorialesDropDown(int id)
        {
            List<DropDownItem> list = _context.Editoriales.Select(e => new DropDownItem
            {
                id = e.Id,
                value = e.Nombre
            }).ToList();            

            return Ok(list);
        }
    }
}