using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOS.Question;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ApplicationDBContext _context;
        public QuestionRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Question> CreateAsync(Question questionModel)
        {
            await _context.questions.AddAsync(questionModel);
            await _context.SaveChangesAsync();
            return questionModel;
        }

        public async Task<Question?> DeleteAsync(int id)
        {
            var questionModel = await _context.questions.FirstOrDefaultAsync(x => x.QuestionID == id);

            if(questionModel == null)
            {
                return null;
            }

            _context.questions.Remove(questionModel);
            await _context.SaveChangesAsync();
            return questionModel;
        }

        public async Task<List<Question>> GetAllAsync()
        {
            return await _context.questions.ToListAsync();
        }

        public async Task<Question?> GetByIdAsync(int id)
        {
            return await _context.questions.FindAsync(id);
        }

        public async Task<Question?> UpdateAsync(int id, UpdateQuestionRequestDTO questionRequestDTO)
        {
            var existingQuestion = await _context.questions.FirstOrDefaultAsync(x => x.QuestionID == id);

            if(existingQuestion == null)
            {
                return null;
            }

            existingQuestion.QuestionText = questionRequestDTO.QuestionText;
            existingQuestion.isMandatory = questionRequestDTO.isMandatory;

            await _context.SaveChangesAsync();
            return existingQuestion;
        }
    }
}