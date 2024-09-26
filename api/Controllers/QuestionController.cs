using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOS.Question;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : ControllerBase
    {
          private readonly ApplicationDBContext _context;
        private readonly IQuestionRepository _questionRepo;
         public QuestionController(ApplicationDBContext context, IQuestionRepository questionRepo)
         {
            _questionRepo = questionRepo;
            _context = context;
         }

         [HttpGet]
         public async Task<IActionResult> GetAll()
         {
            var _question = await _questionRepo.GetAllAsync();
            var questionDTO = _question.Select(s => s.ToQuestionDTO());

            return Ok(_question);
         }

         [HttpGet("{id}")]
         public async Task<IActionResult> GetById([FromRoute] int id)
         {
            var _question = await _questionRepo.GetByIdAsync(id);

            if(_question == null)
            {
                return NotFound();
            }

            return Ok(_question.ToQuestionDTO());
         }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateQuestionRequestDTO _questionDTO)
        {
            var _questionModel = _questionDTO.ToQuestionFromCreateDTO();

            await _questionRepo.CreateAsync(_questionModel);

            return CreatedAtAction(nameof(GetById), new { id = _questionModel.QuestionID}, _questionModel.ToQuestionDTO());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateQuestionRequestDTO updateClassDTO) 
        {
            var _questionModel = await _questionRepo.UpdateAsync(id, updateClassDTO);

            if(_questionModel == null)
            {
                return NotFound();
            }

            return Ok(_questionModel.ToQuestionDTO());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var _questionModel = await _questionRepo.DeleteAsync(id);
            
            if(_questionModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}