using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOS.Class;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IClassRepository _classRepo;
         public ClassController(ApplicationDBContext context, IClassRepository classRepo)
         {
            _classRepo = classRepo;
            _context = context;
         }

         [HttpGet]
         public async Task<IActionResult> GetAll()
         {
            var _classes = await _classRepo.GetAllAsync();
            var classDTO = _classes.Select(s => s.ToClassDTO());

            return Ok(_classes);
         }

         [HttpGet("{id}")]
         public async Task<IActionResult> GetById([FromRoute] int id)
         {
            var _class = await _classRepo.GetByIdAsync(id);

            if(_class == null)
            {
                return NotFound();
            }

            return Ok(_class.ToClassDTO());
         }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateClassRequestDTO _classDTO)
        {
            var _classModel = _classDTO.ToClassFromCreateDTO();

            await _classRepo.CreateAsync(_classModel);

            return CreatedAtAction(nameof(GetById), new { id = _classModel.ClassID}, _classModel.ToClassDTO());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateClassRequestDTO updateClassDTO) 
        {
            var _classModel = await _classRepo.UpdateAsync(id, updateClassDTO);

            if(_classModel == null)
            {
                return NotFound();
            }

            return Ok(_classModel.ToClassDTO());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var _classModel = await _classRepo.DeleteAsync(id);
            
            if(_classModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}