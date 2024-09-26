using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOS.Question;
using api.Models;

namespace api.Interfaces
{
    public interface IQuestionRepository
    {
        Task<List<Question>> GetAllAsync();
        Task<Question?> GetByIdAsync(int id);
        Task<Question> CreateAsync(Question questionModel);
        Task<Question?> UpdateAsync(int id, UpdateQuestionRequestDTO questionRequestDTO);
        Task<Question?> DeleteAsync(int id);
    }
}