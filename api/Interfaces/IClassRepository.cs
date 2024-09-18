using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOS.Class;
using api.Models;

namespace api.Interfaces
{
    public interface IClassRepository
    {
        Task<List<Classes>> GetAllAsync();
        Task<Classes?> GetByIdAsync(int id);
        Task<Classes> CreateAsync(Classes classModel);
        Task<Classes?> UpdateAsync(int id, UpdateClassRequestDTO classRequestDTO);
        Task<Classes?> DeleteAsync(int id);
    }
}