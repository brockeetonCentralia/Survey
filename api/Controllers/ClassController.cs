using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOS.Class;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
         public ClassController(ApplicationDBContext context)
         {
            _context = context;
         }

         [HttpGet]
         public IActionResult GetAll(){
            var _classes = _context.classes.ToList()
            .Select(s => s.ToClassDTO());

            return Ok(_classes);
         }

         [HttpGet("{id}")]
         public IActionResult GetById([FromRoute] int id){
            var _class = _context.classes.Find(id);

            if(_class == null){
                return NotFound();
            }

            return Ok(_class.ToClassDTO());
         }

        [HttpPost]
        public IActionResult Create([FromBody] CreateClassRequestDTO _classDTO) {
            var _classModel = _classDTO.ToClassFromCreateDTO();
            _context.classes.Add(_classModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = _classModel.ClassID}, _classModel.ToClassDTO());
        }

    }
}